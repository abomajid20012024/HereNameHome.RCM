using System;
using System.Collections.Generic;
using System.Linq;

namespace IbrhemDeri
{
    internal class Doctor : User, IProcessHelper<Doctor>
    {
        public enum Title
        {
            First,
            Second,
            Third,

        }
        public enum Spe
        {
            FirstSpe,
            SecondSpe,
            ThirdSpe,

        }
        public Title TitleDoctor {  get; set; }
        public Spe Specialization { get; set; }
        static int id = 1;
        public Doctor(String Name, DateTime BirthDate, Spe specialization)
        {
            Id = id;
            id += 1;
            this.Name = Name;
            this.BirthDate = BirthDate;
            this.Specialization = specialization;

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
            if (!DB.Doctors.ContainsKey(Id))
            {
                DB.Doctors.Add(Id, this);
                Console.WriteLine("Okey thid id " + Id + " Name : " + Name + " doctor is added");
            }

            else
            {
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
            if (DB.Doctors.ContainsKey(Id))
            {
                DB.Doctors.Remove(Id);
                Console.WriteLine("Okey Deleted ID:" + Id + " Name : " + Name + "Name :" + Name);
            }

            else
            {
                Console.WriteLine("Error this id " + Id + " Name : " + Name + " is not exist before");
            }
        }

        public List<Doctor> GetAll()
        {
            /* =====================
          * get from DB.Doctors and return 
          * =====================
          */
            return DB.Doctors.Values.ToList();
        }

        public Doctor GetById(int id)
        {
            /* ===========================================================
       * To get object will get id to get object linked in id from DB.Doctors
       * ===========================================================
      */
            if (DB.Doctors.ContainsKey(Id))
            {
                return DB.Doctors[Id];
            }

            throw new Exception("Error this Doctor is not exist before");
        }

        public void Update(Doctor value)
        {
            /*
           * ====================================================
           * To update object will get object and send to DB 
           * will check if id Object in DB in dictionary Doctors
           */
            if (DB.Doctors.ContainsKey(value.Id))
                DB.Doctors[value.Id] = value;
            else
            {
                Console.WriteLine("Error is not found this Doctor to update ! ");
            }
        }
        override
        public String ToString()
        {
            /*
             * ===========================
             * Override tostring from Object
             * ===========================
             */
            return "Id is : " + Id + "\nName is : " + Name + "\nDate is: " + BirthDate + "\nSpecialization is: " + Specialization;
        }
        public int GetSalary()
        {
            /*
             * =================================================
             * first get all object MedicalService in DB
             * will get  id doctor and if equal id here will sum 
             * return sum
             * =================================================
             */
            int sum = 0;
            List<MedicalService>lis= DB.MedicalServices.Values.ToList();
            foreach (var item in lis)
            {
                if(item.DoctorId == id)
                {
                    sum += item.Price;
                }
                
            }

            return sum;
        }
    }
}
