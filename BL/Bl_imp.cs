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
            //init();
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
                totalWeeklyHours += thisMom._scheduleMom[i].end.Hour - thisMom._scheduleMom[i].begin.Hour;

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
        public static int caculateDistance(string mom, string nanny)
        {
            var drivingDirectionRequest = new DirectionsRequest()
            {
                TravelMode = TravelMode.Walking,
                Origin = mom,
                Destination = nanny,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }

        // add all nannies via IEnumerable<list>
        public IEnumerable<Nanny> getAllCompatibleNanny(Mother thisMom)
        {
            var nannyList = dal.getAllNanny();
            // check if there are suitible nannies for thisMom schdule
            var compatibleNanny = from a in nannyList
                                  where checkSchedule(a, thisMom)
                                  select a;
            // if we didn't find any suitable nanny
            if (!compatibleNanny.Any()) 
                return fiveNearestNanny(thisMom);
            
            return compatibleNanny;
        }

        private IEnumerable<Nanny> fiveNearestNanny(Mother thisMom)
        {
            // copy the list into new one
            var nannyList = from a in dal.getAllNanny()
                            select a.duplicate();

            foreach (var a in nannyList)
               schduleDifference(a, thisMom);
            

            return nannyList.OrderBy(a => a._diff).Take(5);
        }

        public void schduleDifference(Nanny nanny, Mother mom)
        {
            nanny._diff = 0;
            for (int i = 0; i < 6; i++)
            {
                if (nanny._scheduleNan[i].begin > mom._scheduleMom[i].begin)
                {
                    TimeSpan sum = new TimeSpan();
                    sum = nanny._scheduleNan[i].begin - mom._scheduleMom[i].begin;
                    nanny._diff += ((sum.Days - 1) * 24 + sum.Hours + sum.Minutes / 60.0);
                }
                if (nanny._scheduleNan[i].end < mom._scheduleMom[i].end)
                {
                    TimeSpan sum = new TimeSpan();
                    sum = mom._scheduleMom[i].end - nanny._scheduleNan[i].end;
                    nanny._diff += ((sum.Days - 1) * 24 + sum.Hours + sum.Minutes / 60.0);
                }
            }
        }
        public bool checkSchedule(Nanny nanny, Mother mom)
        {
          for (int i = 0; i < 6; i++) {
          if (nanny._scheduleNan[i].begin > mom._scheduleMom[i].begin ||
                nanny._scheduleNan[i].end < mom._scheduleMom[i].end)
                return false;
          }
          return true;
        }

        public IEnumerable<Child> getAllChildWithoutNanny()
        {
        return from a in dal.getKidsByMom()
                   let idChild = a._childID
                   from b in dal.getContracts()
                   where idChild != b._childID
                   select a;
        }

        public IEnumerable<Nanny> getTamatNanny()
        {
            return dal.getAllNanny(a => a._isTamatNanny);
        }

        public IEnumerable<Contract> contractByTerm(Func<Contract, bool> Predicate = null)
        {
            return dal.getContracts(Predicate);
        }

        public int numContractByTerm(Func<Contract, bool> Predicate = null)
        {
            return contractByTerm(Predicate).Count();
        }

        public IEnumerable<Nanny> getNannyByDistance(Mother mom, double distance)
        {
            int distanceMeter = (int)(distance * 1000);

            // copy this list into new one
            var nannyList = from a in dal.getAllNanny()
                            select a.duplicate();

            foreach (var a in nannyList)
            {
                a._distance = caculateDistance(mom._momAdress, a._nannyAdress);
            }

            return from a in nannyList
                   where a._distance < distanceMeter
                   select a;
        }


        public IEnumerable<IGrouping<int, Nanny>> getChildByAgeRange(bool minimumAge, bool isSort)
        {
            if (isSort)
                if (minimumAge)
                    return from a in dal.getAllNanny()
                           orderby a._minMonthAge
                           group a by a._minMonthAge / 3; // sort list by min age
                else
                    return from a in dal.getAllNanny()
                           orderby a._maxMonthAge
                           group a by a._minMonthAge / 3; // sort list by max age
            else
                    if (minimumAge)
                return from a in dal.getAllNanny()
                       group a by a._minMonthAge / 3;
            else
                return from a in dal.getAllNanny()
                       group a by a._minMonthAge / 3;
        }

        public IEnumerable<IGrouping<bool, Nanny>> getNannyByDistance(string addressMom, string addressNanny, double rangeMeter)
        {
            return from a in dal.getAllNanny()
                       // select all nannies that are maximum 10 km distance away
                   group a by caculateDistance(addressNanny, addressMom) < rangeMeter * 10000;
        }
    }
}
