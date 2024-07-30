using System;
using System.Threading;
using System.Windows.Forms;
using ManagementulProiectelor.Forms;

namespace ManagementulProiectelor
{
    static class Program
    {
        private static Mutex mutex = new Mutex(true, "ManagementulProiectelorMutex");

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                try
                {
                    if (SesiuneUtilizatorEsteActiv())
                    {
                        FormLogare formLogare = new FormLogare();
                        Application.Run();
                    }
                    else
                    {
                        Application.Run(new FormLogare());
                    }
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            else
            {
                MessageBox.Show("Aplicația rulează deja.");
            }
        }
        static bool SesiuneUtilizatorEsteActiv()
        {
            return !string.IsNullOrEmpty(Properties.Settings.Default.Username) && !string.IsNullOrEmpty(Properties.Settings.Default.Parola);
        }
    }
}
