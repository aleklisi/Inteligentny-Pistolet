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
        private static ServiceReference1.ICoreService channel;

        public MessagesFilter()
        {
            ServiceHost host = new ServiceHost(typeof(ServiceReference1.CoreServiceClient));
            ChannelFactory<ServiceReference1.ICoreService> cf = new ChannelFactory<ServiceReference1
                .ICoreService>("BasicHttpBinding_ICoreService");
            channel = cf.CreateChannel();
        }

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
                    channel.HandleShot(new ShotMessage(message.X, message.Y, message.Username));
                    break;
                 
                case MessageType.Warning:
                    channel.HandleWarning(new WarningMessage(message.X, message.Y, message.Username));
                    break;
                case MessageType.Update:
                    client.Add(new Policeman {Name = message.Username,
                        X = message.X, Y = message.Y});
                    break;
            }
        }
    }
}