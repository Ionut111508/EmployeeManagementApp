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
    public partial class FormAdministrareAngajati : Form
    {
        static List<Angajat> listaAngajati = DBHelper.ExtrageAngajatiWithDapper();
        static List<AfisareAdministrareAngajati> listaProprietatiAngajat;
        private BindingSource bindingSource = new BindingSource();
        private AfisareAdministrareAngajati informatiiAngajat;


        public FormAdministrareAngajati()
        {
            InitializeComponent();
            setareDataGridView();
            AfisareComponenteAdmin();
        }

        private void setareDataGridView()
        {
            dataGridViewAngajati.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            panelDataGridView.BackColor = Color.Empty;

            IncarcaDateAngajati(false);
            bindingSource.DataSource = listaProprietatiAngajat;
            dataGridViewAngajati.DataSource = bindingSource;

            configurareColoaneDataGridView();

            dataGridViewAngajati.Dock = DockStyle.Fill;
            dataGridViewAngajati.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

            dataGridViewAngajati.DefaultCellStyle.Padding = new Padding(8);
            dataGridViewAngajati.RowTemplate.Height = 39;

            dataGridViewAngajati.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAngajati.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewAngajati.RowHeadersVisible = false;
            dataGridViewAngajati.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dataGridViewAngajati.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            dataGridViewAngajati.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewAngajati.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dataGridViewAngajati.GridColor = Color.Black;

            dataGridViewAngajati.Refresh();
        }

        private void configurareColoaneDataGridView()
        {
            dataGridViewAngajati.Columns["idAngajat"].Visible = false;
            dataGridViewAngajati.Columns["fullName"].HeaderText = "Nume angajat";
            dataGridViewAngajati.Columns["email"].HeaderText = "Email";
            dataGridViewAngajati.Columns["numarProiecteAlocate"].HeaderText = "Proiecte";
            dataGridViewAngajati.Columns["progresProiecte"].Visible = false;
            dataGridViewAngajati.Columns["numarTaskuriAlocate"].HeaderText = "Taskuri";
            dataGridViewAngajati.Columns["progresTaskuri"].Visible = false;

            foreach (DataGridViewColumn column in dataGridViewAngajati.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Font = new Font("Times New Roman", 14);
                column.HeaderCell.Style.Font = new Font("Times New Roman", 16, FontStyle.Bold);
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.Width = 350;
            }
            dataGridViewAngajati.Columns["email"].Width = 420;
            dataGridViewAngajati.Columns["fullName"].Width = 420;
            dataGridViewAngajati.AllowUserToAddRows = false;
        }

        private void buttonCautare_Click(object sender, EventArgs e)
        {
            string searchValue = textBoxSearch.Text;

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                listaProprietatiAngajat = DBHelper.ReturnareAfisareAdministrareAngajati(true);
                bindingSource.DataSource = listaProprietatiAngajat;
            }
            else
            {
                listaProprietatiAngajat = DBHelper.ReturnareAfisareAdministrareAngajatiCuFiltru(searchValue);
                bindingSource.DataSource = listaProprietatiAngajat;
            }
            dataGridViewAngajati.Refresh();
            listBoxProiecte.Visible = false;
            listBoxTaskuri.Visible = false;
            buttonRemove.Visible = false;
        }

        private void FormAdministrareAngajati_Resize(object sender, EventArgs e)
        {
            dataGridViewAngajati.Size = new Size(panelDataGridView.Width - dataGridViewAngajati.Margin.Left - dataGridViewAngajati.Margin.Right, panelDataGridView.Height - dataGridViewAngajati.Margin.Top - dataGridViewAngajati.Margin.Bottom);
        }

        private void dataGridViewAngajati_VisibleChanged(object sender, EventArgs e)
        {
            if (dataGridViewAngajati.Visible)
            {
                dataGridViewAngajati.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void buttonSterge_Click(object sender, EventArgs e)
        {      
        }

        private void buttonAdaugare_Click(object sender, EventArgs e)
        {
            FormAdaugaAngajat formAdauga = new FormAdaugaAngajat();

            this.Enabled = false;
            formAdauga.ShowDialog();
            this.Enabled = true;

            // Reîncarcă datele după ce formularul de adăugare este închis
            IncarcaDateAngajati(false);
        }

        private bool IsAdmin(string userName, string parola)
        {
            if (userName == "admin" & parola == "admin")
            {
                Sesiune.IsAdmin = true;
                return true;
            }
            return false;
        }

        public void AfisareComponenteAdmin()
        {
            if (IsAdmin(Properties.Settings.Default.Username, Properties.Settings.Default.Parola))
            {
                buttonAdaugare.Visible = true;
            }
        }

        // Declaram o variabila globala pentru a retine ultimul index selectat
        private int ultimulIndexSelectat = -1;

        private void dataGridViewAngajati_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                informatiiAngajat = (AfisareAdministrareAngajati)dataGridViewAngajati.Rows[e.RowIndex].DataBoundItem;
                // Verificam daca s-a facut clic pe coloana "numarProiecteAlocate"
                if (dataGridViewAngajati.Columns[e.ColumnIndex].Name == "numarProiecteAlocate")
                {
                    // Daca s-a facut clic pe aceeasi celula a doua oara, ascundem listbox-ul
                    if (e.RowIndex == ultimulIndexSelectat)
                    {
                        listBoxProiecte.Visible = false;
                        labelProiecte.Visible = false;
                        ultimulIndexSelectat = -1; // Resetam variabila
                    }
                    else
                    {
                        // Daca s-a facut clic pe o celula diferita, afisam listbox-ul si setam noul index
                        var angajatSelectat = listaProprietatiAngajat[e.RowIndex];
                        var proiecteAngajat = DBHelper.ExtrageProiecteAngajat(angajatSelectat.idAngajat);
                        var proiecteDistincte = proiecteAngajat
                            .GroupBy(p => p.denumireProiect)
                            .Select(g => g.First())
                            .ToList();

                        listBoxProiecte.DataSource = null;
                        listBoxProiecte.DataSource = proiecteDistincte;
                        listBoxProiecte.DisplayMember = "denumireProiect";

                        listBoxProiecte.Visible = true;
                        labelProiecte.Visible = true;

                        // Actualizam ultimul index selectat
                        ultimulIndexSelectat = e.RowIndex;
                    }
                }

                // Verificam daca s-a facut clic pe coloana "numarTaskuriAlocate"
                if (dataGridViewAngajati.Columns[e.ColumnIndex].Name == "numarTaskuriAlocate")
                {
                    // Daca s-a facut clic pe aceeasi celula a doua oara, ascundem listbox-ul
                    if (e.RowIndex == ultimulIndexSelectat)
                    {
                        listBoxTaskuri.Visible = false;
                        buttonRemove.Visible = false;
                        labelTaskuri.Visible = false;
                        ultimulIndexSelectat = -1; // Resetam variabila
                    }
                    else
                    {
                        // Daca s-a facut clic pe o celula diferita, afisam listbox-ul si setam noul index
                        var angajatSelectat = listaProprietatiAngajat[e.RowIndex];
                        var taskuriAngajat = DBHelper.ReturneazaTaskuriAngajat(angajatSelectat.idAngajat);
                        var taskuriDistincte = taskuriAngajat
                            .GroupBy(p => p.denumireTask)
                            .Select(g => g.First())
                            .ToList();

                        listBoxTaskuri.DataSource = null;
                        listBoxTaskuri.DataSource = taskuriDistincte;
                        listBoxTaskuri.DisplayMember = "denumireTask";

                        listBoxTaskuri.Visible = true;
                        buttonRemove.Visible = true;
                        labelTaskuri.Visible = true;

                        ultimulIndexSelectat = e.RowIndex;
                    }
                }
            }
        }
        private void VerificareListBox(ListBox listBox)
        {
            listBox.Visible = !listBox.Visible;
            labelProiecte.Visible = false;
            labelTaskuri.Visible = false;
        }
        private void AfiseazaProiecteAngajat(int rowIndex)
        {
            var angajatSelectat = listaProprietatiAngajat[rowIndex];
            var proiecteAngajat = DBHelper.ExtrageProiecteAngajat(angajatSelectat.idAngajat);
            var proiecteDistincte = proiecteAngajat
                .GroupBy(p => p.denumireProiect)
                .Select(g => g.First())
                .ToList();

            listBoxProiecte.DataSource = null;
            listBoxProiecte.DataSource = proiecteDistincte;
            listBoxProiecte.DisplayMember = "denumireProiect";
        }
        private void AfiseazaTaskuriAngajat(int rowIndex)
        {
            var angajatSelectat = listaProprietatiAngajat[rowIndex];
            var taskuriAngajat = DBHelper.ReturneazaTaskuriAngajat(angajatSelectat.idAngajat);
            var taskuriDistincte = taskuriAngajat
                .GroupBy(p => p.denumireTask)
                .Select(g => g.First())
                .ToList();

            listBoxTaskuri.DataSource = null;
            listBoxTaskuri.DataSource = taskuriDistincte;
            listBoxTaskuri.DisplayMember = "denumireTask";
        }
        private void FormAdministrareAngajati_Activated(object sender, EventArgs e)
        {
            IncarcaDateAngajati(false);
        }
        private void IncarcaDateAngajati(bool activi)
        {
            listaProprietatiAngajat = DBHelper.ReturnareAfisareAdministrareAngajati(activi);
            bindingSource.DataSource = listaProprietatiAngajat;
            dataGridViewAngajati.Refresh();
        }
        private void checkBoxActivi_CheckedChanged(object sender, EventArgs e)
        {
            IncarcaDateAngajati(checkBoxActivi.Checked);
        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            Task taskSelectat = (Task)listBoxTaskuri.SelectedItem;

            if (dataGridViewAngajati.CurrentRow != null && taskSelectat != null)
            {
                AfisareAdministrareAngajati angajatSelectat = (AfisareAdministrareAngajati)dataGridViewAngajati.CurrentRow.DataBoundItem;

                if (angajatSelectat != null)
                {
                    // Întrebare pentru confirmare
                    DialogResult result = MessageBox.Show($"Ești sigur că vrei să elimini angajatul {angajatSelectat.fullName} de la taskul {taskSelectat.denumireTask}?", "Confirmare ștergere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Utilizatorul a apăsat Yes, efectuează operația de ștergere
                        DBHelper.EliminaAngajatDeLaTask(taskSelectat.Id_Task, angajatSelectat.idAngajat); // presupunând că idAngajat este tipul corect pentru ID-ul angajatului

                        MessageBox.Show($"Angajatul a fost eliminat de la taskul '{taskSelectat.denumireTask}'.");

                        // Actualizați `ListBoxTaskuri` eliminând taskul șters
                        var taskuriAngajat = DBHelper.ReturneazaTaskuriAngajat(angajatSelectat.idAngajat);
                        var taskuriDistincte = taskuriAngajat
                            .GroupBy(p => p.denumireTask)
                            .Select(g => g.First())
                            .ToList();

                        listBoxTaskuri.DataSource = null;
                        listBoxTaskuri.DataSource = taskuriDistincte;
                        listBoxTaskuri.DisplayMember = "denumireTask";

                        // Actualizați numărul de taskuri în DataGridView
                        angajatSelectat.numarTaskuriAlocate = taskuriDistincte.Count.ToString();
                        bindingSource.ResetBindings(false);
                    }
                }
                else
                {
                    MessageBox.Show("Nu s-a putut identifica angajatul selectat.");
                }
            }
            else
            {
                MessageBox.Show("Nu este selectat niciun rând în datagridview sau taskul nu este selectat.");
            }
        }
        private void FormAdministrareAngajati_Load(object sender, EventArgs e)
        {

        }

        private void buttonEditare_Click(object sender, EventArgs e)
        {
            if (informatiiAngajat == null)
            {
                MessageBox.Show("Vă rugăm să selectați un angajat pentru editare.");
                return;
            }
            Angajat angajat = listaAngajati.FirstOrDefault(a => a.Id_Angajat == informatiiAngajat.idAngajat);
            if (angajat == null)
            {
                MessageBox.Show("Angajatul selectat nu a fost găsit.");
                return;
            }
            MessageBox.Show($"Ați selectat angajatul: {angajat.AngajatFullName}");

            FormEditareProprietatiAngajat editareProprietatiAngajat = new FormEditareProprietatiAngajat(angajat);
            editareProprietatiAngajat.ShowDialog();
            IncarcaDateAngajati(false);
        }
    }
}
