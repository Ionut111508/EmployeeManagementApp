using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ManagementulProiectelor.Java;
using ManagementulProiectelor;
using System.Linq;

namespace ManagementulProiectelor.Forms
{
    public partial class FormDetineAngajatSkill : Form
    {
        static List<Angajat> listaAngajati = DBHelper.ExtrageAngajatiWithDapper();
        static List<Skill> listaSkilluri = DBHelper.ExtrageSkilluriWithDapper();
        static List<DetineAngajatSkill> listaSkilluriAngajati = DBHelper.ExtrageSkilluriAngajatiWithDapper();
        static List<SkilluriAngajat> listaSkilluriAngajatiFiltrata = new List<SkilluriAngajat>();

        public FormDetineAngajatSkill()
        {
            InitializeComponent();
            PopulareListBoxuri();
        }
        private void PopulareListBoxuri()
        {
            listBoxAngajati.DataSource = null;
            listBoxAngajati.DataSource = listaAngajati;
            listBoxAngajati.DisplayMember = "AngajatFullName";
        }
        private void buttonAdaugaSkill_Click(object sender, EventArgs e)
        {
            bool doresteAlocareSkill = MessageBox.Show("Dorești să aloci un nou skill?", "Titlu", MessageBoxButtons.YesNo) == DialogResult.Yes;

            if (doresteAlocareSkill == false)
            {
                MessageBox.Show("Nu se aloca skill-ul ");
            }
            else
            {
                int index = listBoxAngajati.SelectedIndex;
                Angajat angajatSelectat = listaAngajati[index];

                String denumireSkillSelectata = comboBoxDenumireSkilluri.SelectedItem.ToString();
                String nivelSkillSelectat = comboBoxNivelSkilluri.SelectedItem.ToString();

                DateTime dataCurenta = DateTime.Now;

                String idSkill = generareIdSkillNou(nivelSkillSelectat, denumireSkillSelectata);
                if (DBHelper.VerificareExistentaAngajatSkill(angajatSelectat.Id_Angajat, denumireSkillSelectata, nivelSkillSelectat) == true)
                {
                    MessageBox.Show("Exista deja asocierea");
                }
                else
                {
                    DetineAngajatSkill angajatSkill = new DetineAngajatSkill()
                    {
                        Id_Angajat = angajatSelectat.Id_Angajat,
                        Id_Skill = idSkill,
                        dataObtinere = dataCurenta
                    };
                    DBHelper.AlocareSkillAngajat(angajatSkill);
                    SkilluriAngajat angajatSkillNou = new SkilluriAngajat()
                    {
                        denumireSkill = denumireSkillSelectata,
                        nivelSkill = nivelSkillSelectat 
                    };
                    listaSkilluriAngajatiFiltrata.Add(angajatSkillNou);
                    MessageBox.Show("S-a asociat angajatul " + angajatSelectat.numeAngajat + " " + angajatSelectat.prenumeAngajat +
                        "\n cu skillul " + idSkill);
                    PopuleazaComboBoxuriPentruAngajat(angajatSelectat.Id_Angajat);
                    PopulareListboxSkilluri();
                }
            }
        }
        private String generareIdSkillNou(String nivel, String denumire)
        {
            String idFinal = denumire + "-" + nivel;
            //MessageBox.Show("Valoarea maximă a ID-ului nou : " + idFinal);
            return idFinal;

        }

        private void listBoxAfisareSkilluri_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void PopulareListboxSkilluri()
        {
            listBoxAfisareSkilluri.DataSource = null;
            listBoxAfisareSkilluri.DataSource = listaSkilluriAngajatiFiltrata;
            listBoxAfisareSkilluri.DisplayMember = "DetaliiSkill";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AfisareComponente();
        }
        private void listBoxAngajati_SelectedIndexChanged(object sender, EventArgs e)
        {
            Angajat angajatSelectat = (Angajat)listBoxAngajati.SelectedItem;
            listaSkilluriAngajatiFiltrata = DBHelper.ReturneazaSkilluriAngajat(angajatSelectat.Id_Angajat);          //ok 
            PopulareListboxSkilluri();
            PopuleazaComboBoxuriPentruAngajat(angajatSelectat.Id_Angajat);

        }
        private void PopuleazaComboBoxuriPentruAngajat(string idAngajat)
        {
            List<SkilluriAngajat> skilluriAngajat = DBHelper.ReturneazaSkilluriAngajat(idAngajat);

            List<Skill> skilluriDisponibile = listaSkilluri;

            if (skilluriAngajat.Count == 0)
            {
                comboBoxDenumireSkilluri.DataSource = skilluriDisponibile
                                                      .Select(s => s.denumireSkill)
                                                      .Distinct()
                                                      .ToList();

                comboBoxNivelSkilluri.DataSource = skilluriDisponibile
                                                   .Select(s => s.nivelSkill)
                                                   .Distinct()
                                                   .ToList();
            }
            else
            {
                List<Skill> skilluriFiltrate = new List<Skill>();

                foreach (var skill in skilluriDisponibile)
                {
                    var skillAngajat = skilluriAngajat.FirstOrDefault(sa => sa.denumireSkill == skill.denumireSkill);
                    if (skillAngajat == null)
                    {
                        skilluriFiltrate.Add(skill);
                    }
                    else
                    {
                        if (ComparaNiveluri(skill.nivelSkill, skillAngajat.nivelSkill) > 0)
                        {
                            skilluriFiltrate.Add(skill);
                        }
                    }
                }

                comboBoxDenumireSkilluri.DataSource = skilluriFiltrate
                                                      .Select(s => s.denumireSkill)
                                                      .Distinct()
                                                      .ToList();

                string selectedSkill = comboBoxDenumireSkilluri.SelectedItem.ToString();
                var niveluriDisponibile = skilluriFiltrate
                                          .Where(s => s.denumireSkill == selectedSkill)
                                          .Select(s => s.nivelSkill)
                                          .Distinct()
                                          .ToList();

                comboBoxNivelSkilluri.DataSource = niveluriDisponibile;

                comboBoxDenumireSkilluri.SelectedIndexChanged += (sender, e) =>
                {
                    string selectedSkill = comboBoxDenumireSkilluri.SelectedItem.ToString();
                    var niveluriDisponibile = skilluriFiltrate
                                              .Where(s => s.denumireSkill == selectedSkill)
                                              .Select(s => s.nivelSkill)
                                              .Distinct()
                                              .ToList();

                    comboBoxNivelSkilluri.DataSource = niveluriDisponibile;
                };
                if (comboBoxDenumireSkilluri.Items.Count > 0)
                {
                    comboBoxDenumireSkilluri.SelectedIndex = 0;
                }
            }
        }

        private int ComparaNiveluri(string nivel1, string nivel2)
        {
            var nivele = new List<string> { "junior", "mediu", "senior" };

            int indexNivel1 = nivele.IndexOf(nivel1.ToLower());
            int indexNivel2 = nivele.IndexOf(nivel2.ToLower());

            return indexNivel1.CompareTo(indexNivel2);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxAfisareSkilluri.Items.Count != 0)
            {
                DialogResult result = MessageBox.Show("Ești sigur că vrei să ștergi acest element?", "Confirmare ștergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SkilluriAngajat skillSelectat = (SkilluriAngajat)listBoxAfisareSkilluri.SelectedItem;
                    Angajat angajatSelectat = (Angajat)listBoxAngajati.SelectedItem;
                    DBHelper.StergeSkillAngajat(angajatSelectat.Id_Angajat, skillSelectat.denumireSkill, skillSelectat.nivelSkill);
                    listaSkilluriAngajatiFiltrata.Remove(skillSelectat);
                    PopuleazaComboBoxuriPentruAngajat(angajatSelectat.Id_Angajat);
                    PopulareListboxSkilluri();

                    if (labelDenumireSkill.Visible == true)
                    {
                        AfisareComponente();
                    }
                }
                else
                {
                    MessageBox.Show("Ștergerea a fost anulată.", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Angajatul nu are niciun skill alocat");
            }
        }


        public void AfisareComponente()
        {
            bool visible = labelDenumireSkill.Visible;

            labelDenumireSkill.Visible = !visible;
            comboBoxDenumireSkilluri.Visible = !visible;
            labelNivelSkilluri.Visible = !visible;
            comboBoxNivelSkilluri.Visible = !visible;
            buttonAdaugaSkill.Visible = !visible;
        }

        private void FormDetineAngajatSkill_Load(object sender, EventArgs e)
        {
            if (listaAngajati.Count > 0)
            {
                Angajat primulAngajat = listaAngajati[0];
                PopuleazaComboBoxuriPentruAngajat(primulAngajat.Id_Angajat);
            }
        }
    }
}
