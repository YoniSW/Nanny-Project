using BE;
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
        // nany function declarations
        void addNanny(Nanny nanny);
        void deleteNanny(long ID);
        Nanny getNanny(long ID);
        void updateNany(Nanny nanny);
        

        // mother function declarations
        void addMother(Mother mom);
        void deleteMother(long ID);
        Mother getMother(long ID);
        void updateMother(Mother mom);

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

        IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null);
        IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null);
        IEnumerable<Child> getKidsByMom(Func<Child, bool> Predicate = null);
        IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null);
    }
}
