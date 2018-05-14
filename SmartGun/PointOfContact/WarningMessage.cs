using System.Runtime.Serialization;

namespace PointOfContact
{
    [DataContract]
    public class WarningMessage:Message
    {

        public WarningMessage(int x, int y, string username) 
            : base(x, y, username)
        {
            MessageType = MessageType.Warning;
        }
    }
}
