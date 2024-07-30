using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManagementulProiectelor
{
    public partial class FormAdaugaAngajat : Form
    {
        static List<Angajat> listaAngajati = DBHelper.ExtrageAngajatiWithDapper();
        static List<Norma> listaNorme = DBHelper.ExtrageNormeWithDapper();
        static List<Cont> listaConturi = DBHelper.ExtrageConturiWithDapper();
        public FormAdaugaAngajat()
        {
            InitializeComponent();
            AddToListBox();       
        }
        private void AddToListBox()
        {
            listBoxNorma.DataSource = null;
            listBoxNorma.DataSource = listaNorme;
            listBoxNorma.DisplayMember = "FullDescNorma";
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
        }
        private void buttonAdaugareAngajat_Click(object sender, EventArgs e)
        {
            if ( VerificaTextBoxes() is true)
            {
                String nume = textBoxNume.Text;
                String prenume = textBoxPrenume.Text;
                int nrAngajati = DBHelper.ExtrageNrAngajatiCuAceeasiDenumire(generareUserAngajat(nume, prenume));
                String Username = nrAngajati > 0 ? $"{nume}{prenume}{nrAngajati++}" : $"{nume}{prenume}";
                String Parola = generareParolaContNou();
                String email = textBoxEmail.Text;
                String Id = generareIdAngajatNou();
                String nrTel = textBoxNumarDeTelefon.Text;
                String idCont = generareIdContNou();
                String idNorma = "N" + (listBoxNorma.SelectedIndex + 1).ToString();

                Cont cont = new Cont()
                {
                    Id_Cont = idCont,
                    UserCont = Username,
                    ParolaCont = Parola
                };
                DBHelper.AddCont(cont);
                listaConturi.Add(cont);
                MessageBox.Show("Contul a fost creat" +
                    "\n cu userul " + Username +
                    "\n si parola " + Parola +
                    "\n si asociat cu angajatul " + nume + " " + prenume, "Cont creat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Angajat angajat = new Angajat()
                {
                    Id_Angajat = Id,
                    numeAngajat = nume,
                    prenumeAngajat = prenume,
                    emailAngajat = email,
                    numarTelefonAngajat = nrTel,
                    Id_Cont = idCont,
                    Id_Norma = idNorma
                };
                DBHelper.AddAngajat(angajat);
                listaAngajati.Add(angajat);
                golireTextBox();
            }         
        }
        private String generareIdAngajatNou()
        {
            String idFinal;
            if (listaAngajati.Count == 0)
            {
                idFinal = "A1";
            }
            else
            {
                int maxNumericPart = listaAngajati
              .Where(obj => obj.Id_Angajat.StartsWith("A"))
              .Select(obj => int.TryParse(obj.Id_Angajat.Substring(1), out int numeric) ? numeric : 0)
              .Max();
               idFinal = "A" + (maxNumericPart + 1).ToString();
            }
            return idFinal;
        }
        private String generareUserAngajat(String nume, String prenume)
        {
            String UserName = nume + prenume;
            return UserName;
        }
        private String generareIdContNou()
        {
            var numericParts = listaConturi
                .Select(cont => {
                    if (int.TryParse(cont.Id_Cont.Substring(1), out int result))
                        return result;
                    return -1;
                })
                .Where(num => num != -1)
                .ToList();

            if (numericParts.Count == 0)
                return "C1";

            int maxNumericPart = numericParts.Max() + 1;

            string uniqueId = "C" + maxNumericPart.ToString();

            return uniqueId;
        }
        private String generareParolaContNou()
        {
            int lungimeParola = 10;
            string caractereValide = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();
            char[] parolaCont = new char[lungimeParola];
            for (int i = 0; i < lungimeParola; i++)
            {
                parolaCont[i] = caractereValide[random.Next(0, caractereValide.Length)];
            }
            return new string(parolaCont);
        }
        private void golireTextBox()
        {
            textBoxNume.Clear();
            textBoxPrenume.Clear();
            textBoxEmail.Clear();
            textBoxNumarDeTelefon.Clear();
        }
        private bool VerificaPrenume(string prenume)
        {
            string[] cuvinte = prenume.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            return cuvinte.All(cuvant => cuvant.All(char.IsLetter)); // daca prenumele contine minim 1
        }
        private bool VerificaTextBoxes()
        {
            if (string.IsNullOrWhiteSpace(textBoxNume.Text))
            {
                MessageBox.Show("Numele nu poate fi gol");
                return false;
            }
            if (!textBoxNume.Text.Trim().All(char.IsLetter))
            {
                MessageBox.Show("Numele trebuie să conțină doar litere!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxPrenume.Text))
            {
                MessageBox.Show("Prenumele nu poate fi gol");
                return false;
            }

            if (!VerificaPrenume(textBoxPrenume.Text))
            {
                MessageBox.Show("Prenumele trebuie să conțină doar litere!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPrenume.Text))
            {
                MessageBox.Show("Adresa de email nu poate fi goala");
                return false;
            }
            if (!textBoxEmail.Text.Trim().Contains("@"))
            {
                MessageBox.Show("Adresa de email invalida - trebuie să conțină un @ ");
                return false;
            }
            if(!textBoxEmail.Text.Trim().Contains("."))
            {
                MessageBox.Show("Adresa de email invalida ");
                return false;
            }
            if(textBoxNumarDeTelefon.Text.Length !=10)
            {
                MessageBox.Show("Numărul de telefon trebuie să conțină maxim 10 cifre");
                return false;
            }
            if (!textBoxNumarDeTelefon.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Numărul de telefon trebuie să nu conțină caractere speciale!");
                return false;
            }
            return true;
        }
    }
}
