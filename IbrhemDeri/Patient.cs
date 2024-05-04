using System;
using System.Collections.Generic;
using System.Linq;

namespace IbrhemDeri
{

    internal class Patient : User, IProcessHelper<Patient>
    {
        public enum Status
        {
            in_Waiting,
            in_procsing,
            out_waiting,
            dead,
            Unknwon,
        }
 
        static int id = 1;
        public Status patientStatus { get; set; }
        public Patient(String Name, DateTime BirthDate ,Status status)
        {
             
            Id = id;
            id += 1;
            this.Name = Name;
            this.BirthDate = BirthDate;
          patientStatus = status;

        }
        override
        public String ToString()
        {
            return ( "Id is : "+ Id + "\nName : " + Name +"\nBirthDate is: "+BirthDate + "\nStatus it: " + patientStatus.ToString());
        }
        public void Add()
        {
            /*
             * =======================================
             * To add Object where have id  
             * will check if id isnot exist before in dictionary in DB will added 
             * else show error message
             * =======================================
             */
            if (!DB.Patients.ContainsKey(Id))
            {
                DB.Patients.Add(Id, this);
                Console.WriteLine("Okey this id " + Id + " Name : " + Name + " patient is added");
            }


            else
            {
                //error is exist before 
                Console.WriteLine("Error this id " + Id + " Name : " + Name + " is exist before");
            }
        }

        public void Delete()
        {
            /*
           * =======================================
           * 
           * To delete Object will send Id where have it
           * will check if id is  exist before in dictionary in DB
           * if exist will delet it
           * else show message error
           * =======================================
           */
            if (DB.Patients.ContainsKey(Id))
            {
                DB.Patients.Remove(Id);
                Console.WriteLine("Okey Deleted ID Patient:" + Id + " Name : " + Name + "Name :" + Name);
            }

            else
            {//Error isnot exist to delete 
                Console.WriteLine("Error this id Patient " + Id + " Name : " + Name + " is not exist before"+ " and Status it ");
            }
        }

        public List<Patient> GetAll()
        {
            /* =====================
             * get from DB.Patient and return 
             * =====================
             */
            return DB.Patients.Values.ToList();
        }

        public Patient GetById(int id)
        {
          /* ===========================================================
           * To get object will get id to get object linked in id from DB
           * ===========================================================
          */
            if (DB.Patients.ContainsKey(Id))
            {
                return DB.Patients[Id];
            }
            Console.WriteLine("Error this Patient is not exist before ");
            throw new Exception("Error this Patient is not exist before");
        }

        public void Update(Patient value)
        {
            /*
             * ====================================================
             * To update object will get object and send to DB 
             * will check if id Object in DB in dictionary Patients
             */

            if (DB.Patients.ContainsKey(value.Id))
                DB.Patients[value.Id] = value;
            else
            {//Error 
                Console.WriteLine("Error is not found this Patient to update ! ");
            }
        }
    }
}
