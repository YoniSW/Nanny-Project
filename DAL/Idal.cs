using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public interface Idal
    {
        //get object by ID
        Nanny getNanny(long id);
        Mother getMom(long id);
        Child getChild(long id);
        Contract getContract(long id);

        // nany function declarations
        void addNanny(Nanny nanny);
        void deleteNanny(Nanny nanny);
        void updateNany(Nanny nanny, string name);

        // mother function declarations
        void addMother(Mother mom);
        void deleteMother(Mother mom);
        void updateMother(Mother mom, string name);

        // child function declarations
        void addChild(Child kid);
        void deleteChild(Child kid);
        void updateChild(Child kid, string name);

        // contract function declarations
        void addContract(Contract con);
        void updateContract(Contract con, long id);
        void deleteContract(Contract con);


        IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null);
        IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null);
        IEnumerable<Child> getKidsByMom(Func<Child, bool> Predicate = null);
        IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null);

    }
}
