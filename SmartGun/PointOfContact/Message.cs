using System.Runtime.Serialization;
using System.ServiceModel;
using Microsoft.SqlServer.Server;

namespace PointOfContact
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public int X;
        [DataMember]
        public int Y;
        [DataMember]
        public string Username;
        [DataMember]
        public MessageType MessageType;

        public Message(int x, int y, string username)
        {
            X = x;
            Y = y;
            Username = username;
        }
    }
}