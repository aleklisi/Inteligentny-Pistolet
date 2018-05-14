using System.Runtime.Serialization;
using System.ServiceModel.Channels;

namespace MessagesLibrary
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
