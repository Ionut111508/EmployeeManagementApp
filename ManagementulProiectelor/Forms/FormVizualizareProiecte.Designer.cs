
namespace ManagementulProiectelor.Forms
{
    partial class FormVizualizareProiecte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVizualizareProiecte));
            this.dataGridViewAfisareProiecte = new System.Windows.Forms.DataGridView();
            this.panelProiecte = new System.Windows.Forms.Panel();
            this.buttonEditare = new System.Windows.Forms.Button();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.checkBoxFinalizate = new System.Windows.Forms.CheckBox();
            this.checkBoxViitoare = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAfisareProiecte)).BeginInit();
            this.panelProiecte.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewAfisareProiecte
            // 
            this.dataGridViewAfisareProiecte.AllowUserToAddRows = false;
            this.dataGridViewAfisareProiecte.AllowUserToDeleteRows = false;
            this.dataGridViewAfisareProiecte.AllowUserToResizeColumns = false;
            this.dataGridViewAfisareProiecte.AllowUserToResizeRows = false;
            this.dataGridViewAfisareProiecte.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewAfisareProiecte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAfisareProiecte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAfisareProiecte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAfisareProiecte.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAfisareProiecte.Name = "dataGridViewAfisareProiecte";
            this.dataGridViewAfisareProiecte.ReadOnly = true;
            this.dataGridViewAfisareProiecte.RowTemplate.Height = 25;
            this.dataGridViewAfisareProiecte.Size = new System.Drawing.Size(1546, 754);
            this.dataGridViewAfisareProiecte.TabIndex = 0;
            this.dataGridViewAfisareProiecte.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAfisareProiecte_CellClick);
            // 
            // panelProiecte
            // 
            this.panelProiecte.Controls.Add(this.dataGridViewAfisareProiecte);
            this.panelProiecte.Location = new System.Drawing.Point(12, 67);
            this.panelProiecte.Name = "panelProiecte";
            this.panelProiecte.Size = new System.Drawing.Size(1546, 754);
            this.panelProiecte.TabIndex = 1;
            // 
            // buttonEditare
            // 
            this.buttonEditare.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonEditare.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditare.Image")));
            this.buttonEditare.Location = new System.Drawing.Point(1523, 67);
            this.buttonEditare.Name = "buttonEditare";
            this.buttonEditare.Size = new System.Drawing.Size(64, 57);
            this.buttonEditare.TabIndex = 43;
            this.buttonEditare.UseVisualStyleBackColor = false;
            this.buttonEditare.Click += new System.EventHandler(this.buttonEditare_Click);
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxActive.Location = new System.Drawing.Point(37, 30);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(95, 31);
            this.checkBoxActive.TabIndex = 2;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            this.checkBoxActive.Visible = false;
            // 
            // checkBoxFinalizate
            // 
            this.checkBoxFinalizate.AutoSize = true;
            this.checkBoxFinalizate.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxFinalizate.Location = new System.Drawing.Point(138, 30);
            this.checkBoxFinalizate.Name = "checkBoxFinalizate";
            this.checkBoxFinalizate.Size = new System.Drawing.Size(124, 31);
            this.checkBoxFinalizate.TabIndex = 3;
            this.checkBoxFinalizate.Text = "Finalizate";
            this.checkBoxFinalizate.UseVisualStyleBackColor = true;
            this.checkBoxFinalizate.Visible = false;
            // 
            // checkBoxViitoare
            // 
            this.checkBoxViitoare.AutoSize = true;
            this.checkBoxViitoare.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxViitoare.Location = new System.Drawing.Point(268, 30);
            this.checkBoxViitoare.Name = "checkBoxViitoare";
            this.checkBoxViitoare.Size = new System.Drawing.Size(107, 31);
            this.checkBoxViitoare.TabIndex = 4;
            this.checkBoxViitoare.Text = "Viitoare";
            this.checkBoxViitoare.UseVisualStyleBackColor = true;
            this.checkBoxViitoare.Visible = false;
            // 
            // FormVizualizareProiecte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1666, 833);
            this.Controls.Add(this.buttonEditare);
            this.Controls.Add(this.checkBoxViitoare);
            this.Controls.Add(this.checkBoxFinalizate);
            this.Controls.Add(this.checkBoxActive);
            this.Controls.Add(this.panelProiecte);
            this.Name = "FormVizualizareProiecte";
            this.Text = "FormVizualizareProiecte";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAfisareProiecte)).EndInit();
            this.panelProiecte.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAfisareProiecte;
        private System.Windows.Forms.Panel panelProiecte;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.CheckBox checkBoxFinalizate;
        private System.Windows.Forms.CheckBox checkBoxViitoare;
        private System.Windows.Forms.Button buttonEditare;
    }
}