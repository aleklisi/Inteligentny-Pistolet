using System.ServiceModel;
using Database.CrudService;
using Database.Model;
using MessagesLibrary;

namespace PointOfContact
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MessagesFilter : IMessagesFilter
    {
        private static IPolicemanCollection client = new PolicemanCollection();

        public bool LogIn(string username)
        {
            if (client.GetAll().Exists(x => x.Name == username))
            {
                return true;
            }
            else
            {
                return false;
            }
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
                    client.Add(new Policeman {Name = message.Username,
                        X = message.X, Y = message.Y});
                    break;
            }
        }
    }
}