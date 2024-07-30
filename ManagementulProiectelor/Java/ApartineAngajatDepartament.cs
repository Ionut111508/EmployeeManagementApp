using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementulProiectelor.Java
{
    class ApartineAngajatDepartament
    {
        public String Id_Angajat { get; set; }
        public String Id_Departament { get; set; }
        public DateTime DataIntrare { get; set; }
        public DateTime DataIesire { get; set; }
        public String Detalii
        {
            get { return $"{DBHelper.ExtrageDenumireDepartamentById(Id_Departament)} : {DataIntrare.ToString("dd/MM/yyyy")} "; }
        }
    }
}
