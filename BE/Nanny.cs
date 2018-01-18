﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
        public string _fullName { get { return _nannyFname + " " + _nannyLname; } }
        public long _nannyID { get; set; }
        public string _nannyLname { get; set; }
        public string _nannyFname { get; set; }
        public int _amountChildren { get; set; }
        public DateTime _nannyBirth { get; set; }
        public long _nannyPhone { get; set; }
        public string _nannyAdress { get; set; }
        public bool _isElevator { get; set; }
        public int _floor { get; set; }
        public double _yearsOfExp { get; set; }
        public int _maxamountChildren { get; set; }
        public int _minMonthAge { get; set; }
        public int _maxMonthAge { get; set; }
        public bool _acceptByHour { get; set; }
        public double _rateByHour { get; set; }
        public double _rateByMonth { get; set; }
        public bool[] _workDays { get; set; }
        public DateTime[] _startHour { get; set; }
        public DateTime[] _endHour { get; set; }
        public bool _isTamatNanny { get; set; }
        public string _recommendation { get; set; }
        public double _diff { get; set; }  /* this is the difference between the hours the nanny can take care if a mother's child
                                             and the actual time she did, for example, nanny is open from 8:00 but child comes at 9:00
                                             so diff == 1 */

        public double _distance { get; set; } // yes, its a distance from a mother
        

        public Nanny duplicate()
        {
            Nanny dupNanny = new Nanny();

            dupNanny._nannyID = this._nannyID;
            dupNanny._nannyFname = this._nannyFname;
            dupNanny._nannyLname = this._nannyLname; //changed from I to L
            dupNanny._amountChildren = this._amountChildren;
            dupNanny._nannyBirth = this._nannyBirth;
            dupNanny._nannyPhone = this._nannyPhone;
            dupNanny._nannyAdress = this._nannyAdress;
            dupNanny._isElevator = this._isElevator;
            dupNanny._floor = this._floor;
            dupNanny._yearsOfExp = this._yearsOfExp;
            dupNanny._maxamountChildren = this._maxamountChildren;
            dupNanny._minMonthAge = this._minMonthAge;
            dupNanny._minMonthAge = this._maxMonthAge;
            dupNanny._acceptByHour = this._acceptByHour;
            dupNanny._rateByHour = this._rateByHour;
            dupNanny._rateByMonth = this._rateByMonth;
            dupNanny._workDays = this._workDays;
            dupNanny._isTamatNanny = this._isTamatNanny;
            dupNanny._recommendation = this._recommendation;
            dupNanny._startHour = this._startHour;
            dupNanny._endHour = this._endHour;


            return dupNanny;
        }
        //public Nanny ()
        //    {
        //        _nannyBirth = DateTime.Now;
        //    }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
