namespace PointOfContact
{
    public class WarningMessage:Message
    {
        public WarningMessage(int x, int y, string username, MessageType messageType) 
            : base(x, y, username, messageType)
        {
        }
    }
}
