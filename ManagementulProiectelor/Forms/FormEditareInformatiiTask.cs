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
    public partial class FormEditareInformatiiTask : Form
    {
        private Proiect proiect;
        private Task task;
        private string denumireTaskOriginal;
        private string descriereOriginal;
        private decimal numarOreOriginal;
        private DateTime dataIncepereOriginal;
        private DateTime dataFinalizareOriginal;

        public FormEditareInformatiiTask()
        {
            InitializeComponent();
        }
        public FormEditareInformatiiTask(Proiect proiect, Task task) : this()
        {
            this.proiect = proiect;
            this.task = task;
            this.denumireTaskOriginal = task.denumireTask;
            this.descriereOriginal = DBHelper.ExtrageDescriereById(task.Id_Descriere);
            this.numarOreOriginal = task.numarOre;
            var detaliiTask = DBHelper.ExtrageDetaliiTask(task.Id_Task);
            this.dataIncepereOriginal = detaliiTask.dataIncepereTask;
            this.dataFinalizareOriginal = detaliiTask.dataFinalizareTask;

            VerificariInitiale(task);

            InitializeFormValues();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            if (AreModificari())
            {
                DialogResult result = MessageBox.Show("Sunteți sigur că doriți să părăsiți fără a salva modificările?", "Confirmare părăsire", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            this.Close();
        }
        private void InitializeFormValues()
        {
            textBoxDenumire.Text = task.denumireTask;
            richTextBoxDescriere.Text = descriereOriginal;
            numericUpDownNumarOreNecesar.Value = task.numarOre;
            numericUpDownNumarOreNecesar.Minimum = task.numarOre;
            dateTimePickerDataIncepere.Value = dataIncepereOriginal;
            dateTimePickerDataFinalizare.Value = dataFinalizareOriginal;
        }
        private void buttonSalvare_Click(object sender, EventArgs e)
        {
            if (AreModificari())
            {
                DialogResult result = MessageBox.Show("Ești sigur că vrei să salvezi modificările?", "Confirmare Salvare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Task updatedTask = new Task
                    {
                        Id_Task = task.Id_Task,
                        denumireTask = textBoxDenumire.Text,
                        numarOre = (decimal)numericUpDownNumarOreNecesar.Value
                    };
                    DBHelper.ActualizeazaTask(updatedTask);

                    DBHelper.ActualizareDescriere(richTextBoxDescriere.Text,updatedTask.Id_Task);

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

                    DBHelper.ActualizeazaPerioada(perioadaInceput, perioadaSfarsit, task.Id_Task, task.Id_Proiect);

                    denumireTaskOriginal = updatedTask.denumireTask;
                    descriereOriginal = richTextBoxDescriere.Text;
                    numarOreOriginal = updatedTask.numarOre;
                    dataIncepereOriginal = dateTimePickerDataIncepere.Value;
                    dataFinalizareOriginal = dateTimePickerDataFinalizare.Value;

                    MessageBox.Show("Informațiile task-ului au fost salvate cu succes.", "Salvare completă", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Nu s-au detectat modificări", "Salvare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool AreModificari()
        {
            return textBoxDenumire.Text != denumireTaskOriginal ||
                   richTextBoxDescriere.Text != descriereOriginal ||
                   numericUpDownNumarOreNecesar.Value != numarOreOriginal ||
                   dateTimePickerDataIncepere.Value != dataIncepereOriginal ||
                   dateTimePickerDataFinalizare.Value != dataFinalizareOriginal;
        }
        public void VerificariInitiale(Task task)
        {
            var detaliiTask = DBHelper.ExtrageDetaliiTask(task.Id_Task);
            var detaliiProiect = DBHelper.ExtrageDetaliiProiect(task.Id_Proiect);
            if(detaliiProiect.dataIncepereProiect<detaliiTask.dataIncepereTask)
            {
                if(DateTime.Today>detaliiProiect.dataIncepereProiect && DateTime.Today<detaliiTask.dataIncepereTask)
                {
                    dateTimePickerDataIncepere.MinDate = DateTime.Today;
                }
                if(DateTime.Today<detaliiProiect.dataIncepereProiect)
                {
                dateTimePickerDataIncepere.MinDate = detaliiProiect.dataIncepereProiect.AddDays(1);
                }
            }
            if(DateTime.Today >= detaliiTask.dataIncepereTask)
            {
                dateTimePickerDataIncepere.Enabled = false;
            }
            if(detaliiProiect.dataFinalizareProiect>=detaliiTask.dataFinalizareTask)
            {
                if(DateTime.Today>detaliiTask.dataFinalizareTask && DateTime.Today<detaliiProiect.dataFinalizareProiect)
                {
                    dateTimePickerDataFinalizare.Enabled = false;
                }
                if(DateTime.Today<detaliiTask.dataFinalizareTask)
                {
                    dateTimePickerDataFinalizare.MaxDate = detaliiProiect.dataFinalizareProiect;
                }
            }
            dateTimePickerDataIncepere.MaxDate = detaliiTask.dataFinalizareTask.AddDays(-1);
            dateTimePickerDataFinalizare.MinDate = detaliiTask.dataIncepereTask.AddDays(1); 
        }
    }
}
