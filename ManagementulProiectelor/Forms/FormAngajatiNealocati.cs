using ManagementulProiectelor.Java;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ManagementulProiectelor.Forms
{
    public partial class FormAngajatiNealocati : Form
    {
        private List<AngajatAlocat> angajatiNealocati;

        public FormAngajatiNealocati(List<AngajatAlocat> angajatiNealocati)
        {
            InitializeComponent();
            this.angajatiNealocati = angajatiNealocati;
            labelDataCurenta.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            SetareDatagridView();
            PopulareDataGridview();
        }


        private void SetareDatagridView()
        {
            dataGridViewAngajati.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            panelDataGridView.BackColor = Color.Empty;

            foreach (DataGridViewColumn column in dataGridViewAngajati.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Font = new Font("Times New Roman", 28);
                column.HeaderCell.Style.Font = new Font("Times New Roman", 32, FontStyle.Bold);
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.Width = 350;
            }
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

        private void PopulareDataGridview()
        {
            var dataSource = angajatiNealocati.Select(a => new
            {
                Nume = a.angajat.numeAngajat,
                Prenume = a.angajat.prenumeAngajat,
                OreRamaseDeLucrat = a.nrOreRamasDeLucrat
            }).ToList();

            dataGridViewAngajati.DataSource = dataSource;
        }
    }
}
