using System.ServiceModel;
using PointOfContact;

namespace CORE
{
    [ServiceContract]
    public interface ICoreService
    {
        [OperationContract]
        void HandleWarning(WarningMessage message);
        [OperationContract]
        void HandleShot(ShotMessage message);
    }
}
