using System.Collections.Generic;

namespace IbrhemDeri
{
    internal class DB
    {
        DB()
        {

        }
        /*
         * ============================
         * This class contain dictionary
         * for every class can store 
         * id class and object 
         * ============================
         * 
         */
        public static Dictionary<int, Doctor> Doctors = new Dictionary<int, Doctor>();
        public static Dictionary<int, Patient> Patients = new Dictionary<int, Patient>();
        public static Dictionary<int, MedicalService> MedicalServices = new Dictionary<int, MedicalService>();
        public static Dictionary<int, Invoice> Invoices = new Dictionary<int, Invoice>();
    }
}
