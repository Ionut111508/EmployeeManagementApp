using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementulProiectelor
{
    class ExceptieDateInvalide : Exception
    {
        public ExceptieDateInvalide(string message)
            : base(message)
        {

        }
    }
}
