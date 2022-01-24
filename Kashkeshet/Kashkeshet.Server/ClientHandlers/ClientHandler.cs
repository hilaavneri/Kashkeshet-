using Kashkeshet.Common.SendRecv;
using Kashkeshet.Server.Commands;
using System;
using System.IO;
using System.Text;

namespace Kashkeshet.Server.ClientHandlers
{
    class ClientHandler : IClientHandler
    {
        private ClientsMsgs _messages;
        private ISendRecv _senderReciever;
        private CommandFactory _commandFactory;
        private object _lock;

        public ClientHandler(ClientsMsgs messages, CommandFactory commandFactory)
        {
            _messages = messages;
            _commandFactory = commandFactory;
            _lock = new object();
        }

        public void HandleClient(int id, ISendRecv senderReciever)
        {
            Console.WriteLine("start " + id);
            _senderReciever = senderReciever;

            while (true)
            {
                try
                {
                    if (_messages.IsClientSignedIn(id))
                    {
                        var messages = _messages.GetMessagesById(id);
                        foreach (var item in messages)
                        {
                            Console.WriteLine("GOT MESSAGE");
                            _senderReciever.WriteData(item);
                        }

                    }
                    (string command, int bytesRec, byte[] bytes) = _senderReciever.ReadData();

                        Console.WriteLine("HANDLE CLIENT ID " + id);
                        _commandFactory.Create(command, bytes, _messages, id)?.Run();
                    
                    
                }

                catch (Exception e)
                {
                    if (!(e is IOException))
                    {
                        Console.WriteLine(e.Message);
                        _senderReciever.CloseConnection();
                        throw;
                    }
                    
                }
                
                


            }
        }
    }
}
