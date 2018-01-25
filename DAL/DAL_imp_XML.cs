using BE;
using DS;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
//using  static DS.XML_Source;


namespace DAL
{
    internal class DAL_imp_XML : Idal
    {
        #region password //is XML
        public static int uniqueContractID = 1;
        public static string _password = "1234";

        public void addPass()
        {
            string firstCode = "1234";
            XML_Source.Passwords.Add(firstCode.toXMLPassword());
            XML_Source.SavePasswords();
        }

        public string getPass()   // שומר את הסיסמא בקובץ נפרד, אם הקובץ קיים- מאחזר את הסיסמא ממנו, אם הקובץ לא קיים- משתמש  בדיפולט
        {
            var code = (from n in XML_Source.Passwords.Elements()                             
                         select n).First();
            return code.Element("password").Value;
        }        
        
        public void changePass(string code)
        {
            if (code.Length < 4)
                throw new Exception("Password must be minimum 4 characters!");           

            var deletecode = (from n in XML_Source.Passwords.Elements()
                        select n).First();
            deletecode.Remove();            // clears the password existing
            XML_Source.SavePasswords();
            XML_Source.Passwords.Add(code.toXMLPassword());
            XML_Source.SavePasswords();
        }

#endregion

        #region   Nanny  //is XML


        public Nanny getNanny(long thisID)//is XML 
        {
            var thisNanny = (from n in XML_Source.Nannys.Elements()
                             where Convert.ToInt64(n.Element("id").Value) == thisID
                             select n).FirstOrDefault();
            if (thisNanny == null)
                throw new Exception("ID doesn't exist");

            return thisNanny.toNanny();
        }

        public void addNanny(Nanny thisNanny)//is XML  
        {
            var index = (from n in XML_Source.Nannys.Elements()
                         where Convert.ToInt64(n.Element("id").Value) == thisNanny._nannyID
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

        #region Mother functions  //is XML


        public void addMother(Mother mother)      //is XML  
        {
            var temp = (from m in XML_Source.Mothers.Elements()
                        where Convert.ToInt64(m.Element("id").Value) == mother._momID
                        select m).FirstOrDefault();
            if (temp != null)
            {
                throw new Exception("you are trying to add a existing mother.\n");
            }
            else
            {

                XML_Source.Mothers.Add(mother.toXML());
                XML_Source.SaveMothers();
            }
        }

        public Mother getMom(long thisID)           // is XML
        {
            var thisMom = (from n in XML_Source.Mothers.Elements()
                           where Convert.ToInt64(n.Element("id").Value) == thisID
                           select n).FirstOrDefault();
            if (thisMom == null)
                throw new Exception("ID doesn't exist");

            return thisMom.toMother();


        }


        public void deleteMother(long thisMom)            //is XML  
        {
            XElement motherElement = (from n in XML_Source.Mothers.Elements()
                                      where Convert.ToInt32(n.Element("id").Value) == thisMom
                                      select n).FirstOrDefault();
            if (motherElement == null)
            {
                throw new Exception("you are trying to delete a mother that does not exist\n");
            }

            // deleates childs that are related to the mother
            XElement ChildtDelete = (from n in XML_Source.Children.Elements()
                                     where Convert.ToInt64(n.Element("id").Value) == thisMom
                                     select n).FirstOrDefault();
            if (ChildtDelete != null)
            {
                ChildtDelete.Remove();
            }

            // deleates contracts that are related to the mother 
            XElement ContractDelete = (from n in XML_Source.Contracts.Elements()
                                       where Convert.ToInt64(n.Element("id").Value) == thisMom
                                       select n).FirstOrDefault();
            if (ContractDelete != null)
            {
                ContractDelete.Remove();
            }


            motherElement.Remove();
            XML_Source.SaveMothers();



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

        #region child functions  // is XML

        public Child getChild(long thisID)    // is XML
        {
            var thisChild = (from n in XML_Source.Nannys.Elements()
                             where Convert.ToInt64(n.Element("id").Value) == thisID
                             select n).FirstOrDefault();
            if (thisChild == null)
                throw new Exception("ID doesn't exist");

            return thisChild.toChild();
        }

        public void addChild(Child thisKid)   // is XML
        {
            var index = (from n in XML_Source.Children.Elements()
                         where Convert.ToInt64(n.Element("id").Value) == thisKid._childID
                         select n).FirstOrDefault();
            if (index != null)
                throw new Exception("Child already exists in the system");

            //var momExist = (from n in XML_Source.Mothers.Elements()
            //                where Convert.ToInt64(n.Element("id").Value) == thisKid._momID
            //                select n).FirstOrDefault();

            //if (momExist != null)
            //{
            //    throw new Exception("Mom's ID doesn't exist");
            //}
            else
            {
                XML_Source.Children.Add(thisKid.toXML());
                XML_Source.SaveChildren();
            }



            //var childID = thisKid._childID;

            // add after XML database is added

            //var momHasThisID = DataSource.motherList.Any
            //   (c => c._momID == childID);
            //if(momHasThisID)
            //throw new Exception("we have a mom with same ID!");

            //var thisMom = thisKid._momID;

            //var momExist = DataSource.motherList.Any
            //               (c => c._momID == thisMom);



        }


        public void deleteChild(long thisKid)   // is XML
        {

            XElement index = (from n in XML_Source.Children.Elements()
                              where Convert.ToInt64(n.Element("id").Value) == thisKid
                              select n).FirstOrDefault();
            if (index == null)
                throw new Exception("Child  doesn't exist in the system");
            // else

            // 1. delete all contracts with thisKid
            XElement ContractDelete = (from n in XML_Source.Contracts.Elements()
                                       where Convert.ToInt64(n.Element("id").Value) == thisKid
                                       select n).FirstOrDefault();
            ContractDelete.Remove();
            //DataSource.contractList.RemoveAll
            //    (c => c._childID == thisKid);

            // 2. remove thisKid           
            index.Remove();                     // removes the kid
            XML_Source.SaveContracts();

        }

        public void updateChild(Child thisChild)  //  is XML
        {

            XElement childElement = (from n in XML_Source.Nannys.Elements()
                                     where Convert.ToInt32(n.Element("id").Value) == thisChild._childID
                                     select n).FirstOrDefault();
            if (childElement != null)
            {
                childElement.Remove();
                XML_Source.Children.Add(thisChild.toXML());
                XML_Source.SaveChildren();
            }
            else
            {
                throw new Exception("the child does not exist in the system.");
            }
        }



        #endregion

        #region contract functions  // is XML

        //public void addContract(Contract thisContract)
        //{

        //    var index = DataSource.contractList.FindIndex
        //        (c => c._childID == thisContract._childID &&
        //    c._nannyID == thisContract._nannyID);

        //    if (index != -1)
        //        throw new Exception("Contract already exists in the system");

        //    // else - let's start creating a new contract

        //    // 1. add a child
        //    Child thisChild = getChild(thisContract._childID);
        //    // 2. add a mother according to thisChild
        //    Mother thisMom = getMom(thisChild._momID);

        //    // 3. check that mother exists
        //    var index2 = DataSource.motherList.FindIndex
        //        (m => m._momID == thisMom._momID);
        //    if (index2 == -1)
        //        throw new Exception("Mother doesn't exist in the system");

        //    // 4. add a nanny
        //    Nanny thisNanny = getNanny(thisContract._nannyID);

        //    // 5. check nanny exists
        //    var index3 = DataSource.nannyList.FindIndex
        //        (n => n._nannyID == thisNanny._nannyID);
        //    if (index3 == -1)
        //        throw new Exception("Nanny doesn't exist in the system");

        //    // 6. add to thisContract an unique ID
        //    thisContract._contractID = uniqueContractID++;

        //    // 7. add thisContract to our contractLint
        //    DataSource.contractList.Add(thisContract);
        //}

        public void addContract(Contract thisContract)  // is XML
        {

            var index = (from n in XML_Source.Contracts.Elements()
                         where Convert.ToInt64(n.Element("NannysId").Value) == thisContract._nannyID
                         select n).FirstOrDefault();
            var temp = (from n in XML_Source.Contracts.Elements()
                         where Convert.ToInt64(n.Element("childId").Value) == thisContract._childID
                         select n).FirstOrDefault();

            if ((index != null) && (temp != null))
                throw new Exception("Contract already exists in the system");

            // else - let's start creating a new contract

            // 1. add a child
            Child thisChild = getChild(thisContract._childID);

            // 2. add a mother according to thisChild
            Mother thisMother = getMom(thisChild._momID);

            var index2 = (from n in XML_Source.Mothers.Elements()
                          where Convert.ToInt64(n.Element("id").Value) == thisMother._momID
                          select n).FirstOrDefault();

            if (index2 == null)
                throw new Exception("Mother doesn't exist in the system");

            // 4. add a nanny
            Nanny thisNanny = getNanny(thisContract._nannyID);

            // 5. check nanny exists
            var index3 = (from n in XML_Source.Nannys.Elements()
                          where Convert.ToInt64(n.Element("id").Value) == thisNanny._nannyID
                          select n).FirstOrDefault();

            if (index3 == null)
                throw new Exception("Nanny doesn't exist in the system");

            // 6. add to thisContract an unique ID
            thisContract._contractID = ++uniqueContractID;

            // 7. add thisContract to our contractLint
            XML_Source.Contracts.Add(thisContract);
        }

        public Contract getContract(long id)    // is XML
        {
            var thisContract = (from n in XML_Source.Nannys.Elements()
                                where Convert.ToInt64(n.Element("id").Value) == id
                                select n).FirstOrDefault();
            if (thisContract == null)
                throw new Exception("ID doesn't exist");

            return thisContract.toContract();

        }

        public void updateContract(Contract thisContract)   //  is XML
        {
            var index = (from n in XML_Source.Contracts.Elements()
                         where Convert.ToInt64(n.Element("id").Value) == thisContract._contractID
                         select n).FirstOrDefault();

            if (index != null)
            {
                index.ReplaceWith(thisContract.toXML());
                XML_Source.SaveContracts();
            }
            else
                throw new Exception("Contract doesn't exist in the system");
        }

        public void deleteContract(long thisContract)   // is XML
        {
            XElement index = (from n in XML_Source.Contracts.Elements()
                              where Convert.ToInt64(n.Element("id").Value) == thisContract
                              select n).FirstOrDefault();
            if (index == null)
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
            index.Remove();
        }
        #endregion

        #region IEnumerable methods

        //public IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null)     --->  original
        //{
        //    if (Predicate == null)
        //        return nannyList.AsEnumerable();
        //    return nannyList.Where(Predicate);
        //}


        //public IEnumerable<Nanny> getListOfNanny()
        //{
        //    XElement root = XML_Source.Nannys;
        //    List<Nanny> result = new List<Nanny>();
        //    foreach (var n in root.Elements("Nanny"))
        //    {
        //        result.Add(n.toNanny());
        //    }
        //    return result.AsEnumerable();
        //}

        public IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null)
        {
            XElement root = XML_Source.Nannys;
            List<Nanny> result = new List<Nanny>();

            foreach (var n in root.Elements("Nanny"))
            {
                result.Add(n.toNanny());
            }
            return result.AsEnumerable();
            //  if (Predicate == null)
            //return XML_Source.Nannys.AsEnumerable();
            //return XML_Source.Nannys.Where(Predicate);
            //    ;
        }



        public IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null)
        {
            XElement root = XML_Source.Mothers;
            List<Mother> result = new List<Mother>();

            foreach (var n in root.Elements("Mother"))
            {
                result.Add(n.toMother());
            }
            return result.AsEnumerable();

        }

        public IEnumerable<Child> getAllChildren(Func<Child, bool> Predicate = null)
        {
            XElement root = XML_Source.Children;
            List<Child> result = new List<Child>();

            if (Predicate!=null)
            {
                return result.Where(Predicate);
            }

            foreach (var n in root.Elements("Child"))
            {
                result.Add(n.toChild());
            }
            return result.AsEnumerable();

        }

        public IEnumerable<Child> getKidsByMom(Func<Child, bool> Predicate = null) // is XML but needed check
        {
           
            if (Predicate == null)
                throw new Exception("Please send mother ID");
            //var nothing = Predicate;
            //return XML_Source.Children.(Predicate);

            //var index = (from n in XML_Source.Children.Elements()
            //             where Convert.ToInt64(n.Element("momsId").Value) == nothing
            //             select n).FirstOrDefault();

            XElement root = XML_Source.Children;
            List<Child> result;    //= new List<Child>();  

            result = (from child in root.Elements("Child")
                      select new Child()
                      {
                          _childID = Int32.Parse(child.Element("id").Value),
                          _childFname = child.Element("name").Value,
                          _momID = Int32.Parse(child.Element("momsId").Value),
                          _birthday = DateTime.Parse(child.Element("birthday").Value),
                          _isSpecialNeed = Boolean.Parse(child.Element("hasSpecialNeeds").Value),
                          _specialNeeds = child.Element("specialNeeds").Value,
                          _isAlergic = Boolean.Parse(child.Element("isAlergic").Value),
                          _alergies = child.Element("alergies").Value,

                          //idMom = long.Parse(child.Element("idMom").Value),
                          //idChild = long.Parse(child.Element("idChild").Value),
                          //firstName = child.Element("name").Element("firstName").Value,
                          //lastName = child.Element("name").Element("lastName").Value,
                          //birthdayKid = DateTime.Parse(child.Element("birthday").Value),
                          //isSpecialNeed = bool.Parse(child.Element("isSpecial").Value),
                          //specialNeeds = child.Element("needs").Value,
                      } ).ToList(); 
        
                //catch 
                //{
                //    result = null;
                //}
                if (Predicate == null)
                    return result;
                return result.Where(Predicate);
        }





        //    foreach (var n in root.Elements("Child"))
        //    {
        //        //if (Predicate != null)
        //            result.Add(n.toChild());
        //    }          

        //    //if (Predicate == null)
        //    //    return result;            
        //    return result.Where(Predicate);
        //    // return result.AsEnumerable();

        //}

        //public IEnumerable<Child> getKids(Func<Child, bool> Predicate = null)
        //{
        //    LoadData("child");
        //    List<Child> kidsList;
        //    try
        //    {
        //        kidsList = (from child in childFile.Elements()
        //                    select new Child()
        //                    {
        //                        idMom = long.Parse(child.Element("idMom").Value),
        //                        idChild = long.Parse(child.Element("idChild").Value),
        //                        firstName = child.Element("name").Element("firstName").Value,
        //                        lastName = child.Element("name").Element("lastName").Value,
        //                        birthdayKid = DateTime.Parse(child.Element("birthday").Value),
        //                        isSpecialNeed = bool.Parse(child.Element("isSpecial").Value),
        //                        specialNeeds = child.Element("needs").Value,
        //                    }).ToList();

        //    }
        //    catch
        //    {
        //        kidsList = null;
        //    }
        //    if (Predicate == null)
        //        return kidsList;
        //    return kidsList.Where(Predicate);
        //}

        public IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null)
        {
            XElement root = XML_Source.Contracts;
            List<Contract> result = new List<Contract>();

            foreach (var n in root.Elements("Child"))
            {
                result.Add(n.toContract());
            }
            return result.AsEnumerable();

        }


        #endregion

    }
}
