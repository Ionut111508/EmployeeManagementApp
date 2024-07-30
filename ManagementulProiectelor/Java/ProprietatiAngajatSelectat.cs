using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementulProiectelor.Java
{
    class ProprietatiAngajatSelectat
    {
        public string numeAngajat { get; set; }
        public string prenumeAngajat { get; set; }
        public DateTime dataAlocare { get; set; }
        public DateTime dataParasire { get; set; }
        public decimal nrOre { get; set; }
        public String AfisareDetalii
        {
            get { return $"{numeAngajat} {prenumeAngajat} : {dataAlocare:dd/MM/yyyy} - {dataParasire:dd/MM/yyyy} - {nrOre} ore"; }
        }
    }
}
