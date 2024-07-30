
namespace ManagementulProiectelor.Forms
{
    partial class FormLogare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogare));
            this.button1 = new System.Windows.Forms.Button();
            this.labelDenumire = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxAfisareParola = new System.Windows.Forms.CheckBox();
            this.buttonLogare = new System.Windows.Forms.Button();
            this.textBoxNumeUtilizator = new System.Windows.Forms.TextBox();
            this.textBoxParola = new System.Windows.Forms.TextBox();
            this.labelNumeUtilizator = new System.Windows.Forms.Label();
            this.labelParola = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelWindowButtons = new System.Windows.Forms.Panel();
            this.buttonShowHideApp = new System.Windows.Forms.Button();
            this.iconExit = new FontAwesome.Sharp.IconButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelWindowButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(108, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(217, 170);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // labelDenumire
            // 
            this.labelDenumire.AutoSize = true;
            this.labelDenumire.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDenumire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labelDenumire.Location = new System.Drawing.Point(385, 71);
            this.labelDenumire.Margin = new System.Windows.Forms.Padding(0);
            this.labelDenumire.Name = "labelDenumire";
            this.labelDenumire.Size = new System.Drawing.Size(325, 31);
            this.labelDenumire.TabIndex = 1;
            this.labelDenumire.Text = "Managementul Proiectelor";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.Controls.Add(this.checkBoxAfisareParola);
            this.panel2.Controls.Add(this.buttonLogare);
            this.panel2.Controls.Add(this.textBoxNumeUtilizator);
            this.panel2.Controls.Add(this.textBoxParola);
            this.panel2.Controls.Add(this.labelNumeUtilizator);
            this.panel2.Controls.Add(this.labelParola);
            this.panel2.Location = new System.Drawing.Point(320, 170);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 324);
            this.panel2.TabIndex = 6;
            // 
            // checkBoxAfisareParola
            // 
            this.checkBoxAfisareParola.AutoSize = true;
            this.checkBoxAfisareParola.Location = new System.Drawing.Point(83, 205);
            this.checkBoxAfisareParola.Name = "checkBoxAfisareParola";
            this.checkBoxAfisareParola.Size = new System.Drawing.Size(105, 19);
            this.checkBoxAfisareParola.TabIndex = 7;
            this.checkBoxAfisareParola.Text = "Afiseaza parola";
            this.checkBoxAfisareParola.UseVisualStyleBackColor = true;
            this.checkBoxAfisareParola.CheckedChanged += new System.EventHandler(this.checkBoxAfisareParola_CheckedChanged);
            // 
            // buttonLogare
            // 
            this.buttonLogare.Location = new System.Drawing.Point(181, 251);
            this.buttonLogare.Name = "buttonLogare";
            this.buttonLogare.Size = new System.Drawing.Size(75, 23);
            this.buttonLogare.TabIndex = 6;
            this.buttonLogare.Text = "Logare";
            this.buttonLogare.UseVisualStyleBackColor = true;
            this.buttonLogare.Click += new System.EventHandler(this.buttonLogare_Click);
            // 
            // textBoxNumeUtilizator
            // 
            this.textBoxNumeUtilizator.Location = new System.Drawing.Point(83, 82);
            this.textBoxNumeUtilizator.Multiline = true;
            this.textBoxNumeUtilizator.Name = "textBoxNumeUtilizator";
            this.textBoxNumeUtilizator.PlaceholderText = "Nume de utilizator";
            this.textBoxNumeUtilizator.Size = new System.Drawing.Size(300, 30);
            this.textBoxNumeUtilizator.TabIndex = 4;
            // 
            // textBoxParola
            // 
            this.textBoxParola.Location = new System.Drawing.Point(83, 168);
            this.textBoxParola.Multiline = true;
            this.textBoxParola.Name = "textBoxParola";
            this.textBoxParola.PasswordChar = '*';
            this.textBoxParola.PlaceholderText = "Parola";
            this.textBoxParola.Size = new System.Drawing.Size(300, 30);
            this.textBoxParola.TabIndex = 5;
            // 
            // labelNumeUtilizator
            // 
            this.labelNumeUtilizator.AutoSize = true;
            this.labelNumeUtilizator.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNumeUtilizator.Location = new System.Drawing.Point(130, 43);
            this.labelNumeUtilizator.Name = "labelNumeUtilizator";
            this.labelNumeUtilizator.Size = new System.Drawing.Size(193, 25);
            this.labelNumeUtilizator.TabIndex = 2;
            this.labelNumeUtilizator.Text = "Nume de utilizator:";
            // 
            // labelParola
            // 
            this.labelParola.AutoSize = true;
            this.labelParola.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelParola.Location = new System.Drawing.Point(175, 140);
            this.labelParola.Name = "labelParola";
            this.labelParola.Size = new System.Drawing.Size(81, 25);
            this.labelParola.TabIndex = 3;
            this.labelParola.Text = "Parolă:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panelWindowButtons);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelDenumire);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(977, 647);
            this.panel1.MinimumSize = new System.Drawing.Size(977, 647);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 647);
            this.panel1.TabIndex = 0;
            // 
            // panelWindowButtons
            // 
            this.panelWindowButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWindowButtons.Controls.Add(this.buttonShowHideApp);
            this.panelWindowButtons.Controls.Add(this.iconExit);
            this.panelWindowButtons.Location = new System.Drawing.Point(876, 3);
            this.panelWindowButtons.Name = "panelWindowButtons";
            this.panelWindowButtons.Size = new System.Drawing.Size(101, 30);
            this.panelWindowButtons.TabIndex = 1;
            // 
            // buttonShowHideApp
            // 
            this.buttonShowHideApp.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonShowHideApp.FlatAppearance.BorderSize = 0;
            this.buttonShowHideApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowHideApp.Image = ((System.Drawing.Image)(resources.GetObject("buttonShowHideApp.Image")));
            this.buttonShowHideApp.Location = new System.Drawing.Point(0, 0);
            this.buttonShowHideApp.Name = "buttonShowHideApp";
            this.buttonShowHideApp.Size = new System.Drawing.Size(54, 30);
            this.buttonShowHideApp.TabIndex = 11;
            this.buttonShowHideApp.UseVisualStyleBackColor = true;
            this.buttonShowHideApp.Click += new System.EventHandler(this.buttonShowHideApp_Click);
            // 
            // iconExit
            // 
            this.iconExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconExit.FlatAppearance.BorderSize = 0;
            this.iconExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconExit.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.iconExit.IconChar = FontAwesome.Sharp.IconChar.X;
            this.iconExit.IconColor = System.Drawing.Color.Black;
            this.iconExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconExit.IconSize = 25;
            this.iconExit.Location = new System.Drawing.Point(51, 0);
            this.iconExit.Name = "iconExit";
            this.iconExit.Size = new System.Drawing.Size(50, 30);
            this.iconExit.TabIndex = 10;
            this.iconExit.UseVisualStyleBackColor = true;
            this.iconExit.Click += new System.EventHandler(this.iconExit_Click);
            // 
            // FormLogare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 647);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelWindowButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelDenumire;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxNumeUtilizator;
        private System.Windows.Forms.TextBox textBoxParola;
        private System.Windows.Forms.Label labelNumeUtilizator;
        private System.Windows.Forms.Label labelParola;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonLogare;
        private System.Windows.Forms.CheckBox checkBoxAfisareParola;
        private System.Windows.Forms.Panel panelWindowButtons;
        private FontAwesome.Sharp.IconButton iconButtonMaximizeMinimize;
        private System.Windows.Forms.Button buttonShowHideApp;
        private FontAwesome.Sharp.IconButton iconExit;
    }
}