using System.ServiceModel;

namespace PointOfContact
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MessageFilter : IMessagesFilter
    {
        public bool LogIn(string username)
        {
            // TODO check out in database 
            return true;
        }

        public void ReceiveData(Message message)
        {
            switch (message.MessageType)
            {
                case MessageType.Shot:
                    //TODO direct to core
                    break;
                case MessageType.Warning:
                    //TODO direct to core
                    break;
                case MessageType.Update:
                    //TODO update database
                    break;
            }
        }

        public Message GetProperTypeForMessage(int x, int y, string username, MessageType messageType)
        {
            if (messageType == MessageType.Update)
            {
                return new UpdateMessage(x, y, username);
            }
            if (messageType == MessageType.Warning)
            {
                return new WarningMessage(x, y, username);
            }
            if (messageType == MessageType.Shot)
            {
                return new ShotMessage(x, y, username);
            }

            return new Message(x, y, username);
        }
    }
}
