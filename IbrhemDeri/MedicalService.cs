using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IbrhemDeri
{
    internal class MedicalService : IProcessHelper<MedicalService>
    {
        public enum Title
        {
            First,
            Second,
            Third,

        }
        public Title title { get; set; }
        static int id = 1;
        public int Id { get; }
        public DateTime DeliveryDate {  get; set; }
        public int DoctorId { get; set; }
        public String description { get; set; }
        public int Price {  get; set; }
     
         public MedicalService(Title title, DateTime DeliveryDate,int DoctorId,String desc,int Price,int IdDoctor)
        {
            Id= id;
            id++;
          this.DeliveryDate = DeliveryDate;
            this.description = desc;
            this.Price = Price;
            this.title = title;
            this.DoctorId = IdDoctor;

        }
        public MedicalService(Title title, String desc, int Price)
        {
            Id = id;
            id++;
            this.DeliveryDate = DeliveryDate;
            this.description = desc;
            this.Price = Price;
            this.title = title;
           
        }
        public void Add()
        {
            if (!DB.MedicalServices.ContainsKey(Id))
            {
                if (DB.Doctors.ContainsKey(DoctorId))
                    {
                    DB.MedicalServices.Add(Id, this);
                    Console.WriteLine("Okey this id " + Id  + " MedicalServices is added");
                }
                else
                {
                    Console.WriteLine("This doctor is not found please input id for doctor ");
                }


            }
            else
            {
                Console.WriteLine("Error this id " + Id + " MedicalServices is exist before");
            }

        }

        public void Delete()
        {

            if (DB.MedicalServices.ContainsKey(Id))
            {
                DB.MedicalServices.Remove(Id);
                Console.WriteLine("Okey Deleted ID MedicalServices:" + Id + "Title is "+title);
            }

            else
            {
                Console.WriteLine("Error this id MedicalServices " + Id +" is not exist before");
            }
        }

        public List<MedicalService> GetAll()
        {
            return DB.MedicalServices.Values.ToList();
        }

        public MedicalService GetById(int id)
        {
            if (DB.MedicalServices.ContainsKey(Id))
            {
                return DB.MedicalServices[Id];
            }
            Console.WriteLine("Error this MedicalServices is not exist before ");
            throw new Exception("Error this MedicalServices is not exist before");
        }

        public void Update(MedicalService value)
        {
            if (DB.MedicalServices.ContainsKey(value.Id))
                DB.MedicalServices[value.Id] = value;
            else
            {
                Console.WriteLine("Error is not found this Patient to update ! ");
            }
        }
    }
}
