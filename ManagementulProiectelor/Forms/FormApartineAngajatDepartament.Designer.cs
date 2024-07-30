
namespace ManagementulProiectelor.Forms
{
    partial class FormApartineAngajatDepartament
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApartineAngajatDepartament));
            this.listBoxAngajati = new System.Windows.Forms.ListBox();
            this.listBoxDepartamente = new System.Windows.Forms.ListBox();
            this.buttonAlocareDepartament = new System.Windows.Forms.Button();
            this.listBoxApartine = new System.Windows.Forms.ListBox();
            this.labelAngajati = new System.Windows.Forms.Label();
            this.labelApartine = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxAngajati
            // 
            this.listBoxAngajati.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxAngajati.FormattingEnabled = true;
            this.listBoxAngajati.ItemHeight = 31;
            this.listBoxAngajati.Location = new System.Drawing.Point(289, 86);
            this.listBoxAngajati.Name = "listBoxAngajati";
            this.listBoxAngajati.Size = new System.Drawing.Size(461, 376);
            this.listBoxAngajati.TabIndex = 1;
            this.listBoxAngajati.SelectedIndexChanged += new System.EventHandler(this.listBoxAngajati_SelectedIndexChanged);
            // 
            // listBoxDepartamente
            // 
            this.listBoxDepartamente.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxDepartamente.FormattingEnabled = true;
            this.listBoxDepartamente.ItemHeight = 31;
            this.listBoxDepartamente.Location = new System.Drawing.Point(460, 474);
            this.listBoxDepartamente.Name = "listBoxDepartamente";
            this.listBoxDepartamente.Size = new System.Drawing.Size(581, 221);
            this.listBoxDepartamente.TabIndex = 2;
            this.listBoxDepartamente.Visible = false;
            // 
            // buttonAlocareDepartament
            // 
            this.buttonAlocareDepartament.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAlocareDepartament.Location = new System.Drawing.Point(665, 701);
            this.buttonAlocareDepartament.Name = "buttonAlocareDepartament";
            this.buttonAlocareDepartament.Size = new System.Drawing.Size(231, 55);
            this.buttonAlocareDepartament.TabIndex = 3;
            this.buttonAlocareDepartament.Text = "Aloca departament";
            this.buttonAlocareDepartament.UseVisualStyleBackColor = true;
            this.buttonAlocareDepartament.Visible = false;
            this.buttonAlocareDepartament.Click += new System.EventHandler(this.buttonAlocareDepartament_Click);
            // 
            // listBoxApartine
            // 
            this.listBoxApartine.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxApartine.FormattingEnabled = true;
            this.listBoxApartine.ItemHeight = 27;
            this.listBoxApartine.Location = new System.Drawing.Point(792, 86);
            this.listBoxApartine.Name = "listBoxApartine";
            this.listBoxApartine.Size = new System.Drawing.Size(471, 382);
            this.listBoxApartine.TabIndex = 7;
            // 
            // labelAngajati
            // 
            this.labelAngajati.AutoSize = true;
            this.labelAngajati.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAngajati.Location = new System.Drawing.Point(289, 51);
            this.labelAngajati.Name = "labelAngajati";
            this.labelAngajati.Size = new System.Drawing.Size(251, 31);
            this.labelAngajati.TabIndex = 8;
            this.labelAngajati.Text = "Selecteaza angajatul";
            // 
            // labelApartine
            // 
            this.labelApartine.AutoSize = true;
            this.labelApartine.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelApartine.Location = new System.Drawing.Point(792, 51);
            this.labelApartine.Name = "labelApartine";
            this.labelApartine.Size = new System.Drawing.Size(271, 31);
            this.labelApartine.TabIndex = 9;
            this.labelApartine.Text = "Departamente actuale";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
            this.buttonRemove.Location = new System.Drawing.Point(1270, 133);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(39, 42);
            this.buttonRemove.TabIndex = 35;
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Image")));
            this.buttonAdd.Location = new System.Drawing.Point(1269, 86);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(40, 40);
            this.buttonAdd.TabIndex = 34;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // FormApartineAngajatDepartament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 810);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelApartine);
            this.Controls.Add(this.labelAngajati);
            this.Controls.Add(this.listBoxApartine);
            this.Controls.Add(this.buttonAlocareDepartament);
            this.Controls.Add(this.listBoxDepartamente);
            this.Controls.Add(this.listBoxAngajati);
            this.Name = "FormApartineAngajatDepartament";
            this.Text = "FormApartineAngajatDepartament";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAngajati;
        private System.Windows.Forms.ListBox listBoxDepartamente;
        private System.Windows.Forms.Button buttonAlocareDepartament;
        private System.Windows.Forms.ListBox listBoxApartine;
        private System.Windows.Forms.Label labelAngajati;
        private System.Windows.Forms.Label labelApartine;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
    }
}