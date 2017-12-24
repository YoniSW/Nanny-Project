using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
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
        public DateTime[,] _workTime {get; set;}
        bool _isTamatNanny { get; set; }
        string _recommendation { get; set; }


        public Nanny duplicae()
        {
            Nanny dupNanny = new Nanny();

            dupNanny._nannyID = this._nannyID;
            dupNanny._nannyFname = this._nannyFname;
            dupNanny._nannyFname = this._nannyFname;
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
            dupNanny._workTime = this._workTime;
            dupNanny._isTamatNanny = this._isTamatNanny;
            dupNanny._recommendation = this._recommendation;

            return dupNanny;
        }

        public override string ToString()
        {
            return base.ToString();
        }



    }
}
