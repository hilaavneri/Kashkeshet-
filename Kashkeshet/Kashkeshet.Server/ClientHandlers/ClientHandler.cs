using Kashkeshet.Common.SendRecv;
using Kashkeshet.Server.Commands;
using System;

namespace Kashkeshet.Server.ClientHandlers
{
    class ClientHandler : IClientHandler
    {
        private ClientsMsgs _messages;
        private ISendRecv _senderReciever;
        private CommandFactory _commandFactory;

        public void HandleClient(Guid guid)
        {
            while (true)
            {
                try
                {
                    (string command, int bytesRec, byte[] bytes) = _senderReciever.ReadData();
                    _commandFactory.Create(command, bytes, _messages);
                    
                }
                catch (TimeoutException)
                {
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    _senderReciever.CloseConnection();
                    
                }
                
                


            }
        }
    }
}
