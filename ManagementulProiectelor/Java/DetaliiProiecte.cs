using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementulProiectelor.Java
{
    public enum StatusProiect
    {
        Activ,
        Finalizat,
        Neînceput
    }
    public class DetaliiProiecte
    {
        public string denumireProiect { get; set; }
        public DateTime dataIncepere { get; set; }
        public DateTime datFinalizare { get; set; }
        public StatusProiect activeStatus { get; set; } // true= activ ; false = finalizat
        public String AfisareDetalii
        {
            get { return $"{denumireProiect} : {dataIncepere.ToString("dd/MM/yyyy")} -- {datFinalizare.ToString("dd/MM/yyyy")} , {activeStatus}"; }
        }
    }
}
