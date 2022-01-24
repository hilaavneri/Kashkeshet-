using Kashkeshet.Client.Chats;
using Kashkeshet.Client.Commands;
using Client.Common;
using Kashkeshet.Client.Messages;
using Kashkeshet.Common.SendRecv;
using System;
using System.Collections.Generic;
using System.IO;

namespace Kashkeshet.Client.Clients
{
    public class ChatClient
    {
        private ISendRecv _sendRecv;
        private CommandFactory _commandFactory;
        private readonly MessagesFactory _messagesFactory;
        private IWriter _writer;
        private readonly List<Chat> _chats;

        public ChatClient(ISendRecv sendRecv, CommandFactory commandFactory, MessagesFactory messagesFactory, List<Chat> chats, IWriter writer)
        {
            _sendRecv = sendRecv;
            _commandFactory = commandFactory;
            _messagesFactory = messagesFactory;
            _chats = chats;
            _writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var data = _writer.GetData();
                    if (data != null)
                    {
                        _sendRecv.WriteData(data);
                    }
                    (string command, int len, byte[] bytes) = _sendRecv.ReadData();
                    _commandFactory.Create(command, bytes, _chats, _messagesFactory)?.Run();
                }
                catch (Exception e)
                {
                    if (!(e is IOException))
                    {
                        Console.WriteLine(e);
                    }
                }

            }
        }
    }
}
