﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    interface IBL
    {
        // nany function declarations
        void addNanny(Nanny nanny);
        void deleteNanny(Nanny nanny);
        void updateNany(Nanny nanny);

        // mother function declarations
        void addMother(Mother mom);
        void deleteMother(Mother mom);
        void updateMother(Mother mom);

        // child function declarations
        void addChild(Child kid);
        void deleteChild(Child kid);
        void updateChild(Child kid);

        // contract function declarations
        void addContract(Contract con);
        void updateContract(Contract con);
        void deleteContract(Contract con);

        IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null);
        IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null);
        IEnumerable<Child> getKidsByMom(Func<Child, bool> Predicate = null);
        IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null);
    }
}
