
namespace ManagementulProiectelor.Forms
{
    partial class FormCreeareSkill
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
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonAdaugareSkill = new System.Windows.Forms.Button();
            this.labelDenumire = new System.Windows.Forms.Label();
            this.textBoxDenumireSkill = new System.Windows.Forms.TextBox();
            this.labelSkilluriExistente = new System.Windows.Forms.Label();
            this.listBoxSkilluri = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonHome
            // 
            this.buttonHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHome.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonHome.Location = new System.Drawing.Point(27, 491);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(106, 50);
            this.buttonHome.TabIndex = 18;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonExit.Location = new System.Drawing.Point(457, 491);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(141, 50);
            this.buttonExit.TabIndex = 19;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonAdaugareSkill
            // 
            this.buttonAdaugareSkill.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdaugareSkill.Location = new System.Drawing.Point(205, 343);
            this.buttonAdaugareSkill.Name = "buttonAdaugareSkill";
            this.buttonAdaugareSkill.Size = new System.Drawing.Size(220, 79);
            this.buttonAdaugareSkill.TabIndex = 20;
            this.buttonAdaugareSkill.Text = "Adăugare skill";
            this.buttonAdaugareSkill.UseVisualStyleBackColor = true;
            this.buttonAdaugareSkill.Click += new System.EventHandler(this.buttonAdaugareSkill_Click);
            // 
            // labelDenumire
            // 
            this.labelDenumire.AutoSize = true;
            this.labelDenumire.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDenumire.Location = new System.Drawing.Point(69, 118);
            this.labelDenumire.Name = "labelDenumire";
            this.labelDenumire.Size = new System.Drawing.Size(152, 27);
            this.labelDenumire.TabIndex = 21;
            this.labelDenumire.Text = "Denumire skill";
            // 
            // textBoxDenumireSkill
            // 
            this.textBoxDenumireSkill.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDenumireSkill.Location = new System.Drawing.Point(36, 148);
            this.textBoxDenumireSkill.Name = "textBoxDenumireSkill";
            this.textBoxDenumireSkill.Size = new System.Drawing.Size(243, 35);
            this.textBoxDenumireSkill.TabIndex = 23;
            // 
            // labelSkilluriExistente
            // 
            this.labelSkilluriExistente.AutoSize = true;
            this.labelSkilluriExistente.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSkilluriExistente.Location = new System.Drawing.Point(353, 20);
            this.labelSkilluriExistente.Name = "labelSkilluriExistente";
            this.labelSkilluriExistente.Size = new System.Drawing.Size(211, 31);
            this.labelSkilluriExistente.TabIndex = 27;
            this.labelSkilluriExistente.Text = "Skilluri existente";
            // 
            // listBoxSkilluri
            // 
            this.listBoxSkilluri.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxSkilluri.FormattingEnabled = true;
            this.listBoxSkilluri.ItemHeight = 31;
            this.listBoxSkilluri.Location = new System.Drawing.Point(321, 54);
            this.listBoxSkilluri.Name = "listBoxSkilluri";
            this.listBoxSkilluri.Size = new System.Drawing.Size(277, 252);
            this.listBoxSkilluri.TabIndex = 28;
            // 
            // FormCreeareSkill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 641);
            this.Controls.Add(this.listBoxSkilluri);
            this.Controls.Add(this.labelSkilluriExistente);
            this.Controls.Add(this.textBoxDenumireSkill);
            this.Controls.Add(this.labelDenumire);
            this.Controls.Add(this.buttonAdaugareSkill);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonHome);
            this.Name = "FormCreeareSkill";
            this.Text = "FormSkill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonAdaugareSkill;
        private System.Windows.Forms.Label labelDenumire;
        private System.Windows.Forms.Label labelSkilluriExistente;
        private System.Windows.Forms.ListBox listBoxSkilluri;
        private System.Windows.Forms.TextBox textBoxDenumireSkill;
    }
}