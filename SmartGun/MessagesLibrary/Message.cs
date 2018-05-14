using System.Runtime.Serialization;

namespace MessagesLibrary
{
    [DataContract]
    [KnownType(typeof(UpdateMessage))]
    [KnownType(typeof(WarningMessage))]
    [KnownType(typeof(ShotMessage))]
    public class Message
    {
        [DataMember]
        public double X;
        [DataMember]
        public double Y;
        [DataMember]
        public string Username;
        [DataMember]
        public MessageType MessageType;

        public Message(double x, double y, string username)
        {
            X = x;
            Y = y;
            Username = username;
        }
    }
}