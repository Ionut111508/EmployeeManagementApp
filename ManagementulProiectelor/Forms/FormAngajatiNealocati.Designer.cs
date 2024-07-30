
namespace ManagementulProiectelor.Forms
{
    partial class FormAngajatiNealocati
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
            this.dataGridViewAngajati = new System.Windows.Forms.DataGridView();
            this.panelDataGridView = new System.Windows.Forms.Panel();
            this.labelDataCurenta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAngajati)).BeginInit();
            this.panelDataGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewAngajati
            // 
            this.dataGridViewAngajati.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewAngajati.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAngajati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAngajati.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewAngajati.Name = "dataGridViewAngajati";
            this.dataGridViewAngajati.RowTemplate.Height = 25;
            this.dataGridViewAngajati.Size = new System.Drawing.Size(1009, 593);
            this.dataGridViewAngajati.TabIndex = 0;
            // 
            // panelDataGridView
            // 
            this.panelDataGridView.Controls.Add(this.dataGridViewAngajati);
            this.panelDataGridView.Location = new System.Drawing.Point(160, 70);
            this.panelDataGridView.Name = "panelDataGridView";
            this.panelDataGridView.Size = new System.Drawing.Size(1015, 599);
            this.panelDataGridView.TabIndex = 1;
            // 
            // labelDataCurenta
            // 
            this.labelDataCurenta.AutoSize = true;
            this.labelDataCurenta.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDataCurenta.Location = new System.Drawing.Point(566, 30);
            this.labelDataCurenta.Name = "labelDataCurenta";
            this.labelDataCurenta.Size = new System.Drawing.Size(74, 26);
            this.labelDataCurenta.TabIndex = 2;
            this.labelDataCurenta.Text = "label1";
            // 
            // FormAngajatiNealocati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 695);
            this.Controls.Add(this.labelDataCurenta);
            this.Controls.Add(this.panelDataGridView);
            this.Name = "FormAngajatiNealocati";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAngajatiNealocati";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAngajati)).EndInit();
            this.panelDataGridView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAngajati;
        private System.Windows.Forms.Panel panelDataGridView;
        private System.Windows.Forms.Label labelDataCurenta;
    }
}