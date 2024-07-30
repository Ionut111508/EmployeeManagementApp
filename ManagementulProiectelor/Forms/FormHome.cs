using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementulProiectelor.Forms;
using ManagementulProiectelor.Java;

namespace ManagementulProiectelor
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
            AfisareMesajBunVenit(5000);
            AdaugareDateInSesiune();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            AfisareComponenteSpeciale();

        }
        #region New Options
        #endregion
        #region WindowButtons
        private void iconExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void iconButtonMaximizeMinimize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }
        private void buttonShowHideApp_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion
        #region GestionareProiecte
        private void buttonGestionareProiecte_Click(object sender, EventArgs e)
        {
            showSubmenu(panelProiecteSubmenu);
        }
        #endregion
        #region Submenu options
        private void hideSubmenu()
        {          
            if (panelAngajatiSubmenu.Visible == true)
                panelAngajatiSubmenu.Visible = false;

            if (panelProiecteSubmenu.Visible == true)
                panelProiecteSubmenu.Visible = false;

            if (panelGestionareTaskuriSubmenu.Visible == true)
                panelGestionareTaskuriSubmenu.Visible = false;

            if (panelGraficSubmenu.Visible == true)
                panelGraficSubmenu.Visible = false;         

            if (panelPontajSubmenu.Visible == true)
                panelPontajSubmenu.Visible = false;
        }
        private void showSubmenu(Panel Submenu)
        {
            if (Submenu.Visible == false)
            {
                hideSubmenu();
                Submenu.Visible = true;
            }
            else
                Submenu.Visible = false;
        }
        #endregion
        #region Dashboard
        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            showSubmenu(panelGraficSubmenu);
        }
        #endregion
        #region GestionareAngajati
        private void buttonGestionareAngajati_Click(object sender, EventArgs e)
        {
            showSubmenu(panelAngajatiSubmenu);
        }
        private void buttonAdaugaAngajat_Click(object sender, EventArgs e)
        {
            openChildForm(new FormAdaugaAngajat());
        }

        private void buttonAlocareSkill_Click(object sender, EventArgs e)
        {
            openChildForm(new FormDetineAngajatSkill());
        }
        private void buttonAlocareDepartament_Click(object sender, EventArgs e)
        {
            openChildForm(new FormApartineAngajatDepartament());
        }
        #endregion
        #region Utils
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();          
        }
        #endregion
        private void buttonGestionareTaskuri_Click(object sender, EventArgs e)
        {
            showSubmenu(panelGestionareTaskuriSubmenu);
        }
        private void buttonCalendar_Click(object sender, EventArgs e)
        {
            openChildForm(new FormCalendar());
        }

        private void buttonAdaugaProiectNou_Click(object sender, EventArgs e)
        {
            openChildForm(new FormAdaugareProiect());

        }

        private void buttonPontaj_Click(object sender, EventArgs e)
        {
            showSubmenu(panelPontajSubmenu);
        }

        private void buttonEfectuarePontaj_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPontaj());
        }

        private void buttonDeconectare_Click(object sender, EventArgs e)
        {
            Sesiune.GolireSesiune();
            Properties.Settings.Default.Username = string.Empty;
            Properties.Settings.Default.Parola = string.Empty;
            Properties.Settings.Default.Save();
            FormLogare formLogare = new FormLogare();
            formLogare.Show();
            this.Hide();
        }
        private async void AfisareMesajBunVenit(int interval)
        {
            var (numeAngajat, prenumeAngajat) = DBHelper.DetaliiAngajatDupaCont(Properties.Settings.Default.Username, Properties.Settings.Default.Parola);
            if (!string.IsNullOrEmpty(numeAngajat) && !string.IsNullOrEmpty(prenumeAngajat))
            {
                labelMesajBunVenit.Text = labelMesajBunVenit.Text + numeAngajat + " " + prenumeAngajat + " !";
            }
            else
            {
                labelMesajBunVenit.Text = "Angajat neidentificat !";
            }
            await System.Threading.Tasks.Task.Delay(interval);
            labelMesajBunVenit.Visible = false;
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            FormAdmin formAdmin = new FormAdmin();
            formAdmin.Show();
            this.Hide();
        }

        private void AdaugareDateInSesiune()
        {
            var (numeAngajat, prenumeAngajat) = DBHelper.DetaliiAngajatDupaCont(Properties.Settings.Default.Username, Properties.Settings.Default.Parola);
            String User = Properties.Settings.Default.Username;
            String Parola = Properties.Settings.Default.Parola;
            Sesiune.ID_ANGAJAT = DBHelper.ReturneazaIdAngajat(User, Parola);
        }

        private void buttonAdaugaTaskNow_Click(object sender, EventArgs e)
        {
            openChildForm(new FormCreeareTask());
        }

        private void buttonAlocareAngajatPeProiect_Click(object sender, EventArgs e)
        {
        }

        private void buttonGraficAngajati_Click(object sender, EventArgs e)
        {
            openChildForm(new FormGanttAngajat());
        }

        private void buttonVizualizareProiecte_Click(object sender, EventArgs e)
        {
            openChildForm(new FormVizualizareProiecte());
        }

        private void buttonGraficProiecte_Click(object sender, EventArgs e)
        {
            openChildForm(new FormGanttProiect());
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        protected static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        protected void renderingBorders()
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        private void buttonAlocareAngajati_Click(object sender, EventArgs e)
        {
            openChildForm(new FormAlocareAngajat());
        }

        private void buttonAdministrareAngajati_Click(object sender, EventArgs e)
        {
            openChildForm(new FormAdministrareAngajati());
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitlu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void buttonVizualizareTaskuri_Click(object sender, EventArgs e)
        {
            openChildForm(new FormVizualizareTaskuri());
        }
        private bool IsAdmin(string userName, string parola)
        {
            if(userName=="admin" & parola=="admin")
            {
                Sesiune.IsAdmin = true;
                return true;
            }
            return false;
        }
        private bool IsManager(string userName, string parola)
        {
            if (userName == "manager" & parola == "manager")
            {
                Sesiune.IsManager = true;
                return true;
            }
            return false;
        }
        public void AfisareComponenteSpeciale()
        {
            if (IsAdmin(Properties.Settings.Default.Username, Properties.Settings.Default.Parola) == true)
            {
                panelHomePage.Visible = true;

            }
            else if(IsManager(Properties.Settings.Default.Username, Properties.Settings.Default.Parola) == true)
            {
                
            }
            else
            {
                buttonGestionareAngajati.Visible = false;
                panelAngajatiSubmenu.Visible = false;
                buttonAdaugaProiectNou.Visible = false;
                buttonAdaugaTaskNow.Visible = false;
            }
        }
    }
}
