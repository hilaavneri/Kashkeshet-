using System;
using System.Collections.Generic;
using System.Text;

namespace Client.UI.Menus
{
    class Menu<T>
    {
        private Dictionary<T, OptionBase> _options;

        public Menu(Dictionary<T, OptionBase> options)
        {
            _options = options;
        }

        public void RunOption(T key)
        {
            _options[key]?.Run();
        }

        public void AddOption(T key, OptionBase option)
        {
            _options[key] = option;
        }
    }
}
