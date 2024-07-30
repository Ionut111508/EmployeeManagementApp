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
    public partial class FormCreeareNorma : Form
    {
        static List<Norma> listaNorme = DBHelper.ExtrageNormeWithDapper();
        public FormCreeareNorma()
        {
            InitializeComponent();
        }

        private void buttonAdaugareNorma_Click(object sender, EventArgs e)
        {
            String denumire = textBoxDenumire.Text;
            float nrOre = Convert.ToSingle(numericUpDownNumarOre.Value);
            if (textBoxDenumire.Text != null )
            {
                String id_nou = generareIdNormaNoua();
                Norma norma = new Norma()
                {
                    Id_Norma = id_nou,
                    denumireNorma = denumire,
                    normaOre = nrOre
                };
                DBHelper.AddNorma(norma);
                MessageBox.Show("Norma a fost inserata cu id-ul" + norma.Id_Norma);
                listaNorme.Add(norma);
                textBoxDenumire.Clear();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
                FormHome formHome = new FormHome();
                formHome.Show();
                this.Hide();
        }
        private String generareIdNormaNoua()
        {
            String idFinal;
            if (listaNorme.Count == 0)
            {
                idFinal = "N1";
            }
            else
            {
                String idMax = listaNorme.Max(obj => obj.Id_Norma);

                MessageBox.Show("Valoarea maximă a ID-ului deja existent : " + idMax);

                int numericPart = Convert.ToInt32(idMax.ToString().Substring(1));
                idFinal = "N" + (numericPart + 1);
            }
            return idFinal;
        }
    }
}