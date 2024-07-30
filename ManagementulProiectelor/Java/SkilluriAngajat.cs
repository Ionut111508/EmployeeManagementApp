using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementulProiectelor.Java
{
    public class SkilluriAngajat
    {
        public string denumireSkill { get; set; }
        public string nivelSkill { get; set; }
        public String DetaliiSkill
        {
            get { return $"{denumireSkill} - {nivelSkill}"; }
        }
    }
}
