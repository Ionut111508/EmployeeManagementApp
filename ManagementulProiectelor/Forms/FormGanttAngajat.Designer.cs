
namespace ManagementulProiectelor.Forms
{
    partial class FormGanttAngajat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelGantt = new System.Windows.Forms.Panel();
            this.labelAngajat = new System.Windows.Forms.Label();
            this.comboBoxAngajati = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDataInceput = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDataSfarsit = new System.Windows.Forms.DateTimePicker();
            this.checkBoxFiltrare = new System.Windows.Forms.CheckBox();
            this.buttonAplica = new System.Windows.Forms.Button();
            this.panelSub = new System.Windows.Forms.Panel();
            this.pieChartPontari = new LiveCharts.WinForms.PieChart();
            this.pieChartAngajati = new LiveCharts.WinForms.PieChart();
            this.labelChart = new System.Windows.Forms.Label();
            this.labelPontari = new System.Windows.Forms.Label();
            this.innerPanel = new System.Windows.Forms.Panel();
            this.panelSub.SuspendLayout();
            this.innerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGantt
            // 
            this.panelGantt.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelGantt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGantt.Location = new System.Drawing.Point(0, 0);
            this.panelGantt.Name = "panelGantt";
            this.panelGantt.Size = new System.Drawing.Size(1519, 490);
            this.panelGantt.TabIndex = 0;
            this.panelGantt.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelGantt_Scroll);
            this.panelGantt.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGantt_Paint);
            this.panelGantt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelGantt_MouseMove);
            // 
            // labelAngajat
            // 
            this.labelAngajat.AutoSize = true;
            this.labelAngajat.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAngajat.Location = new System.Drawing.Point(37, 56);
            this.labelAngajat.Name = "labelAngajat";
            this.labelAngajat.Size = new System.Drawing.Size(190, 26);
            this.labelAngajat.TabIndex = 1;
            this.labelAngajat.Text = "Selectare angajat";
            // 
            // comboBoxAngajati
            // 
            this.comboBoxAngajati.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAngajati.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.comboBoxAngajati.FormattingEnabled = true;
            this.comboBoxAngajati.Location = new System.Drawing.Point(37, 95);
            this.comboBoxAngajati.MaxDropDownItems = 6;
            this.comboBoxAngajati.Name = "comboBoxAngajati";
            this.comboBoxAngajati.Size = new System.Drawing.Size(392, 32);
            this.comboBoxAngajati.TabIndex = 2;
            this.comboBoxAngajati.SelectedIndexChanged += new System.EventHandler(this.comboBoxAngajati_SelectedIndexChanged);
            // 
            // dateTimePickerDataInceput
            // 
            this.dateTimePickerDataInceput.Location = new System.Drawing.Point(623, 100);
            this.dateTimePickerDataInceput.Name = "dateTimePickerDataInceput";
            this.dateTimePickerDataInceput.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerDataInceput.TabIndex = 3;
            // 
            // dateTimePickerDataSfarsit
            // 
            this.dateTimePickerDataSfarsit.Location = new System.Drawing.Point(938, 101);
            this.dateTimePickerDataSfarsit.Name = "dateTimePickerDataSfarsit";
            this.dateTimePickerDataSfarsit.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerDataSfarsit.TabIndex = 4;
            // 
            // checkBoxFiltrare
            // 
            this.checkBoxFiltrare.AutoSize = true;
            this.checkBoxFiltrare.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxFiltrare.Location = new System.Drawing.Point(458, 99);
            this.checkBoxFiltrare.Name = "checkBoxFiltrare";
            this.checkBoxFiltrare.Size = new System.Drawing.Size(101, 25);
            this.checkBoxFiltrare.TabIndex = 5;
            this.checkBoxFiltrare.Text = "Filtru nou";
            this.checkBoxFiltrare.UseVisualStyleBackColor = true;
            this.checkBoxFiltrare.CheckedChanged += new System.EventHandler(this.checkBoxFiltrare_CheckedChanged);
            // 
            // buttonAplica
            // 
            this.buttonAplica.Location = new System.Drawing.Point(1195, 100);
            this.buttonAplica.Name = "buttonAplica";
            this.buttonAplica.Size = new System.Drawing.Size(75, 23);
            this.buttonAplica.TabIndex = 6;
            this.buttonAplica.Text = "Aplică";
            this.buttonAplica.UseVisualStyleBackColor = true;
            this.buttonAplica.Click += new System.EventHandler(this.buttonAplica_Click);
            // 
            // panelSub
            // 
            this.panelSub.Controls.Add(this.pieChartPontari);
            this.panelSub.Controls.Add(this.pieChartAngajati);
            this.panelSub.Location = new System.Drawing.Point(37, 654);
            this.panelSub.Name = "panelSub";
            this.panelSub.Size = new System.Drawing.Size(1522, 275);
            this.panelSub.TabIndex = 7;
            // 
            // pieChartPontari
            // 
            this.pieChartPontari.Dock = System.Windows.Forms.DockStyle.Right;
            this.pieChartPontari.Location = new System.Drawing.Point(770, 0);
            this.pieChartPontari.Name = "pieChartPontari";
            this.pieChartPontari.Size = new System.Drawing.Size(752, 275);
            this.pieChartPontari.TabIndex = 1;
            // 
            // pieChartAngajati
            // 
            this.pieChartAngajati.Dock = System.Windows.Forms.DockStyle.Left;
            this.pieChartAngajati.Location = new System.Drawing.Point(0, 0);
            this.pieChartAngajati.Name = "pieChartAngajati";
            this.pieChartAngajati.Size = new System.Drawing.Size(788, 275);
            this.pieChartAngajati.TabIndex = 0;
            this.pieChartAngajati.Text = " Participări angajat";
            // 
            // labelChart
            // 
            this.labelChart.AutoSize = true;
            this.labelChart.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelChart.Location = new System.Drawing.Point(1070, 949);
            this.labelChart.Name = "labelChart";
            this.labelChart.Size = new System.Drawing.Size(245, 31);
            this.labelChart.TabIndex = 1;
            this.labelChart.Text = " Participări angajat";
            this.labelChart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPontari
            // 
            this.labelPontari.AutoSize = true;
            this.labelPontari.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPontari.Location = new System.Drawing.Point(301, 949);
            this.labelPontari.Name = "labelPontari";
            this.labelPontari.Size = new System.Drawing.Size(249, 31);
            this.labelPontari.TabIndex = 8;
            this.labelPontari.Text = "Pontări lună în curs";
            this.labelPontari.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // innerPanel
            // 
            this.innerPanel.Controls.Add(this.panelGantt);
            this.innerPanel.Location = new System.Drawing.Point(37, 145);
            this.innerPanel.Name = "innerPanel";
            this.innerPanel.Size = new System.Drawing.Size(1519, 490);
            this.innerPanel.TabIndex = 9;
            this.innerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.innerPanel_Paint);
            this.innerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.innerPanel_MouseMove);
            // 
            // FormGanttAngajat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1583, 1014);
            this.Controls.Add(this.innerPanel);
            this.Controls.Add(this.labelPontari);
            this.Controls.Add(this.panelSub);
            this.Controls.Add(this.labelChart);
            this.Controls.Add(this.buttonAplica);
            this.Controls.Add(this.checkBoxFiltrare);
            this.Controls.Add(this.dateTimePickerDataSfarsit);
            this.Controls.Add(this.dateTimePickerDataInceput);
            this.Controls.Add(this.comboBoxAngajati);
            this.Controls.Add(this.labelAngajat);
            this.Name = "FormGanttAngajat";
            this.Text = "FormGanttAngajat";
            this.Load += new System.EventHandler(this.FormGanttAngajat_Load);
            this.panelSub.ResumeLayout(false);
            this.innerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelGantt;
        private System.Windows.Forms.Label labelAngajat;
        private System.Windows.Forms.ComboBox comboBoxAngajati;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataInceput;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataSfarsit;
        private System.Windows.Forms.CheckBox checkBoxFiltrare;
        private System.Windows.Forms.Button buttonAplica;
        private System.Windows.Forms.Panel panelSub;
        private LiveCharts.WinForms.PieChart pieChartAngajati;
        private System.Windows.Forms.Label labelChart;
        private LiveCharts.WinForms.PieChart pieChartPontari;
        private System.Windows.Forms.Label labelPontari;
        private System.Windows.Forms.Panel innerPanel;
    }
}