namespace PointOfContact
{
    public class UpdateMessage:Message
    {
        public UpdateMessage(int x, int y, string username, MessageType messageType) : base(x, y, username, messageType)
        {
        }
    }
}
