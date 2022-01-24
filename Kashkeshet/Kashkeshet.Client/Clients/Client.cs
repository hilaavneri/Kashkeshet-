using Kashkeshet.Client.Chats;
using Kashkeshet.Client.Commands;
using Kashkeshet.Client.Common;
using Kashkeshet.Client.Messages;
using Kashkeshet.Common.SendRecv;
using System;
using System.Collections.Generic;
using System.IO;

namespace Kashkeshet.Client.Clients
{
    class Client
    {
        private ISendRecv _sendRecv;
        private CommandFactory _commandFactory;
        private MessagesFactory _messagesFactory;
        private IWriter _writer;
        private List<Chat> _chats;

        public Client(ISendRecv sendRecv, CommandFactory commandFactory, MessagesFactory messagesFactory, List<Chat> chats)
        {
            _sendRecv = sendRecv;
            _commandFactory = commandFactory;
            _messagesFactory = messagesFactory;
            _chats = chats;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    _sendRecv.WriteData(_writer.GetData());
                    (string command, int len, byte[] bytes) = _sendRecv.ReadData();
                    _commandFactory.Create(command, bytes, _chats, _messagesFactory)?.Run();
                }
                catch (Exception e)
                {
                    if (!(e is IOException))
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }
        }
    }
}
