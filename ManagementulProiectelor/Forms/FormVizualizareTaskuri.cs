using ManagementulProiectelor.Java;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Task = ManagementulProiectelor.Java.Task;

namespace ManagementulProiectelor.Forms
{
    public partial class FormVizualizareTaskuri : Form
    {
        List<Proiect> listaProiecte = DBHelper.ExtrageProiecteWithDapper();
        List<Task> listaTaskuri = DBHelper.ExtrageTaskuriWithDapper();
        List<ComentariuTask> listaComentarii = DBHelper.ExtrageComentariiTaskWithDapper();
        List<Angajat> listaAngajati = DBHelper.ExtrageAngajatiWithDapper();

        public FormVizualizareTaskuri()
        {
            InitializeComponent();
            PopularecomboBoxProiecte();
            AfisareComponenteSpeciale();
        }

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


        private void PopularecomboBoxTaskuri()
        {
            comboBoxTaskuri.DataSource = null;
            if (comboBoxProiecte.SelectedItem != null && listaTaskuri.Count != 0)
            {
                List<Task> listaNoua = listaTaskuri.Where(t => t.Id_Proiect.Equals(((Proiect)comboBoxProiecte.SelectedItem).Id_Proiect)).ToList();
                comboBoxTaskuri.DataSource = listaNoua;
                comboBoxTaskuri.DisplayMember = "denumireTask";

                ActualizeazaComentarii();
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

        private void comboBoxTaskuri_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizeazaComentarii();
        }
        private void ActualizeazaComentarii()
        {
            if (comboBoxTaskuri.SelectedIndex != -1)
            {
                Task taskSelectat = (Task)comboBoxTaskuri.SelectedItem;
                List<ComentariuTask> comentariiTask = DBHelper.ExtrageComentariiTaskByTaskId(taskSelectat.Id_Task);
                listBoxComentarii.DataSource = null;

                if (comentariiTask.Count > 0)
                {
                    listBoxComentarii.DataSource = comentariiTask;
                    listBoxComentarii.DisplayMember = "GetFormattedText";
                    listBoxComentarii.SelectionMode = SelectionMode.One;
                }
                else
                {
                    String text = "Nu există comentarii pentru task-ul selectat.";
                    if (!listBoxComentarii.Items.Contains(text) && listBoxComentarii.Items.Count==0)
                    {
                        listBoxComentarii.Items.Add(text);
                    }
                    listBoxComentarii.SelectionMode = SelectionMode.None;
                }
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            panelAdaugareComentariu.Visible = !panelAdaugareComentariu.Visible;
        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxComentarii.SelectedIndex != -1)
            {
                ComentariuTask comentariuSelectat = (ComentariuTask)listBoxComentarii.SelectedItem;

                DialogResult result = MessageBox.Show("Ești sigur că vrei să ștergi acest comentariu?", "Confirmare ștergere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DBHelper.StergeComentariuTask(comentariuSelectat.Id_ComentariuTask);

                    listaComentarii.Remove(comentariuSelectat);
                    ActualizeazaComentarii();
                    MessageBox.Show("Comentariul a fost șters cu succes.", "Ștergere completă", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Nu este selectat niciun comentariu.", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buttonAdaugare_Click(object sender, EventArgs e)
        {
            if (comboBoxProiecte.SelectedIndex == -1)
            {
                MessageBox.Show("Vă rugăm să selectați un proiect.");
                return;
            }

            if (comboBoxTaskuri.SelectedIndex == -1)
            {
                MessageBox.Show("Vă rugăm să selectați un task.");
                return;
            }

            if (string.IsNullOrWhiteSpace(richTextBoxTextComentariu.Text))
            {
                MessageBox.Show("Vă rugăm să completați textul comentariului.");
                return;
            }

            DialogResult result = MessageBox.Show("Ești sigur că vrei să adaugi acest comentariu?", "Confirmare adăugare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ComentariuTask comentariu = new ComentariuTask()
                {
                    Id_ComentariuTask = generareIdComentariuNou(),
                    textComentariuTask = richTextBoxTextComentariu.Text,
                    dataComentariu = DateTime.Now,
                    Id_Proiect = ((Proiect)comboBoxProiecte.SelectedItem).Id_Proiect,
                    Id_Task = ((Task)comboBoxTaskuri.SelectedItem).Id_Task,
                    Id_Angajat = Sesiune.ID_ANGAJAT,
                    NumeAngajat = listaAngajati.FirstOrDefault(a => a.Id_Angajat == Sesiune.ID_ANGAJAT)?.AngajatFullName ?? "Nume necunoscut"
                };

                DBHelper.AddComentariuTask(comentariu);
                MessageBox.Show("Comentariul a fost adăugat cu succes.");

                // Actualizăm lista de comentarii
                listaComentarii = DBHelper.ExtrageComentariiTaskWithDapper();
                ActualizeazaComentarii();

                // Resetăm câmpul textului comentariului
                richTextBoxTextComentariu.Clear();
                panelAdaugareComentariu.Visible = false;
            }
        }


        private String generareIdComentariuNou()
        {
            String idFinal;
            if (listaComentarii.Count == 0)
            {
                idFinal = "C1";
            }
            else
            {
                int maxNumericPart = listaComentarii
                    .Where(obj => obj.Id_ComentariuTask.StartsWith("C"))
                    .Select(obj => int.TryParse(obj.Id_ComentariuTask.Substring(1), out int numeric) ? numeric : 0)
                    .Max();
                idFinal = "C" + (maxNumericPart + 1).ToString();
            }
            return idFinal;
        }

        private void listBoxComentarii_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonEditare_Click(object sender, EventArgs e)
        {
            // Verificăm dacă au fost selectate proiectul și task-ul
            if (comboBoxProiecte.SelectedIndex == -1 || comboBoxTaskuri.SelectedIndex == -1)
            {
                MessageBox.Show("Vă rugăm să selectați un proiect și un task pentru editare.");
                return;
            }

            // Obținem proiectul și task-ul selectat din combobox-uri
            Proiect proiectSelectat = (Proiect)comboBoxProiecte.SelectedItem;
            Task taskSelectat = (Task)comboBoxTaskuri.SelectedItem;

            // Creăm o instanță a formularului de editare și transmitem proiectul și task-ul selectat
            FormEditareInformatiiTask editareInformatiiTask = new FormEditareInformatiiTask(proiectSelectat, taskSelectat);
            editareInformatiiTask.ShowDialog();
            
                        /*Task taskActualizat = DBHelper.ExtrageTaskById(taskSelectat.Id_Task);

                        // Actualizăm denumirea taskului în formular
                        taskSelectat.denumireTask = taskActualizat.denumireTask;*/
            listaTaskuri.Clear();
            listaTaskuri = DBHelper.ExtrageTaskuriWithDapper();
            PopularecomboBoxProiecte();
            PopularecomboBoxTaskuri();
        }
        public void AfisareComponenteSpeciale()
        {
            if(Sesiune.IsAdmin==false & Sesiune.IsManager==false)
            {
                buttonRemove.Visible = false;
                buttonEditare.Visible = false;
            }
        }

    }
}
