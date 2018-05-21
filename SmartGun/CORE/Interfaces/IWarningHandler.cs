using MessagesLibrary;
using PointOfContact;

namespace CORE.Interfaces
{
    public interface IWarningHandler
    {
        void Handle(WarningMessage message);
    }
}