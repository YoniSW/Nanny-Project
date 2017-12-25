using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;

namespace BL
{
    class Bl_imp : IBL
    {
        DAL.Idal dal;
        public Bl_imp()
        {
            dal = DAL.factoryDal.getDal();
        }

        // sent function to Idal by certian methods =========================


        public void addNanny(Nanny thisNanny)
        {
            DateTime now = DateTime.Now;
            if (now.Year - 18 < thisNanny._nannyBirth.Year)
                throw new Exception("Nanny is under 18");

            dal.addNanny(thisNanny);
        }

        
        public void addContract(Contract thisCon)
        {
            // get rest of feilds from dal
            Child thisKid = dal.getChild(thisCon._childID);
            Mother thisMom = dal.getMom(thisKid._momID);
            Nanny thisNannay = dal.getNanny(thisCon._nannyID);

            double discount = 1;
            for (int i = 0; i < amountOfKidsForMomAndNanny(thisKid, thisNannay); i++)
                discount -= 0.02; 

            if(thisNannay._amountChildren == thisNannay._maxamountChildren)
                throw new Exception("This nanny reached the maximum children");

            DateTime now = DateTime.Today;
            if(now.Year - thisKid._birthday.Year < 1 && now.Month - thisKid._birthday.Month < 3)
                throw new Exception("Child is under 3 months");

            if (thisCon._isByHour)
                thisCon._ratePerMonth = getMotherHours(thisMom) * 4 * thisNannay._rateByHour * discount;

            else
                thisCon._ratePerMonth = thisNannay._rateByMonth * discount;

            dal.addContract(thisCon);

        }

        public double getMotherHours(Mother thisMom)
        {
            double totalWeeklyHours = 0;

            for (int i = 0; i < 6; i++)
                totalWeeklyHours += thisMom._schedule[i].end.Hour - thisMom._schedule[i].begin.Hour;

            return totalWeeklyHours;
        }

        // the function returns number of kids from SAME contract and SAME mother 
        public int amountOfKidsForMomAndNanny(Child thisKid, Nanny thisNanny)
        {
            var kidsOfMom = dal.getKidsByMom(m => m._momID == thisKid._momID);
            var thisNannyContract = dal.getContracts(c => c._nannyID == thisNanny._nannyID);

            var howMuch = from k1 in kidsOfMom
                          from k2 in thisNannyContract
                          where k1._childID == k2._childID
                          select k2;

            return howMuch.Count();
        }

        // send rest of the function to Idal without any method =============================

        public void addMother(Mother thisMom)
        {
            dal.addMother(thisMom);
        }

        public void addChild(Child thisKid)
        {
            dal.addChild(thisKid);
        }

        public void deleteNanny(Nanny thisNany)
        {
            dal.deleteNanny(thisNany);
        }

        public void updateNany(Nanny thisNany)
        {
            dal.updateNany(thisNany);
        }

        public void deleteMother(Mother thisMom)
        {
            dal.deleteMother(thisMom);
        }

        public void updateMother(Mother thisMom)
        {
            dal.updateMother(thisMom);
        }

        public void deleteChild(Child thisKid)
        {
            dal.deleteChild(thisKid);
        }

        public void updateChild(Child thisChild)
        {
            dal.updateChild(thisChild);
        }

        public void updateContract(Contract thisContract)
        {
            dal.updateContract(thisContract);
        }

        public void deleteContract(Contract thisContract)
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

        // google maps 
        public static int distanceAlgorithm(string source/*mother*/, string dest/*nanny*/)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }

    }
}
