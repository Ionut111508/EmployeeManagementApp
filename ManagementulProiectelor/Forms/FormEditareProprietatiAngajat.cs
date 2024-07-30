using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementulProiectelor.Java;

namespace ManagementulProiectelor.Forms
{
    public partial class FormEditareProprietatiAngajat : Form
    {
        private Angajat angajat;
        private string numeOriginal;
        private string prenumeOriginal;
        private string emailOriginal;
        private string numarTelefonOriginal;
        private float normaOriginal;
        static List<Norma> listaNorme = DBHelper.ExtrageNormeWithDapper();

        public FormEditareProprietatiAngajat(Angajat angajat)
        {
            InitializeComponent();
            this.angajat = angajat;
            this.numeOriginal = angajat.numeAngajat;
            this.prenumeOriginal = angajat.prenumeAngajat;
            this.emailOriginal = angajat.emailAngajat;
            this.numarTelefonOriginal = angajat.numarTelefonAngajat;
            this.normaOriginal = (float)listaNorme.FirstOrDefault(n => n.Id_Norma == angajat.Id_Norma).normaOre;
            PopulareTextBoxuri();
            ValidariInitiale();
        }
        private void buttonSalvare_Click(object sender, EventArgs e)
        {
            if (AreModificari())
            {
                DialogResult result = MessageBox.Show("Ești sigur că vrei să salvezi modificările?", "Confirmare Salvare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    float normaSelectata = (float)comboBoxNorma.SelectedItem;
                    if (normaSelectata != normaOriginal)
                    {
                        List<Participa> listaParticipari = DBHelper.ExtrageParticipariWithDapper();
                        int numarParticipari = listaParticipari.Count(p => p.Id_Angajat == angajat.Id_Angajat);

                        if (numarParticipari != 0)
                        {
                            MessageBox.Show("Angajatul nu trebuie sa mai participe la niciun task");
                            return;
                        }            
                        if(numarParticipari==0)
                        {
                            angajat.numeAngajat = textBoxNume.Text;
                            angajat.prenumeAngajat = textBoxPrenume.Text;
                            angajat.emailAngajat = textBoxEmail.Text;
                            angajat.numarTelefonAngajat = textBoxNumarTelefon.Text;
                            angajat.Id_Norma = listaNorme.FirstOrDefault(n => n.normaOre == (float)comboBoxNorma.SelectedItem).Id_Norma;

                            Cont cont = DBHelper.ReturnareContAngajat(angajat.Id_Angajat);
                            cont.UserCont = textBoxUsername.Text;
                            cont.ParolaCont = textBoxParola.Text;

                            DBHelper.ActualizeazaAngajat(angajat);
                            DBHelper.ActualizeazaCont(cont);

                            MessageBox.Show("Modificările au fost salvate cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        angajat.numeAngajat = textBoxNume.Text;
                        angajat.prenumeAngajat = textBoxPrenume.Text;
                        angajat.emailAngajat = textBoxEmail.Text;
                        angajat.numarTelefonAngajat = textBoxNumarTelefon.Text;
                        angajat.Id_Norma = listaNorme.FirstOrDefault(n => n.normaOre == (float)comboBoxNorma.SelectedItem).Id_Norma;

                        Cont cont = DBHelper.ReturnareContAngajat(angajat.Id_Angajat);
                        cont.UserCont = textBoxUsername.Text;
                        cont.ParolaCont = textBoxParola.Text;

                        DBHelper.ActualizeazaAngajat(angajat);
                        DBHelper.ActualizeazaCont(cont);

                        MessageBox.Show("Modificările au fost salvate cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }                 
                }
            }
            else
            {
                MessageBox.Show("Nu s-au detectat modificări", "Salvare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void buttonAnulare_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void PopulareTextBoxuri()
        {
            textBoxNume.Text = angajat.numeAngajat;
            textBoxPrenume.Text = angajat.prenumeAngajat;
            textBoxEmail.Text = angajat.emailAngajat;
            textBoxNumarTelefon.Text = angajat.numarTelefonAngajat;

            comboBoxNorma.DataSource = null;
            var listaNormeOre = listaNorme.Select(n => n.normaOre).ToList();
            comboBoxNorma.DataSource = listaNormeOre;
            comboBoxNorma.DisplayMember = "normaOre";

            Norma normaAngajat = listaNorme.FirstOrDefault(n => n.Id_Norma == angajat.Id_Norma);
            if (normaAngajat != null)
            {
                comboBoxNorma.SelectedItem = normaAngajat.normaOre;
            }

            var detaliiCont = DBHelper.ReturnareContAngajat(angajat.Id_Angajat);
            comboBoxNorma.Enabled = false;
            textBoxUsername.Text = detaliiCont.UserCont;
            textBoxParola.Text = detaliiCont.ParolaCont;
        }

        private void ValidariInitiale()
        {

        }
        private bool AreModificari()
        {

            return textBoxNume.Text != numeOriginal ||
                   textBoxPrenume.Text != prenumeOriginal ||
                   textBoxEmail.Text != emailOriginal ||
                   textBoxNumarTelefon.Text != numarTelefonOriginal ||
                   textBoxUsername.Text != DBHelper.ReturnareContAngajat(angajat.Id_Angajat).UserCont ||
                   textBoxParola.Text != DBHelper.ReturnareContAngajat(angajat.Id_Angajat).ParolaCont ||
                   (float)comboBoxNorma.SelectedItem != normaOriginal;
        }

        private void buttonEditare_Click(object sender, EventArgs e)
        {
            comboBoxNorma.Enabled = !comboBoxNorma.Enabled;
        }

        private void comboBoxNorma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
