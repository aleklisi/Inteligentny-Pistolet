using System.ServiceModel;

namespace PointOfContact
{
    [ServiceContract]
    public class ShotMessage : Message
    {
        public ShotMessage(int x, int y, string username) : base(x, y, username)
        {
            MessageType = MessageType.Shot;
        }
    }
}