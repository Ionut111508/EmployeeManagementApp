
namespace ManagementulProiectelor
{
    partial class FormCreeareNorma
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
            this.buttonAdaugareNorma = new System.Windows.Forms.Button();
            this.labelDenumire = new System.Windows.Forms.Label();
            this.labelNumarOre = new System.Windows.Forms.Label();
            this.textBoxDenumire = new System.Windows.Forms.TextBox();
            this.numericUpDownNumarOre = new System.Windows.Forms.NumericUpDown();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumarOre)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAdaugareNorma
            // 
            this.buttonAdaugareNorma.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdaugareNorma.Location = new System.Drawing.Point(219, 190);
            this.buttonAdaugareNorma.Name = "buttonAdaugareNorma";
            this.buttonAdaugareNorma.Size = new System.Drawing.Size(241, 53);
            this.buttonAdaugareNorma.TabIndex = 0;
            this.buttonAdaugareNorma.Text = "Adaugă normă";
            this.buttonAdaugareNorma.UseVisualStyleBackColor = true;
            this.buttonAdaugareNorma.Click += new System.EventHandler(this.buttonAdaugareNorma_Click);
            // 
            // labelDenumire
            // 
            this.labelDenumire.AutoSize = true;
            this.labelDenumire.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDenumire.Location = new System.Drawing.Point(97, 50);
            this.labelDenumire.Name = "labelDenumire";
            this.labelDenumire.Size = new System.Drawing.Size(114, 26);
            this.labelDenumire.TabIndex = 1;
            this.labelDenumire.Text = "Denumire";
            // 
            // labelNumarOre
            // 
            this.labelNumarOre.AutoSize = true;
            this.labelNumarOre.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNumarOre.Location = new System.Drawing.Point(97, 113);
            this.labelNumarOre.Name = "labelNumarOre";
            this.labelNumarOre.Size = new System.Drawing.Size(124, 26);
            this.labelNumarOre.TabIndex = 2;
            this.labelNumarOre.Text = "Numar ore";
            // 
            // textBoxDenumire
            // 
            this.textBoxDenumire.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDenumire.Location = new System.Drawing.Point(261, 50);
            this.textBoxDenumire.Name = "textBoxDenumire";
            this.textBoxDenumire.Size = new System.Drawing.Size(271, 35);
            this.textBoxDenumire.TabIndex = 3;
            // 
            // numericUpDownNumarOre
            // 
            this.numericUpDownNumarOre.DecimalPlaces = 1;
            this.numericUpDownNumarOre.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownNumarOre.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownNumarOre.Location = new System.Drawing.Point(261, 104);
            this.numericUpDownNumarOre.Name = "numericUpDownNumarOre";
            this.numericUpDownNumarOre.Size = new System.Drawing.Size(100, 35);
            this.numericUpDownNumarOre.TabIndex = 4;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonExit.Location = new System.Drawing.Point(499, 310);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(105, 44);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonHome.Location = new System.Drawing.Point(97, 310);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(105, 44);
            this.buttonHome.TabIndex = 6;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // FormCreeareNorma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 438);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.numericUpDownNumarOre);
            this.Controls.Add(this.textBoxDenumire);
            this.Controls.Add(this.labelNumarOre);
            this.Controls.Add(this.labelDenumire);
            this.Controls.Add(this.buttonAdaugareNorma);
            this.Name = "FormCreeareNorma";
            this.Text = "FormCreeareNorma";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumarOre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdaugareNorma;
        private System.Windows.Forms.Label labelDenumire;
        private System.Windows.Forms.Label labelNumarOre;
        private System.Windows.Forms.TextBox textBoxDenumire;
        private System.Windows.Forms.NumericUpDown numericUpDownNumarOre;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonHome;
    }
}