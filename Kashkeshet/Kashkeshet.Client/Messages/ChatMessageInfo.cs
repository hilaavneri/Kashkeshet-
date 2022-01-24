using Kashkeshet.Client.Chats;

namespace Kashkeshet.Client.Messages
{
    public class ChatMessageInfo
    {

        public ChatTypes ChatType { get; private set; }
        public string SenderUserName { get; private set; }
        public byte[] Message { get; private set; }

        public ChatMessageInfo(ChatTypes chatType, string senderUserName, byte[] message)
        {
            ChatType = chatType;
            SenderUserName = senderUserName;
            Message = message;
        }

    }
}
