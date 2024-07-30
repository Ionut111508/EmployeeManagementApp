using ManagementulProiectelor.Java;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = ManagementulProiectelor.Java.Task;

namespace ManagementulProiectelor.Forms
{
    public partial class FormEditareInformatiiProiect : Form
    {
        private Proiect proiect;
        private string denumireProiectOriginal;
        private DateTime dataIncepereOriginal;
        private DateTime dataFinalizareOriginal;
        public FormEditareInformatiiProiect()
        {
            InitializeComponent();
        }
        public FormEditareInformatiiProiect(Proiect proiect) : this()
        {
            this.proiect = proiect;
            this.denumireProiectOriginal = proiect.denumireProiect;
            var detaliiProiect = DBHelper.ExtrageDetaliiProiect(proiect.Id_Proiect);
            this.dataIncepereOriginal = detaliiProiect.dataIncepereProiect;
            this.dataFinalizareOriginal = detaliiProiect.dataFinalizareProiect;

            ValidariInitiale(proiect);
            InitializeFormValues();
        }
        private void InitializeFormValues()
        {
            textBoxDenumire.Text = proiect.denumireProiect;
            dateTimePickerDataIncepere.Value = dataIncepereOriginal;
            dateTimePickerDataFinalizare.Value = dataFinalizareOriginal;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            if (AreModificari())
            {
                DialogResult result = MessageBox.Show("Aveți modificări nesalvate. Sunteți sigur că doriți să părăsiți formularul?", "Modificări nesalvate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            this.Close();
        }
        private bool AreModificari()
        {
            return textBoxDenumire.Text != denumireProiectOriginal ||
                   dateTimePickerDataIncepere.Value != dataIncepereOriginal ||
                   dateTimePickerDataFinalizare.Value != dataFinalizareOriginal;
        }
        private void buttonSalvare_Click(object sender, EventArgs e)
        {
            if (AreModificari())
            {
                DialogResult result = MessageBox.Show("Ești sigur că vrei să salvezi modificările?", "Confirmare Salvare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Proiect updatedProject = new Proiect
                    {
                        Id_Proiect = proiect.Id_Proiect,
                        denumireProiect = textBoxDenumire.Text
                    };

                    proiect.denumireProiect = textBoxDenumire.Text;
                    var dataIncepere = dateTimePickerDataIncepere.Value;
                    var dataFinalizare = dateTimePickerDataFinalizare.Value;
                    if (dataFinalizare < dataIncepere)
                    {
                        MessageBox.Show("Data de finalizare trebuie să fie după data de începere.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var detaliiProiect = DBHelper.ExtrageDetaliiProiect(updatedProject.Id_Proiect);
                    DBHelper.UpdateProiect(proiect);
                    MessageBox.Show("perioadaInceputVeche " + detaliiProiect.dataIncepereProiect);
                    MessageBox.Show("perioadaSfarsitVeche " + detaliiProiect.dataFinalizareProiect);


                    Perioada perioadaInceput = new Perioada
                    {
                        an = (dateTimePickerDataIncepere.Value.Year).ToString(),
                        luna = (dateTimePickerDataIncepere.Value.Month).ToString(),
                        zi = (dateTimePickerDataIncepere.Value.Day).ToString(),
                    };

                    Perioada perioadaSfarsit = new Perioada
                    {
                        an = (dateTimePickerDataFinalizare.Value.Year).ToString(),
                        luna = (dateTimePickerDataFinalizare.Value.Month).ToString(),
                        zi = (dateTimePickerDataFinalizare.Value.Day).ToString(),
                    };

                    MessageBox.Show("perioadaInceputVeche " + perioadaInceput.an + " " +perioadaInceput.luna + " " + perioadaInceput.zi);
                    MessageBox.Show("perioadaSfarsitVeche " + perioadaSfarsit.an + " " + perioadaSfarsit.luna + " " + perioadaSfarsit.zi);
                    
                    DBHelper.ActualizeazaPerioadaProiect(perioadaInceput, perioadaSfarsit, proiect.Id_Proiect);

                    denumireProiectOriginal = updatedProject.denumireProiect;
                    dataIncepereOriginal = dataIncepere;
                    dataFinalizareOriginal = dataFinalizare;

                    MessageBox.Show("Proiectul a fost actualizat cu succes.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Nu s-au detectat modificări", "Salvare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void ValidariInitiale(Proiect proiect)
        {
            DateTime dataInceperePrimulTask = new DateTime(2100, 12, 1);
            DateTime dataFinalizareUltimulTask = new DateTime(1900, 12, 1);
            var detaliiProiect = DBHelper.ExtrageDetaliiProiect(proiect.Id_Proiect);
            List<Task> listaTaskuriProiect = DBHelper.ExtrageTaskuriByProiect(proiect.Id_Proiect);
            foreach(Task t in listaTaskuriProiect)
            {
                var detaliiTask = DBHelper.ExtrageDetaliiTask(t.Id_Task);
                if(detaliiTask.dataIncepereTask<dataInceperePrimulTask)
                {
                    dataInceperePrimulTask = detaliiTask.dataIncepereTask;
                }
                if(detaliiTask.dataFinalizareTask>dataFinalizareUltimulTask)
                {
                    dataFinalizareUltimulTask = detaliiTask.dataFinalizareTask;
                }
            }
            if (DateTime.Today<detaliiProiect.dataIncepereProiect)
            {
                dateTimePickerDataIncepere.MinDate = DateTime.Today.AddDays(1);
                dateTimePickerDataIncepere.MaxDate = dataInceperePrimulTask;

                dateTimePickerDataFinalizare.MinDate = dataFinalizareUltimulTask;
            }
            else if(DateTime.Today>detaliiProiect.dataIncepereProiect && DateTime.Today<detaliiProiect.dataFinalizareProiect)
            {
                dateTimePickerDataIncepere.Enabled = false;
                dateTimePickerDataFinalizare.MinDate = dataFinalizareUltimulTask;

            }
            else
            {
                labelMesaj.Text = "Proiectul este finalizat. Nu se mai pot face modificări!";
                textBoxDenumire.Enabled = false;
                dateTimePickerDataFinalizare.Enabled = false;
                dateTimePickerDataIncepere.Enabled = false;
            }
        }
    }
}
