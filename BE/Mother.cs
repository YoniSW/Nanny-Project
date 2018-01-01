﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace BE /// test123
{
    public class Mother
    {
        public long _momID { get; set; }
        public string _momLname { get; set; }
        public string _momFname { get; set; }
        public long _momPhone { get; set; }
        public string _momAdress { get; set; }
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
            dupMom._isLookingForNanny = this._isLookingForNanny;
            dupMom._daysRequestMom = this._daysRequestMom;
            dupMom._scheduleMom = this._scheduleMom;
            return dupMom;
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
