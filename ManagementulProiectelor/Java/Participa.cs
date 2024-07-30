using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementulProiectelor.Java
{
    class Participa
    {
        public String Id_Angajat { get; set; }
        public String Id_Proiect { get; set; }
        public String Id_Task { get; set; }
        public DateTime dataParticipareTask { get; set; }
        public DateTime dataParasireTask { get; set; }
        public decimal nrOre { get; set; }
    }
}
