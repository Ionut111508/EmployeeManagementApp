
namespace ManagementulProiectelor.Forms
{
    partial class FormAdaugareProiect
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
            this.labelDenumireProiect = new System.Windows.Forms.Label();
            this.textBoxDenumireProiect = new System.Windows.Forms.TextBox();
            this.buttonAdaugaProiect = new System.Windows.Forms.Button();
            this.dateTimePickerDataIncepereProiect = new System.Windows.Forms.DateTimePicker();
            this.labelDataFinalizareProiect = new System.Windows.Forms.Label();
            this.labelDataIncepereProiect = new System.Windows.Forms.Label();
            this.dateTimePickerDataFinalizareProiect = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewProiecte = new System.Windows.Forms.DataGridView();
            this.panelProiecte = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProiecte)).BeginInit();
            this.panelProiecte.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDenumireProiect
            // 
            this.labelDenumireProiect.AutoSize = true;
            this.labelDenumireProiect.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDenumireProiect.Location = new System.Drawing.Point(206, 732);
            this.labelDenumireProiect.Name = "labelDenumireProiect";
            this.labelDenumireProiect.Size = new System.Drawing.Size(219, 31);
            this.labelDenumireProiect.TabIndex = 0;
            this.labelDenumireProiect.Text = "Denumire proiect";
            // 
            // textBoxDenumireProiect
            // 
            this.textBoxDenumireProiect.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDenumireProiect.Location = new System.Drawing.Point(145, 768);
            this.textBoxDenumireProiect.Name = "textBoxDenumireProiect";
            this.textBoxDenumireProiect.Size = new System.Drawing.Size(355, 35);
            this.textBoxDenumireProiect.TabIndex = 1;
            // 
            // buttonAdaugaProiect
            // 
            this.buttonAdaugaProiect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAdaugaProiect.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonAdaugaProiect.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAdaugaProiect.Location = new System.Drawing.Point(574, 869);
            this.buttonAdaugaProiect.Name = "buttonAdaugaProiect";
            this.buttonAdaugaProiect.Size = new System.Drawing.Size(276, 42);
            this.buttonAdaugaProiect.TabIndex = 8;
            this.buttonAdaugaProiect.Text = "Adauga proiect";
            this.buttonAdaugaProiect.UseVisualStyleBackColor = false;
            this.buttonAdaugaProiect.Click += new System.EventHandler(this.buttonAdaugaProiect_Click);
            // 
            // dateTimePickerDataIncepereProiect
            // 
            this.dateTimePickerDataIncepereProiect.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataIncepereProiect.Location = new System.Drawing.Point(574, 768);
            this.dateTimePickerDataIncepereProiect.MinDate = new System.DateTime(2024, 2, 29, 8, 52, 40, 0);
            this.dateTimePickerDataIncepereProiect.Name = "dateTimePickerDataIncepereProiect";
            this.dateTimePickerDataIncepereProiect.Size = new System.Drawing.Size(332, 35);
            this.dateTimePickerDataIncepereProiect.TabIndex = 9;
            this.dateTimePickerDataIncepereProiect.Value = new System.DateTime(2024, 2, 29, 8, 52, 40, 0);
            this.dateTimePickerDataIncepereProiect.ValueChanged += new System.EventHandler(this.dateTimePickerDataIncepereProiect_ValueChanged);
            // 
            // labelDataFinalizareProiect
            // 
            this.labelDataFinalizareProiect.AutoSize = true;
            this.labelDataFinalizareProiect.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDataFinalizareProiect.Location = new System.Drawing.Point(980, 732);
            this.labelDataFinalizareProiect.Name = "labelDataFinalizareProiect";
            this.labelDataFinalizareProiect.Size = new System.Drawing.Size(278, 31);
            this.labelDataFinalizareProiect.TabIndex = 10;
            this.labelDataFinalizareProiect.Text = "Data finalizare proiect";
            // 
            // labelDataIncepereProiect
            // 
            this.labelDataIncepereProiect.AutoSize = true;
            this.labelDataIncepereProiect.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDataIncepereProiect.Location = new System.Drawing.Point(607, 734);
            this.labelDataIncepereProiect.Name = "labelDataIncepereProiect";
            this.labelDataIncepereProiect.Size = new System.Drawing.Size(265, 31);
            this.labelDataIncepereProiect.TabIndex = 11;
            this.labelDataIncepereProiect.Text = "Data incepere proiect";
            // 
            // dateTimePickerDataFinalizareProiect
            // 
            this.dateTimePickerDataFinalizareProiect.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataFinalizareProiect.Location = new System.Drawing.Point(954, 768);
            this.dateTimePickerDataFinalizareProiect.MinDate = new System.DateTime(2024, 2, 29, 0, 0, 0, 0);
            this.dateTimePickerDataFinalizareProiect.Name = "dateTimePickerDataFinalizareProiect";
            this.dateTimePickerDataFinalizareProiect.Size = new System.Drawing.Size(341, 35);
            this.dateTimePickerDataFinalizareProiect.TabIndex = 12;
            this.dateTimePickerDataFinalizareProiect.ValueChanged += new System.EventHandler(this.dateTimePickerDataFinalizareProiect_ValueChanged);
            // 
            // dataGridViewProiecte
            // 
            this.dataGridViewProiecte.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewProiecte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewProiecte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProiecte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProiecte.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewProiecte.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewProiecte.Name = "dataGridViewProiecte";
            this.dataGridViewProiecte.ReadOnly = true;
            this.dataGridViewProiecte.RowTemplate.Height = 25;
            this.dataGridViewProiecte.Size = new System.Drawing.Size(1524, 561);
            this.dataGridViewProiecte.TabIndex = 13;
            this.dataGridViewProiecte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProiecte_CellContentClick);
            // 
            // panelProiecte
            // 
            this.panelProiecte.Controls.Add(this.dataGridViewProiecte);
            this.panelProiecte.Location = new System.Drawing.Point(24, 77);
            this.panelProiecte.Margin = new System.Windows.Forms.Padding(0);
            this.panelProiecte.Name = "panelProiecte";
            this.panelProiecte.Size = new System.Drawing.Size(1524, 561);
            this.panelProiecte.TabIndex = 15;
            // 
            // FormAdaugareProiect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 989);
            this.Controls.Add(this.panelProiecte);
            this.Controls.Add(this.dateTimePickerDataFinalizareProiect);
            this.Controls.Add(this.labelDataIncepereProiect);
            this.Controls.Add(this.labelDataFinalizareProiect);
            this.Controls.Add(this.dateTimePickerDataIncepereProiect);
            this.Controls.Add(this.buttonAdaugaProiect);
            this.Controls.Add(this.textBoxDenumireProiect);
            this.Controls.Add(this.labelDenumireProiect);
            this.Name = "FormAdaugareProiect";
            this.Text = "FormAdaugareProiect";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProiecte)).EndInit();
            this.panelProiecte.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDenumireProiect;
        private System.Windows.Forms.TextBox textBoxDenumireProiect;
        private System.Windows.Forms.Button buttonAdaugaProiect;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataIncepereProiect;
        private System.Windows.Forms.Label labelDataFinalizareProiect;
        private System.Windows.Forms.Label labelDataIncepereProiect;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataFinalizareProiect;
        private System.Windows.Forms.DataGridView dataGridViewProiecte;
        private System.Windows.Forms.Panel panelProiecte;
    }
}