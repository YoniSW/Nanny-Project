using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
namespace DAL
{
    public static class XMLConverter
    {
        /// <summary>
        /// turns a nanny class type into a XML type
        /// </summary>
        /// <param name="nanny"></param>
        /// <returns></returns>
        public static XElement toXML(this Nanny nanny)
        {
            return new XElement("Nanny",
                 new XElement("id", nanny._nannyID),
                 new XElement("familyName", nanny._nannyLname),
                 new XElement("firstName", nanny._nannyFname),
                 new XElement("birthday", nanny._nannyBirth),
                 new XElement("phoneNumber", nanny._nannyPhone),
                 new XElement("address", nanny._nannyAdress),
                 new XElement("hasElevator", nanny._isElevator),
                 new XElement("floorNumber", nanny._floor),
                 new XElement("seniority", nanny._yearsOfExp),
                 new XElement("maxOfKids", nanny._maxamountChildren),
                 new XElement("IsTamat", nanny._isTamatNanny),
                 new XElement("minAgeOfKid", nanny._minMonthAge),
                 new XElement("maxAgeOfKid", nanny._maxMonthAge),
                 new XElement("doesWorkPerHour", nanny._acceptByHour),
                 new XElement("hourWage", nanny._rateByHour),
                 new XElement("monthlyWage", nanny._rateByMonth),
                 new XElement("recomendations", nanny._recommendation),
                // new XElement("StartHour", nanny._startHour),
                 //new XElement("EndHour", nanny._endHour),

                  
                  new XElement("StartHour",
                    (from d in nanny._startHour
                     select new XElement("Days", d.ToString()))),

                  new XElement("EndHour",
                    (from d in nanny._endHour
                     select new XElement("Days", d.ToString()))),

                new XElement("daysOfWork",
                    (from d in nanny._workDays
                     select new XElement("Days", d.ToString())
                         ))                         
                               );
        }

        /// <summary>
        /// turns a mother class type into XML type
        /// </summary>
        /// <param name="mother"></param>
        /// <returns></returns>
        public static XElement toXML(this Mother mother)
        {
            return new XElement("Mother",
                new XElement("id", mother._momID),
                new XElement("familyName", mother._momLname),
                new XElement("firstName", mother._momFname),
                new XElement("phoneNumber", mother._momPhone),
                new XElement("address", mother._momAdress),
                new XElement("locationNanny", mother._locationOfNanny),
                new XElement("isLookingForNanny", mother._isLookingForNanny),
               // new XElement("StartHour", mother._startHour),
               //new XElement("EndHour", mother._endHour),
               //new XElement("motherSchedule", mother._scheduleMom),

                new XElement("motherSchedule",
                    (from d in mother._scheduleMom
                     select new XElement("Days", d.ToString()))),

                new XElement("StartHour",
                    (from d in mother._startHour
                     select new XElement("Days", d.ToString()))),
                 new XElement("EndHour",
                    (from d in mother._endHour
                     select new XElement("Days", d.ToString()))),

                new XElement("daysOfMother",
                    (from d in mother._daysRequestMom
                     select new XElement("Days", d.ToString())
                    ))                   

            );
        }



        public static XElement toXML(this Child child)
        {
            return new XElement("Child",
                new XElement("id", child._childID),
                new XElement("name", child._childFname),
                new XElement("momsId", child._momID),
                new XElement("birthday", child._birthday),
                new XElement("hasSpecialNeeds", child._isSpecialNeed),
                new XElement("specialNeeds", child._specialNeeds),
                new XElement("isAlergic", child._isAlergic),
                new XElement("alergies", child._alergies)
                );
        }

        /// <summary>
        /// turns a contract type into a XML type
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public static XElement toXML(this Contract contract)
        {
            return new XElement("Contract",
                new XElement("numberOfContract", contract._contractID),
                new XElement("NannysId", contract._nannyID),
                new XElement("childId", contract._childID),
                new XElement("isSingedContract", contract._didSign),
                new XElement("moneyPerHour", contract._ratePerHour),
                new XElement("monthSalary", contract._ratePerMonth),
                new XElement("isHoureContract", contract._isByHour),
                new XElement("BeginWork", contract._beginWork),
                new XElement("EndWork", contract._endWork),
                new XElement("didMeet", contract._didMeet)
          );
        }

        #region summary
        ///// <summary>
        ///// turns a Day class type to a XML type
        ///// </summary>
        ///// <param name="day"></param>
        ///// <param name="attribute"></param>
        ///// <returns></returns>
        //public static XElement toXML(this Day day)
        //{
        //    return new XElement("Day",
        //        new XElement("start_hour", day.start_hour),
        //        new XElement("start_minute", day.start_minute),
        //        new XElement("finish_hour", day.finish_hour),
        //        new XElement("finish_minute", day.finish_minute),
        //   new XElement("string_start", day.string_start),
        //    new XElement("string_finish", day.string_finish));
        //}

        //public static Day toDay(this XElement dayXml)
        //{
        //    Day day = null;
        //    if (dayXml == null)
        //    {
        //        return day;
        //    }
        //    day = new Day
        //    {
        //        start_hour = Int32.Parse(dayXml.Element("start_hour").Value),
        //        start_minute = Int32.Parse(dayXml.Element("start_minute").Value),
        //        finish_hour = Int32.Parse(dayXml.Element("finish_hour").Value),
        //        finish_minute = Int32.Parse(dayXml.Element("finish_minute").Value),
        //        string_start = dayXml.Element("string_start").Value,
        //        string_finish = dayXml.Element("string_finish").Value
        ////    };


        //    return day;
        //}
#endregion

        public static Nanny toNanny(this XElement NannyXml)
        {
            Nanny nanny = null;

            if (NannyXml == null)
            {
                throw new Exception(" the nanny is declared by NULL!!!");
                return nanny;
            }
            nanny = new Nanny
            {
                _nannyID = Int64.Parse(NannyXml.Element("id").Value),
                _nannyFname = NannyXml.Element("firstName").Value,
                _nannyLname = NannyXml.Element("familyName").Value,
                _nannyPhone = long.Parse(NannyXml.Element("phoneNumber").Value),
                _nannyBirth = DateTime.Parse(NannyXml.Element("birthday").Value),
                _nannyAdress= NannyXml.Element("address").Value,
                _isElevator = Boolean.Parse(NannyXml.Element("hasElevator").Value),
                _floor = Int32.Parse(NannyXml.Element("floorNumber").Value),
                _yearsOfExp = Int32.Parse(NannyXml.Element("seniority").Value),
                _maxamountChildren = Int32.Parse(NannyXml.Element("maxOfKids").Value),
                _minMonthAge = Int32.Parse(NannyXml.Element("minAgeOfKid").Value),
                _maxMonthAge = Int32.Parse(NannyXml.Element("maxAgeOfKid").Value),
                _acceptByHour = Boolean.Parse(NannyXml.Element("doesWorkPerHour").Value),
                _isTamatNanny = Boolean.Parse(NannyXml.Element("IsTamat").Value),
                _rateByHour = Int32.Parse(NannyXml.Element("hourWage").Value),
                _rateByMonth = Int32.Parse(NannyXml.Element("monthlyWage").Value),
                _recommendation = NannyXml.Element("recommendations").Value,
              
                
                _workDays = (from e in NannyXml.Element("daysOfWork").Elements("Days")
                             select Boolean.Parse(e.Value)).ToArray(),

               
                _startHour = (from d in NannyXml.Element("StartHour").Elements("Day")
                              select DateTime.Parse(d.Value)).ToArray(),

                _endHour = (from d in NannyXml.Element("EndHour").Elements("Day")
                               select DateTime.Parse(d.Value)).ToArray(),
            };
            return nanny;
        }

        public static Mother toMother(this XElement motherXml)
        {
            Mother mother = null;

            if (motherXml == null)
            {
                return mother;
            }

            mother = new Mother
            {
                _momID = Int32.Parse(motherXml.Element("id").Value),
                _momLname = motherXml.Element("familyName").Value,
                _momFname = motherXml.Element("firstName").Value,
                _momPhone = Int32.Parse(motherXml.Element("phoneNumber").Value),
                _momAdress = motherXml.Element("address").Value,
                _locationOfNanny = motherXml.Element("addressRadius").Value,
                _isLookingForNanny=Boolean.Parse(motherXml.Element("isLookingForNanny").Value),

                _daysRequestMom = (from e in motherXml.Element("daysOfWork").Elements("Days")
                             select Boolean.Parse(e.Value)).ToArray(),

                _scheduleMom = (from d in motherXml.Element("motherSchedule").Elements("Day")
                                select d.toSchedule()).ToArray(),

                //  needs to be checked how to convert schedule to string' and back

                _startHour = (from d in motherXml.Element("StartHour").Elements("Day")
                              select DateTime.Parse(d.Value)).ToArray(),

                _endHour = (from d in motherXml.Element("EndHour").Elements("Day")
                            select DateTime.Parse(d.Value)).ToArray(),

                
                
            };
            return mother;
        }

        public static Schedule toSchedule(this XElement ScheduleXml)
        {
            Schedule sched = null;

            if (ScheduleXml == null)
            {
                return sched;
            }

            sched = new Schedule
            {
                begin = DateTime.Parse(ScheduleXml.Value),
                end = DateTime.Parse(ScheduleXml.Value)
            };

            return sched;
        }
       


        public static Child toChild(this XElement childXml)
        {
            Child child = null;

            if (childXml != null)
            {
                child = new Child
                {
                    _childID = Int32.Parse(childXml.Element("id").Value),
                    _childFname = childXml.Element("name").Value,
                    _momID = Int32.Parse(childXml.Element("momsId").Value),
                    _birthday = DateTime.Parse(childXml.Element("birthday").Value),
                    _isSpecialNeed = Boolean.Parse(childXml.Element("hasSpecialNeeds").Value),
                    _specialNeeds = childXml.Element("specialNeeds").Value,
                    _isAlergic = Boolean.Parse(childXml.Element("isAlergic").Value),
                    _alergies = childXml.Element("alergies").Value,
                };
            }

            return child;
        }

        public static Contract toContract(this XElement contractXml)
        {
            Contract contract = null;

            if (contractXml != null)
            {
                contract = new Contract
                {
                    _contractID = Int32.Parse(contractXml.Element("numberOfContract").Value),
                    _nannyID = Int32.Parse(contractXml.Element("NannysId").Value),
                    _childID = Int32.Parse(contractXml.Element("childId").Value),
                    _didSign = Boolean.Parse(contractXml.Element("isSingedContract").Value),
                    _ratePerHour = double.Parse(contractXml.Element("moneyPerHour").Value),
                    _ratePerMonth = double.Parse(contractXml.Element("monthSalary").Value),
                    _isByHour = Boolean.Parse(contractXml.Element("isHourContract").Value),
                    _beginWork = DateTime.Parse(contractXml.Element("BeginWork").Value),
                    _endWork = DateTime.Parse(contractXml.Element("EndWork").Value),
                    _didMeet= Boolean.Parse(contractXml.Element("didMeet").Value),
                };
            }

            return contract;
        }
        
    }
}

 
 