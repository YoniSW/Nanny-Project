using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public long _contractID { get; set; }
        public long _nannyID { get; set; }
        public long _momID { get; set; }
        public long _childID { get; set; }
        public bool _didMeet { get; set; }
        public bool _didSign { get; set; }
        public double _ratePerHour { get; set; }
        public double _ratePerMonth { get; set; }
        public double _finalPerHour { get; set; }
        public double _finalPerMonth { get; set; }
        public double _totalPayment { get; set; }
        public double _monthHours { get; set; }
        public bool _isByHour { get; set; }
        public DateTime _beginWork { get; set; }
        public DateTime _endWork { get; set; }

        public Contract duplicate()
        {
            Contract dupContract = new Contract();

            dupContract._contractID = this._contractID;
            dupContract._nannyID = this._nannyID;
            dupContract._momID = this._momID;
            dupContract._childID = this._childID;
            dupContract._didMeet = this._didMeet;
            dupContract._didSign = this._didSign;
            dupContract._finalPerHour = this._finalPerHour;
            dupContract._finalPerMonth = this._finalPerMonth;
            dupContract._ratePerHour = this._ratePerHour;
            dupContract._ratePerMonth = this._ratePerMonth;
            dupContract._totalPayment = this._totalPayment;
            dupContract._monthHours = this._monthHours;
            dupContract._isByHour = this._isByHour;
            dupContract._beginWork = this._beginWork;
            dupContract._endWork = this._endWork;

            return dupContract;
        }

        public Contract()
        {
            _beginWork = DateTime.Now;
            _endWork = DateTime.Now;

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
