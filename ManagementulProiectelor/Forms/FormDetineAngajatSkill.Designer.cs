
namespace ManagementulProiectelor.Forms
{
    partial class FormDetineAngajatSkill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetineAngajatSkill));
            this.listBoxAngajati = new System.Windows.Forms.ListBox();
            this.buttonAdaugaSkill = new System.Windows.Forms.Button();
            this.comboBoxNivelSkilluri = new System.Windows.Forms.ComboBox();
            this.labelNivelSkilluri = new System.Windows.Forms.Label();
            this.labelDenumireSkill = new System.Windows.Forms.Label();
            this.comboBoxDenumireSkilluri = new System.Windows.Forms.ComboBox();
            this.listBoxAfisareSkilluri = new System.Windows.Forms.ListBox();
            this.labelAngajat = new System.Windows.Forms.Label();
            this.labelSkilluri = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxAngajati
            // 
            this.listBoxAngajati.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxAngajati.FormattingEnabled = true;
            this.listBoxAngajati.ItemHeight = 31;
            this.listBoxAngajati.Location = new System.Drawing.Point(273, 132);
            this.listBoxAngajati.Name = "listBoxAngajati";
            this.listBoxAngajati.Size = new System.Drawing.Size(480, 345);
            this.listBoxAngajati.TabIndex = 0;
            this.listBoxAngajati.SelectedIndexChanged += new System.EventHandler(this.listBoxAngajati_SelectedIndexChanged);
            // 
            // buttonAdaugaSkill
            // 
            this.buttonAdaugaSkill.Location = new System.Drawing.Point(864, 705);
            this.buttonAdaugaSkill.Name = "buttonAdaugaSkill";
            this.buttonAdaugaSkill.Size = new System.Drawing.Size(243, 60);
            this.buttonAdaugaSkill.TabIndex = 2;
            this.buttonAdaugaSkill.Text = "Alocare skill";
            this.buttonAdaugaSkill.UseVisualStyleBackColor = true;
            this.buttonAdaugaSkill.Visible = false;
            this.buttonAdaugaSkill.Click += new System.EventHandler(this.buttonAdaugaSkill_Click);
            // 
            // comboBoxNivelSkilluri
            // 
            this.comboBoxNivelSkilluri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNivelSkilluri.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxNivelSkilluri.FormattingEnabled = true;
            this.comboBoxNivelSkilluri.Location = new System.Drawing.Point(819, 634);
            this.comboBoxNivelSkilluri.Name = "comboBoxNivelSkilluri";
            this.comboBoxNivelSkilluri.Size = new System.Drawing.Size(344, 35);
            this.comboBoxNivelSkilluri.TabIndex = 20;
            this.comboBoxNivelSkilluri.Visible = false;
            // 
            // labelNivelSkilluri
            // 
            this.labelNivelSkilluri.AutoSize = true;
            this.labelNivelSkilluri.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNivelSkilluri.Location = new System.Drawing.Point(946, 604);
            this.labelNivelSkilluri.Name = "labelNivelSkilluri";
            this.labelNivelSkilluri.Size = new System.Drawing.Size(109, 27);
            this.labelNivelSkilluri.TabIndex = 21;
            this.labelNivelSkilluri.Text = "Nivel skill";
            this.labelNivelSkilluri.Visible = false;
            // 
            // labelDenumireSkill
            // 
            this.labelDenumireSkill.AutoSize = true;
            this.labelDenumireSkill.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDenumireSkill.Location = new System.Drawing.Point(927, 504);
            this.labelDenumireSkill.Name = "labelDenumireSkill";
            this.labelDenumireSkill.Size = new System.Drawing.Size(152, 27);
            this.labelDenumireSkill.TabIndex = 22;
            this.labelDenumireSkill.Text = "Denumire skill";
            this.labelDenumireSkill.Visible = false;
            // 
            // comboBoxDenumireSkilluri
            // 
            this.comboBoxDenumireSkilluri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDenumireSkilluri.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxDenumireSkilluri.FormattingEnabled = true;
            this.comboBoxDenumireSkilluri.Location = new System.Drawing.Point(819, 534);
            this.comboBoxDenumireSkilluri.Name = "comboBoxDenumireSkilluri";
            this.comboBoxDenumireSkilluri.Size = new System.Drawing.Size(344, 35);
            this.comboBoxDenumireSkilluri.TabIndex = 23;
            this.comboBoxDenumireSkilluri.Visible = false;
            // 
            // listBoxAfisareSkilluri
            // 
            this.listBoxAfisareSkilluri.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxAfisareSkilluri.FormattingEnabled = true;
            this.listBoxAfisareSkilluri.ItemHeight = 31;
            this.listBoxAfisareSkilluri.Location = new System.Drawing.Point(759, 132);
            this.listBoxAfisareSkilluri.Name = "listBoxAfisareSkilluri";
            this.listBoxAfisareSkilluri.Size = new System.Drawing.Size(512, 345);
            this.listBoxAfisareSkilluri.TabIndex = 28;
            this.listBoxAfisareSkilluri.SelectedIndexChanged += new System.EventHandler(this.listBoxAfisareSkilluri_SelectedIndexChanged);
            // 
            // labelAngajat
            // 
            this.labelAngajat.AutoSize = true;
            this.labelAngajat.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAngajat.Location = new System.Drawing.Point(273, 97);
            this.labelAngajat.Name = "labelAngajat";
            this.labelAngajat.Size = new System.Drawing.Size(251, 31);
            this.labelAngajat.TabIndex = 29;
            this.labelAngajat.Text = "Selecteaza angajatul";
            // 
            // labelSkilluri
            // 
            this.labelSkilluri.AutoSize = true;
            this.labelSkilluri.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSkilluri.Location = new System.Drawing.Point(759, 97);
            this.labelSkilluri.Name = "labelSkilluri";
            this.labelSkilluri.Size = new System.Drawing.Size(193, 31);
            this.labelSkilluri.TabIndex = 31;
            this.labelSkilluri.Text = "Skilluri alocate";
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Image")));
            this.buttonAdd.Location = new System.Drawing.Point(1277, 132);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(40, 40);
            this.buttonAdd.TabIndex = 32;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
            this.buttonRemove.Location = new System.Drawing.Point(1278, 179);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(39, 42);
            this.buttonRemove.TabIndex = 33;
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // FormDetineAngajatSkill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 842);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelSkilluri);
            this.Controls.Add(this.labelAngajat);
            this.Controls.Add(this.listBoxAfisareSkilluri);
            this.Controls.Add(this.comboBoxDenumireSkilluri);
            this.Controls.Add(this.labelDenumireSkill);
            this.Controls.Add(this.labelNivelSkilluri);
            this.Controls.Add(this.comboBoxNivelSkilluri);
            this.Controls.Add(this.buttonAdaugaSkill);
            this.Controls.Add(this.listBoxAngajati);
            this.Name = "FormDetineAngajatSkill";
            this.Load += new System.EventHandler(this.FormDetineAngajatSkill_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAngajati;
        private System.Windows.Forms.Button buttonAdaugaSkill;
        private System.Windows.Forms.ComboBox comboBoxNivelSkilluri;
        private System.Windows.Forms.Label labelNivelSkilluri;
        private System.Windows.Forms.Label labelDenumireSkill;
        private System.Windows.Forms.ComboBox comboBoxDenumireSkilluri;
        private System.Windows.Forms.ListBox listBoxAfisareSkilluri;
        private System.Windows.Forms.Label labelAngajat;
        private System.Windows.Forms.Label labelSkilluri;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
    }
}