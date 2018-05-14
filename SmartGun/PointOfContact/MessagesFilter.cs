using System.ServiceModel;
using MessagesLibrary;

namespace PointOfContact
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MessagesFilter : IMessagesFilter
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
    }
}