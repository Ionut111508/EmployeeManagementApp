
namespace ManagementulProiectelor.Forms
{
    partial class FormAdmin
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
            this.buttonCreeazaNorma = new System.Windows.Forms.Button();
            this.buttonCreeazaSkill = new System.Windows.Forms.Button();
            this.buttonCreeazaDepartament = new System.Windows.Forms.Button();
            this.buttonCreeareCont = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreeazaNorma
            // 
            this.buttonCreeazaNorma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCreeazaNorma.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonCreeazaNorma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreeazaNorma.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCreeazaNorma.ForeColor = System.Drawing.Color.SpringGreen;
            this.buttonCreeazaNorma.Location = new System.Drawing.Point(465, 129);
            this.buttonCreeazaNorma.Name = "buttonCreeazaNorma";
            this.buttonCreeazaNorma.Size = new System.Drawing.Size(549, 93);
            this.buttonCreeazaNorma.TabIndex = 7;
            this.buttonCreeazaNorma.Text = "Creează normă";
            this.buttonCreeazaNorma.UseVisualStyleBackColor = false;
            this.buttonCreeazaNorma.Click += new System.EventHandler(this.buttonCreeazaNorma_Click);
            // 
            // buttonCreeazaSkill
            // 
            this.buttonCreeazaSkill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCreeazaSkill.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonCreeazaSkill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreeazaSkill.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCreeazaSkill.ForeColor = System.Drawing.Color.SpringGreen;
            this.buttonCreeazaSkill.Location = new System.Drawing.Point(466, 368);
            this.buttonCreeazaSkill.Name = "buttonCreeazaSkill";
            this.buttonCreeazaSkill.Size = new System.Drawing.Size(548, 88);
            this.buttonCreeazaSkill.TabIndex = 9;
            this.buttonCreeazaSkill.Text = "Creează skill";
            this.buttonCreeazaSkill.UseVisualStyleBackColor = false;
            this.buttonCreeazaSkill.Click += new System.EventHandler(this.buttonCreeazaSkill_Click_1);
            // 
            // buttonCreeazaDepartament
            // 
            this.buttonCreeazaDepartament.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCreeazaDepartament.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonCreeazaDepartament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreeazaDepartament.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCreeazaDepartament.ForeColor = System.Drawing.Color.SpringGreen;
            this.buttonCreeazaDepartament.Location = new System.Drawing.Point(465, 260);
            this.buttonCreeazaDepartament.Name = "buttonCreeazaDepartament";
            this.buttonCreeazaDepartament.Size = new System.Drawing.Size(549, 82);
            this.buttonCreeazaDepartament.TabIndex = 8;
            this.buttonCreeazaDepartament.Text = "Creează departament";
            this.buttonCreeazaDepartament.UseVisualStyleBackColor = false;
            this.buttonCreeazaDepartament.Click += new System.EventHandler(this.buttonCreeazaDepartament_Click_1);
            // 
            // buttonCreeareCont
            // 
            this.buttonCreeareCont.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCreeareCont.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonCreeareCont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreeareCont.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCreeareCont.ForeColor = System.Drawing.Color.SpringGreen;
            this.buttonCreeareCont.Location = new System.Drawing.Point(466, 478);
            this.buttonCreeareCont.Name = "buttonCreeareCont";
            this.buttonCreeareCont.Size = new System.Drawing.Size(548, 97);
            this.buttonCreeareCont.TabIndex = 6;
            this.buttonCreeareCont.Text = "Creeaza cont nou";
            this.buttonCreeareCont.UseVisualStyleBackColor = false;
            this.buttonCreeareCont.Visible = false;
            this.buttonCreeareCont.Click += new System.EventHandler(this.buttonCreeareCont_Click_1);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 725);
            this.Controls.Add(this.buttonCreeazaNorma);
            this.Controls.Add(this.buttonCreeazaSkill);
            this.Controls.Add(this.buttonCreeazaDepartament);
            this.Controls.Add(this.buttonCreeareCont);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreeazaNorma;
        private System.Windows.Forms.Button buttonCreeazaSkill;
        private System.Windows.Forms.Button buttonCreeazaDepartament;
        private System.Windows.Forms.Button buttonCreeareCont;
    }
}