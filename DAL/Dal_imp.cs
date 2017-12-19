using BE;
using DS;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Dal_imp: Idal
    {
        public static int contractID = 1;
        public Dal_imp() => new DataSource(); //CTOR


        // Nanny functions

        public Nanny getNanny(long thisID)
        {
            return DataSource.nannyList.FirstOrDefault(n => n._nannyID == thisID);
        }

        public void addNanny(Nanny thisNany)
        {
            var index = DataSource.nannyList.FindIndex(n => n._nannyID == thisNany._nannyID);
            // if FindIndex method returns -1 so thisNany doesn't exist
            if (index != -1) 
                throw new Exception("Nanny already exist in the system");

            DataSource.nannyList.Add(thisNany);

        }

        void deleteNanny(Nanny thisNany)
        {
            var index = DataSource.nannyList.FindIndex(n => n._nannyID == thisNany._nannyID);
            if (index == -1)
                throw new Exception("Nanny doesn't exist in the system");

            // delete contractList that refers to thisNany
            DataSource.contractList.RemoveAll(c => c._nannyID == thisNany._nannyID);

            // now we can delete thisNany
            DataSource.nannyList.RemoveAt(index);
        }

        void updateNany(Nanny thisNany)
        {
            var index = DataSource.nannyList.FindIndex(n => n._nannyID == thisNany._nannyID);
            if (index == -1)
                throw new Exception("Nanny doesn't exist in the system");
            DataSource.nannyList[index] = thisNany;
        }

        // Mother functions
 
        public Mother getMom(long thisID)
        {
            return DataSource.motherList.FirstOrDefault(m => m._momID == thisID);
        }

        void deleteMother(Mother thisMom)
        {
            var index = DataSource.motherList.FindIndex(m => m._momID == thisMom._momID);
            if( index == -1 )
                throw new Exception("Mother doesn't exist in the system");

            // delete all children of thisMom
            var deleteAllKids = DataSource.childList.Where(c => c._momID == thisMom._momID);

            foreach (var child in deleteAllKids)
            {
                DataSource.childList.Remove(child);
            }

            // delete contractList that refers to thisMom (by her kids)
            DataSource.contractList.RemoveAll(c => c._childID == thisMom._

            // now we can remove the thisMom
            DataSource.motherList.RemoveAt(index);
        }


    }
}
