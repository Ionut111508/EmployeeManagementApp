
namespace ManagementulProiectelor
{
    partial class FormCreeareCont
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
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxParola = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelParola = new System.Windows.Forms.Label();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonCreeazaCont = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxUsername.Location = new System.Drawing.Point(254, 103);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(206, 35);
            this.textBoxUsername.TabIndex = 0;
            // 
            // textBoxParola
            // 
            this.textBoxParola.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxParola.Location = new System.Drawing.Point(254, 153);
            this.textBoxParola.Name = "textBoxParola";
            this.textBoxParola.Size = new System.Drawing.Size(206, 35);
            this.textBoxParola.TabIndex = 1;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelUsername.Location = new System.Drawing.Point(120, 106);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(115, 26);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Username";
            // 
            // labelParola
            // 
            this.labelParola.AutoSize = true;
            this.labelParola.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelParola.Location = new System.Drawing.Point(120, 156);
            this.labelParola.Name = "labelParola";
            this.labelParola.Size = new System.Drawing.Size(81, 26);
            this.labelParola.TabIndex = 3;
            this.labelParola.Text = "Parola";
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(25, 404);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(75, 23);
            this.buttonHome.TabIndex = 4;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(678, 404);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonCreeazaCont
            // 
            this.buttonCreeazaCont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonCreeazaCont.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonCreeazaCont.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCreeazaCont.Location = new System.Drawing.Point(120, 222);
            this.buttonCreeazaCont.Name = "buttonCreeazaCont";
            this.buttonCreeazaCont.Size = new System.Drawing.Size(282, 89);
            this.buttonCreeazaCont.TabIndex = 6;
            this.buttonCreeazaCont.Text = "Creeaza cont";
            this.buttonCreeazaCont.UseVisualStyleBackColor = false;
            this.buttonCreeazaCont.Click += new System.EventHandler(this.buttonCreeazaCont_Click);
            // 
            // FormCreeareCont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCreeazaCont);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.labelParola);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.textBoxParola);
            this.Controls.Add(this.textBoxUsername);
            this.Name = "FormCreeareCont";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creeare cont";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxParola;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelParola;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonCreeazaCont;
    }
}