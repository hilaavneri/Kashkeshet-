using Kashkeshet.Client.Messages;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Kashkeshet.Client.Chats
{
    class GroupChat : Chat
    {
        public string Name { get; private set; }

        public GroupChat(ConcurrentQueue<ChatMessageInfo> messages, ChatTypes type, string name) : base(messages, type)
        {
            Name = name;
        }

    }
}
