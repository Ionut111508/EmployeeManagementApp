
namespace ManagementulProiectelor.Forms
{
    partial class FormEditareInformatiiProiect
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
            this.buttonSalvare = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.labelDataIncepere = new System.Windows.Forms.Label();
            this.dateTimePickerDataIncepere = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDataFinalizare = new System.Windows.Forms.DateTimePicker();
            this.textBoxDenumire = new System.Windows.Forms.TextBox();
            this.labelDataFinalizare = new System.Windows.Forms.Label();
            this.labelDenumireProiect = new System.Windows.Forms.Label();
            this.labelMesaj = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSalvare
            // 
            this.buttonSalvare.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSalvare.Location = new System.Drawing.Point(1093, 589);
            this.buttonSalvare.Name = "buttonSalvare";
            this.buttonSalvare.Size = new System.Drawing.Size(115, 42);
            this.buttonSalvare.TabIndex = 13;
            this.buttonSalvare.Text = "Salvare";
            this.buttonSalvare.UseVisualStyleBackColor = true;
            this.buttonSalvare.Click += new System.EventHandler(this.buttonSalvare_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonHome.Location = new System.Drawing.Point(125, 589);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(115, 42);
            this.buttonHome.TabIndex = 12;
            this.buttonHome.Text = "Înapoi";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // labelDataIncepere
            // 
            this.labelDataIncepere.AutoSize = true;
            this.labelDataIncepere.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDataIncepere.Location = new System.Drawing.Point(311, 323);
            this.labelDataIncepere.Name = "labelDataIncepere";
            this.labelDataIncepere.Size = new System.Drawing.Size(210, 31);
            this.labelDataIncepere.TabIndex = 23;
            this.labelDataIncepere.Text = "Data de începere";
            // 
            // dateTimePickerDataIncepere
            // 
            this.dateTimePickerDataIncepere.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataIncepere.Location = new System.Drawing.Point(569, 317);
            this.dateTimePickerDataIncepere.Name = "dateTimePickerDataIncepere";
            this.dateTimePickerDataIncepere.Size = new System.Drawing.Size(351, 35);
            this.dateTimePickerDataIncepere.TabIndex = 22;
            // 
            // dateTimePickerDataFinalizare
            // 
            this.dateTimePickerDataFinalizare.CalendarFont = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataFinalizare.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDataFinalizare.Location = new System.Drawing.Point(569, 435);
            this.dateTimePickerDataFinalizare.Name = "dateTimePickerDataFinalizare";
            this.dateTimePickerDataFinalizare.Size = new System.Drawing.Size(351, 35);
            this.dateTimePickerDataFinalizare.TabIndex = 20;
            // 
            // textBoxDenumire
            // 
            this.textBoxDenumire.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDenumire.Location = new System.Drawing.Point(569, 198);
            this.textBoxDenumire.Name = "textBoxDenumire";
            this.textBoxDenumire.Size = new System.Drawing.Size(351, 35);
            this.textBoxDenumire.TabIndex = 18;
            this.textBoxDenumire.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelDataFinalizare
            // 
            this.labelDataFinalizare.AutoSize = true;
            this.labelDataFinalizare.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDataFinalizare.Location = new System.Drawing.Point(311, 441);
            this.labelDataFinalizare.Name = "labelDataFinalizare";
            this.labelDataFinalizare.Size = new System.Drawing.Size(223, 31);
            this.labelDataFinalizare.TabIndex = 17;
            this.labelDataFinalizare.Text = "Data de finalizare";
            // 
            // labelDenumireProiect
            // 
            this.labelDenumireProiect.AutoSize = true;
            this.labelDenumireProiect.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDenumireProiect.Location = new System.Drawing.Point(311, 207);
            this.labelDenumireProiect.Name = "labelDenumireProiect";
            this.labelDenumireProiect.Size = new System.Drawing.Size(130, 31);
            this.labelDenumireProiect.TabIndex = 14;
            this.labelDenumireProiect.Text = "Denumire";
            // 
            // labelMesaj
            // 
            this.labelMesaj.AutoSize = true;
            this.labelMesaj.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMesaj.Location = new System.Drawing.Point(299, 99);
            this.labelMesaj.Name = "labelMesaj";
            this.labelMesaj.Size = new System.Drawing.Size(0, 36);
            this.labelMesaj.TabIndex = 24;
            // 
            // FormEditareInformatiiProiect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 677);
            this.Controls.Add(this.labelMesaj);
            this.Controls.Add(this.labelDataIncepere);
            this.Controls.Add(this.dateTimePickerDataIncepere);
            this.Controls.Add(this.dateTimePickerDataFinalizare);
            this.Controls.Add(this.textBoxDenumire);
            this.Controls.Add(this.labelDataFinalizare);
            this.Controls.Add(this.labelDenumireProiect);
            this.Controls.Add(this.buttonSalvare);
            this.Controls.Add(this.buttonHome);
            this.Name = "FormEditareInformatiiProiect";
            this.Text = "FormEditareInformatiiProiect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSalvare;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Label labelDataIncepere;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataIncepere;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataFinalizare;
        private System.Windows.Forms.TextBox textBoxDenumire;
        private System.Windows.Forms.Label labelDataFinalizare;
        private System.Windows.Forms.Label labelDenumireProiect;
        private System.Windows.Forms.Label labelMesaj;
    }
}