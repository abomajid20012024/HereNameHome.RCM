using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrhemDeri
{
    internal class Invoice : IProcessHelper<Invoice>
    {
        static int id = 1;
        public int Id { get; }
        public DateTime CreationDate { get; set; }
        public string PatientStatus {  get; set; }
        public int DoctorId
        {
            get { return id; }

            set
            {
                if (DB.Doctors.ContainsKey(value))
                {
                    id = value;
                }
                else
                {
                    Console.WriteLine("Error my bro is not Doctor");
                }

            }
        }
        public int PatientId
        {
            get { return id; }

            set
            {
                if (DB.Patients.ContainsKey(value))
                {
                    id = value;
                }
                else
                {
                    Console.WriteLine("Error ,this id my bro, is not Patient");
                }

            }
        }
        public List<MedicalService> MedicalServiceIds=new List<MedicalService>();
        public Invoice(DateTime creationDate, int doctorId, int patientId)
        {
            Id = id;
            id++;
            CreationDate = creationDate;
            DoctorId = doctorId;
            PatientId = patientId;
        }

        public void Add()
        {

            /*
             * We have Patient id so will check if Invoices have this Invoices
             * will check if idPatient in Patients 
             */
            if (!DB.Invoices.ContainsKey(Id))
            {
                if (DB.Patients.ContainsKey(PatientId))
                {
                    DB.Invoices.Add(Id, this);
                    Console.WriteLine("Okey this id " + Id + " MedicalServices is added");
                }
                else
                {
                    Console.WriteLine("This Patient is not found please input id and added to patients object ");
                }
            }  else
                {
                    Console.WriteLine("This Invoice is not found please input id and added to Invoices object ");
                }
        }
        public void Delete()
        {
            /* ==============================================
             * will check if id in Invoices and remove latter
             * ==============================================
             */
            if (DB.Invoices.ContainsKey(Id))
            {
                DB.Invoices.Remove(Id);
                Console.WriteLine("Okey Deleted ID Invoices: " + Id);
            }

            else
            {
                Console.WriteLine("Error this id Invoices " + Id + " is not exist before");
            }
        }

         public List<Invoice> GetAll()
        {
            return DB.Invoices.Values.ToList();
        } 
        public void Update(Invoice value)
        {
            /*
            * ====================================================
            * To update object will get object and send to DB 
            * will check if id Object in DB in dictionary Invoices
            * ====================================================
            */
            if (DB.Invoices.ContainsKey(value.Id))
                DB.Invoices[value.Id] = value;
            else
            {
                Console.WriteLine("Error is not found this Invoices to update ! ");
            }
        }

         public void AddMS(int msId)
        {
            /*
             * ====================================================
             * will check if MedicalServisces have id msId and get if that
             * 
             * 
             * ====================================================
             */
            if (DB.MedicalServices.ContainsKey(msId))
            {
                if (!MedicalServiceIds.Contains(DB.MedicalServices[msId]))
                MedicalServiceIds.Add(DB.MedicalServices[msId]) ;
            }
            else
            {
                Console.WriteLine("is not exist before MsId");
            }
        }
        public void DeleteMS( int idMS)
        {
            int i  = -1;
            /*
             * ====================================================
             * will check if MedicalServisces have object have id msId and get and delete if that
             *
             * ====================================================
             */
            foreach(MedicalService item in MedicalServiceIds)
            {
                if (item.Id== idMS)
                {
                    MedicalServiceIds.Remove(item);
                    i++;
                    Console.WriteLine("Will deleted MedicalServiceIds have id : " + idMS);
                }
            }
            if (i == -1)
            {
                Console.WriteLine("id: "+idMS+" is not found MsId before");
            }
          
        }
        public Invoice GetById(int id)
        {
        /* ===========================================================
        * 
        * To get object will get id to get object linked in id from DB
        * 
        * ===========================================================
       */
            if (DB.Invoices.ContainsKey(Id))
            {
                return DB.Invoices[Id];
            }
            Console.WriteLine("Error this Invoices is not exist before ");
            throw new Exception("Error this Invoices is not exist before");
        }
        public Invoice GetByPatientId(int id)
        {
            if (DB.Patients.ContainsKey(Id))
            {
                foreach (Invoice pat in DB.Invoices.Values.ToList())
                {
                    if (pat.PatientId == id)
                    {
                        return pat;
                    }

                }
            }
            Console.WriteLine("Error this Id patient is not exist Invoice before ");
            throw new Exception("Error this patient Invoices is not exist before");
        }
     
       
        public List<MedicalService> GetMedicalServices()
        {
            return MedicalServiceIds;

        }
        public Patient GetPatient()
        {
            Patient patient;
            if (DB.Patients.TryGetValue(PatientId, out patient))
            {
                return patient;
            }
            else
            {
                throw new Exception("Error this patient  is not exist before");
            }
        }
    }
}
