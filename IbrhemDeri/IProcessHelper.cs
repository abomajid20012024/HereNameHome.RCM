using System.Collections.Generic;

namespace IbrhemDeri
{
    internal interface IProcessHelper<T>
    {
        /*
         * ===============================================================
         * This class contain method for all classes where have same method
         * onley method GetById , Update  have paramaters 
         * =============================================================== 
         */
        void Add();
       
        void Delete();
        /*
         * =======================================================================
         * Delete method have T Type where can send Object to update Object activate 
         * ========================================================================
         */
        void Update(T value);
        List<T> GetAll();
        /*
         * ==============================
         * send Id to get Object 
         * ==============================
         * 
         */
        T GetById(int id);

    }
}
