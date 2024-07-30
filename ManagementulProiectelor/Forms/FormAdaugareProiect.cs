using ManagementulProiectelor.Java;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManagementulProiectelor.Forms
{
    public partial class FormAdaugareProiect : Form
    {
        static List<Proiect> listaProiecte = DBHelper.ExtrageProiecteWithDapper();
        static List<Perioada> listaPerioade = DBHelper.ExtragePerioadeWithDapper();
        static List<PerioadaProiect> listaPerioadeProiect = DBHelper.ExtragePerioadeProiectWithDapper();
        static List<DetaliiProiecte> listaDetaliiProiecte = new List<DetaliiProiecte>();


        public FormAdaugareProiect()
        {
            InitializeComponent();
            InitializareDateTimePickers();
            PopulareDataGridView();
            //MessageBox.Show("Angajatul curent are id-ul " + Sesiune.ID_ANGAJAT);
        }

        private void buttonAdaugaProiect_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBoxDenumireProiect.Text))
            {
                MessageBox.Show("Nu se poate introduce un proiect fara denumire");
            }
            else if(dateTimePickerDataIncepereProiect.Value <DateTime.Today)
            {
                MessageBox.Show("Proiectul trebuie sa inceapa in viitor");
            }
            else
            {
                String idProiect = generareIdProiectNou();
                String denumireProiect = textBoxDenumireProiect.Text;

                Proiect proiect = new Proiect()
                {
                    Id_Proiect = idProiect,
                    denumireProiect = denumireProiect
                };
                listaProiecte.Add(proiect);
                DBHelper.AddProiect(proiect);
                MessageBox.Show("Succes , s-a adaugat proiectul " + denumireProiect + " cu id-ul " + idProiect);

                String IdPerioadaInceput = generareIdPerioada();
                DateTime dataIncepere = dateTimePickerDataIncepereProiect.Value;
                String ziPerioadaIncepere = dataIncepere.Day.ToString();
                String lunaPerioadaIncepere = dataIncepere.Month.ToString();
                String anPerioadaIncepere = dataIncepere.Year.ToString();
                String tipPerioada = "Inceput";//inceput/sfarsit
                String idAngajat = Sesiune.ID_ANGAJAT;
                Perioada perioadaIncepere = new Perioada()
                {
                    Id_Perioada = IdPerioadaInceput,
                    an = anPerioadaIncepere,
                    luna = lunaPerioadaIncepere,
                    zi = ziPerioadaIncepere,
                    tipPerioada = tipPerioada,
                    Id_Angajat = idAngajat
                };
                listaPerioade.Add(perioadaIncepere);
                DBHelper.AddPerioada(perioadaIncepere);

                String IdPerioadaSfarsit = generareIdPerioada();
                DateTime dataFinalizare = dateTimePickerDataFinalizareProiect.Value;
                String ziPerioadaFinalizare = dataFinalizare.Day.ToString();
                String lunaPerioadaFinalizare = dataFinalizare.Month.ToString();
                String anPerioadaFinalizare = dataFinalizare.Year.ToString();
                tipPerioada = "Sfarsit";//inceput/sfarsit
                Perioada perioadaFinalizare = new Perioada()
                {
                    Id_Perioada = IdPerioadaSfarsit,
                    an = anPerioadaFinalizare,
                    luna = lunaPerioadaFinalizare,
                    zi = ziPerioadaFinalizare,
                    tipPerioada = tipPerioada,
                    Id_Angajat = idAngajat
                };
                listaPerioade.Add(perioadaFinalizare);
                DBHelper.AddPerioada(perioadaFinalizare);
                MessageBox.Show("Proiectul incepe la data de \n"
                    + ziPerioadaIncepere + "/" + lunaPerioadaIncepere + "/" + anPerioadaIncepere);
                MessageBox.Show("Proiectul se va finaliza  la data de \n"
                    + ziPerioadaFinalizare + "/" + lunaPerioadaFinalizare + "/" + anPerioadaFinalizare);


                PerioadaProiect perioadaProiectInceput = new PerioadaProiect()
                {
                    Id_Proiect = idProiect,
                    Id_Perioada = IdPerioadaInceput
                };
                MessageBox.Show("S-a adaugat o noua perioada de proiect cu id_Proiect=" + idProiect + " si cu id_perioada=" + IdPerioadaInceput + " de inceput");
                listaPerioadeProiect.Add(perioadaProiectInceput);
                DBHelper.AddPerioadaProiect(perioadaProiectInceput);

                PerioadaProiect perioadaProiectSfarsit = new PerioadaProiect()
                {
                    Id_Proiect = idProiect,
                    Id_Perioada = IdPerioadaSfarsit
                };
                MessageBox.Show("S-a adaugat o noua perioada de proiect cu id_Proiect=" + idProiect + " si cu id_perioada=" + IdPerioadaSfarsit + " de sfarsit");
                listaPerioadeProiect.Add(perioadaProiectSfarsit);
                DBHelper.AddPerioadaProiect(perioadaProiectSfarsit);

                DateTime dataManageriereInceput = DateTime.Now;
                DateTime dataManageriereSfarsit = dateTimePickerDataFinalizareProiect.Value;
                Manageriaza manageriaza = new Manageriaza()
                {
                    Id_Angajat = idAngajat,
                    Id_Proiect = idProiect,
                    dataInceput = dataManageriereInceput
                };
                DBHelper.AddManageriaza(manageriaza);
                MessageBox.Show("Angajatul cu id-ul " + idAngajat + " va fi managerului proeictului " + idProiect);
                textBoxDenumireProiect.Clear();
                listaProiecte.Add(proiect);
                PopulareDataGridView();
            }
        }
        private String generareIdProiectNou()
        {
            String idFinal;
            if (listaProiecte.Count == 0)
            {
                idFinal = "P1";
            }
            else
            {
                int maxNumericPart = listaProiecte
              .Where(obj => obj.Id_Proiect.StartsWith("P"))
              .Select(obj => int.TryParse(obj.Id_Proiect.Substring(1), out int numeric) ? numeric : 0)
              .Max();
                idFinal = "P" + (maxNumericPart + 1).ToString();
            }
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

        private void dateTimePickerDataIncepereProiect_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePickerDataFinalizareProiect.Value < dateTimePickerDataIncepereProiect.Value)
            {
                dateTimePickerDataFinalizareProiect.Value = dateTimePickerDataIncepereProiect.Value.AddDays(5);
            }
            dateTimePickerDataFinalizareProiect.MinDate = dateTimePickerDataIncepereProiect.Value;
        }
        private void InitializareDateTimePickers()
        {
            dateTimePickerDataIncepereProiect.MinDate = DateTime.Today;
            dateTimePickerDataIncepereProiect.Value = DateTime.Today;

            dateTimePickerDataFinalizareProiect.Value = dateTimePickerDataIncepereProiect.Value.AddDays(15);
            dateTimePickerDataFinalizareProiect.MinDate = dateTimePickerDataIncepereProiect.Value;
        }
        private void dateTimePickerDataFinalizareProiect_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePickerDataFinalizareProiect.Value < dateTimePickerDataIncepereProiect.Value)
            {
                dateTimePickerDataFinalizareProiect.Value = dateTimePickerDataIncepereProiect.Value.AddDays(15);
                dateTimePickerDataFinalizareProiect.MinDate = dateTimePickerDataIncepereProiect.Value;
            }    
                dateTimePickerDataIncepereProiect.MaxDate = dateTimePickerDataFinalizareProiect.Value;
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
            dataGridViewProiecte.DataSource = null;
            dataGridViewProiecte.DataSource = listaDetaliiProiecte;
            configurareColoaneDataGridView();
            dataGridViewProiecte.Dock = DockStyle.Fill;
            dataGridViewProiecte.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            dataGridViewProiecte.DefaultCellStyle.Padding = new Padding(8);
            dataGridViewProiecte.RowTemplate.Height = 22;
            dataGridViewProiecte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProiecte.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewProiecte.RowHeadersVisible = false;
            dataGridViewProiecte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dataGridViewProiecte.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewProiecte.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewProiecte.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dataGridViewProiecte.Refresh();
        }
        private void configurareColoaneDataGridView()
        {
            dataGridViewProiecte.Columns["denumireProiect"].HeaderText = "Denumire";
            dataGridViewProiecte.Columns["dataIncepere"].HeaderText = "Data Incepere";
            dataGridViewProiecte.Columns["datFinalizare"].HeaderText = "Data finalizare";
            dataGridViewProiecte.Columns["activeStatus"].HeaderText = "Status";
            dataGridViewProiecte.Columns["AfisareDetalii"].Visible = false;

            foreach (DataGridViewColumn column in dataGridViewProiecte.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            foreach (DataGridViewColumn column in dataGridViewProiecte.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Font = new Font("Times New Roman", 16);
                column.HeaderCell.Style.Font = new Font("Times New Roman", 18, FontStyle.Bold);
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.Width = 374;
            }
            dataGridViewProiecte.AllowUserToAddRows = false;    
        }
        private void adaugaSauConfigurareColoanaButoane(string numeColoana, string textButoane)
        {
            var existingButtonColumn = dataGridViewProiecte.Columns.Cast<DataGridViewColumn>().FirstOrDefault(
            column => column is DataGridViewButtonColumn && ((DataGridViewButtonColumn)column).Text == textButoane);

        if (existingButtonColumn == null)
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "";
            buttonColumn.Text = textButoane;
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridViewProiecte.Columns.Add(buttonColumn);
        }
        }
        private void dataGridViewProiecte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridViewProiecte.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex < dataGridViewProiecte.Rows.Count)
                {
                    DataGridViewButtonCell buttonCell = dataGridViewProiecte.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
                    string buttonText = buttonCell?.Value?.ToString();

                    if (buttonText == "Editare")
                    {
                        MessageBox.Show("Ai apasat pe editare " + e.RowIndex + " " + e.ColumnIndex);
                        /*string idProiectSelectat = dataGridViewProiecte.Rows[e.RowIndex].Cells[dataGridViewProiecte.Columns["idProiect"].Index].Value.ToString();

                        Proiect proiectSelectat = (Proiect)listaProiecte.FirstOrDefault(a => a.Id_Proiect == idProiectSelectat);*/

                        // Creează o fereastră modală sau un alt control pentru editare
                        /*using (Form formEditareAngajat = new FormEditareProprietatiAngajat(proiectSelectat))
                        {
                            // Deschide fereastra modală pentru editare
                            var result = formEditareAngajat.ShowDialog();

                            // Dacă utilizatorul a confirmat modificările, salvează-le în baza de date
                            if (result == DialogResult.OK)
                            {
                                /// trebuie sa fac o metoda care preia datele actualizate din baza de date 
                                PopulareDataGridView();
                            }
                        }*/
                    }
                    else if (buttonText == "Ștergere")
                    {
                        MessageBox.Show("Ai apasat pe stergere " + e.RowIndex + " " + e.ColumnIndex);
                    }
                }
            }
        }
    }
}
