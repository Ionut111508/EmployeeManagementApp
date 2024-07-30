
namespace ManagementulProiectelor.Forms
{
    partial class FormPontaj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPontaj));
            this.labelEfectuarePontaj = new System.Windows.Forms.Label();
            this.labelNrOreLucrate = new System.Windows.Forms.Label();
            this.numericUpDownNrOre = new System.Windows.Forms.NumericUpDown();
            this.buttonAdauga = new System.Windows.Forms.Button();
            this.labelProiect = new System.Windows.Forms.Label();
            this.labelTask = new System.Windows.Forms.Label();
            this.comboBoxTask = new System.Windows.Forms.ComboBox();
            this.comboBoxProiect = new System.Windows.Forms.ComboBox();
            this.listBoxPontariRecente = new System.Windows.Forms.ListBox();
            this.dateTimePickerDataAfisarePontare = new System.Windows.Forms.DateTimePicker();
            this.labelMesaj = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNrOre)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEfectuarePontaj
            // 
            this.labelEfectuarePontaj.AutoSize = true;
            this.labelEfectuarePontaj.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEfectuarePontaj.Location = new System.Drawing.Point(348, 27);
            this.labelEfectuarePontaj.Name = "labelEfectuarePontaj";
            this.labelEfectuarePontaj.Size = new System.Drawing.Size(397, 45);
            this.labelEfectuarePontaj.TabIndex = 0;
            this.labelEfectuarePontaj.Text = "Efectueaza pontajul zilnic";
            // 
            // labelNrOreLucrate
            // 
            this.labelNrOreLucrate.AutoSize = true;
            this.labelNrOreLucrate.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNrOreLucrate.Location = new System.Drawing.Point(23, 427);
            this.labelNrOreLucrate.Name = "labelNrOreLucrate";
            this.labelNrOreLucrate.Size = new System.Drawing.Size(299, 32);
            this.labelNrOreLucrate.TabIndex = 4;
            this.labelNrOreLucrate.Text = "Numarul de ore lucrate";
            // 
            // numericUpDownNrOre
            // 
            this.numericUpDownNrOre.DecimalPlaces = 1;
            this.numericUpDownNrOre.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownNrOre.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownNrOre.Location = new System.Drawing.Point(458, 424);
            this.numericUpDownNrOre.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownNrOre.Name = "numericUpDownNrOre";
            this.numericUpDownNrOre.ReadOnly = true;
            this.numericUpDownNrOre.Size = new System.Drawing.Size(142, 35);
            this.numericUpDownNrOre.TabIndex = 5;
            this.numericUpDownNrOre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownNrOre.ValueChanged += new System.EventHandler(this.numericUpDownNrOre_ValueChanged);
            // 
            // buttonAdauga
            // 
            this.buttonAdauga.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAdauga.Location = new System.Drawing.Point(278, 563);
            this.buttonAdauga.Name = "buttonAdauga";
            this.buttonAdauga.Size = new System.Drawing.Size(281, 63);
            this.buttonAdauga.TabIndex = 6;
            this.buttonAdauga.Text = "Adauga pontaj";
            this.buttonAdauga.UseVisualStyleBackColor = true;
            this.buttonAdauga.Click += new System.EventHandler(this.buttonAdauga_Click);
            // 
            // labelProiect
            // 
            this.labelProiect.AutoSize = true;
            this.labelProiect.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelProiect.Location = new System.Drawing.Point(74, 229);
            this.labelProiect.Name = "labelProiect";
            this.labelProiect.Size = new System.Drawing.Size(101, 32);
            this.labelProiect.TabIndex = 7;
            this.labelProiect.Text = "Proiect";
            // 
            // labelTask
            // 
            this.labelTask.AutoSize = true;
            this.labelTask.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTask.Location = new System.Drawing.Point(74, 327);
            this.labelTask.Name = "labelTask";
            this.labelTask.Size = new System.Drawing.Size(69, 32);
            this.labelTask.TabIndex = 8;
            this.labelTask.Text = "Task";
            // 
            // comboBoxTask
            // 
            this.comboBoxTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTask.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxTask.FormattingEnabled = true;
            this.comboBoxTask.Location = new System.Drawing.Point(351, 324);
            this.comboBoxTask.Name = "comboBoxTask";
            this.comboBoxTask.Size = new System.Drawing.Size(394, 35);
            this.comboBoxTask.TabIndex = 12;
            this.comboBoxTask.SelectedIndexChanged += new System.EventHandler(this.comboBoxTask_SelectedIndexChanged);
            // 
            // comboBoxProiect
            // 
            this.comboBoxProiect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProiect.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxProiect.FormattingEnabled = true;
            this.comboBoxProiect.Location = new System.Drawing.Point(351, 231);
            this.comboBoxProiect.Name = "comboBoxProiect";
            this.comboBoxProiect.Size = new System.Drawing.Size(394, 35);
            this.comboBoxProiect.TabIndex = 13;
            this.comboBoxProiect.SelectedIndexChanged += new System.EventHandler(this.comboBoxProiect_SelectedIndexChanged);
            // 
            // listBoxPontariRecente
            // 
            this.listBoxPontariRecente.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxPontariRecente.FormattingEnabled = true;
            this.listBoxPontariRecente.ItemHeight = 31;
            this.listBoxPontariRecente.Location = new System.Drawing.Point(799, 132);
            this.listBoxPontariRecente.Name = "listBoxPontariRecente";
            this.listBoxPontariRecente.Size = new System.Drawing.Size(726, 531);
            this.listBoxPontariRecente.TabIndex = 14;
            // 
            // dateTimePickerDataAfisarePontare
            // 
            this.dateTimePickerDataAfisarePontare.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataAfisarePontare.Location = new System.Drawing.Point(376, 150);
            this.dateTimePickerDataAfisarePontare.Name = "dateTimePickerDataAfisarePontare";
            this.dateTimePickerDataAfisarePontare.Size = new System.Drawing.Size(295, 32);
            this.dateTimePickerDataAfisarePontare.TabIndex = 15;
            this.dateTimePickerDataAfisarePontare.ValueChanged += new System.EventHandler(this.dateTimePickerDataAfisarePontare_ValueChanged);
            // 
            // labelMesaj
            // 
            this.labelMesaj.AutoSize = true;
            this.labelMesaj.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMesaj.Location = new System.Drawing.Point(269, 281);
            this.labelMesaj.Name = "labelMesaj";
            this.labelMesaj.Size = new System.Drawing.Size(106, 40);
            this.labelMesaj.TabIndex = 16;
            this.labelMesaj.Text = "label1";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
            this.buttonRemove.Location = new System.Drawing.Point(1531, 132);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(39, 42);
            this.buttonRemove.TabIndex = 37;
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // FormPontaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1683, 695);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.labelMesaj);
            this.Controls.Add(this.dateTimePickerDataAfisarePontare);
            this.Controls.Add(this.listBoxPontariRecente);
            this.Controls.Add(this.comboBoxProiect);
            this.Controls.Add(this.comboBoxTask);
            this.Controls.Add(this.labelTask);
            this.Controls.Add(this.labelProiect);
            this.Controls.Add(this.buttonAdauga);
            this.Controls.Add(this.numericUpDownNrOre);
            this.Controls.Add(this.labelNrOreLucrate);
            this.Controls.Add(this.labelEfectuarePontaj);
            this.Name = "FormPontaj";
            this.Text = "FormPontaj";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNrOre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEfectuarePontaj;
        private System.Windows.Forms.Label labelNrOreLucrate;
        private System.Windows.Forms.NumericUpDown numericUpDownNrOre;
        private System.Windows.Forms.Button buttonAdauga;
        private System.Windows.Forms.Label labelProiect;
        private System.Windows.Forms.Label labelTask;
        private System.Windows.Forms.ComboBox comboBoxTask;
        private System.Windows.Forms.ComboBox comboBoxProiect;
        private System.Windows.Forms.ListBox listBoxPontariRecente;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataAfisarePontare;
        private System.Windows.Forms.Label labelMesaj;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonRemove;
    }
}