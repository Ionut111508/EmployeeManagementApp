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
    public partial class FormCreeareCont : Form
    {
        static List<Cont> listaConturi = DBHelper.ExtrageConturiWithDapper();
        public FormCreeareCont()
        {
            InitializeComponent();
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
        private void buttonCreeazaCont_Click(object sender, EventArgs e)
        {

                    if (textBoxUsername.Text != null && textBoxParola.Text != null)
                    {
                        int id_nou = generareIdContNou();
                        if (verificareUser(textBoxUsername) == false)
                        {
                            //
                        }
                        Cont cont = new Cont()
                        {
                            Id_Cont = "sd",
                            UserCont = textBoxUsername.Text,
                            ParolaCont = textBoxParola.Text
                        };
                        DBHelper.AddCont(cont);
                        MessageBox.Show("Contul a fost inserat cu id-ul" + cont.Id_Cont);
                        listaConturi.Add(cont);
                        textBoxParola.Clear();
                        textBoxUsername.Clear();
                    }
                
                //DialogResult dg = MessageBox.Show(ex.Message, "Completati ambele campuri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //DialogResult dg = MessageBox.Show(ex.Message, "Eroare la crearea numelui de utilizator", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private int generareIdContNou ()
        {
            int idFinal ;
            if (listaConturi.Count == 0)
            {
                idFinal = 1;              
            }
            else
            {
                idFinal = Convert.ToInt32(listaConturi.Max(obj => obj.Id_Cont)) + 1;
                //int valoareMaxima = sirCifre.Max(cifra => int.Parse(cifra));
            }
            return idFinal;
        }
        private bool verificareUser(TextBox tb)
        {
            List<Cont> listaUserName = listaConturi.Where(obj => obj.UserCont == tb.Text).ToList();
            if(listaUserName.Count==0)
            {
                return true;
            }
            return false;
        }
    }
}
