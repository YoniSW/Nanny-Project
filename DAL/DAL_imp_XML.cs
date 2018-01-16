using BE;
using DS;
using static DS.XML_Source;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    class DAL_imp_XML : Idal
    {
        public static int uniqueContractID = 1;


        #region Nanny


        public Nanny getNanny(long thisID)     //is XML 
        {
            var thisNanny = (from n in XML_Source.Nannys.Elements()
                             where Convert.ToInt64(n.Element("id").Value) == thisID
                             select n).FirstOrDefault();
            if (thisNanny == null)
                throw new Exception("ID doesn't exist");


            return thisNanny.toNanny();
        }

        public void addNanny(Nanny thisNanny)    //is XML  
        {
            var index = (from n in XML_Source.Nannys.Elements()
                         where Convert.ToInt32(n.Element("id").Value) == thisNanny._nannyID
                         select n).FirstOrDefault();
            // if FindIndex method returns -1 so thisNany doesn't exist
            if (index != null)
                throw new Exception("ID already exist in the system");

            else
            {
                XML_Source.Nannys.Add(thisNanny.toXML());
                XML_Source.SaveNannys();
                
            }


        }

        public void deleteNanny(long nanny)      //is XML   
        {
            XElement nannyElement = (from n in XML_Source.Nannys.Elements()
                                     where Convert.ToInt64(n.Element("id").Value) == nanny
                                     select n).FirstOrDefault();
            if (nannyElement != null)
            {
                nannyElement.Remove();
                XML_Source.SaveNannys();
            }
            else
                throw new Exception("the nanny is not in list\n");
        }

        public void updateNanny(Nanny nanny)     //is XML   
        {
            XElement nannyElement = (from n in XML_Source.Nannys.Elements()
                                     where Convert.ToInt32(n.Element("id").Value) == nanny._nannyID
                                     select n).FirstOrDefault();

            if (nannyElement != null)
            {
                nannyElement.Remove();
                XML_Source.Nannys.Add(nanny.toXML());
                XML_Source.SaveNannys();
            }
            else
                throw new Exception("the nanny is not in the system.\n");
        }


        #endregion





        #region Mother functions


        public Mother getMom(long thisID)
        {
            var thisMom = DataSource.motherList.FirstOrDefault(m => m._momID == thisID);
            if (thisMom == null)
                throw new Exception("ID doesn't exist");

            return thisMom.duplicate();
        }



        public void addMother(Mother mother)      //is XML  
        {
            var temp = (from m in XML_Source.Mothers.Elements()
                        where Convert.ToInt32(m.Element("id").Value) == mother._momID
                        select m).FirstOrDefault();
            if (temp == null)
            {
                XML_Source.Mothers.Add(mother.toXML());
                XML_Source.SaveMothers();
            }
            else
                throw new Exception("you are trying to add a existing mother.\n");
        }


        public void deleteMother(long thisMom)            //is XML  
        {
            XElement motherElement = (from n in XML_Source.Mothers.Elements()
                                      where Convert.ToInt32(n.Element("id").Value) == thisMom
                                      select n).FirstOrDefault();
            if (motherElement != null)
            {
                motherElement.Remove();
                XML_Source.SaveMothers();
            }
            else
                throw new Exception("you are trying to delete a mother that does not exist\n");

            ////else

            //// 1. delete all children of thisMom
            //var deleteAllKids = DataSource.childList.Where(c => c._momID == thisMom);

            //foreach (var child in deleteAllKids)
            //{
            //    DataSource.childList.Remove(child);
            //}

            //// 2. delete contractList that refers to thisMom (by her kids)
            //DataSource.contractList.RemoveAll(c => c._childID == thisMom);

            //// 3. now we can remove the thisMom
            //DataSource.motherList.RemoveAt(index);
            //XML_Source.Mothers.Remove(motherElement);

        }


        public void updateMother(Mother mother)           //is XML   
        {
            XElement motherElement = (from m in XML_Source.Mothers.Elements()
                                      where Convert.ToInt32(m.Element("id").Value) == mother._momID
                                      select m).FirstOrDefault();

            if (motherElement != null)
            {
                motherElement.Remove();
                XML_Source.Mothers.Add(mother.toXML());
                XML_Source.SaveMothers();
            }
            else
                throw new Exception("Mother doesn't exist in the system");
        }



        #endregion

        #region child functions
        public Child getChild(long thisID)
        {
            var thisChild = DataSource.childList.FirstOrDefault
                (c => c._childID == thisID);
            if (thisChild == null)
                throw new Exception("ID doesn't exist");

            return thisChild.duplicate();
        }

        public void addChild(Child thisKid)
        {
            var index = DataSource.childList.FindIndex
                (c => c._childID == thisKid._childID);
            if (index != -1)
                throw new Exception("Child already exists in the system");

            var childID = thisKid._childID;

            // add after XML database is added

            //var momHasThisID = DataSource.motherList.Any
            //   (c => c._momID == childID);
            //if(momHasThisID)
            //throw new Exception("we have a mom with same ID!");

            var thisMom = thisKid._momID;

            var momExist = DataSource.motherList.Any
                           (c => c._momID == thisMom);
            if (!momExist)
                throw new Exception("Mom's ID doesn't exist");

            DataSource.childList.Add(thisKid);
        }

        public void deleteChild(long thisKid)
        {
            var index = DataSource.childList.FindIndex
                (c => c._childID == thisKid);
            if (index == -1)
                throw new Exception("Child  doesn't exist in the system");
            // else

            // 1. delete all contracts with thisKid
            DataSource.contractList.RemoveAll
                (c => c._childID == thisKid);

            // 2. remove thisKid
            DataSource.childList.RemoveAt(index);

        }

        public void updateChild(Child thisChild)
        {

            var index = DataSource.childList.FindIndex
                (c => c._childID == thisChild._childID);
            if (index == -1)
                throw new Exception("Child doesn't exist in the system");

            //else

            DataSource.childList[index] = thisChild;

        }
        #endregion

        #region contract functions
        public Contract getContract(long id)
        {
            var thisContract = DataSource.contractList.FirstOrDefault
                (c => c._contractID == id);
            if (thisContract == null)
                throw new Exception("ID doesn't exist");

            return thisContract.duplicate();

        }

        public void addContract(Contract thisContract)
        {

            var index = DataSource.contractList.FindIndex
                (c => c._childID == thisContract._childID &&
            c._nannyID == thisContract._nannyID);

            if (index != -1)
                throw new Exception("Contract already exists in the system");

            // else - let's start creating a new contract

            // 1. add a child
            Child thisChild = getChild(thisContract._childID);
            // 2. add a mother according to thisChild
            Mother thisMom = getMom(thisChild._momID);

            // 3. check that mother exists
            var index2 = DataSource.motherList.FindIndex
                (m => m._momID == thisMom._momID);
            if (index2 == -1)
                throw new Exception("Mother doesn't exist in the system");

            // 4. add a nanny
            Nanny thisNanny = getNanny(thisContract._nannyID);

            // 5. check nanny exists
            var index3 = DataSource.nannyList.FindIndex
                (n => n._nannyID == thisNanny._nannyID);
            if (index3 == -1)
                throw new Exception("Nanny doesn't exist in the system");

            // 6. add to thisContract an unique ID
            thisContract._contractID = ++uniqueContractID;

            // 7. add thisContract to our contractLint
            DataSource.contractList.Add(thisContract);
        }

        public void updateContract(Contract thisContract)
        {
            var index = DataSource.contractList.FindIndex(c => c._contractID == thisContract._contractID);
            if (index == -1)
                throw new Exception("Contract doesn't exist in the system");

            DataSource.contractList[index] = thisContract;
        }

        public void deleteContract(long thisContract)
        {
            var index = DataSource.contractList.FindIndex(c => c._contractID == thisContract);
            if (index == -1)
                throw new Exception("Contract doesn't exist in the system");

            // contract exists

            // 1. nanny has one extra place
            Nanny thisNanny = getNanny(thisContract);
            thisNanny._amountChildren--;

            // 2. mom is now looking for a nanny
            Child thisKid = getChild(thisContract);
            Mother thisMom = getMom(thisKid._momID);
            thisMom._isLookingForNanny = true;

            // 3. update nanny & mom and then remove thisContract
            updateNanny(thisNanny);
            updateMother(thisMom);
            DataSource.contractList.RemoveAt(index);
        }
        #endregion

        #region IEnumerable methods
        public IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null)
        {
            if (Predicate == null)
                return DataSource.nannyList.AsEnumerable();
            return DataSource.nannyList.Where(Predicate);
        }

        public IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null)
        {
            if (Predicate == null)
                return DataSource.motherList.AsEnumerable();

            return DataSource.motherList.Where(Predicate);
        }

        public IEnumerable<Child> getAllChildren(Func<Child, bool> Predicate = null)
        {
            if (Predicate == null)
                return DataSource.childList.AsEnumerable();

            return DataSource.childList.Where(Predicate);

        }


        public IEnumerable<Child> getKidsByMom(Func<Child, bool> Predicate = null)
        {
            if (Predicate == null)
                throw new Exception("Please send mother ID");
            return DataSource.childList.Where(Predicate);
        }

        public IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null)
        {
            if (Predicate == null)
                return DataSource.contractList.AsEnumerable();

            return DataSource.contractList.Where(Predicate);
        }


        #endregion

    }
}
