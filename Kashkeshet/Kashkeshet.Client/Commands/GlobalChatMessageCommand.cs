using Kashkeshet.Client.Chats;
using Kashkeshet.Client.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kashkeshet.Client.Commands
{
    class GlobalChatMessageCommand : ICommand
    {
        private List<Chat> _chats;
        private ChatMessageInfo _message;

        public void Run()
        {
            var globalChats = _chats.Where(chat => chat.type == ChatTypes.Global);
            globalChats.ToList().ForEach(chat => chat.AddMessage(_message));
        }
    }
}
