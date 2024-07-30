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
    public partial class FormCreeareSkill : Form
    {
        static List<Skill> listaSkilluri = DBHelper.ExtrageSkilluriWithDapper();
        public FormCreeareSkill()
        {
            InitializeComponent();
            PopulareListBoxSkilluri();
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

        private void buttonAdaugareSkill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDenumireSkill.Text))
            {
                MessageBox.Show("Denumirea nu poate fi goala");
            }
            else if(VerificaTextBox(textBoxDenumireSkill)==false)
            {
                MessageBox.Show("Denumirea contine caractere invalide");
            }
            else
            {
                String denumire = textBoxDenumireSkill.Text;
                if (DBHelper.VerificaExistentaAsociere(denumire))
                {
                    MessageBox.Show("Exista deja acest skill");
                }
                else
                {
                    String id_skill = generareIdSkillNou(denumire, "Junior");
                    Skill skillJunior = new Skill()
                    {
                        Id_Skill = id_skill,
                        denumireSkill = denumire,
                        nivelSkill = "Junior"
                    };
                    DBHelper.AddSkill(skillJunior);
                    listaSkilluri.Add(skillJunior);

                    id_skill = generareIdSkillNou(denumire, "Mediu");
                    Skill skillMediu = new Skill()
                    {
                        Id_Skill = id_skill,
                        denumireSkill = denumire,
                        nivelSkill = "Mediu"
                    };
                    DBHelper.AddSkill(skillMediu);
                    listaSkilluri.Add(skillMediu);

                    id_skill = generareIdSkillNou(denumire, "Senior");
                    Skill skillSenior = new Skill()
                    {
                        Id_Skill = id_skill,
                        denumireSkill = denumire,
                        nivelSkill = "Senior"
                    };
                    DBHelper.AddSkill(skillSenior);
                    listaSkilluri.Add(skillSenior);
                    MessageBox.Show("Skill-ul " + skillJunior.denumireSkill + " a fost inserat cu succes");
                    textBoxDenumireSkill.Clear();
                    PopulareListBoxSkilluri();
                }
            }

        }

        private String generareIdSkillNou(String denumire, String nivel)
        {
            String idFinal = denumire + "-" + nivel;
            return idFinal;
        }
        private void PopulareListBoxSkilluri()
        {
            listBoxSkilluri.DataSource = null;
            listBoxSkilluri.DataSource = listaSkilluri.Select(skill => skill.denumireSkill).Distinct().ToList();
            listBoxSkilluri.DisplayMember = "DescriereSkill";
        }
        public static bool VerificaTextBox(TextBox textBox)
        {
            foreach (char c in textBox.Text)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false; 
                }
            }
            return true;
        }
    }
}
