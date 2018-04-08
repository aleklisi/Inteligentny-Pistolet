using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web;

namespace SmartGun
{/*
    enum RState
    {
        METHOD, URL, URLPARM, URLVALUE, VERSION,
        HEADERKEY, HEADERVALUE, BODY, OK
    };

    enum RespState
    {
        OK = 200,
        BAD_REQUEST = 400,
        NOT_FOUND = 404
    }

    public struct HTTPRequestStruct
    {
        public string Method;
        public string URL;
        public string Version;
        public Hashtable Args;
        public bool Execute;
        public Hashtable Headers;
        public int BodySize;
        public byte[] BodyData;
    }

    public struct HTTPResponseStruct
    {
        public int status;
        public string version;
        public Hashtable Headers;
        public int BodySize;
        public byte[] BodyData;
        public System.IO.FileStream fs;
    }

    /// <SUMMARY>
    /// Summary description for CsHTTPRequest.
    /// </SUMMARY>
    public class HTTPRequest
    {
        private TcpClient client;

        private RState ParserState;

        private HTTPRequestStruct HTTPRequestStr;

        private HTTPResponseStruct HTTPResponse;

        byte[] myReadBuffer;

        HTTPServer Parent;

        public HTTPRequest(TcpClient client, HTTPServer Parent)
        {
            this.client = client;
            this.Parent = Parent;

            this.HTTPResponse.BodySize = 0;
        }

        public void Process()
        {
            myReadBuffer = new byte[client.ReceiveBufferSize];
            String myCompleteMessage = "";
            int numberOfBytesRead = 0;

            Parent.WriteLog("Connection accepted. Buffer: " + client.ReceiveBufferSize.ToString());
            NetworkStream ns = client.GetStream();

            string hValue = "";
            string hKey = "";

            try
            {
                // binary data buffer index
                int bfndx = 0;

                // Incoming message may be larger than the buffer size.
                do
                {
                    numberOfBytesRead = ns.Read(myReadBuffer, 0, myReadBuffer.Length);
                    myCompleteMessage =
                       String.Concat(myCompleteMessage,
                          Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));

                    // read buffer index
                    int ndx = 0;
                    do
                    {
                        switch (ParserState)
                        {
                            case RState.METHOD:
                                if (myReadBuffer[ndx] != ' ')
                                    HTTPRequestStr.Method += (char)myReadBuffer[ndx++];
                                else
                                {
                                    ndx++;
                                    ParserState = RState.URL;
                                }
                                break;
                            case RState.URL:
                                if (myReadBuffer[ndx] == '?')
                                {
                                    ndx++;
                                    hKey = "";
                                    HTTPRequestStr.Execute = true;
                                    HTTPRequestStr.Args = new Hashtable();
                                    ParserState = RState.URLPARM;
                                }
                                else if (myReadBuffer[ndx] != ' ')
                                    HTTPRequestStr.URL += (char)myReadBuffer[ndx++];
                                else
                                {
                                    ndx++;
                                    HTTPRequestStr.URL = HttpUtility.UrlDecode(HTTPRequestStr.URL);
                                    ParserState = RState.VERSION;
                                }
                                break;
                            case RState.URLPARM:
                                if (myReadBuffer[ndx] == '=')
                                {
                                    ndx++;
                                    hValue = "";
                                    ParserState = RState.URLVALUE;
                                }
                                else if (myReadBuffer[ndx] == ' ')
                                {
                                    ndx++;

                                    HTTPRequestStr.URL = HttpUtility.UrlDecode(HTTPRequestStr.URL);
                                    ParserState = RState.VERSION;
                                }
                                else
                                {
                                    hKey += (char)myReadBuffer[ndx++];
                                }
                                break;
                            case RState.URLVALUE:
                                if (myReadBuffer[ndx] == '&')
                                {
                                    ndx++;
                                    hKey = HttpUtility.UrlDecode(hKey);
                                    hValue = HttpUtility.UrlDecode(hValue);
                                    HTTPRequestStr.Args[hKey] =  HTTPRequestStr.Args[hKey] != null ?
                                        HTTPRequestStr.Args[hKey] + ", " + hValue : hValue;
                                    hKey = "";
                                    ParserState = RState.URLPARM;
                                }
                                else if (myReadBuffer[ndx] == ' ')
                                {
                                    ndx++;
                                    hKey = HttpUtility.UrlDecode(hKey);
                                    hValue = HttpUtility.UrlDecode(hValue);
                                    HTTPRequestStr.Args[hKey] = HTTPRequestStr.Args[hKey] != null ?
                                        HTTPRequestStr.Args[hKey] + ", " + hValue : hValue;

                                    HTTPRequestStr.URL = HttpUtility.UrlDecode(HTTPRequestStr.URL);
                                    ParserState = RState.VERSION;
                                }
                                else
                                {
                                    hValue += (char)myReadBuffer[ndx++];
                                }
                                break;
                            case RState.VERSION:
                                if (myReadBuffer[ndx] == '\r')
                                    ndx++;
                                else if (myReadBuffer[ndx] != '\n')
                                    HTTPRequestStr.Version += (char)myReadBuffer[ndx++];
                                else
                                {
                                    ndx++;
                                    hKey = "";
                                    HTTPRequestStr.Headers = new Hashtable();
                                    ParserState = RState.HEADERKEY;
                                }
                                break;
                            case RState.HEADERKEY:
                                if (myReadBuffer[ndx] == '\r')
                                    ndx++;
                                else if (myReadBuffer[ndx] == '\n')
                                {
                                    ndx++;
                                    if (HTTPRequestStr.Headers["Content-Length"] != null)
                                    {
                                        HTTPRequestStr.BodySize =
                                 Convert.ToInt32(HTTPRequestStr.Headers["Content-Length"]);
                                        this.HTTPRequestStr.BodyData = new byte[this.HTTPRequestStr.BodySize];
                                        ParserState = RState.BODY;
                                    }
                                    else
                                        ParserState = RState.OK;

                                }
                                else if (myReadBuffer[ndx] == ':')
                                    ndx++;
                                else if (myReadBuffer[ndx] != ' ')
                                    hKey += (char)myReadBuffer[ndx++];
                                else
                                {
                                    ndx++;
                                    hValue = "";
                                    ParserState = RState.HEADERVALUE;
                                }
                                break;
                            case RState.HEADERVALUE:
                                if (myReadBuffer[ndx] == '\r')
                                    ndx++;
                                else if (myReadBuffer[ndx] != '\n')
                                    hValue += (char)myReadBuffer[ndx++];
                                else
                                {
                                    ndx++;
                                    HTTPRequestStr.Headers.Add(hKey, hValue);
                                    hKey = "";
                                    ParserState = RState.HEADERKEY;
                                }
                                break;
                            case RState.BODY:
                                // Append to request BodyData
                                Array.Copy(myReadBuffer, ndx, this.HTTPRequestStr.BodyData,
                                   bfndx, numberOfBytesRead - ndx);
                                bfndx += numberOfBytesRead - ndx;
                                ndx = numberOfBytesRead;
                                if (this.HTTPRequestStr.BodySize <= bfndx)
                                {
                                    ParserState = RState.OK;
                                }
                                break;
                                //default:
                                //   ndx++;
                                //   break;

                        }
                    }
                    while (ndx < numberOfBytesRead);

                }
                while (ns.DataAvailable);

                // Print out the received message to the console.
                Parent.WriteLog("You received the following message : \n" +
                   myCompleteMessage);

                HTTPResponse.version = "HTTP/1.1";

                if (ParserState != RState.OK)
                    HTTPResponse.status = (int)RespState.BAD_REQUEST;
                else
                    HTTPResponse.status = (int)RespState.OK;

                this.HTTPResponse.Headers = new Hashtable();
                this.HTTPResponse.Headers.Add("Server", Parent.Name);
                this.HTTPResponse.Headers.Add("Date", DateTime.Now.ToString("r"));

                // if (HTTPResponse.status == (int)RespState.OK)
                this.Parent.OnResponse(ref this.HTTPRequestStr, ref this.HTTPResponse);

                string HeadersString = this.HTTPResponse.version + " "
                   + this.Parent.respStatus[this.HTTPResponse.status] + "\n";

                foreach (DictionaryEntry Header in this.HTTPResponse.Headers)
                {
                    HeadersString += Header.Key + ": " + Header.Value + "\n";
                }

                HeadersString += "\n";
                byte[] bHeadersString = Encoding.ASCII.GetBytes(HeadersString);

                // Send headers
                ns.Write(bHeadersString, 0, bHeadersString.Length);

                // Send body
                if (this.HTTPResponse.BodyData != null)
                    ns.Write(this.HTTPResponse.BodyData, 0, this.HTTPResponse.BodyData.Length);

                if (this.HTTPResponse.fs != null)
                    using (this.HTTPResponse.fs)
                    {
                        byte[] b = new byte[client.SendBufferSize];
                        int bytesRead;
                        while ((bytesRead = this.HTTPResponse.fs.Read(b, 0, b.Length)) > 0)
                        {
                            ns.Write(b, 0, bytesRead);
                        }

                        this.HTTPResponse.fs.Close();
                    }

            }
            catch (Exception e)
            {
                Parent.WriteLog(e.ToString());
            }
            finally
            {
                ns.Close();
                client.Close();
                if (this.HTTPResponse.fs != null)
                    this.HTTPResponse.fs.Close();
                Thread.CurrentThread.Abort();
            }
        }

    }*/
}
