using MessagesLibrary;

namespace CORE.Interfaces
{
    public interface IWarningHandler
    {
        void Handle(WarningMessage message);
    }
}