using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementulProiectelor.Java
{
    class ProprietatiPontaj
    {
        public string denumireTask { get; set; }
        public DateTime dataPontare { get; set; }
        public decimal nrOre { get; set; }
        public override string ToString()
        {
            string oreSauOra = nrOre < 2 ? "ora" : "ore";
            return $"{denumireTask} - {dataPontare:dddd, dd MMMM}  ---  {nrOre:F1} {oreSauOra}";
        }
    }

}
