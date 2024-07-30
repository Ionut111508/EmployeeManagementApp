using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementulProiectelor.Java
{
    class IntervalLucru
    {
        public string Id_Angajat { get; set; }
        public DateTime DataInceput { get; set; }
        public DateTime DataSfarsit { get; set; }
        public decimal NrOre { get; set; }
        public int NrZile { get; set; } //dataInceput-dataSfarsit (doar zile lucratoare)

        public String DetaliiInterval
        {
            get { return $"{DataInceput.ToString("dd/MM/yyyy")} - {DataSfarsit.ToString("dd/MM/yyyy")}, Ore disponibile: {NrOre}"; }
        }
        public String DetaliiAfisareInterval
        {
            get { return $"Interval: {DataInceput.ToString("dd/MM/yyyy")} - {DataSfarsit.ToString("dd/MM/yyyy")}, Ore : {NrOre} - {NrZile} zile "; }
        }
        public String DetaliiIntervalCuAngajat
        {
            get { return $"Angajatul {DBHelper.ReturneazaDetaliiAngajatDupaId(Id_Angajat) } cu interval: {DataInceput.ToString("dd/MM/yyyy")} - {DataSfarsit.ToString("dd/MM/yyyy")}, Ore disponibile: {NrOre} - {NrZile} zile "; }
        }

        public static implicit operator IntervalLucru(List<IntervalLucru> v)
        {
            throw new NotImplementedException();
        }
    }
}
