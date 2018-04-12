using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SmartGun
{
    class Response
    {
        private Byte[] Data = null;
        private String Status;
        private String Mime;

        private Response(String status, String mime, Byte[] data)
        {
            Data = data;
            Status = status;
            Mime = mime;
        }

        public static Response From(Request request)
        {
            if (request == null)
                return MakeNullRequest();

            if (request.Type == "GET")
            {
                String file = Environment.CurrentDirectory + HTTPServer.WEB_DIR + request.URL;
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Exists && fileInfo.Extension.Contains("."))
                {
                    return MakeFromFile(fileInfo);
                }
                else
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(fileInfo + "/");
                    FileInfo[] files = directoryInfo.GetFiles();
                    foreach (FileInfo ff in files)
                    {
                        String name = ff.Name;
                        if (name.Contains("default.html") || name.Contains("default.htm") ||
                            name.Contains("index.html") || name.Contains("index.htm"))
                            return MakeFromFile(ff);
                    }
                }
            }
            else
                return MakeMethodNotAllowed();
            return MakPageNotFound();
    
        }

        private static Response MakeFromFile(FileInfo fi)
        {
            FileStream fs = fi.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new byte[fs.Length];
            reader.Read(d, 0, d.Length);
            fs.Close();
            return new Response("200 OK", "text/html", d);
        }

        private static Response MakeNullRequest()
        {
            String file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "400.html";
            FileInfo fileInfo = new FileInfo(file);
            FileStream fs = fileInfo.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new byte[fs.Length];
            reader.Read(d, 0, d.Length);
            fs.Close();
            return new Response("400 Bad Request", "text/html", d);
        }

        private static Response MakPageNotFound()
        {
            String file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "404.html";
            FileInfo fileInfo = new FileInfo(file);
            FileStream fs = fileInfo.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new byte[fs.Length];
            reader.Read(d, 0, d.Length);
            fs.Close();
            return new Response("404 Page Not Found", "text/html", d);
        }

        private static Response MakeMethodNotAllowed()
        {
            String file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "405.html";
            FileInfo fileInfo = new FileInfo(file);
            FileStream fs = fileInfo.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new byte[fs.Length];
            reader.Read(d, 0, d.Length);
            fs.Close();
            return new Response("405 Method Not Allowed", "text/html", d);
        }


        public void Post(NetworkStream stream)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(String.Format("{0} {1}\r\nServer: {2}\r\nContent-Type: {3}\r\nAccept-Ranges: bytes\r\nContent-Length: {4}\r\n",
                HTTPServer.VERSION, Status, HTTPServer.NAME, Mime, Data.Length));
            writer.Flush();
            stream.Write(Data, 0, Data.Length);
        }
    }
}
