using System.ServiceModel;

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
        [OperationContract]
        Message GetProperTypeForMessage(int x, int y, string username, MessageType messageType);

        // TODO: Add your service operations here
    }
}
