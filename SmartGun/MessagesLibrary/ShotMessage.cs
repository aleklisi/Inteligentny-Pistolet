using System.Runtime.Serialization;

namespace MessagesLibrary
{
    [DataContract]
    public class ShotMessage : Message
    {
        public ShotMessage(double x, double y, string username) : base(x, y, username)
        {
            MessageType = MessageType.Shot;
        }
    }
}