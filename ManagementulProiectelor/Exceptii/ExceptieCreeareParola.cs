using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementulProiectelor
{
    class ExceptieCreeareParola : Exception
    { 
        public ExceptieCreeareParola()
            : base("Parola nu respecta criteriile : Trebuie sa contina minim 6 caractere, o litera mare si o cifra") { }
    }
}
