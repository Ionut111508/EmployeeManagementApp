using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementulProiectelor
{
    public class ExceptieCreeareCont : Exception
    {
        public ExceptieCreeareCont()
            : base("Va rog completati ambele campuri") { }
    }
}
