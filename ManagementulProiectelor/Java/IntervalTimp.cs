using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementulProiectelor.Java
{
    public class IntervalTimp
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public IntervalTimp(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
        public IntervalTimp()
        { 
        }

        public IntervalTimp Intersect(IntervalTimp other)
        {
            DateTime start = Start > other.Start ? Start : other.Start;
            DateTime end = End < other.End ? End : other.End;

            if (start < end)
            {
                return new IntervalTimp(start, end);
            }
            return null;
        }
        public String FullPerioada
        {
            get { return $"Interval: {Start.ToString("dd/MM/yyyy")} - {End.ToString("dd/MM/yyyy")}"; }
        }
    }
}
