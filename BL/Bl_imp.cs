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

        // sent function to Idal only if method allowes =========================

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

        // send rest of the function to Idal without any method =============================

        public void addMother(Mother thisMom)
        {
            dal.addMother(thisMom);
        }

        void addChild(Child thisKid)
        {
            dal.addChild(thisKid);
        }

        void deleteNanny(Nanny thisNany)
        {
            dal.deleteNanny(thisNany);
        }

        void updateNany(Nanny thisNany)
        {
            dal.updateNany(thisNany);
        }

        void deleteMother(Mother thisMom)
        {
            dal.deleteMother(thisMom);
        }

        void updateMother(Mother thisMom)
        {
            dal.updateMother(thisMom);
        }

        void deleteChild(Child thisKid)
        {
            dal.deleteChild(thisKid);
        }

        void updateChild(Child thisChild)
        {
            dal.updateChild(thisChild);
        }

        void updateContract(Contract thisContract)
        {
            dal.updateContract(thisContract);
        }

        void deleteContract(Contract thisContract)
        {
            dal.deleteContract(thisContract);
        }

        // send IEnumerables to Idal ==================================================

        public IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null)
        {
            if (Predicate == null)
                return dal.getAllNanny();
            return dal.getAllNanny(Predicate);
        }

        public IEnumerable<Child> getKidsByMom(Func<Child, bool> Predicate = null)
        {
            if (Predicate == null)
                return dal.getKidsByMom();
            return dal.getKidsByMom(Predicate);
        }

        public IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null)
        {
            if (Predicate == null)
                return dal.getContracts();
            return dal.getContracts(Predicate);
        }

        public IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null)
        {
            if (Predicate == null)
                return dal.getAllMothers();
            return dal.getAllMothers(Predicate);
        }

    }
}
