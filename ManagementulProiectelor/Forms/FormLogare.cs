using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ManagementulProiectelor.Java;
using System.Windows.Forms;

namespace ManagementulProiectelor.Forms
{
    public partial class FormLogare : Form
    {
        public FormLogare()
        {
            InitializeComponent();
            textBoxNumeUtilizator.Text = Properties.Settings.Default.Username;
            textBoxParola.Text = Properties.Settings.Default.Parola;
            if (!string.IsNullOrEmpty(textBoxNumeUtilizator.Text) && !string.IsNullOrEmpty(textBoxParola.Text))
            {
                LogareAutomata();
            }
        }

        private void buttonLogare_Click(object sender, EventArgs e)
        {
            String user = textBoxNumeUtilizator.Text;
            String parola = textBoxParola.Text;

            if (DBHelper.VerificareCredentialeLogare(user,parola))
            {
                Properties.Settings.Default.Username = user;
                Properties.Settings.Default.Parola = parola;
                Properties.Settings.Default.Save();
                Boolean isAdmin = false;
                Boolean isManager = false;
                Boolean isAngajatSimplu = false;
                if(user=="admin" & parola == "admin")
                {
                    isAdmin = true;
                }
                if (user == "manager" & parola == "manager")
                {
                    isManager = true;
                }
                if(isAdmin==false & isManager==false)
                {
                    isAngajatSimplu = true;
                }
                Sesiune.IncepeSesiune(DBHelper.ReturneazaIdAngajat(user, parola), isAdmin, isManager, isAngajatSimplu);


                FormHome formhome = new FormHome();
                formhome.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User sau parola incorecte");
            }
        }

        private void checkBoxAfisareParola_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxAfisareParola.Checked)
            {
                textBoxParola.PasswordChar = '\0';
            }
            else
            {
                textBoxParola.PasswordChar = '*';
            }
        }

        private void LogareAutomata()
        {
            String user = Properties.Settings.Default.Username;
            String parola = Properties.Settings.Default.Parola;

            if (DBHelper.VerificareCredentialeLogare(user, parola))
            {
                Boolean isAdmin = false;
                Boolean isManager = false;
                Boolean isAngajatSimplu = false;
                
                if (user == "admin" && parola == "admin")
                {
                    isAdmin = true;
                }
                if (user == "manager" && parola == "manager")
                {
                    isManager = true;
                }
                if (isAdmin == false & isManager == false)
                {
                    isAngajatSimplu = true;
                }
                Sesiune.IncepeSesiune(DBHelper.ReturneazaIdAngajat(user, parola), isAdmin, isManager,isAngajatSimplu);

                FormHome formhome = new FormHome();
                formhome.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User sau parola incorecte pentru logarea automată");
            }
        }
        public static Form SetareFormInitial()
        {
            Form formInitial;
            if(LogareAutomataPosibila()==true)
            {
                formInitial = new FormHome();
                MessageBox.Show("Logare automata posibila");
            }
            else
            {
                formInitial = new FormLogare();
                MessageBox.Show("Logare automata imposibila");

            }
            return formInitial;            
        }
        public static bool LogareAutomataPosibila()
        {
            if(!string.IsNullOrEmpty(Properties.Settings.Default.Username) && !string.IsNullOrEmpty(Properties.Settings.Default.Parola))
            {
                return true;
            }
            return false;
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButtonMaximizeMinimize_Click(object sender, EventArgs e)
        {
        }

        private void buttonShowHideApp_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
