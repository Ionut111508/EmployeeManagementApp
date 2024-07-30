using System;

namespace ManagementulProiectelor.Java
{
    class Sesiune
    {
        public static String ID_ANGAJAT { get; set; }
        public static bool IsAdmin { get; set; }
        public static bool IsManager { get; set; }
        public static bool IsAngajatSimplu { get; set; }

        private static bool esteConectat;

        public static bool EsteConectat
        {
            get { return esteConectat; }
        }

        public static void IncepeSesiune(String idAngajat, bool isAdmin, bool isManager, bool isAngajatSimplu)
        {
            ID_ANGAJAT = idAngajat;
            IsAdmin = isAdmin;
            IsManager = isManager;
            IsAngajatSimplu = isAngajatSimplu;
            esteConectat = true;
        }

        public static void GolireSesiune()
        {
            ID_ANGAJAT = null;
            IsAdmin = false;
            IsManager = false;
            IsAngajatSimplu = false;
            esteConectat = false;
        }
    }
}
