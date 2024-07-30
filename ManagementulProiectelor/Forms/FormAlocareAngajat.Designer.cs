
namespace ManagementulProiectelor.Forms
{
    partial class FormAlocareAngajat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlocareAngajat));
            this.buttonAlocare = new System.Windows.Forms.Button();
            this.dateTimePickerDataInceput = new System.Windows.Forms.DateTimePicker();
            this.labelSelectareProiect = new System.Windows.Forms.Label();
            this.labelSelectareTask = new System.Windows.Forms.Label();
            this.labelDataParticipare = new System.Windows.Forms.Label();
            this.labelAngajatiDisponibili = new System.Windows.Forms.Label();
            this.listBoxAngajatiDisponibili = new System.Windows.Forms.ListBox();
            this.listBoxNrOreRamase = new System.Windows.Forms.ListBox();
            this.listBoxAfisareAngajatiSelectati = new System.Windows.Forms.ListBox();
            this.buttonAdauga = new System.Windows.Forms.Button();
            this.buttonElimina = new System.Windows.Forms.Button();
            this.panelAngajatiDisponibili = new System.Windows.Forms.Panel();
            this.labelPerioadaDeLucru = new System.Windows.Forms.Label();
            this.labelOreAlocate = new System.Windows.Forms.Label();
            this.textBoxOreAlocate = new System.Windows.Forms.TextBox();
            this.textBoxOreNecesare = new System.Windows.Forms.TextBox();
            this.labelOreNecesare = new System.Windows.Forms.Label();
            this.dateTimePickerDataFinalizare = new System.Windows.Forms.DateTimePicker();
            this.labelDataFinaliza = new System.Windows.Forms.Label();
            this.numericUpDownOreAlocate = new System.Windows.Forms.NumericUpDown();
            this.progressBarNumarOreAlocate = new System.Windows.Forms.ProgressBar();
            this.labelPrevizualizareAngajati = new System.Windows.Forms.Label();
            this.panelListBoxPrevizualizareAngajati = new System.Windows.Forms.Panel();
            this.comboBoxProiecte = new System.Windows.Forms.ComboBox();
            this.comboBoxTaskuri = new System.Windows.Forms.ComboBox();
            this.textBoxDataIncepereTask = new System.Windows.Forms.TextBox();
            this.textBoxDataFinalizareTask = new System.Windows.Forms.TextBox();
            this.labelDataIncepereTask = new System.Windows.Forms.Label();
            this.labelDataFinalizareTask = new System.Windows.Forms.Label();
            this.checkBoxInformatiiTask = new System.Windows.Forms.CheckBox();
            this.panelInformatiiTask = new System.Windows.Forms.Panel();
            this.labelProgres = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelAngajatiDisponibili.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOreAlocate)).BeginInit();
            this.panelListBoxPrevizualizareAngajati.SuspendLayout();
            this.panelInformatiiTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAlocare
            // 
            this.buttonAlocare.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAlocare.Location = new System.Drawing.Point(944, 870);
            this.buttonAlocare.Name = "buttonAlocare";
            this.buttonAlocare.Size = new System.Drawing.Size(131, 56);
            this.buttonAlocare.TabIndex = 0;
            this.buttonAlocare.Text = "Alocare";
            this.buttonAlocare.UseVisualStyleBackColor = true;
            this.buttonAlocare.Click += new System.EventHandler(this.buttonAlocare_Click);
            // 
            // dateTimePickerDataInceput
            // 
            this.dateTimePickerDataInceput.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataInceput.Location = new System.Drawing.Point(700, 766);
            this.dateTimePickerDataInceput.MinDate = new System.DateTime(2024, 2, 5, 0, 0, 0, 0);
            this.dateTimePickerDataInceput.Name = "dateTimePickerDataInceput";
            this.dateTimePickerDataInceput.Size = new System.Drawing.Size(279, 32);
            this.dateTimePickerDataInceput.TabIndex = 4;
            // 
            // labelSelectareProiect
            // 
            this.labelSelectareProiect.AutoSize = true;
            this.labelSelectareProiect.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSelectareProiect.Location = new System.Drawing.Point(118, 34);
            this.labelSelectareProiect.Name = "labelSelectareProiect";
            this.labelSelectareProiect.Size = new System.Drawing.Size(256, 32);
            this.labelSelectareProiect.TabIndex = 7;
            this.labelSelectareProiect.Text = "Selecteaza proiectul";
            this.labelSelectareProiect.Click += new System.EventHandler(this.labelSelectareProiect_Click);
            // 
            // labelSelectareTask
            // 
            this.labelSelectareTask.AutoSize = true;
            this.labelSelectareTask.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSelectareTask.Location = new System.Drawing.Point(118, 149);
            this.labelSelectareTask.Name = "labelSelectareTask";
            this.labelSelectareTask.Size = new System.Drawing.Size(221, 32);
            this.labelSelectareTask.TabIndex = 8;
            this.labelSelectareTask.Text = "Selecteaza taskul";
            this.labelSelectareTask.Visible = false;
            this.labelSelectareTask.Click += new System.EventHandler(this.labelSelectareTask_Click);
            // 
            // labelDataParticipare
            // 
            this.labelDataParticipare.AutoSize = true;
            this.labelDataParticipare.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDataParticipare.Location = new System.Drawing.Point(716, 740);
            this.labelDataParticipare.Name = "labelDataParticipare";
            this.labelDataParticipare.Size = new System.Drawing.Size(224, 23);
            this.labelDataParticipare.TabIndex = 9;
            this.labelDataParticipare.Text = "Selecteaza data de alocare";
            // 
            // labelAngajatiDisponibili
            // 
            this.labelAngajatiDisponibili.AutoSize = true;
            this.labelAngajatiDisponibili.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAngajatiDisponibili.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAngajatiDisponibili.Location = new System.Drawing.Point(0, 0);
            this.labelAngajatiDisponibili.Name = "labelAngajatiDisponibili";
            this.labelAngajatiDisponibili.Size = new System.Drawing.Size(209, 25);
            this.labelAngajatiDisponibili.TabIndex = 13;
            this.labelAngajatiDisponibili.Text = "Angajati disponibili :";
            // 
            // listBoxAngajatiDisponibili
            // 
            this.listBoxAngajatiDisponibili.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxAngajatiDisponibili.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxAngajatiDisponibili.FormattingEnabled = true;
            this.listBoxAngajatiDisponibili.HorizontalScrollbar = true;
            this.listBoxAngajatiDisponibili.ItemHeight = 27;
            this.listBoxAngajatiDisponibili.Location = new System.Drawing.Point(0, 25);
            this.listBoxAngajatiDisponibili.Name = "listBoxAngajatiDisponibili";
            this.listBoxAngajatiDisponibili.Size = new System.Drawing.Size(427, 299);
            this.listBoxAngajatiDisponibili.TabIndex = 14;
            this.listBoxAngajatiDisponibili.SelectedIndexChanged += new System.EventHandler(this.listBoxAngajatiDisponibili_SelectedIndexChanged);
            // 
            // listBoxNrOreRamase
            // 
            this.listBoxNrOreRamase.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxNrOreRamase.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxNrOreRamase.FormattingEnabled = true;
            this.listBoxNrOreRamase.HorizontalScrollbar = true;
            this.listBoxNrOreRamase.ItemHeight = 27;
            this.listBoxNrOreRamase.Location = new System.Drawing.Point(433, 25);
            this.listBoxNrOreRamase.Name = "listBoxNrOreRamase";
            this.listBoxNrOreRamase.Size = new System.Drawing.Size(552, 299);
            this.listBoxNrOreRamase.TabIndex = 15;
            this.listBoxNrOreRamase.SelectedIndexChanged += new System.EventHandler(this.listBoxNrOreRamase_SelectedIndexChanged);
            // 
            // listBoxAfisareAngajatiSelectati
            // 
            this.listBoxAfisareAngajatiSelectati.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAfisareAngajatiSelectati.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxAfisareAngajatiSelectati.FormattingEnabled = true;
            this.listBoxAfisareAngajatiSelectati.HorizontalScrollbar = true;
            this.listBoxAfisareAngajatiSelectati.ItemHeight = 31;
            this.listBoxAfisareAngajatiSelectati.Location = new System.Drawing.Point(0, 25);
            this.listBoxAfisareAngajatiSelectati.Name = "listBoxAfisareAngajatiSelectati";
            this.listBoxAfisareAngajatiSelectati.Size = new System.Drawing.Size(813, 279);
            this.listBoxAfisareAngajatiSelectati.TabIndex = 16;
            // 
            // buttonAdauga
            // 
            this.buttonAdauga.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdauga.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdauga.Image")));
            this.buttonAdauga.Location = new System.Drawing.Point(812, 359);
            this.buttonAdauga.Name = "buttonAdauga";
            this.buttonAdauga.Size = new System.Drawing.Size(77, 50);
            this.buttonAdauga.TabIndex = 17;
            this.buttonAdauga.UseVisualStyleBackColor = true;
            this.buttonAdauga.Click += new System.EventHandler(this.buttonAdauga_Click);
            // 
            // buttonElimina
            // 
            this.buttonElimina.Image = ((System.Drawing.Image)(resources.GetObject("buttonElimina.Image")));
            this.buttonElimina.Location = new System.Drawing.Point(1148, 359);
            this.buttonElimina.Name = "buttonElimina";
            this.buttonElimina.Size = new System.Drawing.Size(69, 50);
            this.buttonElimina.TabIndex = 18;
            this.buttonElimina.UseVisualStyleBackColor = true;
            this.buttonElimina.Click += new System.EventHandler(this.buttonElimina_Click);
            // 
            // panelAngajatiDisponibili
            // 
            this.panelAngajatiDisponibili.Controls.Add(this.labelPerioadaDeLucru);
            this.panelAngajatiDisponibili.Controls.Add(this.listBoxAngajatiDisponibili);
            this.panelAngajatiDisponibili.Controls.Add(this.listBoxNrOreRamase);
            this.panelAngajatiDisponibili.Controls.Add(this.labelAngajatiDisponibili);
            this.panelAngajatiDisponibili.Location = new System.Drawing.Point(548, 24);
            this.panelAngajatiDisponibili.Name = "panelAngajatiDisponibili";
            this.panelAngajatiDisponibili.Size = new System.Drawing.Size(985, 324);
            this.panelAngajatiDisponibili.TabIndex = 19;
            // 
            // labelPerioadaDeLucru
            // 
            this.labelPerioadaDeLucru.AutoSize = true;
            this.labelPerioadaDeLucru.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPerioadaDeLucru.Location = new System.Drawing.Point(433, -2);
            this.labelPerioadaDeLucru.Name = "labelPerioadaDeLucru";
            this.labelPerioadaDeLucru.Size = new System.Drawing.Size(179, 24);
            this.labelPerioadaDeLucru.TabIndex = 16;
            this.labelPerioadaDeLucru.Text = "Perioada de lucru :";
            // 
            // labelOreAlocate
            // 
            this.labelOreAlocate.AutoSize = true;
            this.labelOreAlocate.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelOreAlocate.Location = new System.Drawing.Point(12, 264);
            this.labelOreAlocate.Name = "labelOreAlocate";
            this.labelOreAlocate.Size = new System.Drawing.Size(114, 24);
            this.labelOreAlocate.TabIndex = 21;
            this.labelOreAlocate.Text = "Ore alocate";
            // 
            // textBoxOreAlocate
            // 
            this.textBoxOreAlocate.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxOreAlocate.Location = new System.Drawing.Point(5, 291);
            this.textBoxOreAlocate.Name = "textBoxOreAlocate";
            this.textBoxOreAlocate.ReadOnly = true;
            this.textBoxOreAlocate.Size = new System.Drawing.Size(203, 35);
            this.textBoxOreAlocate.TabIndex = 22;
            this.textBoxOreAlocate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxOreAlocate.TextChanged += new System.EventHandler(this.textBoxOreAlocate_TextChanged);
            // 
            // textBoxOreNecesare
            // 
            this.textBoxOreNecesare.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxOreNecesare.Location = new System.Drawing.Point(242, 291);
            this.textBoxOreNecesare.Name = "textBoxOreNecesare";
            this.textBoxOreNecesare.ReadOnly = true;
            this.textBoxOreNecesare.Size = new System.Drawing.Size(197, 35);
            this.textBoxOreNecesare.TabIndex = 23;
            this.textBoxOreNecesare.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelOreNecesare
            // 
            this.labelOreNecesare.AutoSize = true;
            this.labelOreNecesare.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelOreNecesare.Location = new System.Drawing.Point(257, 264);
            this.labelOreNecesare.Name = "labelOreNecesare";
            this.labelOreNecesare.Size = new System.Drawing.Size(127, 24);
            this.labelOreNecesare.TabIndex = 24;
            this.labelOreNecesare.Text = "Ore necesare";
            this.labelOreNecesare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerDataFinalizare
            // 
            this.dateTimePickerDataFinalizare.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataFinalizare.Location = new System.Drawing.Point(1064, 766);
            this.dateTimePickerDataFinalizare.MinDate = new System.DateTime(2024, 2, 5, 0, 0, 0, 0);
            this.dateTimePickerDataFinalizare.Name = "dateTimePickerDataFinalizare";
            this.dateTimePickerDataFinalizare.Size = new System.Drawing.Size(286, 32);
            this.dateTimePickerDataFinalizare.TabIndex = 25;
            // 
            // labelDataFinaliza
            // 
            this.labelDataFinaliza.AutoSize = true;
            this.labelDataFinaliza.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDataFinaliza.Location = new System.Drawing.Point(1079, 740);
            this.labelDataFinaliza.Name = "labelDataFinaliza";
            this.labelDataFinaliza.Size = new System.Drawing.Size(229, 23);
            this.labelDataFinaliza.TabIndex = 26;
            this.labelDataFinaliza.Text = "Selecteaza data de parasire";
            // 
            // numericUpDownOreAlocate
            // 
            this.numericUpDownOreAlocate.DecimalPlaces = 1;
            this.numericUpDownOreAlocate.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownOreAlocate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownOreAlocate.Location = new System.Drawing.Point(950, 818);
            this.numericUpDownOreAlocate.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownOreAlocate.Name = "numericUpDownOreAlocate";
            this.numericUpDownOreAlocate.ReadOnly = true;
            this.numericUpDownOreAlocate.Size = new System.Drawing.Size(125, 32);
            this.numericUpDownOreAlocate.TabIndex = 27;
            // 
            // progressBarNumarOreAlocate
            // 
            this.progressBarNumarOreAlocate.ForeColor = System.Drawing.Color.SpringGreen;
            this.progressBarNumarOreAlocate.Location = new System.Drawing.Point(5, 203);
            this.progressBarNumarOreAlocate.Name = "progressBarNumarOreAlocate";
            this.progressBarNumarOreAlocate.Size = new System.Drawing.Size(436, 36);
            this.progressBarNumarOreAlocate.TabIndex = 28;
            // 
            // labelPrevizualizareAngajati
            // 
            this.labelPrevizualizareAngajati.AutoSize = true;
            this.labelPrevizualizareAngajati.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPrevizualizareAngajati.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPrevizualizareAngajati.Location = new System.Drawing.Point(0, 0);
            this.labelPrevizualizareAngajati.Name = "labelPrevizualizareAngajati";
            this.labelPrevizualizareAngajati.Size = new System.Drawing.Size(231, 25);
            this.labelPrevizualizareAngajati.TabIndex = 29;
            this.labelPrevizualizareAngajati.Text = "Previzualizare Angajati";
            // 
            // panelListBoxPrevizualizareAngajati
            // 
            this.panelListBoxPrevizualizareAngajati.Controls.Add(this.listBoxAfisareAngajatiSelectati);
            this.panelListBoxPrevizualizareAngajati.Controls.Add(this.labelPrevizualizareAngajati);
            this.panelListBoxPrevizualizareAngajati.Location = new System.Drawing.Point(618, 419);
            this.panelListBoxPrevizualizareAngajati.Name = "panelListBoxPrevizualizareAngajati";
            this.panelListBoxPrevizualizareAngajati.Size = new System.Drawing.Size(813, 304);
            this.panelListBoxPrevizualizareAngajati.TabIndex = 31;
            // 
            // comboBoxProiecte
            // 
            this.comboBoxProiecte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProiecte.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxProiecte.FormattingEnabled = true;
            this.comboBoxProiecte.Location = new System.Drawing.Point(24, 69);
            this.comboBoxProiecte.Name = "comboBoxProiecte";
            this.comboBoxProiecte.Size = new System.Drawing.Size(403, 35);
            this.comboBoxProiecte.TabIndex = 32;
            this.comboBoxProiecte.SelectedIndexChanged += new System.EventHandler(this.comboBoxProiecte_SelectedIndexChanged);
            // 
            // comboBoxTaskuri
            // 
            this.comboBoxTaskuri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTaskuri.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxTaskuri.FormattingEnabled = true;
            this.comboBoxTaskuri.Location = new System.Drawing.Point(24, 184);
            this.comboBoxTaskuri.Name = "comboBoxTaskuri";
            this.comboBoxTaskuri.Size = new System.Drawing.Size(403, 35);
            this.comboBoxTaskuri.TabIndex = 33;
            this.comboBoxTaskuri.SelectedIndexChanged += new System.EventHandler(this.comboBoxTaskuri_SelectedIndexChanged);
            // 
            // textBoxDataIncepereTask
            // 
            this.textBoxDataIncepereTask.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxDataIncepereTask.Location = new System.Drawing.Point(5, 90);
            this.textBoxDataIncepereTask.Name = "textBoxDataIncepereTask";
            this.textBoxDataIncepereTask.ReadOnly = true;
            this.textBoxDataIncepereTask.Size = new System.Drawing.Size(182, 39);
            this.textBoxDataIncepereTask.TabIndex = 34;
            this.textBoxDataIncepereTask.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxDataFinalizareTask
            // 
            this.textBoxDataFinalizareTask.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxDataFinalizareTask.Location = new System.Drawing.Point(257, 90);
            this.textBoxDataFinalizareTask.Name = "textBoxDataFinalizareTask";
            this.textBoxDataFinalizareTask.ReadOnly = true;
            this.textBoxDataFinalizareTask.Size = new System.Drawing.Size(184, 39);
            this.textBoxDataFinalizareTask.TabIndex = 35;
            this.textBoxDataFinalizareTask.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelDataIncepereTask
            // 
            this.labelDataIncepereTask.AutoSize = true;
            this.labelDataIncepereTask.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDataIncepereTask.Location = new System.Drawing.Point(3, 61);
            this.labelDataIncepereTask.Name = "labelDataIncepereTask";
            this.labelDataIncepereTask.Size = new System.Drawing.Size(176, 24);
            this.labelDataIncepereTask.TabIndex = 36;
            this.labelDataIncepereTask.Text = "Data incepere task";
            // 
            // labelDataFinalizareTask
            // 
            this.labelDataFinalizareTask.AutoSize = true;
            this.labelDataFinalizareTask.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDataFinalizareTask.Location = new System.Drawing.Point(257, 61);
            this.labelDataFinalizareTask.Name = "labelDataFinalizareTask";
            this.labelDataFinalizareTask.Size = new System.Drawing.Size(183, 24);
            this.labelDataFinalizareTask.TabIndex = 37;
            this.labelDataFinalizareTask.Text = "Data finalizare task";
            // 
            // checkBoxInformatiiTask
            // 
            this.checkBoxInformatiiTask.AutoSize = true;
            this.checkBoxInformatiiTask.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxInformatiiTask.Location = new System.Drawing.Point(24, 226);
            this.checkBoxInformatiiTask.Name = "checkBoxInformatiiTask";
            this.checkBoxInformatiiTask.Size = new System.Drawing.Size(136, 25);
            this.checkBoxInformatiiTask.TabIndex = 39;
            this.checkBoxInformatiiTask.Text = "Informatii task";
            this.checkBoxInformatiiTask.UseVisualStyleBackColor = true;
            this.checkBoxInformatiiTask.CheckedChanged += new System.EventHandler(this.checkBoxInformatiiTask_CheckedChanged);
            // 
            // panelInformatiiTask
            // 
            this.panelInformatiiTask.Controls.Add(this.labelProgres);
            this.panelInformatiiTask.Controls.Add(this.labelOreNecesare);
            this.panelInformatiiTask.Controls.Add(this.labelOreAlocate);
            this.panelInformatiiTask.Controls.Add(this.labelDataFinalizareTask);
            this.panelInformatiiTask.Controls.Add(this.textBoxOreAlocate);
            this.panelInformatiiTask.Controls.Add(this.labelDataIncepereTask);
            this.panelInformatiiTask.Controls.Add(this.textBoxOreNecesare);
            this.panelInformatiiTask.Controls.Add(this.textBoxDataFinalizareTask);
            this.panelInformatiiTask.Controls.Add(this.textBoxDataIncepereTask);
            this.panelInformatiiTask.Controls.Add(this.progressBarNumarOreAlocate);
            this.panelInformatiiTask.Location = new System.Drawing.Point(12, 285);
            this.panelInformatiiTask.Name = "panelInformatiiTask";
            this.panelInformatiiTask.Size = new System.Drawing.Size(470, 341);
            this.panelInformatiiTask.TabIndex = 40;
            this.panelInformatiiTask.Visible = false;
            // 
            // labelProgres
            // 
            this.labelProgres.AutoSize = true;
            this.labelProgres.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelProgres.Location = new System.Drawing.Point(5, 176);
            this.labelProgres.Name = "labelProgres";
            this.labelProgres.Size = new System.Drawing.Size(80, 24);
            this.labelProgres.TabIndex = 38;
            this.labelProgres.Text = "Progres";
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(458, 49);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 53);
            this.button1.TabIndex = 41;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAlocareAngajat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1777, 960);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelInformatiiTask);
            this.Controls.Add(this.checkBoxInformatiiTask);
            this.Controls.Add(this.comboBoxTaskuri);
            this.Controls.Add(this.comboBoxProiecte);
            this.Controls.Add(this.labelSelectareProiect);
            this.Controls.Add(this.labelSelectareTask);
            this.Controls.Add(this.panelListBoxPrevizualizareAngajati);
            this.Controls.Add(this.numericUpDownOreAlocate);
            this.Controls.Add(this.labelDataFinaliza);
            this.Controls.Add(this.dateTimePickerDataFinalizare);
            this.Controls.Add(this.dateTimePickerDataInceput);
            this.Controls.Add(this.panelAngajatiDisponibili);
            this.Controls.Add(this.buttonElimina);
            this.Controls.Add(this.buttonAdauga);
            this.Controls.Add(this.labelDataParticipare);
            this.Controls.Add(this.buttonAlocare);
            this.Name = "FormAlocareAngajat";
            this.Text = "FormAlocareAngajat";
            this.panelAngajatiDisponibili.ResumeLayout(false);
            this.panelAngajatiDisponibili.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOreAlocate)).EndInit();
            this.panelListBoxPrevizualizareAngajati.ResumeLayout(false);
            this.panelListBoxPrevizualizareAngajati.PerformLayout();
            this.panelInformatiiTask.ResumeLayout(false);
            this.panelInformatiiTask.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAlocare;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataInceput;
        private System.Windows.Forms.Label labelSelectareProiect;
        private System.Windows.Forms.Label labelSelectareTask;
        private System.Windows.Forms.Label labelDataParticipare;
        private System.Windows.Forms.Label labelAngajatiDisponibili;
        private System.Windows.Forms.ListBox listBoxAngajatiDisponibili;
        private System.Windows.Forms.ListBox listBoxNrOreRamase;
        private System.Windows.Forms.ListBox listBoxAfisareAngajatiSelectati;
        private System.Windows.Forms.Button buttonAdauga;
        private System.Windows.Forms.Button buttonElimina;
        private System.Windows.Forms.Panel panelAngajatiDisponibili;
        private System.Windows.Forms.Label labelOreAlocate;
        private System.Windows.Forms.TextBox textBoxOreAlocate;
        private System.Windows.Forms.TextBox textBoxOreNecesare;
        private System.Windows.Forms.Label labelOreNecesare;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataFinalizare;
        private System.Windows.Forms.Label labelDataFinaliza;
        private System.Windows.Forms.NumericUpDown numericUpDownOreAlocate;
        private System.Windows.Forms.ProgressBar progressBarNumarOreAlocate;
        private System.Windows.Forms.Label labelPrevizualizareAngajati;
        private System.Windows.Forms.Panel panelListBoxPrevizualizareAngajati;
        private System.Windows.Forms.ListBox listBoxPerioadeAngajatiPosibili;
        private System.Windows.Forms.ComboBox comboBoxProiecte;
        private System.Windows.Forms.ComboBox comboBoxTaskuri;
        private System.Windows.Forms.TextBox textBoxDataIncepereTask;
        private System.Windows.Forms.TextBox textBoxDataFinalizareTask;
        private System.Windows.Forms.Label labelDataIncepereTask;
        private System.Windows.Forms.Label labelDataFinalizareTask;
        private System.Windows.Forms.CheckBox checkBoxInformatiiTask;
        private System.Windows.Forms.Panel panelInformatiiTask;
        private System.Windows.Forms.Label labelPerioadaDeLucru;
        private System.Windows.Forms.Label labelProgres;
        private System.Windows.Forms.Button button1;
    }
}