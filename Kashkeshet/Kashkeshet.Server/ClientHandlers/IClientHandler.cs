using System;
using System.Collections.Generic;
using System.Text;

namespace Kashkeshet.Server.ClientHandlers
{
    public interface IClientHandler
    {
        void HandleClient(Guid guid);
    }
}
