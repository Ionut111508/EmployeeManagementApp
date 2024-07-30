using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementulProiectelor
{
    class Cont
    {
        public String Id_Cont { get; set; }
        public String UserCont { get; set; }
        public String ParolaCont { get; set; }

        public string FullDescCont
        {
            get { return $" {UserCont}  "; }
        }

    }

    
}