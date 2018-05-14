using System.Runtime.Serialization;

namespace PointOfContact
{
    [DataContract]
    public class UpdateMessage:Message
    {

        public UpdateMessage(int x, int y, string username) : base(x, y, username)
        {
            MessageType = MessageType.Update;
        }
    }
}
