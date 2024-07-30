
namespace ManagementulProiectelor
{
    partial class FormCreeazaDepartament
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
            this.labelDenumire = new System.Windows.Forms.Label();
            this.textBoxDenumireDepartament = new System.Windows.Forms.TextBox();
            this.buttonCreeazaDepartament = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonHome
            // 
            this.buttonHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHome.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonHome.Location = new System.Drawing.Point(12, 341);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(139, 51);
            this.buttonHome.TabIndex = 17;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonExit.Location = new System.Drawing.Point(392, 341);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(132, 51);
            this.buttonExit.TabIndex = 18;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelDenumire
            // 
            this.labelDenumire.AutoSize = true;
            this.labelDenumire.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDenumire.Location = new System.Drawing.Point(143, 51);
            this.labelDenumire.Name = "labelDenumire";
            this.labelDenumire.Size = new System.Drawing.Size(286, 31);
            this.labelDenumire.TabIndex = 19;
            this.labelDenumire.Text = "Denumire departament";
            // 
            // textBoxDenumireDepartament
            // 
            this.textBoxDenumireDepartament.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDenumireDepartament.Location = new System.Drawing.Point(113, 130);
            this.textBoxDenumireDepartament.Name = "textBoxDenumireDepartament";
            this.textBoxDenumireDepartament.Size = new System.Drawing.Size(354, 32);
            this.textBoxDenumireDepartament.TabIndex = 22;
            // 
            // buttonCreeazaDepartament
            // 
            this.buttonCreeazaDepartament.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCreeazaDepartament.Location = new System.Drawing.Point(153, 198);
            this.buttonCreeazaDepartament.Name = "buttonCreeazaDepartament";
            this.buttonCreeazaDepartament.Size = new System.Drawing.Size(276, 65);
            this.buttonCreeazaDepartament.TabIndex = 23;
            this.buttonCreeazaDepartament.Text = "Creează departament";
            this.buttonCreeazaDepartament.UseVisualStyleBackColor = true;
            this.buttonCreeazaDepartament.Click += new System.EventHandler(this.buttonCreeazaDepartament_Click);
            // 
            // FormCreeazaDepartament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 404);
            this.Controls.Add(this.buttonCreeazaDepartament);
            this.Controls.Add(this.textBoxDenumireDepartament);
            this.Controls.Add(this.labelDenumire);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonHome);
            this.Name = "FormCreeazaDepartament";
            this.Text = "FormCreeazaDepartament";
            this.Load += new System.EventHandler(this.FormCreeazaDepartament_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelDenumire;
        private System.Windows.Forms.TextBox textBoxDenumireDepartament;
        private System.Windows.Forms.Button buttonCreeazaDepartament;
    }
}