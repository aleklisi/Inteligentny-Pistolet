using MessagesLibrary;

namespace CORE.Interfaces
{
    public interface IShotHandler
    {
        void Handle(ShotMessage message);
    }
}