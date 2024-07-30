using ManagementulProiectelor.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementulProiectelor.Java
{
    class PerioadeTaskGantt
    {

        public string DenumireTask { get; set; }
        public DateTime DataIncepereTask { get; set; }
        public DateTime DataFinalizareTask { get; set; }
        public decimal NumarOreAlocate { get; set; }
        public decimal NumarOreMaxim { get; set; }

        public PerioadeTaskGantt(string name, DateTime startDate, DateTime endDate, decimal nrOre, decimal nrOreMaxim)
        {
            DenumireTask = name;
            DataIncepereTask = startDate;
            DataFinalizareTask = endDate;
            NumarOreAlocate = nrOre;
            NumarOreMaxim = nrOreMaxim;
        }
        public String DetaliiIntervalFull
        {
            get { return $"{DenumireTask} - {DataIncepereTask.ToString("dd/MM/yyyy")} - {DataFinalizareTask.ToString("dd/MM/yyyy")} - Ore: {NumarOreAlocate} / {NumarOreMaxim}"; }
        }
        public String DetaliiInterval
        {
            get { return $"{DenumireTask} : {DataIncepereTask.ToString("dd/MM/yyyy")} - {DataFinalizareTask.ToString("dd/MM/yyyy")} "; }
        }
    }
}
