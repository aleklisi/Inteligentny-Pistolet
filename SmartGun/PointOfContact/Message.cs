using System.Runtime.Serialization;

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

        public MessageType Type { get; }

        [DataMember]
        public MessageType MessageType;

        public Message(int x, int y, string username, MessageType messageType)
        {
            X = x;
            Y = y;
            Username = username;
            Type = messageType;
        }
    }
}