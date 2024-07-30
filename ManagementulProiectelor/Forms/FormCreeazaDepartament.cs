using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManagementulProiectelor
{
    public partial class FormCreeazaDepartament : Form
    {
        static List<Departament> listaDepartamente = DBHelper.ExtrageDepartamenteWithDapper();
        public FormCreeazaDepartament()
        {
            InitializeComponent();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            FormHome formHome = new FormHome();
            formHome.Show();
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCreeazaDepartament_Click(object sender, EventArgs e)
        {
            if(textBoxDenumireDepartament.Text==null || String.IsNullOrEmpty(textBoxDenumireDepartament.Text))
            {
                MessageBox.Show("Completeaza denumirea departamentului");
            }
            else
            {
                String id_dep = generareIdDepartamentNou();
                String den_dep = textBoxDenumireDepartament.Text;
                Departament departament = new Departament()
                {
                    Id_Departament = id_dep,
                    denumireDepartament = den_dep
                };
                DBHelper.AddDepartament(departament);
                MessageBox.Show("Departamentul a fost inserat cu id-ul" + departament.Id_Departament);
                listaDepartamente.Add(departament);
                textBoxDenumireDepartament.Clear();
            }
            
        }

        private String generareIdDepartamentNou()
        {
            String idFinal;
            if (listaDepartamente.Count == 0)
            {
                idFinal = "D1";
            }
            else
            {
                String idMax = listaDepartamente.Max(obj => obj.Id_Departament);

                int numericPart = Convert.ToInt32(idMax.ToString().Substring(1));
                idFinal = "D" + (numericPart + 1);

            }
            return idFinal;
        }

        private void FormCreeazaDepartament_Load(object sender, EventArgs e)
        {

        }
    }
}
