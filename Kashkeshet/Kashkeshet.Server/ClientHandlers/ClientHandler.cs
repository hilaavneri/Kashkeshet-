using Kashkeshet.Common.SendRecv;
using System;

namespace Kashkeshet.Server.ClientHandlers
{
    class ClientHandler : IClientHandler
    {
        private string _username;
        private ClientsMsgs _messages;
        private ISendRecv _senderReciever;

        public void HandleClient()
        {
            throw new NotImplementedException();
        }
    }
}
