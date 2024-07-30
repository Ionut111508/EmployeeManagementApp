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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void buttonCreeazaNorma_Click(object sender, EventArgs e)
        {
            FormCreeareNorma formCreeareNorma = new FormCreeareNorma();
            formCreeareNorma.Show();
            this.Hide();
        }

        private void buttonCreeazaDepartament_Click_1(object sender, EventArgs e)
        {
            FormCreeazaDepartament formCreeazaDepartament = new FormCreeazaDepartament();
            formCreeazaDepartament.Show();
            this.Hide();
        }

        private void buttonCreeazaSkill_Click_1(object sender, EventArgs e)
        {
            FormCreeareSkill formCreeareSkill = new FormCreeareSkill();
            formCreeareSkill.Show();
            this.Hide();
        }

        private void buttonCreeareCont_Click_1(object sender, EventArgs e)
        {
            FormCreeareCont formCreeareCont = new FormCreeareCont();
            formCreeareCont.Show();
            this.Hide();
        }
    }
}
