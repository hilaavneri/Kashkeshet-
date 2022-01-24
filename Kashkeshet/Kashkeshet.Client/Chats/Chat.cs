using Kashkeshet.Client.Messages;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Kashkeshet.Client.Chats
{
    public class Chat
    {

        public ConcurrentQueue<ChatMessageInfo> Messages { get; private set; }
        public ChatTypes type { get; private set; }

        public Chat(ConcurrentQueue<ChatMessageInfo> messages, ChatTypes type)
        {
            Messages = messages;
            this.type = type;
        }

        public void AddMessage(ChatMessageInfo msg)
        {
            Messages.Enqueue(msg);
        }
    }
}
