using System;
using System.Collections.Generic;
using System.Text;
using Kashkeshet.Client.Chats;

namespace Kashkeshet.Client.Messages
{
    public class GroupChatMessageInfo : ChatMessageInfo
    {
        public string GroupName { get; private set; }

        public GroupChatMessageInfo(ChatTypes chatType, string senderUserName, byte[] message, string groupName) : base(chatType, senderUserName, message)
        {
            GroupName = groupName;
        }
    
    }
}
