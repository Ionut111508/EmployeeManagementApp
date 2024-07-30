using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ManagementulProiectelor.Java
{
    public class AfisareAdministrareAngajati
    {
        public string idAngajat { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string numarProiecteAlocate { get; set; }
        public ProgressBar progresProiecte { get; set; }
        public string numarTaskuriAlocate { get; set; }
        public ProgressBar progresTaskuri { get; set; }
    }
}
