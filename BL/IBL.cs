﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    // logical abstract declerations
    // the Bl.imp will inherit those declerations
    public interface IBL
    {
        void addPass();
        string getPass();
        void changePass(string s);
        // nany function declarations
        void addNanny(Nanny nanny);
        void deleteNanny(long ID);
        Nanny getNanny(long ID);
        void updateNanny(Nanny nanny);


        // mother function declarations
        void addMother(Mother mom);
        void deleteMother(long ID);
        Mother getMother(long ID);
        void updateMother(Mother mom);
        double getMotherHours(Mother addMom);

        // child function declarations
        void addChild(Child kid);
        void deleteChild(long ID);
        Child getChild(long ID);
        void updateChild(Child kid);

        // contract function declarations
        void addContract(Contract con);
        void updateContract(Contract con);
        Contract getContract(long ID);
        void deleteContract(long ID);
        int getContractDays(Contract addMom);
        double getUpdatedRate(long kidID, long nannyID, bool isHour);

        // methods
        int caculateDistance(string source, string destination);
        IEnumerable<Child> getAllChildren(Func<Child, bool> Predicate = null);
        IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null);
        IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null);
        IEnumerable<Child> getKidsByMom(Func<Child, bool> Predicate = null);
        IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null);
        IEnumerable<Nanny> allCompatibleNannies(Mother mom);
        IEnumerable<Child> allChildWithoutNannies();
        IEnumerable<Nanny> tamatNannies();
        IEnumerable<Contract> contractByTerm(Func<Contract, bool> Predicate = null);
        //IEnumerable<Nanny> getListOfNanny();
        int numOfContractByTerm(Func<Contract, bool> Predicate = null);



    }
}
