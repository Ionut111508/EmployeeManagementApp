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
    public partial class FormApartineAngajatDepartament : Form
    {
        static List<Angajat> listaAngajati = DBHelper.ExtrageAngajatiWithDapper();
        static List<Departament> listaDepartamente = DBHelper.ExtrageDepartamenteWithDapper();
        static List<ApartineAngajatDepartament> listaAngajatiDepartamente = DBHelper.ExtrageAngajatiDepartamenteWithDapper();
        public FormApartineAngajatDepartament()
        {
            InitializeComponent();
            PopulareListBoxuri();
        }
        private void PopulareListBoxuri()
        {
            listBoxAngajati.DataSource = null;
            listBoxAngajati.DataSource = listaAngajati;
            listBoxAngajati.DisplayMember = "AngajatFullName";

            Angajat angajatSelectat = (Angajat)listBoxAngajati.SelectedItem;

            if (angajatSelectat != null)
            {
                List<ApartineAngajatDepartament> departamenteAleAngajatului = DBHelper.ExtrageAngajatiDepartamenteByIdAngajat(angajatSelectat.Id_Angajat);

                List<Departament> departamenteToate = DBHelper.ExtrageDepartamenteWithDapper();

                foreach (var departament in departamenteToate.ToList())
                {
                    if (departamenteAleAngajatului.Any(ad => ad.Id_Departament == departament.Id_Departament))
                    {
                        departamenteToate.Remove(departament);
                    }
                }

                listBoxDepartamente.DataSource = null;
                listBoxDepartamente.DataSource = departamenteToate;
                listBoxDepartamente.DisplayMember = "denumireDepartament";
            }
            else
            {
                listBoxDepartamente.DataSource = null;
            }
        }

        private void buttonAlocareDepartament_Click(object sender, EventArgs e)
        {
            int curentIndexAngajat = listBoxAngajati.SelectedIndex;
            Angajat angajatSelectat = listaAngajati[curentIndexAngajat];

            List<ApartineAngajatDepartament> departamenteAleAngajatului = DBHelper.ExtrageAngajatiDepartamenteByIdAngajat(angajatSelectat.Id_Angajat);

            int curentIndexDepartament = listBoxDepartamente.SelectedIndex;
            Departament departamentSelectat = listaDepartamente[curentIndexDepartament];
            if (departamenteAleAngajatului.Any(dep => dep.Id_Departament == departamentSelectat.Id_Departament))
            {
                MessageBox.Show("Angajatul este deja alocat în acest departament.");
            }
            else
            {
                DateTime dataCurenta = DateTime.Now;
                DateTime dataIesire = dataCurenta.AddYears(5);

                ApartineAngajatDepartament angajatDepartament = new ApartineAngajatDepartament()
                {
                    Id_Angajat = angajatSelectat.Id_Angajat,
                    Id_Departament = departamentSelectat.Id_Departament,
                    DataIntrare = dataCurenta,
                    DataIesire = dataIesire
                };

                DBHelper.AddAngajatDepartament(angajatDepartament);
                listaAngajatiDepartamente.Add(angajatDepartament);
                PopulareListBoxAngajatDepartament();
                MessageBox.Show("S-a asociat angajatul " + angajatSelectat.numeAngajat + " " + angajatSelectat.prenumeAngajat +
                    "\n cu departamentul " + departamentSelectat.denumireDepartament);

                PopulareListBoxuri();
            }
        }

        private void listBoxAngajati_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulareListBoxAngajatDepartament();
            PopulareListBoxuri();
        }
        private void PopulareListBoxAngajatDepartament()
        {
            if (listBoxAngajati.SelectedIndex != -1)
            {
                Angajat angajatSelectat = (Angajat)listBoxAngajati.SelectedItem;
                List<ApartineAngajatDepartament> lista = DBHelper.ExtrageAngajatiDepartamenteByIdAngajat(angajatSelectat.Id_Angajat);
                if (lista.Count != 0)
                {
                    listBoxApartine.DataSource = null;
                    listBoxApartine.DataSource = lista;
                    listBoxApartine.DisplayMember = "Detalii";
                }
                else
                {
                    listBoxApartine.DataSource = null;
                }
            }
        }



        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AfisareComponente();
        }
        public void AfisareComponente()
        {
            bool visible = listBoxDepartamente.Visible;

            listBoxDepartamente.Visible = !visible;
            buttonAlocareDepartament.Visible = !visible;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxAngajati.SelectedIndex != -1 && listBoxApartine.SelectedIndex != -1)
            {
                Angajat angajatSelectat = (Angajat)listBoxAngajati.SelectedItem;
                ApartineAngajatDepartament apartineAngajatDepartament = (ApartineAngajatDepartament)listBoxApartine.SelectedItem;

                DialogResult result = MessageBox.Show("Sunteți sigur că doriți să eliminați asocierea angajatului din departament?", "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DateTime dataIesire = DateTime.Now;
                    DBHelper.EliminaAngajatDepartament(angajatSelectat.Id_Angajat, apartineAngajatDepartament.Id_Departament, dataIesire);

                    listaAngajatiDepartamente.RemoveAll(ad => ad.Id_Angajat == angajatSelectat.Id_Angajat && ad.Id_Departament == apartineAngajatDepartament.Id_Departament);
                    PopulareListBoxAngajatDepartament();
                    PopulareListBoxuri();

                    MessageBox.Show("Asocierea angajatului din departament a fost eliminată cu succes.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Eliminarea asocierea angajatului din departament a fost anulată.", "Anulat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Selectați un angajat și un departament pentru a elimina asocierea.", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



    }
}
