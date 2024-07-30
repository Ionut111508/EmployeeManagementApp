using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ManagementulProiectelor.Java;

namespace ManagementulProiectelor.Forms
{
    public partial class FormCalendar : Form
    {
        private string idAngajat = Sesiune.ID_ANGAJAT;

        public FormCalendar()
        {
            InitializeComponent();
            InitializeCalendar();
        }

        private void InitializeCalendar()
        {
            MonthCalendar calendar = new MonthCalendar();
            calendar.Dock = DockStyle.Fill;
            calendar.DateSelected += Calendar_DateSelected;

            this.Controls.Add(calendar);
        }

        private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = e.Start;

            List<Participa> participariZi = DBHelper.ExtrageParticipariAngajatZi(idAngajat, selectedDate);

            if (participariZi.Any())
            {
                string text = $"În data de: {selectedDate.ToShortDateString()}\n\n" +
                              "Ai de lucrat:\n\n";

                foreach (var participare in participariZi)
                {
                    text += $"{participare.nrOre} ore pe {DBHelper.ExtrageDenumireTask(participare.Id_Task)}\n";
                }

                MessageBox.Show(text, "Informații", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"În data de {selectedDate.ToShortDateString()} nu esti alocat pe niciun task.", "Informații", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
