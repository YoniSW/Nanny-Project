using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Bl_imp : IBL
    {
        DAL.Idal dal;
        //public Bl_imp()
        //{
        //    dal = DAL.factoryDal.getDal(); ---> ask 
        //}

        // metods,  
        // before values are sent to functions at Dal_imp,
        // check next logics:

        // =============================================================================================

        // 1. nanny sould be older that 18
        public void addNanny(Nanny thisNanny)
        {
            DateTime now = DateTime.Now;
            if (now.Year - 18 < thisNanny._nannyBirth.Year)
                throw new Exception("Nanny is under 18");

            dal.addNanny(thisNanny);
        }

        // 2. child should be older than 3 months
        public void addContract(Contract thisCon)
        {
            Child thisKid = dal.getChild(thisCon._childID);
            DateTime now = DateTime.Now;
            if (now.Month - thisKid._birthdayKid.Month < 3)
                throw new Exception("Child is under 3 months");

            // 2a. add only an available Nanny
            Nanny thisNanny = dal.getNanny(thisCon._nannyID);
            if (thisNanny._amountChildren == thisNanny._maxamountChildren)
                throw new Exception("This nanny reached the limit of children");
            /////////////////////////
            // add salary function
            /////////////////////////
            dal.addContract(thisCon);
        }



    }
}
