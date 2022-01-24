using System;
using System.Collections.Generic;
using System.Text;

namespace Client.UI
{
    public abstract class OptionBase
    {
        public string Description { get; private set; }

        public abstract void Run();
    }
}
