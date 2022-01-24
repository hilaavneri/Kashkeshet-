using Kashkeshet.Client.Messages;
using System.Collections.Generic;

namespace Kashkeshet.Client.Chats
{
    public class Chat
    {

        public List<ChatMessageInfo> Messages { get; private set; }
        public ChatTypes type { get; private set; }

        public Chat(List<ChatMessageInfo> messages, ChatTypes type)
        {
            Messages = messages;
            this.type = type;
        }

        public void AddMessage(ChatMessageInfo msg)
        {
            Messages.Add(msg);
        }
    }
}
