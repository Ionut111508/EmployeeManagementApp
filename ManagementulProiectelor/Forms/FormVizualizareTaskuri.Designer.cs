
namespace ManagementulProiectelor.Forms
{
    partial class FormVizualizareTaskuri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVizualizareTaskuri));
            this.listBoxComentarii = new System.Windows.Forms.ListBox();
            this.comboBoxTaskuri = new System.Windows.Forms.ComboBox();
            this.comboBoxProiecte = new System.Windows.Forms.ComboBox();
            this.labelSelectareProiect = new System.Windows.Forms.Label();
            this.labelSelectareTask = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panelAdaugareComentariu = new System.Windows.Forms.Panel();
            this.buttonAdaugare = new System.Windows.Forms.Button();
            this.richTextBoxTextComentariu = new System.Windows.Forms.RichTextBox();
            this.labelTextComentariu = new System.Windows.Forms.Label();
            this.labelComentarii = new System.Windows.Forms.Label();
            this.buttonEditare = new System.Windows.Forms.Button();
            this.panelAdaugareComentariu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxComentarii
            // 
            this.listBoxComentarii.FormattingEnabled = true;
            this.listBoxComentarii.HorizontalScrollbar = true;
            this.listBoxComentarii.ItemHeight = 27;
            this.listBoxComentarii.Location = new System.Drawing.Point(480, 96);
            this.listBoxComentarii.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.listBoxComentarii.Name = "listBoxComentarii";
            this.listBoxComentarii.Size = new System.Drawing.Size(1033, 436);
            this.listBoxComentarii.TabIndex = 0;
            this.listBoxComentarii.SelectedIndexChanged += new System.EventHandler(this.listBoxComentarii_SelectedIndexChanged);
            // 
            // comboBoxTaskuri
            // 
            this.comboBoxTaskuri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTaskuri.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxTaskuri.FormattingEnabled = true;
            this.comboBoxTaskuri.Location = new System.Drawing.Point(37, 251);
            this.comboBoxTaskuri.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.comboBoxTaskuri.Name = "comboBoxTaskuri";
            this.comboBoxTaskuri.Size = new System.Drawing.Size(431, 39);
            this.comboBoxTaskuri.TabIndex = 37;
            this.comboBoxTaskuri.SelectedIndexChanged += new System.EventHandler(this.comboBoxTaskuri_SelectedIndexChanged);
            // 
            // comboBoxProiecte
            // 
            this.comboBoxProiecte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProiecte.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxProiecte.FormattingEnabled = true;
            this.comboBoxProiecte.Location = new System.Drawing.Point(37, 118);
            this.comboBoxProiecte.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.comboBoxProiecte.Name = "comboBoxProiecte";
            this.comboBoxProiecte.Size = new System.Drawing.Size(431, 39);
            this.comboBoxProiecte.TabIndex = 36;
            this.comboBoxProiecte.SelectedIndexChanged += new System.EventHandler(this.comboBoxProiecte_SelectedIndexChanged);
            // 
            // labelSelectareProiect
            // 
            this.labelSelectareProiect.AutoSize = true;
            this.labelSelectareProiect.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSelectareProiect.Location = new System.Drawing.Point(130, 68);
            this.labelSelectareProiect.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSelectareProiect.Name = "labelSelectareProiect";
            this.labelSelectareProiect.Size = new System.Drawing.Size(232, 32);
            this.labelSelectareProiect.TabIndex = 34;
            this.labelSelectareProiect.Text = "Selectează proiect";
            // 
            // labelSelectareTask
            // 
            this.labelSelectareTask.AutoSize = true;
            this.labelSelectareTask.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSelectareTask.Location = new System.Drawing.Point(152, 200);
            this.labelSelectareTask.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSelectareTask.Name = "labelSelectareTask";
            this.labelSelectareTask.Size = new System.Drawing.Size(197, 32);
            this.labelSelectareTask.TabIndex = 35;
            this.labelSelectareTask.Text = "Selectează task";
            this.labelSelectareTask.Visible = false;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
            this.buttonRemove.Location = new System.Drawing.Point(1522, 223);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(49, 47);
            this.buttonRemove.TabIndex = 39;
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Image")));
            this.buttonAdd.Location = new System.Drawing.Point(1521, 96);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(50, 46);
            this.buttonAdd.TabIndex = 38;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panelAdaugareComentariu
            // 
            this.panelAdaugareComentariu.Controls.Add(this.buttonAdaugare);
            this.panelAdaugareComentariu.Controls.Add(this.richTextBoxTextComentariu);
            this.panelAdaugareComentariu.Controls.Add(this.labelTextComentariu);
            this.panelAdaugareComentariu.Location = new System.Drawing.Point(204, 561);
            this.panelAdaugareComentariu.Name = "panelAdaugareComentariu";
            this.panelAdaugareComentariu.Size = new System.Drawing.Size(1229, 346);
            this.panelAdaugareComentariu.TabIndex = 40;
            this.panelAdaugareComentariu.Visible = false;
            // 
            // buttonAdaugare
            // 
            this.buttonAdaugare.Location = new System.Drawing.Point(507, 284);
            this.buttonAdaugare.Name = "buttonAdaugare";
            this.buttonAdaugare.Size = new System.Drawing.Size(220, 48);
            this.buttonAdaugare.TabIndex = 2;
            this.buttonAdaugare.Text = "Adaugă comentariu";
            this.buttonAdaugare.UseVisualStyleBackColor = true;
            this.buttonAdaugare.Click += new System.EventHandler(this.buttonAdaugare_Click);
            // 
            // richTextBoxTextComentariu
            // 
            this.richTextBoxTextComentariu.Location = new System.Drawing.Point(6, 52);
            this.richTextBoxTextComentariu.Name = "richTextBoxTextComentariu";
            this.richTextBoxTextComentariu.Size = new System.Drawing.Size(1197, 226);
            this.richTextBoxTextComentariu.TabIndex = 1;
            this.richTextBoxTextComentariu.Text = "";
            // 
            // labelTextComentariu
            // 
            this.labelTextComentariu.AutoSize = true;
            this.labelTextComentariu.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTextComentariu.Location = new System.Drawing.Point(3, 10);
            this.labelTextComentariu.Name = "labelTextComentariu";
            this.labelTextComentariu.Size = new System.Drawing.Size(246, 31);
            this.labelTextComentariu.TabIndex = 0;
            this.labelTextComentariu.Text = "Scrie un comentariu :";
            // 
            // labelComentarii
            // 
            this.labelComentarii.AutoSize = true;
            this.labelComentarii.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelComentarii.Location = new System.Drawing.Point(795, 36);
            this.labelComentarii.Name = "labelComentarii";
            this.labelComentarii.Size = new System.Drawing.Size(186, 40);
            this.labelComentarii.TabIndex = 41;
            this.labelComentarii.Text = "Comentarii";
            // 
            // buttonEditare
            // 
            this.buttonEditare.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonEditare.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditare.Image")));
            this.buttonEditare.Location = new System.Drawing.Point(1522, 159);
            this.buttonEditare.Name = "buttonEditare";
            this.buttonEditare.Size = new System.Drawing.Size(50, 46);
            this.buttonEditare.TabIndex = 42;
            this.buttonEditare.UseVisualStyleBackColor = false;
            this.buttonEditare.Click += new System.EventHandler(this.buttonEditare_Click);
            // 
            // FormVizualizareTaskuri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.buttonEditare);
            this.Controls.Add(this.labelComentarii);
            this.Controls.Add(this.panelAdaugareComentariu);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBoxTaskuri);
            this.Controls.Add(this.comboBoxProiecte);
            this.Controls.Add(this.labelSelectareProiect);
            this.Controls.Add(this.labelSelectareTask);
            this.Controls.Add(this.listBoxComentarii);
            this.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FormVizualizareTaskuri";
            this.Text = "FormVizualizareTaskuri";
            this.panelAdaugareComentariu.ResumeLayout(false);
            this.panelAdaugareComentariu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxComentarii;
        private System.Windows.Forms.ComboBox comboBoxTaskuri;
        private System.Windows.Forms.ComboBox comboBoxProiecte;
        private System.Windows.Forms.Label labelSelectareProiect;
        private System.Windows.Forms.Label labelSelectareTask;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panelAdaugareComentariu;
        private System.Windows.Forms.Label labelTextComentariu;
        private System.Windows.Forms.Button buttonAdaugare;
        private System.Windows.Forms.RichTextBox richTextBoxTextComentariu;
        private System.Windows.Forms.Label labelComentarii;
        private System.Windows.Forms.Button buttonEditare;
    }
}