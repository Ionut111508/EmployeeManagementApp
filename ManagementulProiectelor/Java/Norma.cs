using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementulProiectelor
{
    class Norma
    {
        public String Id_Norma { get; set; }
        public String denumireNorma { get; set; }
        public float normaOre { get; set; }


        public string FullDescNorma
        {
            get { return $" {denumireNorma} - {normaOre} ore"; }
        }
    }
}