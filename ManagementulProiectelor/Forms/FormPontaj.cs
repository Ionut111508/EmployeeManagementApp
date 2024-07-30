using ManagementulProiectelor.Java;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ManagementulProiectelor.Forms
{
    public partial class FormPontaj : Form
    {
        static List<Pontaj> listaPontaje = DBHelper.ExtragePontajeWithDapper();
        static List<Proiect> listaProiecte = new List<Proiect>();
        static List<Task> listaTaskuri = new List<Task>();
        static List<Participa> listaParticipari = DBHelper.ExtrageParticipariWithDapper();
        static List<Participa> listaParticipariAngajat = new List<Participa>();
        string Id_Angajat = Sesiune.ID_ANGAJAT;

        public FormPontaj()
        {
            InitializeComponent();
            InitializareCombobox();
            ActualizeazaPontajeRecente();
            dateTimePickerDataAfisarePontare.MaxDate = DateTime.Today;
            dateTimePickerDataAfisarePontare.ValueChanged += new EventHandler(dateTimePickerDataAfisarePontare_ValueChanged);
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            if (numericUpDownNrOre.Value == 0)
            {
                MessageBox.Show("Pontarea nu se poate face cu 0 ore");
            }
            else
            {
                Proiect proiectSelectat = (Proiect)comboBoxProiect.SelectedItem;
                Task taskSelectat = (Task)comboBoxTask.SelectedItem;
                decimal nrOreP = numericUpDownNrOre.Value;
                DateTime dataPontareP = dateTimePickerDataAfisarePontare.Value.Date; // Utilizăm data selectată din dateTimePicker

                // Verificăm dacă există deja un pontaj pentru aceeași zi, proiect, task și angajat
                Pontaj existingPontaj = listaPontaje.FirstOrDefault(p =>
                    p.Id_Proiect == proiectSelectat.Id_Proiect &&
                    p.Id_Task == taskSelectat.Id_Task &&
                    p.Id_Angajat == Id_Angajat &&
                    p.dataPontare.Date == dataPontareP.Date);

                if (existingPontaj != null)
                {
                    // Dacă există, actualizăm numărul de ore
                    existingPontaj.nrOre += nrOreP;
                    DBHelper.UpdatePontaj(existingPontaj); // Implementează metoda de actualizare în funcție de nevoi
                    MessageBox.Show($"S-au adăugat încă {nrOreP:F1} ore la pontajul existent.");

                    // Actualizăm lista locală pentru a reflecta modificările în baza de date
                    listaPontaje = DBHelper.ExtragePontajeWithDapper();
                }
                else
                {
                    // În caz contrar, inserăm un nou pontaj
                    Pontaj pontaj = new Pontaj()
                    {
                        Id_Angajat = Sesiune.ID_ANGAJAT,
                        nrOre = nrOreP,
                        dataPontare = dataPontareP,
                        Id_Proiect = proiectSelectat.Id_Proiect,
                        Id_Task = taskSelectat.Id_Task
                    };
                    DBHelper.AddPontaj(pontaj);

                    // Actualizăm lista locală cu noul pontaj adăugat
                    listaPontaje.Add(pontaj);

                    MessageBox.Show($"Ai adăugat {pontaj.nrOre:F1} ore");
                }
                ActualizeazaValoareMaxima();
                ActualizeazaPontajeRecente();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxPontariRecente.SelectedItem == null)
            {
                MessageBox.Show("Te rog să selectezi o pontare pentru a o șterge.");
                return;
            }

            // Extragem pontajul selectat din listBox
            string selectedItem = listBoxPontariRecente.SelectedItem.ToString();
            DateTime dataSelectata = dateTimePickerDataAfisarePontare.Value.Date;

            // Căutăm pontajul în lista de pontaje folosind detaliile din elementul selectat
            var pontajDeSters = listaPontaje.FirstOrDefault(p =>
                p.Id_Angajat == Id_Angajat &&
                p.dataPontare.Date == dataSelectata &&
                selectedItem.Contains(DBHelper.ExtrageDenumireTask(p.Id_Task)) &&
                selectedItem.Contains(p.nrOre.ToString("F1"))
            );

            if (pontajDeSters != null)
            {
                // Ștergem pontajul din baza de date
                DBHelper.DeletePontaj(pontajDeSters);

                // Actualizăm lista locală de pontaje
                listaPontaje.Remove(pontajDeSters);

                // Actualizăm afișarea pontajelor recente
                ActualizeazaPontajeRecente();

                MessageBox.Show("Pontarea a fost ștearsă cu succes.");
            }
            else
            {
                MessageBox.Show("Nu s-a putut găsi pontarea selectată pentru ștergere.");
            }
        }

        private void InitializareCombobox()
        {
            // Filtrăm lista participărilor angajatului pentru data selectată
            DateTime dataSelectata = dateTimePickerDataAfisarePontare.Value.Date;
            listaParticipariAngajat = listaParticipari
                .Where(p => p.Id_Angajat == Sesiune.ID_ANGAJAT &&
                            p.dataParticipareTask <= dataSelectata &&
                            p.dataParasireTask >= dataSelectata)
                .ToList();

            // Selectăm proiectele în care angajatul este alocat în data selectată
            listaProiecte = listaParticipariAngajat
                .Select(p => p.Id_Proiect)
                .Distinct()
                .Join(DBHelper.ExtrageProiecteWithDapper(), idProiect => idProiect, proiect => proiect.Id_Proiect, (idProiect, proiect) => proiect)
                .ToList();

            // Verificăm dacă există proiecte în data selectată
            if (listaProiecte.Count > 0)
            {
                // Afișăm controalele necesare
                comboBoxProiect.Visible = true;
                comboBoxTask.Visible = true;
                numericUpDownNrOre.Visible = true;
                buttonAdauga.Visible = true;
                buttonRemove.Visible = true; // Facem vizibil butonul Remove
                labelProiect.Visible = true;
                labelTask.Visible = true;
                labelNrOreLucrate.Visible = true;
                listBoxPontariRecente.Visible = true;
                labelMesaj.Visible = false;

                comboBoxProiect.DataSource = null;
                comboBoxProiect.DataSource = listaProiecte;
                comboBoxProiect.DisplayMember = "denumireProiect";

                // Actualizăm și lista de task-uri în funcție de proiectul selectat
                if (comboBoxProiect.SelectedItem != null)
                {
                    Proiect proiectSelectat = (Proiect)comboBoxProiect.SelectedItem;
                    ActualizeazaListaTaskuri(proiectSelectat);
                }
            }
            else
            {
                // Nu există proiecte în data selectată, ascundem controalele și afișăm mesajul
                AscundeControale();
            }
        }

        private void comboBoxProiect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProiect.SelectedItem != null)
            {
                Proiect proiectSelectat = (Proiect)comboBoxProiect.SelectedItem;
                ActualizeazaListaTaskuri(proiectSelectat);
            }
        }

        private void ActualizeazaListaTaskuri(Proiect proiectSelectat)
        {
            // Filtrăm task-urile angajatului în proiectul selectat și în data selectată
            listaTaskuri = listaParticipariAngajat
                .Where(p => p.Id_Proiect == proiectSelectat.Id_Proiect)
                .Join(DBHelper.ReturnareListaTaskuriAngajatAlocat(Id_Angajat, proiectSelectat.Id_Proiect),
                      participare => participare.Id_Task,
                      task => task.Id_Task,
                      (participare, task) => task)
                .ToList();

            comboBoxTask.DataSource = null;
            comboBoxTask.DataSource = listaTaskuri;
            comboBoxTask.DisplayMember = "denumireTask";

            ActualizeazaValoareMaxima(); // Actualizăm numărul maxim de ore disponibile
        }

        private void numericUpDownNrOre_ValueChanged(object sender, EventArgs e)
        {
            ActualizeazaValoareMaxima();
        }

        private void comboBoxTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizeazaValoareMaxima();
        }

        private void ActualizeazaValoareMaxima()
        {
            if (comboBoxTask.SelectedItem != null)
            {
                Task taskSelectat = (Task)comboBoxTask.SelectedItem;

                // Filtrăm pontajele pentru ziua selectată din dateTimePicker
                DateTime dataSelectata = dateTimePickerDataAfisarePontare.Value.Date;
                decimal nrOreAlocare = DBHelper.ExtrageNrOreParticipare(Id_Angajat, taskSelectat.Id_Task);

                decimal oreAlocateTask = listaPontaje
                    .Where(p => p.Id_Task == taskSelectat.Id_Task && p.Id_Angajat == Id_Angajat && p.dataPontare.Date == dataSelectata)
                    .Sum(p => p.nrOre);

                decimal oreRamase = nrOreAlocare - oreAlocateTask;
                numericUpDownNrOre.Maximum = oreRamase > 0 ? oreRamase : 0;
            }
            else
            {
                numericUpDownNrOre.Maximum = 0;
            }
        }

        private void ActualizeazaPontajeRecente()
        {
            DateTime dataSelectata = dateTimePickerDataAfisarePontare.Value.Date;
            listaPontaje = DBHelper.ExtragePontajeWithDapper(); // Actualizăm lista de pontaje cu cele mai recente

            var pontajeFiltrate = listaPontaje.Where(p => p.dataPontare.Date == dataSelectata && p.Id_Angajat == Id_Angajat).ToList();

            listBoxPontariRecente.Items.Clear();

            if (pontajeFiltrate.Count == 0)
            {
                listBoxPontariRecente.Items.Add("Nu există pontaje pentru data selectată.");
            }
            else
            {
                foreach (var pontaj in pontajeFiltrate)
                {
                    string oreSauOra = pontaj.nrOre < 2 ? "ora" : "ore";
                    string denumireTask = DBHelper.ExtrageDenumireTask(pontaj.Id_Task);
                    string item = $"{denumireTask} - {pontaj.dataPontare:dddd, dd MMMM}  ---  {pontaj.nrOre:F1} {oreSauOra}";
                    listBoxPontariRecente.Items.Add(item);
                }
            }
        }

        private void dateTimePickerDataAfisarePontare_ValueChanged(object sender, EventArgs e)
        {
            // Verificăm dacă ziua selectată este o zi de weekend
            if (dateTimePickerDataAfisarePontare.Value.DayOfWeek == DayOfWeek.Saturday || dateTimePickerDataAfisarePontare.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                // Setăm data selectată la următoarea zi lucrătoare
                //dateTimePickerDataAfisarePontare.Value = dateTimePickerDataAfisarePontare.Value.AddDays(dateTimePickerDataAfisarePontare.Value.DayOfWeek == DayOfWeek.Saturday ? 2 : 1);
            }

            // La schimbarea datei, reinițializăm combobox-urile pentru a reflecta proiectele și task-urile din data nou selectată
            InitializareCombobox();
            ActualizeazaPontajeRecente();
            ActualizeazaValoareMaxima();
        }

        private void AscundeControale()
        {
            // Ascundem controalele și afișăm mesajul corespunzător
            comboBoxProiect.Visible = false;
            comboBoxTask.Visible = false;
            numericUpDownNrOre.Visible = false;
            buttonAdauga.Visible = false;
            buttonRemove.Visible = false; // Ascundem butonul Remove
            labelProiect.Visible = false;
            labelTask.Visible = false;
            labelNrOreLucrate.Visible = false;
            listBoxPontariRecente.Visible = false;
            labelMesaj.Visible = true;
            labelMesaj.Text = "Angajatul nu este alocat pe niciun task în ziua selectată";
        }
    }
}
