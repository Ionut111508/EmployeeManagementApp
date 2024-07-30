using ManagementulProiectelor.Java;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Task = ManagementulProiectelor.Java.Task;

namespace ManagementulProiectelor.Forms
{
    public partial class FormCreeareTask : Form
    {
        static List<Proiect> listaProiecte = DBHelper.ExtrageProiecteWithDapper();
        static List<Descriere> listaDescrieri = DBHelper.ExtrageDescrieriWithDapper();
        static List<Task> listaTaskuri = DBHelper.ExtrageTaskuriWithDapper();
        static List<Perioada> listaPerioade = DBHelper.ExtragePerioadeWithDapper();
        static List<PerioadaTask> listaPerioadeTask = DBHelper.ExtragePerioadeTaskWithDapper();
        static List<PerioadeTaskGantt> listaIntervaleTaskuri = new List<PerioadeTaskGantt>();
        public FormCreeareTask()
        {
            InitializeComponent();
            PopulareListBoxuri();
            InitializareDateTimePickers();
            FormatareTextboxuri();
        }

        private void buttonCreeazaTask_Click(object sender, EventArgs e)
        {
            // Validările inițiale
            if (string.IsNullOrWhiteSpace(textBoxDenumireTask.Text))
            {
                MessageBox.Show("Denumirea taskului nu poate fi goala");
                return;
            }
            if (textBoxDenumireTask.Text.Length > 50)
            {
                MessageBox.Show("Denumirea taskului nu poate fi mai mare de 50 de caractere");
                return;
            }
            if (richTextBoxDescriereTask.Text.Length > 500)
            {
                MessageBox.Show("Descrierea nu poate fi mai mare de 500 de caractere");
                return;
            }
            if (string.IsNullOrWhiteSpace(richTextBoxDescriereTask.Text))
            {
                MessageBox.Show("Descrierea nu poate fi goala");
                return;
            }
            if (dateTimePickerDataIncepere.Value < Convert.ToDateTime(textBoxDataIncepereProiect.Text))
            {
                MessageBox.Show("Data de incepere a taskului depaseste perioada proiectului");
                return;
            }
            if (dateTimePickerDataFinalizare.Value > Convert.ToDateTime(textBoxDataFinalizareProiect.Text))
            {
                MessageBox.Show("Data de finalizare a taskului depaseste perioada proiectului");
                return;
            }
            if (numericUpDownNumarOreNecesare.Value == 0)
            {
                MessageBox.Show("Numarul de ore necesare nu poate fi 0");
                return;
            }

            // Adăugarea descrierii taskului
            String descriereTask = richTextBoxDescriereTask.Text;
            String id_descriere = generareIdDescriere();
            Descriere descriere = new Descriere()
            {
                Id_Descriere = id_descriere,
                descriereTask = descriereTask
            };
            DBHelper.AddDescriere(descriere);
            listaDescrieri.Add(descriere);

            // Adăugarea taskului
            Proiect proiectSelectat = (Proiect)listBoxProiecte.SelectedItem;
            String id_proiect = proiectSelectat.Id_Proiect;
            String Id_Task = generareIdTask(id_proiect);
            String denumireTask = textBoxDenumireTask.Text;
            Decimal numarOreNecesare = numericUpDownNumarOreNecesare.Value;

            Task task = new Task()
            {
                Id_Proiect = id_proiect,
                Id_Task = Id_Task,
                denumireTask = denumireTask,
                numarOre = numarOreNecesare,
                Id_Descriere = id_descriere
            };
            DBHelper.AddTask(task);
            listaTaskuri.Add(task);
            // Adăugarea perioadelor taskului
            String IdPerioadaInceput = generareIdPerioada();
            DateTime dataIncepere = dateTimePickerDataIncepere.Value;
            Perioada perioadaIncepere = new Perioada()
            {
                Id_Perioada = IdPerioadaInceput,
                an = dataIncepere.Year.ToString(),
                luna = dataIncepere.Month.ToString(),
                zi = dataIncepere.Day.ToString(),
                tipPerioada = "Inceput",
                Id_Angajat = Sesiune.ID_ANGAJAT
            };
            listaPerioade.Add(perioadaIncepere);
            DBHelper.AddPerioada(perioadaIncepere);

            String IdPerioadaSfarsit = generareIdPerioada();
            DateTime dataFinalizare = dateTimePickerDataFinalizare.Value;
            Perioada perioadaFinalizare = new Perioada()
            {
                Id_Perioada = IdPerioadaSfarsit,
                an = dataFinalizare.Year.ToString(),
                luna = dataFinalizare.Month.ToString(),
                zi = dataFinalizare.Day.ToString(),
                tipPerioada = "Sfarsit",
                Id_Angajat = Sesiune.ID_ANGAJAT
            };
            listaPerioade.Add(perioadaFinalizare);
            DBHelper.AddPerioada(perioadaFinalizare);

            PerioadaTask perioadaTaskInceput = new PerioadaTask()
            {
                Id_Proiect = id_proiect,
                Id_Task = Id_Task,
                Id_Perioada = IdPerioadaInceput
            };
            listaPerioadeTask.Add(perioadaTaskInceput);
            DBHelper.AddPerioadaTask(perioadaTaskInceput);

            PerioadaTask perioadaTaskSfarsit = new PerioadaTask()
            {
                Id_Proiect = id_proiect,
                Id_Task = Id_Task,
                Id_Perioada = IdPerioadaSfarsit
            };
            listaPerioadeTask.Add(perioadaTaskSfarsit);
            DBHelper.AddPerioadaTask(perioadaTaskSfarsit);
            MessageBox.Show("Inserarea s-a realizat cu succes!");


            listaProiecte = DBHelper.ExtrageProiecteWithDapper();
            listaTaskuri = DBHelper.ExtrageTaskuriWithDapper();

            // Re-populează listBoxProiecte
            PopulareListBoxuri();

            // Re-populează listBoxPerioadeTaskuri
            listBoxProiecte_SelectedIndexChanged(sender, e);

            // Refresh-uieste controalele pentru a reflecta modificările
            Refresh();
            PopularePerioadeTaskuri();

            GolireControale();
        }
        private void PopulareListBoxuri()
        {
            List<Proiect> listaProiecteFiltrate = new List<Proiect>();
            foreach (var i in listaProiecte)
            {
                var detaliiProiect = DBHelper.ExtrageDetaliiProiect(i.Id_Proiect);
                if (detaliiProiect.dataFinalizareProiect > DateTime.Now)
                {
                    listaProiecteFiltrate.Add(i);
                }
            }
            listBoxProiecte.DataSource = null;
            listBoxProiecte.DataSource = listaProiecteFiltrate;
            listBoxProiecte.DisplayMember = "denumireProiect";
        }
        private String generareIdDescriere()
        {
            var numericParts = listaDescrieri
                .Select(desc => {
                    if (int.TryParse(desc.Id_Descriere.Substring(3), out int result))
                        return result;
                    return -1;
                })
                .Where(num => num != -1)
                .ToList();

            if (numericParts.Count == 0)
                return "DES1";

            int maxNumericPart = numericParts.Max() + 1;

            string uniqueId = "DES" + maxNumericPart.ToString();

            return uniqueId;
        }
        private String generareIdTask(String idProiect)
        {

            var taskuriProiect = listaTaskuri.Where(task => task.Id_Proiect == idProiect).ToList();

            int numarTaskuriProiect = taskuriProiect.Count;

            string idFinal = $"{idProiect}-T{numarTaskuriProiect + 1}";
            return idFinal;
        }
        private String generareIdPerioada()
        {
            var numericParts = listaPerioade
                .Select(perioada => {
                    if (int.TryParse(perioada.Id_Perioada.Substring(3), out int result))
                        return result;
                    return -1;
                    })
                .Where(num => num != -1)
                .ToList();

            if (numericParts.Count == 0)
                return "PER1";

            int maxNumericPart = numericParts.Max() + 1;

            string uniqueId = "PER" + maxNumericPart.ToString();

            return uniqueId;
        }
        private void GolireControale()
        {
            textBoxDenumireTask.Clear();
            richTextBoxDescriereTask.Clear();
            numericUpDownNumarOreNecesare.Value = 0;
            dateTimePickerDataIncepere.ResetText();
            dateTimePickerDataFinalizare.ResetText();
        }
        public int CalculeazaDiferentaInOre(DateTime dataInceput, DateTime dataSfarsit)
        {
            int numarZile = 0;

            for (DateTime dataCurenta = dataInceput; dataCurenta <= dataSfarsit; dataCurenta = dataCurenta.AddDays(1))
            {
                if (dataCurenta.DayOfWeek != DayOfWeek.Saturday && dataCurenta.DayOfWeek != DayOfWeek.Sunday)
                {
                    numarZile++;
                }
            }

            return numarZile*8; // numarul de ore necesar pentru finalizarea taskului
        }
        public void SetareDateTimePickers(string idTask)
        {
            var detaliiTask = DBHelper.ExtrageDetaliiTask(idTask);

        }/*
        public void VerificareDateTimePicker(bool taskNou)
        {
            Proiect proiectSelectat = (Proiect)listBoxProiecte.SelectedItem;
            List<Task> listaTaskuriAfisare = new List<Java.Task>();
            if (listaProiecte.Count != 0 && listaTaskuri.Count != 0)
            {
                listaTaskuriAfisare = listaTaskuri.Where(t => t.Id_Proiect.Equals(((Proiect)listBoxProiecte.SelectedItem).Id_Proiect)).ToList();
            }
            if (proiectSelectat == null || taskSelectat == null)
            {
                return; // Ieși dacă nu sunt selectate proiect sau task
            }

            var detaliiTask = DBHelper.ExtrageDetaliiTask(taskSelectat.Id_Task);

            dateTimePickerDataInceput.MinDate = new DateTime(2000, 5, 5);
            dateTimePickerDataInceput.MaxDate = new DateTime(3000, 5, 5);
            dateTimePickerDataFinalizare.MinDate = new DateTime(2000, 5, 5);
            dateTimePickerDataFinalizare.MaxDate = new DateTime(3000, 5, 5);

            if (taskNou == true)
            {
                dateTimePickerDataInceput.MinDate = detaliiTask.dataIncepereTask;
                dateTimePickerDataInceput.MaxDate = detaliiTask.dataFinalizareTask;
                dateTimePickerDataInceput.Value = detaliiTask.dataIncepereTask;

                dateTimePickerDataFinalizare.MinDate = detaliiTask.dataIncepereTask;
                dateTimePickerDataFinalizare.MaxDate = detaliiTask.dataFinalizareTask;
                dateTimePickerDataFinalizare.Value = detaliiTask.dataFinalizareTask;
            }
            else
            {
                IntervalLucru interval = (IntervalLucru)listBoxNrOreRamase.SelectedItem;
                dateTimePickerDataInceput.Value = interval.DataInceput;
                dateTimePickerDataFinalizare.Value = interval.DataSfarsit;
                numericUpDownOreAlocate.Value = interval.NrOre;
            }

        }*/
        private void listBoxProiecte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxProiecte.SelectedIndex != -1)
            {
                Proiect proiectSelectat = (Proiect)listBoxProiecte.SelectedItem;
                var detaliiProiect = DBHelper.ExtrageDetaliiProiect(proiectSelectat.Id_Proiect);
                var listaTaskuriFiltrate = listaTaskuri.Where(t => t.Id_Proiect.Equals(((Proiect)listBoxProiecte.SelectedItem).Id_Proiect)).ToList();
                listaIntervaleTaskuri.Clear();
                foreach (var i in listaTaskuriFiltrate)
                {
                    listaIntervaleTaskuri.Add(DBHelper.ExtrageDetaliiTaskGantt(i.Id_Task));//obiect PerioadeTaskGantt
                }
                PopularePerioadeTaskuri();
                textBoxDataIncepereProiect.Text = detaliiProiect.dataIncepereProiect.ToString("dd/MM/yyyy");
                textBoxDataFinalizareProiect.Text = detaliiProiect.dataFinalizareProiect.ToString("dd/MM/yyyy");

                IntervalTimp intervalProiect = new IntervalTimp()
                {
                    Start = detaliiProiect.dataIncepereProiect,
                    End = detaliiProiect.dataFinalizareProiect
                };
                if (intervalProiect.Start >= DateTime.Today)
                {
                    SetareDateTimePickers(intervalProiect, true);
                }
                else if (intervalProiect.Start < DateTime.Today && intervalProiect.End >= DateTime.Today)
                {
                    SetareDateTimePickers(intervalProiect, false);
                }
                else
                {
                    MessageBox.Show("Proiectul s-a finalizat");
                }
            }
        }
        private void PopularePerioadeTaskuri()
        {
            listBoxPerioadeTaskuri.DataSource = null;
            listBoxPerioadeTaskuri.DataSource = listaIntervaleTaskuri.OrderBy(interval => interval.DataIncepereTask).ToList();
            listBoxPerioadeTaskuri.DisplayMember = "DetaliiInterval";
        }
        public static bool ValidateTaskName(string taskName)
        {
            if (string.IsNullOrWhiteSpace(taskName))
            {
                return false;
            }
            int maxLength = 50;
            if (taskName.Length > maxLength)
            {
                return false;
            }
            return true;
        }

        private void listBoxPerioadeTaskDisponibile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void InitializareDateTimePickers()
        {
            /*dateTimePickerDataIncepere.MinDate = DateTime.Today;
            dateTimePickerDataIncepere.Value = DateTime.Today;

            dateTimePickerDataFinalizare.Value = dateTimePickerDataIncepere.Value.AddDays(15);
            dateTimePickerDataFinalizare.MinDate = dateTimePickerDataIncepere.Value;*/
        }

        private void dateTimePickerDataIncepere_ValueChanged(object sender, EventArgs e)
        {
           /* if (dateTimePickerDataFinalizare.Value < dateTimePickerDataIncepere.Value)
            {
                dateTimePickerDataFinalizare.Value = dateTimePickerDataIncepere.Value.AddDays(5);
            }
            dateTimePickerDataFinalizare.MinDate = dateTimePickerDataIncepere.Value;*/
        }

        private void dateTimePickerDataFinalizare_ValueChanged(object sender, EventArgs e)
        {
            /*// Verificăm dacă data de finalizare este înaintea datei de început
            if (dateTimePickerDataFinalizare.Value < dateTimePickerDataIncepere.Value)
            {
                // Setăm data de finalizare la o valoare corespunzătoare (ex. cu 15 zile după data de început)
                dateTimePickerDataFinalizare.Value = dateTimePickerDataIncepere.Value.AddDays(15);
            }

            // Reactualizăm minimul și maximul pentru data de început
            dateTimePickerDataIncepere.MinDate = DateTime.Today;
            dateTimePickerDataIncepere.MaxDate = dateTimePickerDataFinalizare.Value;

            // Reactualizăm minimul și maximul pentru data de finalizare
            dateTimePickerDataFinalizare.MinDate = dateTimePickerDataIncepere.Value;
            dateTimePickerDataFinalizare.MaxDate = new DateTime(3000, 12, 31); // sau altă valoare maximă dorită

            // Reactualizăm data de început pentru a fi mai mică sau egală cu data de finalizare
            dateTimePickerDataIncepere.Value = DateTime.Today < dateTimePickerDataFinalizare.Value
                                                    ? DateTime.Today
                                                    : dateTimePickerDataFinalizare.Value;*/
        }

        private void FormatareTextboxuri()
        {
            // Formatarea pentru textBoxDataIncepereProiect
            textBoxDataIncepereProiect.TextAlign = HorizontalAlignment.Center;
            textBoxDataIncepereProiect.Multiline = true;
            textBoxDataIncepereProiect.Font = new Font("Times New Roman", 18);
            textBoxDataIncepereProiect.Size = new Size(200, 40); // Ajustează dimensiunea pentru a se potrivi textului

            // Formatarea pentru textBoxDataFinalizareProiect
            textBoxDataFinalizareProiect.TextAlign = HorizontalAlignment.Center;
            textBoxDataFinalizareProiect.Multiline = true;
            textBoxDataFinalizareProiect.Font = new Font("Times New Roman", 18);
            textBoxDataFinalizareProiect.Size = new Size(200, 40); // Ajustează dimensiunea pentru a se potrivi textului
        }

        public void SetareDateTimePickers(IntervalTimp intervalProiect, bool boolean)
        {
            //true  - alegerea taskului se face incepand cu prima zi a proiectului (proiect care urmeaza sa inceapa )
            //false - alegerea taskului se face incepand cu data curenta ( proeict inceput in trecut, neterminat )
            dateTimePickerDataIncepere.MinDate = new DateTime(2000, 5, 5);
            dateTimePickerDataIncepere.MaxDate = new DateTime(3000, 5, 5);
            dateTimePickerDataFinalizare.MinDate = new DateTime(2000, 5, 5);
            dateTimePickerDataFinalizare.MaxDate = new DateTime(3000, 5, 5);

            
            dateTimePickerDataIncepere.MaxDate = intervalProiect.End;       

            dateTimePickerDataFinalizare.MinDate = intervalProiect.Start;
            dateTimePickerDataFinalizare.MaxDate = intervalProiect.End;
            dateTimePickerDataFinalizare.Value = intervalProiect.End;

            if(boolean == true)
            {
                dateTimePickerDataIncepere.MinDate = intervalProiect.Start;
                dateTimePickerDataIncepere.Value = intervalProiect.Start;              

                dateTimePickerDataFinalizare.MinDate = intervalProiect.Start;

            }
            else
            {
                dateTimePickerDataIncepere.Value = DateTime.Today;
                dateTimePickerDataIncepere.MinDate = DateTime.Today;

                dateTimePickerDataFinalizare.MinDate = DateTime.Today;
            }
        }
    }
}
