
namespace ManagementulProiectelor.Forms
{
    partial class FormCreeareTask
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
            this.textBoxDenumireTask = new System.Windows.Forms.TextBox();
            this.labelDemireTask = new System.Windows.Forms.Label();
            this.labelDescriereTask = new System.Windows.Forms.Label();
            this.listBoxProiecte = new System.Windows.Forms.ListBox();
            this.buttonCreeazaTask = new System.Windows.Forms.Button();
            this.dateTimePickerDataIncepere = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDataFinalizare = new System.Windows.Forms.DateTimePicker();
            this.labelDataIncepere = new System.Windows.Forms.Label();
            this.labelDataFinalizare = new System.Windows.Forms.Label();
            this.numericUpDownNumarOreNecesare = new System.Windows.Forms.NumericUpDown();
            this.labelNumarOreNecesare = new System.Windows.Forms.Label();
            this.listBoxPerioadeTaskuri = new System.Windows.Forms.ListBox();
            this.labelProiecte = new System.Windows.Forms.Label();
            this.labelPerioadeTaskuri = new System.Windows.Forms.Label();
            this.labelDataIncepereProiect = new System.Windows.Forms.Label();
            this.labelDataFinalizareProiect = new System.Windows.Forms.Label();
            this.textBoxDataIncepereProiect = new System.Windows.Forms.TextBox();
            this.textBoxDataFinalizareProiect = new System.Windows.Forms.TextBox();
            this.richTextBoxDescriereTask = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumarOreNecesare)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxDenumireTask
            // 
            this.textBoxDenumireTask.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDenumireTask.Location = new System.Drawing.Point(315, 519);
            this.textBoxDenumireTask.Name = "textBoxDenumireTask";
            this.textBoxDenumireTask.Size = new System.Drawing.Size(318, 32);
            this.textBoxDenumireTask.TabIndex = 0;
            // 
            // labelDemireTask
            // 
            this.labelDemireTask.AutoSize = true;
            this.labelDemireTask.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDemireTask.Location = new System.Drawing.Point(78, 521);
            this.labelDemireTask.Name = "labelDemireTask";
            this.labelDemireTask.Size = new System.Drawing.Size(168, 26);
            this.labelDemireTask.TabIndex = 2;
            this.labelDemireTask.Text = "Denumire task ";
            // 
            // labelDescriereTask
            // 
            this.labelDescriereTask.AutoSize = true;
            this.labelDescriereTask.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDescriereTask.Location = new System.Drawing.Point(904, 521);
            this.labelDescriereTask.Name = "labelDescriereTask";
            this.labelDescriereTask.Size = new System.Drawing.Size(111, 26);
            this.labelDescriereTask.TabIndex = 3;
            this.labelDescriereTask.Text = "Descriere";
            // 
            // listBoxProiecte
            // 
            this.listBoxProiecte.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listBoxProiecte.FormattingEnabled = true;
            this.listBoxProiecte.HorizontalScrollbar = true;
            this.listBoxProiecte.ItemHeight = 26;
            this.listBoxProiecte.Location = new System.Drawing.Point(78, 97);
            this.listBoxProiecte.Name = "listBoxProiecte";
            this.listBoxProiecte.Size = new System.Drawing.Size(506, 368);
            this.listBoxProiecte.TabIndex = 5;
            this.listBoxProiecte.SelectedIndexChanged += new System.EventHandler(this.listBoxProiecte_SelectedIndexChanged);
            // 
            // buttonCreeazaTask
            // 
            this.buttonCreeazaTask.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCreeazaTask.Location = new System.Drawing.Point(642, 782);
            this.buttonCreeazaTask.Name = "buttonCreeazaTask";
            this.buttonCreeazaTask.Size = new System.Drawing.Size(257, 56);
            this.buttonCreeazaTask.TabIndex = 6;
            this.buttonCreeazaTask.Text = "Creeaza";
            this.buttonCreeazaTask.UseVisualStyleBackColor = true;
            this.buttonCreeazaTask.Click += new System.EventHandler(this.buttonCreeazaTask_Click);
            // 
            // dateTimePickerDataIncepere
            // 
            this.dateTimePickerDataIncepere.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataIncepere.Location = new System.Drawing.Point(315, 596);
            this.dateTimePickerDataIncepere.MinDate = new System.DateTime(2024, 2, 29, 0, 0, 0, 0);
            this.dateTimePickerDataIncepere.Name = "dateTimePickerDataIncepere";
            this.dateTimePickerDataIncepere.Size = new System.Drawing.Size(318, 32);
            this.dateTimePickerDataIncepere.TabIndex = 7;
            this.dateTimePickerDataIncepere.ValueChanged += new System.EventHandler(this.dateTimePickerDataIncepere_ValueChanged);
            // 
            // dateTimePickerDataFinalizare
            // 
            this.dateTimePickerDataFinalizare.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataFinalizare.Location = new System.Drawing.Point(315, 649);
            this.dateTimePickerDataFinalizare.MinDate = new System.DateTime(2024, 2, 29, 0, 0, 0, 0);
            this.dateTimePickerDataFinalizare.Name = "dateTimePickerDataFinalizare";
            this.dateTimePickerDataFinalizare.Size = new System.Drawing.Size(318, 32);
            this.dateTimePickerDataFinalizare.TabIndex = 8;
            this.dateTimePickerDataFinalizare.ValueChanged += new System.EventHandler(this.dateTimePickerDataFinalizare_ValueChanged);
            // 
            // labelDataIncepere
            // 
            this.labelDataIncepere.AutoSize = true;
            this.labelDataIncepere.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDataIncepere.Location = new System.Drawing.Point(78, 596);
            this.labelDataIncepere.Name = "labelDataIncepere";
            this.labelDataIncepere.Size = new System.Drawing.Size(155, 26);
            this.labelDataIncepere.TabIndex = 9;
            this.labelDataIncepere.Text = "Data incepere";
            // 
            // labelDataFinalizare
            // 
            this.labelDataFinalizare.AutoSize = true;
            this.labelDataFinalizare.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDataFinalizare.Location = new System.Drawing.Point(78, 649);
            this.labelDataFinalizare.Name = "labelDataFinalizare";
            this.labelDataFinalizare.Size = new System.Drawing.Size(163, 26);
            this.labelDataFinalizare.TabIndex = 10;
            this.labelDataFinalizare.Text = "Data finalizare";
            // 
            // numericUpDownNumarOreNecesare
            // 
            this.numericUpDownNumarOreNecesare.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownNumarOreNecesare.Location = new System.Drawing.Point(315, 709);
            this.numericUpDownNumarOreNecesare.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownNumarOreNecesare.Name = "numericUpDownNumarOreNecesare";
            this.numericUpDownNumarOreNecesare.Size = new System.Drawing.Size(120, 32);
            this.numericUpDownNumarOreNecesare.TabIndex = 11;
            // 
            // labelNumarOreNecesare
            // 
            this.labelNumarOreNecesare.AutoSize = true;
            this.labelNumarOreNecesare.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNumarOreNecesare.Location = new System.Drawing.Point(78, 712);
            this.labelNumarOreNecesare.Name = "labelNumarOreNecesare";
            this.labelNumarOreNecesare.Size = new System.Drawing.Size(219, 26);
            this.labelNumarOreNecesare.TabIndex = 12;
            this.labelNumarOreNecesare.Text = "Numar ore necesare";
            // 
            // listBoxPerioadeTaskuri
            // 
            this.listBoxPerioadeTaskuri.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listBoxPerioadeTaskuri.FormattingEnabled = true;
            this.listBoxPerioadeTaskuri.HorizontalScrollbar = true;
            this.listBoxPerioadeTaskuri.ItemHeight = 26;
            this.listBoxPerioadeTaskuri.Location = new System.Drawing.Point(855, 97);
            this.listBoxPerioadeTaskuri.Name = "listBoxPerioadeTaskuri";
            this.listBoxPerioadeTaskuri.Size = new System.Drawing.Size(718, 368);
            this.listBoxPerioadeTaskuri.TabIndex = 13;
            // 
            // labelProiecte
            // 
            this.labelProiecte.AutoSize = true;
            this.labelProiecte.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelProiecte.Location = new System.Drawing.Point(254, 57);
            this.labelProiecte.Name = "labelProiecte";
            this.labelProiecte.Size = new System.Drawing.Size(110, 31);
            this.labelProiecte.TabIndex = 14;
            this.labelProiecte.Text = "Proiecte";
            // 
            // labelPerioadeTaskuri
            // 
            this.labelPerioadeTaskuri.AutoSize = true;
            this.labelPerioadeTaskuri.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPerioadeTaskuri.Location = new System.Drawing.Point(1126, 57);
            this.labelPerioadeTaskuri.Name = "labelPerioadeTaskuri";
            this.labelPerioadeTaskuri.Size = new System.Drawing.Size(213, 31);
            this.labelPerioadeTaskuri.TabIndex = 15;
            this.labelPerioadeTaskuri.Text = "Taskuri existente";
            // 
            // labelDataIncepereProiect
            // 
            this.labelDataIncepereProiect.AutoSize = true;
            this.labelDataIncepereProiect.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDataIncepereProiect.Location = new System.Drawing.Point(603, 142);
            this.labelDataIncepereProiect.Name = "labelDataIncepereProiect";
            this.labelDataIncepereProiect.Size = new System.Drawing.Size(234, 26);
            this.labelDataIncepereProiect.TabIndex = 16;
            this.labelDataIncepereProiect.Text = "Data incepere proiect";
            // 
            // labelDataFinalizareProiect
            // 
            this.labelDataFinalizareProiect.AutoSize = true;
            this.labelDataFinalizareProiect.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDataFinalizareProiect.Location = new System.Drawing.Point(603, 290);
            this.labelDataFinalizareProiect.Name = "labelDataFinalizareProiect";
            this.labelDataFinalizareProiect.Size = new System.Drawing.Size(242, 26);
            this.labelDataFinalizareProiect.TabIndex = 17;
            this.labelDataFinalizareProiect.Text = "Data finalizare proiect";
            // 
            // textBoxDataIncepereProiect
            // 
            this.textBoxDataIncepereProiect.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxDataIncepereProiect.Location = new System.Drawing.Point(606, 180);
            this.textBoxDataIncepereProiect.Name = "textBoxDataIncepereProiect";
            this.textBoxDataIncepereProiect.ReadOnly = true;
            this.textBoxDataIncepereProiect.Size = new System.Drawing.Size(231, 35);
            this.textBoxDataIncepereProiect.TabIndex = 18;
            // 
            // textBoxDataFinalizareProiect
            // 
            this.textBoxDataFinalizareProiect.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxDataFinalizareProiect.Location = new System.Drawing.Point(606, 328);
            this.textBoxDataFinalizareProiect.Name = "textBoxDataFinalizareProiect";
            this.textBoxDataFinalizareProiect.ReadOnly = true;
            this.textBoxDataFinalizareProiect.Size = new System.Drawing.Size(231, 35);
            this.textBoxDataFinalizareProiect.TabIndex = 19;
            // 
            // richTextBoxDescriereTask
            // 
            this.richTextBoxDescriereTask.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxDescriereTask.Location = new System.Drawing.Point(1021, 523);
            this.richTextBoxDescriereTask.Name = "richTextBoxDescriereTask";
            this.richTextBoxDescriereTask.Size = new System.Drawing.Size(292, 218);
            this.richTextBoxDescriereTask.TabIndex = 20;
            this.richTextBoxDescriereTask.Text = "";
            // 
            // FormCreeareTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1677, 905);
            this.Controls.Add(this.richTextBoxDescriereTask);
            this.Controls.Add(this.textBoxDataFinalizareProiect);
            this.Controls.Add(this.textBoxDataIncepereProiect);
            this.Controls.Add(this.labelDataFinalizareProiect);
            this.Controls.Add(this.labelDataIncepereProiect);
            this.Controls.Add(this.labelPerioadeTaskuri);
            this.Controls.Add(this.labelProiecte);
            this.Controls.Add(this.listBoxPerioadeTaskuri);
            this.Controls.Add(this.labelNumarOreNecesare);
            this.Controls.Add(this.numericUpDownNumarOreNecesare);
            this.Controls.Add(this.labelDataFinalizare);
            this.Controls.Add(this.labelDataIncepere);
            this.Controls.Add(this.dateTimePickerDataFinalizare);
            this.Controls.Add(this.dateTimePickerDataIncepere);
            this.Controls.Add(this.buttonCreeazaTask);
            this.Controls.Add(this.listBoxProiecte);
            this.Controls.Add(this.labelDescriereTask);
            this.Controls.Add(this.labelDemireTask);
            this.Controls.Add(this.textBoxDenumireTask);
            this.Name = "FormCreeareTask";
            this.Text = "FormCreeareTask";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumarOreNecesare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDenumireTask;
        private System.Windows.Forms.Label labelDemireTask;
        private System.Windows.Forms.Label labelDescriereTask;
        private System.Windows.Forms.ListBox listBoxProiecte;
        private System.Windows.Forms.Button buttonCreeazaTask;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataIncepere;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataFinalizare;
        private System.Windows.Forms.Label labelDataIncepere;
        private System.Windows.Forms.Label labelDataFinalizare;
        private System.Windows.Forms.NumericUpDown numericUpDownNumarOreNecesare;
        private System.Windows.Forms.Label labelNumarOreNecesare;
        private System.Windows.Forms.ListBox listBoxPerioadeTaskuri;
        private System.Windows.Forms.Label labelProiecte;
        private System.Windows.Forms.Label labelPerioadeTaskuri;
        private System.Windows.Forms.Label labelDataIncepereProiect;
        private System.Windows.Forms.Label labelDataFinalizareProiect;
        private System.Windows.Forms.TextBox textBoxDataIncepereProiect;
        private System.Windows.Forms.TextBox textBoxDataFinalizareProiect;
        private System.Windows.Forms.RichTextBox richTextBoxDescriereTask;
    }
}