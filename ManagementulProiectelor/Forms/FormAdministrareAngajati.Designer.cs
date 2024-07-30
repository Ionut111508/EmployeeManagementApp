
namespace ManagementulProiectelor.Forms
{
    partial class FormAdministrareAngajati
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdministrareAngajati));
            this.dataGridViewAngajati = new System.Windows.Forms.DataGridView();
            this.panelDataGridView = new System.Windows.Forms.Panel();
            this.buttonAdaugare = new System.Windows.Forms.Button();
            this.buttonSterge = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonCautare = new System.Windows.Forms.Button();
            this.listBoxProiecte = new System.Windows.Forms.ListBox();
            this.listBoxTaskuri = new System.Windows.Forms.ListBox();
            this.labelProiecte = new System.Windows.Forms.Label();
            this.labelTaskuri = new System.Windows.Forms.Label();
            this.checkBoxActivi = new System.Windows.Forms.CheckBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonEditare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAngajati)).BeginInit();
            this.panelDataGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewAngajati
            // 
            this.dataGridViewAngajati.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewAngajati.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAngajati.ColumnHeadersHeight = 24;
            this.dataGridViewAngajati.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAngajati.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAngajati.Name = "dataGridViewAngajati";
            this.dataGridViewAngajati.ReadOnly = true;
            this.dataGridViewAngajati.RowTemplate.Height = 25;
            this.dataGridViewAngajati.Size = new System.Drawing.Size(1571, 623);
            this.dataGridViewAngajati.TabIndex = 8;
            this.dataGridViewAngajati.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAngajati_CellClick);
            this.dataGridViewAngajati.VisibleChanged += new System.EventHandler(this.dataGridViewAngajati_VisibleChanged);
            // 
            // panelDataGridView
            // 
            this.panelDataGridView.Controls.Add(this.dataGridViewAngajati);
            this.panelDataGridView.Location = new System.Drawing.Point(12, 71);
            this.panelDataGridView.Name = "panelDataGridView";
            this.panelDataGridView.Size = new System.Drawing.Size(1571, 623);
            this.panelDataGridView.TabIndex = 9;
            // 
            // buttonAdaugare
            // 
            this.buttonAdaugare.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAdaugare.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdaugare.Image")));
            this.buttonAdaugare.Location = new System.Drawing.Point(1415, 12);
            this.buttonAdaugare.Name = "buttonAdaugare";
            this.buttonAdaugare.Size = new System.Drawing.Size(66, 52);
            this.buttonAdaugare.TabIndex = 10;
            this.buttonAdaugare.UseVisualStyleBackColor = true;
            this.buttonAdaugare.Click += new System.EventHandler(this.buttonAdaugare_Click);
            // 
            // buttonSterge
            // 
            this.buttonSterge.Location = new System.Drawing.Point(972, 30);
            this.buttonSterge.Name = "buttonSterge";
            this.buttonSterge.Size = new System.Drawing.Size(155, 32);
            this.buttonSterge.TabIndex = 11;
            this.buttonSterge.Text = "Sterge";
            this.buttonSterge.UseVisualStyleBackColor = true;
            this.buttonSterge.Visible = false;
            this.buttonSterge.Click += new System.EventHandler(this.buttonSterge_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(13, 33);
            this.textBoxSearch.Multiline = true;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Cauta...";
            this.textBoxSearch.Size = new System.Drawing.Size(233, 32);
            this.textBoxSearch.TabIndex = 12;
            // 
            // buttonCautare
            // 
            this.buttonCautare.Image = ((System.Drawing.Image)(resources.GetObject("buttonCautare.Image")));
            this.buttonCautare.Location = new System.Drawing.Point(252, 33);
            this.buttonCautare.Name = "buttonCautare";
            this.buttonCautare.Size = new System.Drawing.Size(39, 32);
            this.buttonCautare.TabIndex = 13;
            this.buttonCautare.UseVisualStyleBackColor = true;
            this.buttonCautare.Click += new System.EventHandler(this.buttonCautare_Click);
            // 
            // listBoxProiecte
            // 
            this.listBoxProiecte.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxProiecte.FormattingEnabled = true;
            this.listBoxProiecte.ItemHeight = 23;
            this.listBoxProiecte.Location = new System.Drawing.Point(184, 746);
            this.listBoxProiecte.Name = "listBoxProiecte";
            this.listBoxProiecte.Size = new System.Drawing.Size(613, 211);
            this.listBoxProiecte.TabIndex = 14;
            this.listBoxProiecte.Visible = false;
            // 
            // listBoxTaskuri
            // 
            this.listBoxTaskuri.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxTaskuri.FormattingEnabled = true;
            this.listBoxTaskuri.ItemHeight = 23;
            this.listBoxTaskuri.Location = new System.Drawing.Point(844, 746);
            this.listBoxTaskuri.Name = "listBoxTaskuri";
            this.listBoxTaskuri.Size = new System.Drawing.Size(664, 211);
            this.listBoxTaskuri.TabIndex = 15;
            this.listBoxTaskuri.Visible = false;
            // 
            // labelProiecte
            // 
            this.labelProiecte.AutoSize = true;
            this.labelProiecte.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelProiecte.Location = new System.Drawing.Point(184, 712);
            this.labelProiecte.Name = "labelProiecte";
            this.labelProiecte.Size = new System.Drawing.Size(110, 31);
            this.labelProiecte.TabIndex = 16;
            this.labelProiecte.Text = "Proiecte";
            this.labelProiecte.Visible = false;
            // 
            // labelTaskuri
            // 
            this.labelTaskuri.AutoSize = true;
            this.labelTaskuri.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTaskuri.Location = new System.Drawing.Point(844, 712);
            this.labelTaskuri.Name = "labelTaskuri";
            this.labelTaskuri.Size = new System.Drawing.Size(105, 31);
            this.labelTaskuri.TabIndex = 17;
            this.labelTaskuri.Text = "Taskuri";
            this.labelTaskuri.Visible = false;
            // 
            // checkBoxActivi
            // 
            this.checkBoxActivi.AutoSize = true;
            this.checkBoxActivi.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxActivi.Location = new System.Drawing.Point(314, 35);
            this.checkBoxActivi.Name = "checkBoxActivi";
            this.checkBoxActivi.Size = new System.Drawing.Size(80, 27);
            this.checkBoxActivi.TabIndex = 18;
            this.checkBoxActivi.Text = "Activi";
            this.checkBoxActivi.UseVisualStyleBackColor = true;
            this.checkBoxActivi.CheckedChanged += new System.EventHandler(this.checkBoxActivi_CheckedChanged);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
            this.buttonRemove.Location = new System.Drawing.Point(1514, 746);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(39, 42);
            this.buttonRemove.TabIndex = 36;
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Visible = false;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonEditare
            // 
            this.buttonEditare.BackColor = System.Drawing.Color.Transparent;
            this.buttonEditare.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonEditare.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditare.Image")));
            this.buttonEditare.Location = new System.Drawing.Point(1487, 12);
            this.buttonEditare.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEditare.Name = "buttonEditare";
            this.buttonEditare.Size = new System.Drawing.Size(66, 52);
            this.buttonEditare.TabIndex = 44;
            this.buttonEditare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonEditare.UseVisualStyleBackColor = false;
            this.buttonEditare.Click += new System.EventHandler(this.buttonEditare_Click);
            // 
            // FormAdministrareAngajati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1704, 1015);
            this.Controls.Add(this.buttonEditare);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.checkBoxActivi);
            this.Controls.Add(this.labelTaskuri);
            this.Controls.Add(this.labelProiecte);
            this.Controls.Add(this.listBoxTaskuri);
            this.Controls.Add(this.listBoxProiecte);
            this.Controls.Add(this.buttonCautare);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonSterge);
            this.Controls.Add(this.buttonAdaugare);
            this.Controls.Add(this.panelDataGridView);
            this.Name = "FormAdministrareAngajati";
            this.Text = "FormAdministrareAngajati";
            this.Activated += new System.EventHandler(this.FormAdministrareAngajati_Activated);
            this.Load += new System.EventHandler(this.FormAdministrareAngajati_Load);
            this.Resize += new System.EventHandler(this.FormAdministrareAngajati_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAngajati)).EndInit();
            this.panelDataGridView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewAngajati;
        private System.Windows.Forms.Panel panelDataGridView;
        private System.Windows.Forms.Button buttonAdaugare;
        private System.Windows.Forms.Button buttonSterge;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonCautare;
        private System.Windows.Forms.ListBox listBoxProiecte;
        private System.Windows.Forms.ListBox listBoxTaskuri;
        private System.Windows.Forms.Label labelProiecte;
        private System.Windows.Forms.Label labelTaskuri;
        private System.Windows.Forms.CheckBox checkBoxActivi;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonEditare;
    }
}