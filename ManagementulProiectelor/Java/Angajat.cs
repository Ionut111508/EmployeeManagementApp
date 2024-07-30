using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementulProiectelor
{
    public class Angajat
    {
        public String Id_Angajat { get; set; }
        public String numeAngajat { get; set; }
        public String prenumeAngajat { get; set; }
        public String emailAngajat { get; set; }
        public String numarTelefonAngajat { get; set; }
        public String Id_Cont { get; set; }
        public String Id_Norma { get; set; }
    
    public String AngajatFullName
    {
        get { return $"{numeAngajat} {prenumeAngajat}"; }
    }
    }

}