using CORE.Interfaces;
using CORE.Logics;
using PointOfContact;

namespace CORE
{
    public class CoreService : ICoreService
    {
        private readonly IWarningHandler _warningHandler;
        private readonly IShotHandler _shotHandler;

        public CoreService()
        {
            _warningHandler = new WarningHandler();
            _shotHandler = new ShotHandler();
        }
        public void HandleWarning(WarningMessage message)
        {
            _warningHandler.Handle(message);
        }

        public void HandleShot(ShotMessage message)
        {
            _shotHandler.Handle(message);
        }
    }
}
