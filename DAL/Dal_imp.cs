using BE;
using DS;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
     public class Dal_imp : Idal
    {
        public static int uniqueContractID = 1;
        public Dal_imp() => new DataSource(); //CTOR

        // Nanny functions ================================================================================

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


        // Mother functions ================================================================================

        public Mother getMom(long thisID)
        {
            return DataSource.motherList.FirstOrDefault(m => m._momID == thisID);
        }

        public void addMother(Mother thisMom)
        {
            var index = DataSource.motherList.FindIndex(m => m._momID == thisMom._momID);
            if (index != -1)
                throw new Exception("Mother already exists in the system");

            DataSource.motherList.Add(thisMom);
        }

        void deleteMother(Mother thisMom)
        {
            var index = DataSource.motherList.FindIndex(m => m._momID == thisMom._momID);
            if( index == -1 )
                throw new Exception("Mother doesn't exist in the system");

            //else

            // 1. delete all children of thisMom
            var deleteAllKids = DataSource.childList.Where(c => c._momID == thisMom._momID);

            foreach (var child in deleteAllKids)
            {
                DataSource.childList.Remove(child);
            }

            // 2. delete contractList that refers to thisMom (by her kids)
            DataSource.contractList.RemoveAll(c => c._childID == thisMom._momID);

            // 3. now we can remove the thisMom
            DataSource.motherList.RemoveAt(index);

        }

        void updateMother(Mother thisMom)
        {
            var index = DataSource.motherList.FindIndex(m => m._momID == thisMom._momID);
            if (index == -1)
                throw new Exception("Mother doesn't exist in the system");

            DataSource.motherList[index] = thisMom;

        }

        // child functions ================================================================================

        public Child getChild(long thisID)
        {
            return DataSource.childList.FirstOrDefault(c => c._childID == thisID);
        }

        void addChild(Child thisKid)
        {
            var index = DataSource.childList.FindIndex(c => c._childID == thisKid._childID);
            if (index != -1)
                throw new Exception("Child already exists in the system");

            DataSource.childList.Add(thisKid);
        }

        void deleteChild(Child thisKid)
        {
            var index = DataSource.childList.FindIndex(c => c._childID == thisKid._childID);
            if (index == -1)
                throw new Exception("Child  doesn't exist in the system");
            // else

            // 1. delete all contracts with thisKid
            DataSource.contractList.RemoveAll(c => c._childID == thisKid._childID);

            // 2. remove thisKid
            DataSource.childList.RemoveAt(index);

        }

        void updateChild(Child thisChild)
        {

            var index = DataSource.childList.FindIndex(c => c._childID == thisChild._childID);
            if (index == -1)
                throw new Exception("Child doesn't exist in the system");

            //else

            DataSource.childList[index] = thisChild;

        }

        // contract functions ================================================================================

        public Contract getContract(long id)
        {
            return DataSource.contractList.FirstOrDefault(c => c._contractID == id);
        }

        void addContract(Contract thisContract)
        {

            var index = DataSource.contractList.FindIndex(c => c._childID == thisContract._childID && 
            c._nannyID == thisContract._nannyID);

            if(index != -1)
                throw new Exception("Contract already exists in the system");

            // else - let's start creating a new contract

            // 1. add a child
            Child thisChild = getChild(thisContract._childID);
            // 2. add a mother according to thisChild
            Mother thisMom = getMom(thisChild._momID);

            // 3. check that mother exists
            var index2 = DataSource.motherList.FindIndex(m => m._momID == thisMom._momID);
            if (index2 == -1)
                throw new Exception("Mother doesn't exist in the system");

            // 4. add a nanny
            Nanny thisNanny = getNanny(thisContract._nannyID);

            // 5. check nanny exists
            var index3 = DataSource.nannyList.FindIndex(n => n._nannyID == thisNanny._nannyID);
            if (index3 == -1)
                throw new Exception("Nanny doesn't exist in the system");

            // 6. add to thisContract an unique ID
            thisContract._contractID = ++uniqueContractID;

            // 7. add thisContract to our contractLint
            DataSource.contractList.Add(thisContract);
        }

        void updateContract (Contract thisContract)
        {
            var index = DataSource.contractList.FindIndex(c => c._contractID == thisContract._contractID);
            if (index == -1)
                throw new Exception("Contract doesn't exist in the system");

            DataSource.contractList[index] = thisContract;
        }

        void deleteContract(Contract thisContract)
        {
            var index = DataSource.contractList.FindIndex(c => c._contractID == thisContract._contractID);
            if (index == -1)
                throw new Exception("Contract doesn't exist in the system");

            // contract exists

            // 1. nanny has one extra place
            Nanny thisNanny = getNanny(thisContract._nannyID);
            thisNanny._amountChildren--;

            // 2. mom is now looking for a nanny
            Child thisKid = getChild(thisContract._childID);
            Mother thisMom = getMom(thisKid._momID);
            thisMom._isLookingForNanny = true;

            // 3. update nanny & mom and then remove thisContract
            updateNany(thisNanny);
            updateMother(thisMom);
            DataSource.contractList.RemoveAt(index);
        }

            // get IEnumerable functions =================================================================

            IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null)
            {
                if (Predicate == null)
                    return DataSource.nannyList.AsEnumerable();
                return DataSource.nannyList.Where(Predicate); 
            }

            IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null)
            {
                if (Predicate == null)
                    return DataSource.motherList.AsEnumerable();

            return DataSource.motherList.Where(Predicate);
            }


            IEnumerable<Child> getKidsByMoms(Func<Child, bool> Predicate = null)
            {
                if (Predicate == null)
                    throw new Exception("Please send mother ID");
                return DataSource.childList.Where(Predicate);
            }

            IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null)
            {
                if (Predicate == null)
                    return DataSource.contractList.AsEnumerable();

                return DataSource.contractList.Where(Predicate);
            }

        


    }
}
