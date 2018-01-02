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
        public long _childID { get; set; }
        public bool _didMeet { get; set; }
        public bool _didSign { get; set; }
        public double _ratePerHour { get; set; }
        public double _ratePerMonth { get; set; }
        public bool _isByHour { get; set; }  // if not by hour- its auto by month?
        public DateTime _beginWork { get; set; }
        public DateTime _endWork { get; set; }

        public Contract duplicate()
        {
            Contract dupContract = new Contract();

            dupContract._contractID = this._contractID;
            dupContract._nannyID = this._nannyID;
            dupContract._childID = this._childID;
            dupContract._didMeet = this._didMeet;
            dupContract._didSign = this._didSign;
            dupContract._ratePerHour = this._ratePerHour;
            dupContract._ratePerMonth = this._ratePerMonth;
            dupContract._isByHour = this._isByHour;
            dupContract._beginWork = this._beginWork;
            dupContract._endWork = this._endWork;

            return dupContract;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
