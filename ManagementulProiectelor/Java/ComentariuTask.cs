using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementulProiectelor.Java
{
    class ComentariuTask
    {
        List<Angajat> listaAngajati = DBHelper.ExtrageAngajatiWithDapper();

        public string Id_ComentariuTask { get; set; }
    public string textComentariuTask { get; set; }
    public DateTime dataComentariu { get; set; }
    public string Id_Proiect { get; set; }
    public string Id_Task { get; set; }
    public string Id_Angajat { get; set; }
    public string NumeAngajat { get; set; }


        public ComentariuTask()
        {
        }

        public string GetFormattedText
    {
        get
        {
            string NumeAngajat = listaAngajati.Where(a => a.Id_Angajat == Sesiune.ID_ANGAJAT).Select(a => a.AngajatFullName).FirstOrDefault() ?? "Nume necunoscut";
            return $"{NumeAngajat}, {dataComentariu.ToString("dd/MM/yyyy")}:\n{textComentariuTask}\n";
        }
    }
}

}
