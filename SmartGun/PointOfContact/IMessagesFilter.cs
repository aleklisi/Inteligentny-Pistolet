using System.ServiceModel;
using MessagesLibrary;

namespace PointOfContact
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMessagesFilter
    {
        [OperationContract]
        bool LogIn(string username);
        [OperationContract]
        void ReceiveData(Message message);
        // TODO: Add your service operations here
    }
}
