using System.Runtime.Serialization;

namespace MessagesLibrary
{
    [DataContract]
    public class UpdateMessage:Message
    {

        public UpdateMessage(double x, double y, string username) : base(x, y, username)
        {
            MessageType = MessageType.Update;
        }
    }
}
