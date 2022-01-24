using Kashkeshet.Common.SendRecv;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashkeshet.Client.Clients
{
    class Client
    {
        private ISendRecv _sendRecv;

        public Client(ISendRecv sendRecv)
        {
            _sendRecv = sendRecv;
        }

        public void Run()
        {

        }
    }
}
