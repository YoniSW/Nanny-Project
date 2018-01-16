using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace BE /// 
{
    public class Mother
    {
        public string _fullName { get { return _momFname + " " + _momLname; } }
        public long _momID { get; set; }
        public string _momLname { get; set; }
        public string _momFname { get; set; }
        public long _momPhone { get; set; }
        public string _momAdress { get; set; }
        public string _locationOfNanny { get; set; } // where the nanny lives
        public bool _isLookingForNanny { get; set; }
        public bool[] _daysRequestMom { get; set; }
        public Schedule[] _scheduleMom { get; set; }
        public DateTime[] _startHour { get; set; }
        public DateTime[] _endHour { get; set; }

        // we will use the dublicate function
        public Mother duplicate()
        {
            Mother dupMom = new Mother();

            dupMom._momID = this._momID;
            dupMom._momLname = this._momLname;
            dupMom._momFname = this._momFname;
            dupMom._momPhone = this._momPhone;
            dupMom._momAdress = this._momAdress;
            dupMom._locationOfNanny = this._locationOfNanny; // location of nanny
            dupMom._isLookingForNanny = this._isLookingForNanny;
            dupMom._daysRequestMom = this._daysRequestMom;
            dupMom._scheduleMom = this._scheduleMom;
            dupMom._startHour = this._startHour;
            dupMom._endHour = this._endHour;

            return dupMom;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
