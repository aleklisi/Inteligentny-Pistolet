using System.Runtime.Serialization;

namespace MessagesLibrary
{
    [DataContract]
    public class WarningMessage:Message
    {

        public WarningMessage(double x, double y, string username) 
            : base(x, y, username)
        {
            MessageType = MessageType.Warning;
        }
    }
}
