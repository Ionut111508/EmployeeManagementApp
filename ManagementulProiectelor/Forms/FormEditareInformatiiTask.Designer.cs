
namespace ManagementulProiectelor.Forms
{
    partial class FormEditareInformatiiTask
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
            this.labelDenumireTask = new System.Windows.Forms.Label();
            this.labelDescriereTask = new System.Windows.Forms.Label();
            this.labelNumarOreNecesar = new System.Windows.Forms.Label();
            this.labelDataFinalizare = new System.Windows.Forms.Label();
            this.textBoxDenumire = new System.Windows.Forms.TextBox();
            this.richTextBoxDescriere = new System.Windows.Forms.RichTextBox();
            this.dateTimePickerDataFinalizare = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownNumarOreNecesar = new System.Windows.Forms.NumericUpDown();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonSalvare = new System.Windows.Forms.Button();
            this.dateTimePickerDataIncepere = new System.Windows.Forms.DateTimePicker();
            this.labelDataIncepere = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumarOreNecesar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDenumireTask
            // 
            this.labelDenumireTask.AutoSize = true;
            this.labelDenumireTask.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDenumireTask.Location = new System.Drawing.Point(327, 47);
            this.labelDenumireTask.Name = "labelDenumireTask";
            this.labelDenumireTask.Size = new System.Drawing.Size(114, 26);
            this.labelDenumireTask.TabIndex = 0;
            this.labelDenumireTask.Text = "Denumire";
            // 
            // labelDescriereTask
            // 
            this.labelDescriereTask.AutoSize = true;
            this.labelDescriereTask.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDescriereTask.Location = new System.Drawing.Point(327, 181);
            this.labelDescriereTask.Name = "labelDescriereTask";
            this.labelDescriereTask.Size = new System.Drawing.Size(111, 26);
            this.labelDescriereTask.TabIndex = 1;
            this.labelDescriereTask.Text = "Descriere";
            // 
            // labelNumarOreNecesar
            // 
            this.labelNumarOreNecesar.AutoSize = true;
            this.labelNumarOreNecesar.CausesValidation = false;
            this.labelNumarOreNecesar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNumarOreNecesar.Location = new System.Drawing.Point(327, 358);
            this.labelNumarOreNecesar.Name = "labelNumarOreNecesar";
            this.labelNumarOreNecesar.Size = new System.Drawing.Size(208, 26);
            this.labelNumarOreNecesar.TabIndex = 2;
            this.labelNumarOreNecesar.Text = "Număr ore necesar";
            // 
            // labelDataFinalizare
            // 
            this.labelDataFinalizare.AutoSize = true;
            this.labelDataFinalizare.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDataFinalizare.Location = new System.Drawing.Point(327, 567);
            this.labelDataFinalizare.Name = "labelDataFinalizare";
            this.labelDataFinalizare.Size = new System.Drawing.Size(193, 26);
            this.labelDataFinalizare.TabIndex = 3;
            this.labelDataFinalizare.Text = "Data de finalizare";
            // 
            // textBoxDenumire
            // 
            this.textBoxDenumire.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDenumire.Location = new System.Drawing.Point(585, 48);
            this.textBoxDenumire.Name = "textBoxDenumire";
            this.textBoxDenumire.Size = new System.Drawing.Size(351, 35);
            this.textBoxDenumire.TabIndex = 4;
            this.textBoxDenumire.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // richTextBoxDescriere
            // 
            this.richTextBoxDescriere.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxDescriere.Location = new System.Drawing.Point(585, 132);
            this.richTextBoxDescriere.Name = "richTextBoxDescriere";
            this.richTextBoxDescriere.Size = new System.Drawing.Size(351, 132);
            this.richTextBoxDescriere.TabIndex = 7;
            this.richTextBoxDescriere.Text = "";
            // 
            // dateTimePickerDataFinalizare
            // 
            this.dateTimePickerDataFinalizare.CalendarFont = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataFinalizare.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataFinalizare.Location = new System.Drawing.Point(585, 561);
            this.dateTimePickerDataFinalizare.Name = "dateTimePickerDataFinalizare";
            this.dateTimePickerDataFinalizare.Size = new System.Drawing.Size(351, 32);
            this.dateTimePickerDataFinalizare.TabIndex = 8;
            // 
            // numericUpDownNumarOreNecesar
            // 
            this.numericUpDownNumarOreNecesar.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownNumarOreNecesar.Location = new System.Drawing.Point(659, 352);
            this.numericUpDownNumarOreNecesar.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownNumarOreNecesar.Name = "numericUpDownNumarOreNecesar";
            this.numericUpDownNumarOreNecesar.Size = new System.Drawing.Size(187, 32);
            this.numericUpDownNumarOreNecesar.TabIndex = 9;
            this.numericUpDownNumarOreNecesar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonHome
            // 
            this.buttonHome.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonHome.Location = new System.Drawing.Point(123, 719);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(115, 42);
            this.buttonHome.TabIndex = 10;
            this.buttonHome.Text = "Înapoi";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonSalvare
            // 
            this.buttonSalvare.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSalvare.Location = new System.Drawing.Point(1091, 719);
            this.buttonSalvare.Name = "buttonSalvare";
            this.buttonSalvare.Size = new System.Drawing.Size(115, 42);
            this.buttonSalvare.TabIndex = 11;
            this.buttonSalvare.Text = "Salvare";
            this.buttonSalvare.UseVisualStyleBackColor = true;
            this.buttonSalvare.Click += new System.EventHandler(this.buttonSalvare_Click);
            // 
            // dateTimePickerDataIncepere
            // 
            this.dateTimePickerDataIncepere.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataIncepere.Location = new System.Drawing.Point(585, 458);
            this.dateTimePickerDataIncepere.Name = "dateTimePickerDataIncepere";
            this.dateTimePickerDataIncepere.Size = new System.Drawing.Size(351, 32);
            this.dateTimePickerDataIncepere.TabIndex = 12;
            // 
            // labelDataIncepere
            // 
            this.labelDataIncepere.AutoSize = true;
            this.labelDataIncepere.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDataIncepere.Location = new System.Drawing.Point(327, 464);
            this.labelDataIncepere.Name = "labelDataIncepere";
            this.labelDataIncepere.Size = new System.Drawing.Size(185, 26);
            this.labelDataIncepere.TabIndex = 13;
            this.labelDataIncepere.Text = "Data de începere";
            // 
            // FormEditareInformatiiTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 796);
            this.Controls.Add(this.labelDataIncepere);
            this.Controls.Add(this.dateTimePickerDataIncepere);
            this.Controls.Add(this.buttonSalvare);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.numericUpDownNumarOreNecesar);
            this.Controls.Add(this.dateTimePickerDataFinalizare);
            this.Controls.Add(this.richTextBoxDescriere);
            this.Controls.Add(this.textBoxDenumire);
            this.Controls.Add(this.labelDataFinalizare);
            this.Controls.Add(this.labelNumarOreNecesar);
            this.Controls.Add(this.labelDescriereTask);
            this.Controls.Add(this.labelDenumireTask);
            this.Name = "FormEditareInformatiiTask";
            this.Text = "FormEditareInformatiiTask";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumarOreNecesar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDenumireTask;
        private System.Windows.Forms.Label labelDescriereTask;
        private System.Windows.Forms.Label labelNumarOreNecesar;
        private System.Windows.Forms.Label labelDataFinalizare;
        private System.Windows.Forms.TextBox textBoxDenumire;
        private System.Windows.Forms.RichTextBox richTextBoxDescriere;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataFinalizare;
        private System.Windows.Forms.NumericUpDown numericUpDownNumarOreNecesar;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonSalvare;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataIncepere;
        private System.Windows.Forms.Label labelDataIncepere;
    }
}