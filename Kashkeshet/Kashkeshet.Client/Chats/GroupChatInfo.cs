using Kashkeshet.Client.Messages;
using System.Collections.Generic;

namespace Kashkeshet.Client.Chats
{
    class GroupChatInfo : ChatInfo
    {
        public string Name { get; private set; }

        public GroupChatInfo(List<ChatMessageInfo> messages, ChatTypes type, string name) : base(messages, type)
        {
            Name = name;
        }

    }
}
