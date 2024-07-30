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

namespace ManagementulProiectelor.Forms
{
    public partial class FormVizualizareProiecte : Form
    {
        static List<Proiect> listaProiecte = DBHelper.ExtrageProiecteWithDapper();
        static List<DetaliiProiecte> listaDetaliiProiecte = new List<DetaliiProiecte>();
        private DetaliiProiecte proiectSelectat; // Member variable to store the selected project


        public FormVizualizareProiecte()
        {
            InitializeComponent();
            PopulareDataGridView();
            AfisareComponenteSpeciale();

        }
        private void InitializareDataGridView()
        {
            dataGridViewAfisareProiecte.DataSource = listaProiecte;
            dataGridViewAfisareProiecte.AutoGenerateColumns = true;
            foreach (DataGridViewColumn column in dataGridViewAfisareProiecte.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        private void PopulareDataGridView()
        {
            listaDetaliiProiecte.Clear();
            foreach (Proiect proiect in listaProiecte)
            {
                if (!listaDetaliiProiecte.Any(p => p.denumireProiect == proiect.denumireProiect))
                {
                    var detaliiProiect = DBHelper.ExtrageDetaliiProiect(proiect.Id_Proiect); // data incepere + data finalizare
                    StatusProiect activeStatus = StatusProiect.Neînceput;

                    if (detaliiProiect.dataFinalizareProiect >= DateTime.Now && detaliiProiect.dataIncepereProiect <= DateTime.Now)
                    {
                        activeStatus = StatusProiect.Activ;
                    }
                    else if (detaliiProiect.dataIncepereProiect > DateTime.Now && detaliiProiect.dataFinalizareProiect > DateTime.Now)
                    {
                        activeStatus = StatusProiect.Neînceput;
                    }
                    else if (detaliiProiect.dataFinalizareProiect < DateTime.Now && detaliiProiect.dataIncepereProiect < DateTime.Now)
                    {
                        activeStatus = StatusProiect.Finalizat;
                    }

                    DetaliiProiecte proiectNou = new DetaliiProiecte
                    {
                        denumireProiect = proiect.denumireProiect,
                        dataIncepere = detaliiProiect.dataIncepereProiect,
                        datFinalizare = detaliiProiect.dataFinalizareProiect,
                        activeStatus = activeStatus
                    };
                    listaDetaliiProiecte = listaDetaliiProiecte
                    .OrderBy(p => p.activeStatus)
                    .ThenBy(p => p.denumireProiect)
                    .ToList();
                    listaDetaliiProiecte.Add(proiectNou);
                }
            }
            dataGridViewAfisareProiecte.DataSource = null;
            dataGridViewAfisareProiecte.DataSource = listaDetaliiProiecte;
            configurareColoaneDataGridView();
            dataGridViewAfisareProiecte.Dock = DockStyle.Fill;
            dataGridViewAfisareProiecte.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            dataGridViewAfisareProiecte.DefaultCellStyle.Padding = new Padding(8);
            dataGridViewAfisareProiecte.RowTemplate.Height = 22;
            dataGridViewAfisareProiecte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAfisareProiecte.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewAfisareProiecte.RowHeadersVisible = false;
            dataGridViewAfisareProiecte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dataGridViewAfisareProiecte.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewAfisareProiecte.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewAfisareProiecte.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dataGridViewAfisareProiecte.Refresh();
        }
        private void configurareColoaneDataGridView()
        {

            dataGridViewAfisareProiecte.Columns["denumireProiect"].HeaderText = "Denumire";
            dataGridViewAfisareProiecte.Columns["dataIncepere"].HeaderText = "Data Incepere";
            dataGridViewAfisareProiecte.Columns["datFinalizare"].HeaderText = "Data finalizare";
            dataGridViewAfisareProiecte.Columns["activeStatus"].HeaderText = "Status";
            dataGridViewAfisareProiecte.Columns["AfisareDetalii"].Visible = false;

            foreach (DataGridViewColumn column in dataGridViewAfisareProiecte.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            foreach (DataGridViewColumn column in dataGridViewAfisareProiecte.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Font = new Font("Times New Roman", 16);
                column.HeaderCell.Style.Font = new Font("Times New Roman", 18, FontStyle.Bold);
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.Width = 374;
            }
            dataGridViewAfisareProiecte.AllowUserToAddRows = false;
        }

        private void ActualizeazaProiecte()
        {
            listaProiecte.Clear();
            listaProiecte = DBHelper.ExtrageProiecteWithDapper();
            PopulareDataGridView();
        }

        private void buttonEditare_Click(object sender, EventArgs e)
        {
            if (proiectSelectat == null)
            {
                MessageBox.Show("Vă rugăm să selectați un proiect pentru editare.");
                return;
            }

            MessageBox.Show($"Ați selectat proiectul: {proiectSelectat.denumireProiect}");

            Proiect proiect = listaProiecte.FirstOrDefault(p => p.denumireProiect == proiectSelectat.denumireProiect);
            if (proiect == null)
            {
                MessageBox.Show("Proiectul selectat nu a fost găsit.");
                return;
            }

            FormEditareInformatiiProiect editareInformatiiProiect = new FormEditareInformatiiProiect(proiect);
            editareInformatiiProiect.ShowDialog();
            ActualizeazaProiecte();
        }
        private void dataGridViewAfisareProiecte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                proiectSelectat = (DetaliiProiecte)dataGridViewAfisareProiecte.Rows[e.RowIndex].DataBoundItem;
            }
        }
        public void AfisareComponenteSpeciale()
        {
            if (Sesiune.IsAdmin == false & Sesiune.IsManager == false)
            {
                buttonEditare.Visible = false;
            }
        }
    }
}
