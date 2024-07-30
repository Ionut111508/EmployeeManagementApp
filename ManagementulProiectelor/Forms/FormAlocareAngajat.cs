using ManagementulProiectelor.Java;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = ManagementulProiectelor.Java.Task;

namespace ManagementulProiectelor.Forms
{
    public partial class FormAlocareAngajat : Form
    {
        List<Angajat> listaAngajati = DBHelper.ExtrageAngajatiWithDapper();
        List<Participa> listaParticipanti = DBHelper.ExtrageParticipariWithDapper();
        List<Proiect> listaProiecte = DBHelper.ExtrageProiecteWithDapper();
        List<Task> listaTaskuri = DBHelper.ExtrageTaskuriWithDapper();
        List<Angajat> listaAngajatiDisponibili = new List<Angajat>();
        List<Angajat> listaAngajatiProvizorii = new List<Angajat>();
        private List<Angajat> listaAngajatiAlocatiPeTask = new List<Angajat>();
        private List<IntervalLucru> perioadaSuprapunere = new List<IntervalLucru>();
        private List<IntervalLucru> perioadeUnice = new List<IntervalLucru>();
        private List<IntervalLucru> intervaleLibereAngajati = new List<IntervalLucru>();       
        private List<IntervalLucru> perioadaLucruAngajat = new List<IntervalLucru>();
        private List<ProprietatiAngajatSelectat> listaProprietatiAngajatSelectat = new List<ProprietatiAngajatSelectat>();

        private static Dictionary<string, decimal> oreAlocateAngajati = new Dictionary<string, decimal>();

        public FormAlocareAngajat()
        {
            InitializeComponent();
            PopularecomboBoxProiecte();
        }

        #region Selectare Proiect
        private void comboBoxProiecte_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTaskuri.SelectedIndex = -1;
            if (comboBoxProiecte.SelectedIndex != -1)
            {            
                comboBoxTaskuri.Visible = true;
                labelSelectareTask.Visible = true;

                int index = comboBoxProiecte.SelectedIndex;
                Proiect proiectSelectat = listaProiecte[index];

                PopularecomboBoxTaskuri();
            }
        }
        private void PopularecomboBoxProiecte()
        {
            List<Proiect> listaProiecteFiltrate = new List<Proiect>();

            foreach (Proiect proiect in listaProiecte)
            {
                var detaliiProiect = DBHelper.ExtrageDetaliiProiect(proiect.Id_Proiect);
                if (detaliiProiect.dataFinalizareProiect > DateTime.Now)
                {
                    bool areTaskuri = listaTaskuri.Any(t => t.Id_Proiect == proiect.Id_Proiect);
                    if (areTaskuri)
                    {
                        listaProiecteFiltrate.Add(proiect);
                    }
                }
            }
            listaProiecteFiltrate = listaProiecteFiltrate.OrderBy(p => p.denumireProiect).ToList();

            comboBoxProiecte.DataSource = null;
            comboBoxProiecte.DataSource = listaProiecteFiltrate;
            comboBoxProiecte.DisplayMember = "denumireProiect";

            if (listaProiecteFiltrate.Count > 0)
            {
                comboBoxProiecte.SelectedIndex = 0;
            }
        }

        #endregion
        #region Selectare Task
        private void comboBoxTaskuri_SelectedIndexChanged(object sender, EventArgs e)
        {
            Task taskSelectat = (Task)comboBoxTaskuri.SelectedItem;
            if (comboBoxTaskuri.SelectedIndex != -1 && taskSelectat != null)
            {
                Proiect proiectSelectat = (Proiect)comboBoxProiecte.SelectedItem;
                var detaliiTask = DBHelper.ExtrageDetaliiTask(taskSelectat.Id_Task);
                decimal nrOreAlocateDinDB = 0;
                List<IntervalLucru> detaliiParticipariTask = new List<IntervalLucru>();
                detaliiParticipariTask = DBHelper.DetaliiPerioadaDeLucru(taskSelectat.Id_Task);//preia toate datele din DB din tabela Participa pentru un anumit task
                foreach (var detalii in detaliiParticipariTask)
                {
                    nrOreAlocateDinDB = nrOreAlocateDinDB + (detalii.NrOre * CalculeazaZileLucratoare(detalii.DataInceput, detalii.DataSfarsit));
                }
                textBoxOreAlocate.Text = nrOreAlocateDinDB.ToString("0.00");
                if (nrOreAlocateDinDB >= detaliiTask.nrOre)
                {
                    string text = "S-a atins numarul maxim de ore alocate ! ";
                    if (listBoxAngajatiDisponibili.Items.Count != 1)
                    {
                        listBoxAngajatiDisponibili.DataSource = null;
                        listBoxAngajatiDisponibili.Items.Add(text);
                    }
                    listBoxAngajatiDisponibili.Enabled = false;
                    listBoxNrOreRamase.Visible = false;
                }
                else
                {
                    listBoxNrOreRamase.Visible = true;
                    listBoxAngajatiDisponibili.Enabled = true;
                    PopulareListBoxAngajatDisponibili();
                }
                    AfiseazaDetaliiTask(taskSelectat.Id_Task, proiectSelectat.Id_Proiect);
                VerificareDateTimePicker();
                progressBarNumarOreAlocate.Maximum = 100;
                progressBarNumarOreAlocate.Value = (int)(((double)nrOreAlocateDinDB / Convert.ToInt32(detaliiTask.nrOre)) * 100);
                oreAlocateAngajati.Clear();
                listBoxAfisareAngajatiSelectati.DataSource = null;
                listBoxAfisareAngajatiSelectati.Items.Clear();
                listaAngajatiProvizorii.Clear();
                listaProprietatiAngajatSelectat.Clear();
                perioadaLucruAngajat.Clear();
            }
            else
            {
                listBoxNrOreRamase.DataSource = null;
            }
        }
        private void PopularecomboBoxTaskuri()
        {
            AfisareControaleAscunse();
            comboBoxTaskuri.DataSource = null;
            if (comboBoxProiecte.SelectedItem != null && listaTaskuri.Count != 0)
            {
                Proiect proiectSelectat = (Proiect)comboBoxProiecte.SelectedItem;
                List<Task> listaNoua = new List<Task>();
                foreach (var task in listaTaskuri)
                {
                    if (task.Id_Proiect == proiectSelectat.Id_Proiect)
                    {
                        var detaliiTask = DBHelper.ExtrageDetaliiTask(task.Id_Task);
                        if (DateTime.Today < detaliiTask.dataFinalizareTask)
                        {
                            listaNoua.Add(task);
                        }
                    }
                }
                comboBoxTaskuri.DataSource = listaNoua;
                comboBoxTaskuri.DisplayMember = "denumireTask";
            }
            
        }
        private void AfiseazaDetaliiTask(string idTask, string idProiect)
        {
            if (comboBoxProiecte.SelectedIndex != -1 && comboBoxTaskuri.SelectedIndex != -1)
            {
                var detaliiTask = DBHelper.ExtrageDetaliiTask(idTask);
                textBoxOreNecesare.Text = null;
                textBoxOreNecesare.Text = detaliiTask.nrOre.ToString();
                textBoxDataIncepereTask.Text = $"{detaliiTask.dataIncepereTask.ToString("dd/MM/yyyy")}";
                textBoxDataFinalizareTask.Text = $"{detaliiTask.dataFinalizareTask.ToString("dd/MM/yyyy")}";
            }

        }
        #endregion
        #region Angajati Disponibili

        private void PopulareListBoxAngajatDisponibili()
        {
            listBoxNrOreRamase.SelectedIndex = -1;
            listBoxAngajatiDisponibili.DataSource = null;
            if (listaTaskuri.Count != 0)
            {
                perioadaSuprapunere.Clear();
                perioadeUnice.Clear();
                listaAngajatiDisponibili.Clear();
                Task taskSelectat = (Task)comboBoxTaskuri.SelectedItem;
                List<Angajat> listaAngajatiIntermediari = DBHelper.AngajatiDisponibiliPentruTask(taskSelectat.Id_Task).ToList();//selecteaza toti angajatii care nu participa la taskul selectat
                foreach (Angajat angajat in listaAngajatiIntermediari)
                {
                    if (!listaAngajatiDisponibili.Any(a => a.Id_Angajat == angajat.Id_Angajat))
                    {
                        perioadeUnice = CalculeazaIntervaleDisponibilitate(taskSelectat.Id_Task, angajat.Id_Angajat);
                        perioadeUnice.RemoveAll(interval => interval.NrOre == 0.0m || interval.NrZile == 0);

                        PopuleazaNrZileLucratoare(perioadeUnice);
                        perioadeUnice.RemoveAll(interval => interval.NrOre == 0.0m || interval.NrZile == 0);

                        if (perioadeUnice.Count != 0 || perioadaSuprapunere.Count ==0)
                        {
                            listaAngajatiDisponibili.Add(angajat);
                        }
                    }
                }
                listaAngajatiDisponibili = listaAngajatiDisponibili.OrderBy(angajat => angajat.AngajatFullName).ToList();
                listBoxAngajatiDisponibili.DataSource = listaAngajatiDisponibili;
                listBoxAngajatiDisponibili.DisplayMember = "AngajatFullName";
            }
            listBoxNrOreRamase.SelectedIndex = -1;
        }
        private void listBoxAngajatiDisponibili_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAngajatiDisponibili.SelectedIndex != -1)
            {
                listBoxNrOreRamase.SelectedIndex = -1;
                Task taskSelectat = (Task)comboBoxTaskuri.SelectedItem;
                perioadaSuprapunere.Clear();

                var detaliiTask = DBHelper.ExtrageDetaliiTask(taskSelectat.Id_Task);
                Angajat angajatSelectat = (Angajat)listBoxAngajatiDisponibili.SelectedItem;

                decimal nrOreNorma = DBHelper.ExtrageNrOreAngajat(angajatSelectat.Id_Angajat);
                numericUpDownOreAlocate.Maximum = nrOreNorma;

                perioadeUnice = CalculeazaIntervaleDisponibilitate(taskSelectat.Id_Task, angajatSelectat.Id_Angajat);
                perioadeUnice.RemoveAll(interval => interval.NrOre == 0.0m || interval.NrZile == 0 || interval.NrOre <= 0.0m);

                if ((perioadeUnice.Count == 0) && (AngajatAlocatInInterval(angajatSelectat.Id_Angajat, taskSelectat.Id_Task) == false))
                {
                    IntervalLucru interval = new IntervalLucru();

                    interval.Id_Angajat = angajatSelectat.Id_Angajat;
                    interval.DataInceput = detaliiTask.dataIncepereTask;
                    interval.DataSfarsit = detaliiTask.dataFinalizareTask; // dataSfarsit este de tip DateTime
                    interval.NrOre = nrOreNorma; // nrOre este de tip decimal
                    interval.NrZile = CalculeazaZileLucratoare(detaliiTask.dataIncepereTask, detaliiTask.dataFinalizareTask);

                    perioadeUnice.Add(interval);
                    //listaAngajatiDisponibili.Add(angajatSelectat);
                }
                AfisarePerioadeUniceInListBox();
                perioadeUnice.Clear();
                //VerificareDateTimePicker(true);
                listBoxNrOreRamase.SelectedIndex = -1;
            }
        }
        private void AfisarePerioadeUniceInListBox()
        {
            listBoxNrOreRamase.DataSource = null;
            listBoxNrOreRamase.DataSource = perioadeUnice;
            listBoxNrOreRamase.DisplayMember = "DetaliiInterval";
        }
        #endregion
        #region Calculare Intervale Disponibilitate

        private List<IntervalLucru> CalculeazaIntervaleDisponibilitate(string idTaskSelectat, string idAngajat)
        {
            var detaliiTask = DBHelper.ExtrageDetaliiTask(idTaskSelectat);
            DateTime dataInceputTask = detaliiTask.dataIncepereTask;
            DateTime dataSfarsitTask = detaliiTask.dataFinalizareTask;
            decimal nrOreNorma = DBHelper.ExtrageNrOreAngajat(idAngajat);
            DateTime dataCurenta = DateTime.Now.Date;
            DateTime dataInceputDisponibilitate = dataInceputTask > dataCurenta ? dataInceputTask : dataCurenta;
            List<Participa> listaFiltrataParticipanti = listaParticipanti.Where(c => c.Id_Angajat == idAngajat).ToList();
            List<IntervalLucru> intervaleLucru = new List<IntervalLucru>();
            foreach (var participare in listaFiltrataParticipanti)
            {
                DateTime dataParticipareAngajat = participare.dataParticipareTask;
                DateTime dataParasireAngajat = participare.dataParasireTask;
                decimal nrOre = participare.nrOre;
                DateTime startSuprapunere = dataParticipareAngajat > dataInceputDisponibilitate ? dataParticipareAngajat : dataInceputDisponibilitate;
                DateTime endSuprapunere = dataParasireAngajat < dataSfarsitTask ? dataParasireAngajat : dataSfarsitTask;
                if (startSuprapunere < endSuprapunere)
                {
                    intervaleLucru.Add(new IntervalLucru
                    {
                        Id_Angajat = idAngajat,
                        DataInceput = startSuprapunere,
                        DataSfarsit = endSuprapunere,
                        NrOre = nrOre
                    });
                }
            }
            intervaleLucru = intervaleLucru.OrderBy(interval => interval.DataInceput).ToList();
            List<IntervalLucru> intervaleProcesate = ProcesareIntervale(intervaleLucru, nrOreNorma);
            VerificaSiAcoperaPerioade(intervaleProcesate, idTaskSelectat, nrOreNorma, idAngajat);
            PopuleazaNrZileLucratoare(intervaleProcesate);
            return intervaleProcesate;
        }

        private List<IntervalLucru> ProcesareIntervale(List<IntervalLucru> intervale, decimal nrOreNorma)
        {
            List<IntervalLucru> intervaleProcesate = new List<IntervalLucru>();

            foreach (var interval in intervale)
            {
                if (intervaleProcesate.Any() && interval.DataInceput <= intervaleProcesate.Last().DataSfarsit)
                {
                    var lastInterval = intervaleProcesate.Last();
                    DateTime dataInceputSuprapunere = interval.DataInceput > lastInterval.DataInceput ? interval.DataInceput : lastInterval.DataInceput;
                    DateTime dataSfarsitSuprapunere = interval.DataSfarsit < lastInterval.DataSfarsit ? interval.DataSfarsit : lastInterval.DataSfarsit;
                    decimal nrOreSuprapunere = interval.NrOre + lastInterval.NrOre;

                    lastInterval.DataSfarsit = dataInceputSuprapunere.AddDays(-1);

                    intervaleProcesate.Add(new IntervalLucru
                    {
                        Id_Angajat = interval.Id_Angajat,
                        DataInceput = dataInceputSuprapunere,
                        DataSfarsit = dataSfarsitSuprapunere,
                        NrOre = nrOreSuprapunere
                    });

                    interval.DataInceput = dataSfarsitSuprapunere.AddDays(1);
                }
                intervaleProcesate.Add(interval);
            }

            foreach (IntervalLucru interval in intervaleProcesate)
            {
                interval.NrOre = nrOreNorma - interval.NrOre;
            }

            return intervaleProcesate.OrderBy(interval => interval.DataInceput).ToList();
        }

        private void VerificaSiAcoperaPerioade(List<IntervalLucru> intervaleProcesate, String idTask, decimal nrOreNorma, string idAngajat)
        {
            var detaliiTask = DBHelper.ExtrageDetaliiTask(idTask);
            DateTime dataCurenta = DateTime.Now.Date;
            DateTime dataInceputTask = detaliiTask.dataIncepereTask > dataCurenta ? detaliiTask.dataIncepereTask : dataCurenta;
            if (intervaleProcesate.Count == 0 || intervaleProcesate[0].DataInceput > dataInceputTask)
            {
                intervaleProcesate.Insert(0, new IntervalLucru
                {
                    Id_Angajat = idAngajat,
                    DataInceput = dataInceputTask,
                    DataSfarsit = intervaleProcesate.Count == 0 ? detaliiTask.dataFinalizareTask : intervaleProcesate[0].DataInceput.AddDays(-1),
                    NrOre = nrOreNorma
                });
            }
            if (intervaleProcesate.Count > 0 && intervaleProcesate.Last().DataSfarsit < detaliiTask.dataFinalizareTask)
            {
                intervaleProcesate.Add(new IntervalLucru
                {
                    Id_Angajat = idAngajat,
                    DataInceput = intervaleProcesate.Last().DataSfarsit.AddDays(1),
                    DataSfarsit = detaliiTask.dataFinalizareTask,
                    NrOre = nrOreNorma
                });
            }
            for (int i = 0; i < intervaleProcesate.Count - 1; i++)
            {
                if (intervaleProcesate[i].DataSfarsit.AddDays(1) < intervaleProcesate[i + 1].DataInceput)
                {
                    intervaleProcesate.Insert(i + 1, new IntervalLucru
                    {
                        Id_Angajat = idAngajat,
                        DataInceput = intervaleProcesate[i].DataSfarsit.AddDays(1),
                        DataSfarsit = intervaleProcesate[i + 1].DataInceput.AddDays(-1),
                        NrOre = nrOreNorma
                    });
                }
            }
        }

        private void PopuleazaNrZileLucratoare(List<IntervalLucru> perioadeUnice)
        {
            foreach (var interval in perioadeUnice)
            {
                interval.NrZile = CalculeazaZileLucratoare(interval.DataInceput, interval.DataSfarsit);
            }
        }

        #endregion
        #region Alocare
        private void buttonAlocare_Click(object sender, EventArgs e)
        {
            if (comboBoxProiecte.SelectedIndex != -1 && comboBoxTaskuri.SelectedIndex != -1)
            {
                if (perioadaLucruAngajat.Count != 0)
                {
                    Proiect proiectSelectat = (Proiect)comboBoxProiecte.SelectedItem;
                    Task taskSelectat = (Task)comboBoxTaskuri.SelectedItem;

                    int nrAngajatiAlocatiInainte = DBHelper.ReturnareNrAngajatiTask(taskSelectat.Id_Task);
                    DialogResult result = MessageBox.Show("Doriți să faceți inserarea?", "Confirmare", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        foreach (IntervalLucru interval in perioadaLucruAngajat)
                        {
                            DateTime dataAlocare = interval.DataInceput;
                            DateTime dataParasire = interval.DataSfarsit;
                            decimal nrOre = interval.NrOre;

                            Participa participa = new Participa()
                            {
                                Id_Angajat = interval.Id_Angajat,
                                Id_Proiect = proiectSelectat.Id_Proiect,
                                Id_Task = taskSelectat.Id_Task,
                                dataParticipareTask = dataAlocare,
                                dataParasireTask = dataParasire,
                                nrOre = nrOre
                            };
                            DBHelper.AddParticipa(participa);
                            Angajat angajat = listaAngajati.FirstOrDefault(a => a.Id_Angajat == interval.Id_Angajat);
                            if (!listaAngajatiAlocatiPeTask.Contains(angajat))
                            {
                                listaAngajatiAlocatiPeTask.Add(angajat);
                            }
                        }

                        int nrAngajatiAlocatiDupa = DBHelper.ReturnareNrAngajatiTask(taskSelectat.Id_Task);
                        MessageBox.Show("Erau alocati " + nrAngajatiAlocatiInainte + " angajati pe taskul " + taskSelectat.denumireTask);
                        MessageBox.Show("Acum lucreaza " + nrAngajatiAlocatiDupa + " angajati pe taskul " + taskSelectat.denumireTask);

                        // Curățare listaProprietatiAngajatSelectat după alocare
                        listaProprietatiAngajatSelectat.Clear();

                        if (nrAngajatiAlocatiDupa != 0)
                        {
                            listBoxAfisareAngajatiSelectati.DataSource = null;
                            listBoxAfisareAngajatiSelectati.Items.Clear();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nu ați selectat niciun angajat pentru alocare.");
                }
            }
            else
            {
                MessageBox.Show("A apărut o eroare.");
            }
            perioadaLucruAngajat.Clear();
            listaAngajatiProvizorii.Clear();
            listaAngajatiAlocatiPeTask.Clear();
        }

        #endregion
        #region Utile
        public static int CalculeazaZileLucratoare(DateTime dataInceput, DateTime dataSfarsit)
        {
            int numarZileLucratoare = 0;

            for (DateTime dataCurenta = dataInceput; dataCurenta <= dataSfarsit; dataCurenta = dataCurenta.AddDays(1))
            {
                if (dataCurenta.DayOfWeek != DayOfWeek.Saturday && dataCurenta.DayOfWeek != DayOfWeek.Sunday)
                {
                    numarZileLucratoare++;
                }
            }

            return numarZileLucratoare;
        }
        public static int ReturnareNrOreLucrate(string idAngajat, string idTask, DateTime dataCurenta)
        {
            int nrOre = DBHelper.ReturnareNrOreZiCurenta(idAngajat, idTask); // returneaza nr de ore pe o singura zi, un singur task
            return nrOre;
        }
        #endregion
        #region Previzualizare Angajati
        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            if (listBoxAngajatiDisponibili.SelectedIndex == -1)
            {
                return;
            }

            Angajat angajatSelectat = (Angajat)listBoxAngajatiDisponibili.SelectedItem;
            Task taskSelectat = (Task)comboBoxTaskuri.SelectedItem;

            var angajatiLaTaskSelectat = listaParticipanti
                .Where(participare => participare.Id_Task == taskSelectat.Id_Task)
                .Select(participare => listaAngajati.FirstOrDefault(angajat => angajat.Id_Angajat == participare.Id_Angajat))
                .ToList();

            if (angajatiLaTaskSelectat.Any(angajat => angajat.Id_Angajat == angajatSelectat.Id_Angajat))
            {
                MessageBox.Show("Angajatul este deja asociat la taskul selectat");
                return;
            }

            var detaliiTask = DBHelper.ExtrageDetaliiTask(taskSelectat.Id_Task);
            decimal nrOreNorma = DBHelper.ExtrageNrOreAngajat(angajatSelectat.Id_Angajat);

            var perioadeUnice = CalculeazaIntervaleDisponibilitate(taskSelectat.Id_Task, angajatSelectat.Id_Angajat);
            perioadeUnice.RemoveAll(interval => interval.NrOre == 0.0m || interval.NrZile == 0);

            bool perioadaValida = false;
            bool nrOreValid = false;
            decimal nrOreAlocateMomentan = CalculeazaZileLucratoare(dateTimePickerDataInceput.Value, dateTimePickerDataFinalizare.Value) * numericUpDownOreAlocate.Value;
            decimal nrOreTextbox = decimal.Parse(textBoxOreAlocate.Text);

            if (!perioadeUnice.Any())
            {
                perioadaValida = true;
                nrOreValid = true;
            }
            else
            {
                bool perioadeDisponibile = true; // Verifică dacă numărul de ore este disponibil în toate intervalele

                foreach (var intervalP in perioadeUnice)
                {
                    if ((dateTimePickerDataInceput.Value >= intervalP.DataInceput && dateTimePickerDataFinalizare.Value <= intervalP.DataSfarsit) ||
                        (dateTimePickerDataInceput.Value <= intervalP.DataInceput && dateTimePickerDataFinalizare.Value >= intervalP.DataSfarsit) ||
                        (dateTimePickerDataInceput.Value <= intervalP.DataInceput && dateTimePickerDataFinalizare.Value >= intervalP.DataInceput && dateTimePickerDataFinalizare.Value <= intervalP.DataSfarsit) ||
                        (dateTimePickerDataInceput.Value >= intervalP.DataInceput && dateTimePickerDataInceput.Value <= intervalP.DataSfarsit && dateTimePickerDataFinalizare.Value >= intervalP.DataSfarsit))
                    {

                        if (numericUpDownOreAlocate.Value > intervalP.NrOre)
                        {
                            perioadeDisponibile = false;
                            break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                if (perioadeDisponibile)
                {
                    perioadaValida = true;
                    nrOreValid = true;
                }
            }


            if (!ValidareAdaugarePerioada(nrOreAlocateMomentan, detaliiTask.nrOre, nrOreTextbox, perioadaValida, nrOreValid, detaliiTask.dataIncepereTask, detaliiTask.dataFinalizareTask))
            {
                return;
            }

            IntervalLucru interval = new IntervalLucru
            {
                Id_Angajat = angajatSelectat.Id_Angajat,
                DataInceput = dateTimePickerDataInceput.Value,
                DataSfarsit = dateTimePickerDataFinalizare.Value,
                NrOre = numericUpDownOreAlocate.Value,
                NrZile = CalculeazaZileLucratoare(dateTimePickerDataInceput.Value, dateTimePickerDataFinalizare.Value)
            };

            perioadaLucruAngajat.Add(interval);
            listaAngajatiProvizorii.Add(angajatSelectat);
            listaAngajatiDisponibili.Remove(angajatSelectat);

            listaAngajatiDisponibili = listaAngajatiDisponibili.OrderBy(angajat => angajat.numeAngajat).ToList();
            listaAngajatiProvizorii = listaAngajatiProvizorii.OrderBy(angajat => angajat.numeAngajat).ToList();

            oreAlocateAngajati[angajatSelectat.Id_Angajat] = nrOreAlocateMomentan;
            nrOreTextbox += nrOreAlocateMomentan;
            
            progressBarNumarOreAlocate.Maximum = 100;
            double procent = (double)(nrOreTextbox / detaliiTask.nrOre) * 100;
            progressBarNumarOreAlocate.Value = (int)procent;
            textBoxOreAlocate.Text = nrOreTextbox.ToString("0.00");

            ProprietatiAngajatSelectat proprietatiAngajat = new ProprietatiAngajatSelectat
            {
                numeAngajat = angajatSelectat.numeAngajat,
                prenumeAngajat = angajatSelectat.prenumeAngajat,
                dataAlocare = dateTimePickerDataInceput.Value,
                dataParasire = dateTimePickerDataFinalizare.Value,
                nrOre = numericUpDownOreAlocate.Value
            };

            listaProprietatiAngajatSelectat.Add(proprietatiAngajat);

            ActualizeazaListeAngajati();
        }
        private bool ValidareAdaugarePerioada(decimal nrOreAlocateMomentan, decimal nrOreTask, decimal nrOreTextbox, bool perioadaValida, bool nrOreValid, DateTime dataIncepereTask, DateTime dataFinalizareTask)
        {
            if (nrOreAlocateMomentan > nrOreTask - nrOreTextbox)
            {
                MessageBox.Show($"Se alocă un număr prea mare de ore " +
                                $"\nAlocat deja: {nrOreTextbox}" +
                                $"\nRămas nealocat: {nrOreTask - nrOreTextbox}" +
                                $"\nDumneavoastră ați dorit să alocați: {nrOreAlocateMomentan}",
                                "Informație",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return false;
            }


            if (dateTimePickerDataInceput.Value < dataIncepereTask || dateTimePickerDataFinalizare.Value > dataFinalizareTask)
            {
                MessageBox.Show("Perioada selectata depaseste limita taskului ales");
                return false;
            }

            if (numericUpDownOreAlocate.Value == 0)
            {
                MessageBox.Show("Nu se poate aloca un angajat cu 0 ore");
                return false;
            }

            if (!perioadaValida)
            {
                MessageBox.Show("Angajatul nu este disponibil in perioada selectata");
                return false;
            }

            if (dateTimePickerDataInceput.Value > dateTimePickerDataFinalizare.Value)
            {
                MessageBox.Show("Data de inceput trebuie sa fie mai mica decat data de sfarsit");
                return false;
            }

            if (!nrOreValid)
            {
                MessageBox.Show("Numarul de ore de lucru este prea mare pentru intervalul selectat");
                return false;
            }

            return true;
        }
        private void buttonElimina_Click(object sender, EventArgs e)
        {
            if (listaAngajatiProvizorii.Count == 0)
            {
                MessageBox.Show("Nu ati adaugat niciun angajat in lista de angajati provizorii");
                return;
            }

            if (listBoxAfisareAngajatiSelectati.SelectedIndex == -1)
            {
                MessageBox.Show("Selectați un angajat pentru a-l elimina.");
                return;
            }

            Task taskSelectat = (Task)comboBoxTaskuri.SelectedItem;
            var detaliiTask = DBHelper.ExtrageDetaliiTask(taskSelectat.Id_Task);
            ProprietatiAngajatSelectat proprietatiAngajatSelectat = (ProprietatiAngajatSelectat)listBoxAfisareAngajatiSelectati.SelectedItem;

            if (proprietatiAngajatSelectat == null)
            {
                MessageBox.Show("Selectați un angajat valid.");
                return;
            }

            Angajat angajatSelectat = listaAngajatiProvizorii
                .FirstOrDefault(angajat => angajat.numeAngajat == proprietatiAngajatSelectat.numeAngajat && angajat.prenumeAngajat == proprietatiAngajatSelectat.prenumeAngajat);

            if (angajatSelectat == null)
            {
                MessageBox.Show("Selectați un angajat valid.");
                return;
            }

            if (oreAlocateAngajati.ContainsKey(angajatSelectat.Id_Angajat))
            {
                decimal oreAngajat = oreAlocateAngajati[angajatSelectat.Id_Angajat];
                oreAlocateAngajati.Remove(angajatSelectat.Id_Angajat);

                decimal oreCurente = decimal.Parse(textBoxOreAlocate.Text);
                oreCurente -= oreAngajat;
                textBoxOreAlocate.Text = oreCurente.ToString("0.00");
                progressBarNumarOreAlocate.Value = (int)(oreCurente / Convert.ToDecimal(detaliiTask.nrOre) * 100);
            }

            IntervalLucru interval = perioadaLucruAngajat.FirstOrDefault(p => p.Id_Angajat == angajatSelectat.Id_Angajat);
            if (interval != null)
            {
                perioadaLucruAngajat.Remove(interval);
            }

            listaAngajatiDisponibili.Add(angajatSelectat);
            listaAngajatiProvizorii.Remove(angajatSelectat);
            listaProprietatiAngajatSelectat.Remove(proprietatiAngajatSelectat);

            listaAngajatiDisponibili = listaAngajatiDisponibili.OrderBy(angajat => angajat.numeAngajat).ToList();
            listaAngajatiProvizorii = listaAngajatiProvizorii.OrderBy(angajat => angajat.numeAngajat).ToList();

            ActualizeazaListeAngajati();
            MessageBox.Show("Angajatul a fost eliminat cu succes.");
        }

        private void ActualizeazaListeAngajati()
        {
            listBoxAngajatiDisponibili.DataSource = null;
            listBoxAngajatiDisponibili.DataSource = listaAngajatiDisponibili;
            listBoxAngajatiDisponibili.DisplayMember = "AngajatFullName";

            listBoxAfisareAngajatiSelectati.DataSource = null;
            listBoxAfisareAngajatiSelectati.DataSource = listaProprietatiAngajatSelectat;
            listBoxAfisareAngajatiSelectati.DisplayMember = "AfisareDetalii";
        }

        #endregion   
        
        private void listBoxNrOreRamase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxNrOreRamase.SelectedIndex != -1)
            {
                //VerificareDateTimePicker(false);
            }
        }
        
       
        public bool AngajatAlocatInInterval(string idAngajat, string idTask)
        {
            var detaliiTask = DBHelper.ExtrageDetaliiTask(idTask);
            foreach (var participare in listaParticipanti)
            {
                if (participare.Id_Angajat == idAngajat)
                {
                    if (participare.dataParticipareTask <= detaliiTask.dataFinalizareTask && participare.dataParasireTask >= detaliiTask.dataIncepereTask)
                    {
                        return true;//verifica daca , dupa ce s-au scos intervalele cu nrOre 0 si nrZile0, angajatul este folosit in perioada taskului
                        //true - este alocat in interval, probabil cu nrOre maxime
                    }
                }
            }
            return false;//false - nu este alocat in intervat => intervalul e gol
        }
        public void InitializareComponente()
        {
            comboBoxTaskuri.SelectedIndex = -1;
            comboBoxTaskuri.DataSource = null;
            comboBoxTaskuri.Items.Clear();
            comboBoxTaskuri.SelectedIndex = -1;
            listBoxAngajatiDisponibili.SelectedIndex = -1;
            listBoxAngajatiDisponibili.DataSource = null;
            listBoxAngajatiDisponibili.Items.Clear();
            dateTimePickerDataInceput.Visible = false;
            dateTimePickerDataFinalizare.Visible = false;
            progressBarNumarOreAlocate.Visible = false;
            labelDataFinaliza.Visible = false;
            labelDataParticipare.Visible = false;
            numericUpDownOreAlocate.Visible = false;
            textBoxOreAlocate.Visible = false;
            textBoxOreNecesare.Visible = false;
            labelOreAlocate.Visible = false;
            labelOreNecesare.Visible = false;
            buttonAdauga.Visible = false;
            buttonElimina.Visible = false;
            buttonAlocare.Visible = false;
        }
        public void AfisareControaleAscunse()
        {
            dateTimePickerDataInceput.Visible = true;
            dateTimePickerDataFinalizare.Visible = true;
            progressBarNumarOreAlocate.Visible = true;
            labelDataFinaliza.Visible = true;
            labelDataParticipare.Visible = true;
            numericUpDownOreAlocate.Visible = true;
            textBoxOreAlocate.Visible = true;
            textBoxOreNecesare.Visible = true;
            labelOreAlocate.Visible = true;
            labelOreNecesare.Visible = true;
            buttonAdauga.Visible = true;
            buttonElimina.Visible = true;
            buttonAlocare.Visible = true;
        }
        public void VerificareDateTimePicker()
        {
            Proiect proiectSelectat = (Proiect)comboBoxProiecte.SelectedItem;
            Task taskSelectat = (Task)comboBoxTaskuri.SelectedItem;

            if (proiectSelectat == null || taskSelectat == null)
            {
                return;
            }

            var detaliiTask = DBHelper.ExtrageDetaliiTask(taskSelectat.Id_Task);

            dateTimePickerDataInceput.MinDate = new DateTime(1900, 1, 1);
            dateTimePickerDataInceput.MaxDate = new DateTime(2300, 1, 1);
            dateTimePickerDataInceput.Value= new DateTime(1900, 1, 1);
            dateTimePickerDataFinalizare.MinDate = new DateTime(1900, 1, 1);
            dateTimePickerDataFinalizare.MaxDate = new DateTime(2300, 1, 1);
            dateTimePickerDataFinalizare.Value= new DateTime(2300, 1, 1);


            if (DateTime.Today >= detaliiTask.dataIncepereTask)
            {
                dateTimePickerDataInceput.Value = DateTime.Today;
                dateTimePickerDataInceput.MinDate = DateTime.Today;
                dateTimePickerDataFinalizare.MinDate = DateTime.Today;
            }
            else
            {
                dateTimePickerDataInceput.Value = detaliiTask.dataIncepereTask;
                dateTimePickerDataInceput.MinDate = detaliiTask.dataIncepereTask;
                dateTimePickerDataFinalizare.MinDate = detaliiTask.dataIncepereTask;
            }
            
            dateTimePickerDataInceput.MaxDate = detaliiTask.dataFinalizareTask;
            dateTimePickerDataFinalizare.MaxDate = detaliiTask.dataFinalizareTask;
            dateTimePickerDataFinalizare.Value = detaliiTask.dataFinalizareTask;

        }
        private void checkBoxInformatiiTask_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInformatiiTask.Checked)
            {
                panelInformatiiTask.Visible = true;
            }
            else
            {
                panelInformatiiTask.Visible = false;
            }
        }

        private void labelSelectareProiect_Click(object sender, EventArgs e)
        {

        }

        private void labelSelectareTask_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<AngajatAlocat> listaAngajatiDisponibiliZiCurenta = DBHelper.GetAngajatiAlocatiAstazi();
            List<AngajatAlocat> angajatiNealocati = listaAngajatiDisponibiliZiCurenta
                .Where(ang => ang.nrOreRamasDeLucrat > 0)
                .ToList();

            if (angajatiNealocati.Count == 0)
            {
                MessageBox.Show("Toți angajații sunt alocați în ziua curentă.");
            }
            else
            {
                FormAngajatiNealocati angajatiNealocatiForm = new FormAngajatiNealocati(angajatiNealocati);
                angajatiNealocatiForm.ShowDialog();
            }
        }

        private void textBoxOreAlocate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
