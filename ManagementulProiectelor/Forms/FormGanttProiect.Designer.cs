
namespace ManagementulProiectelor
{
    partial class FormGanttProiect
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
            this.comboBoxProiecte = new System.Windows.Forms.ComboBox();
            this.panelGrafic = new System.Windows.Forms.Panel();
            this.labelActivitati = new System.Windows.Forms.Label();
            this.panelGrafic.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxProiecte
            // 
            this.comboBoxProiecte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProiecte.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.comboBoxProiecte.FormattingEnabled = true;
            this.comboBoxProiecte.Location = new System.Drawing.Point(115, 60);
            this.comboBoxProiecte.Name = "comboBoxProiecte";
            this.comboBoxProiecte.Size = new System.Drawing.Size(317, 32);
            this.comboBoxProiecte.TabIndex = 0;
            this.comboBoxProiecte.SelectedIndexChanged += new System.EventHandler(this.comboBoxProiecte_SelectedIndexChanged);
            // 
            // panelGrafic
            // 
            this.panelGrafic.AutoScroll = true;
            this.panelGrafic.AutoSize = true;
            this.panelGrafic.Controls.Add(this.labelActivitati);
            this.panelGrafic.Location = new System.Drawing.Point(12, 114);
            this.panelGrafic.Name = "panelGrafic";
            this.panelGrafic.Size = new System.Drawing.Size(1551, 612);
            this.panelGrafic.TabIndex = 1;
            this.panelGrafic.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelGrafic_Scroll);
            this.panelGrafic.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGrafic_Paint);
            // 
            // labelActivitati
            // 
            this.labelActivitati.AutoSize = true;
            this.labelActivitati.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelActivitati.Location = new System.Drawing.Point(12, 39);
            this.labelActivitati.Name = "labelActivitati";
            this.labelActivitati.Size = new System.Drawing.Size(90, 26);
            this.labelActivitati.TabIndex = 2;
            this.labelActivitati.Text = "Taskuri";
            // 
            // FormGanttProiect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 812);
            this.Controls.Add(this.panelGrafic);
            this.Controls.Add(this.comboBoxProiecte);
            this.Name = "FormGanttProiect";
            this.Text = "GanttChartForm";
            this.Load += new System.EventHandler(this.FormGanttProiect_Load);
            this.panelGrafic.ResumeLayout(false);
            this.panelGrafic.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxProiecte;
        private System.Windows.Forms.Panel panelGrafic;
        private System.Windows.Forms.Label labelActivitati;
    }
}