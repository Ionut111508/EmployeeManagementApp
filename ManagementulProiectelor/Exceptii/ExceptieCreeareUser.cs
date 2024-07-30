using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementulProiectelor
{
    class ExceptieCreeareUser : Exception
    {
        public string user_cont { get; }

        public ExceptieCreeareUser(string user_cont)
            : base("Eroare la introducerea noului cont . Username - ul " + user_cont + " exista deja in baza de date") { }
    }
}
