using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementulProiectelor.Java
{
    class Skill
    {
        public String Id_Skill { get; set; }
        public String denumireSkill { get; set; }
        public String nivelSkill { get; set; }

        public string DescriereSkill
        {
            get { return $" {denumireSkill} - {nivelSkill} "; }
        }

    }
}
