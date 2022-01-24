using Kashkeshet.Client.Messages;
using System.Collections.Generic;

namespace Kashkeshet.Client.Chats
{
    public class ChatInfo
    {

        public List<ChatMessageInfo> Messages { get; private set; }
        public ChatTypes type { get; private set; }

        public ChatInfo(List<ChatMessageInfo> messages, ChatTypes type)
        {
            Messages = messages;
            this.type = type;
        }

    }
}
