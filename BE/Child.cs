using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        public long _momID { get; set; }
        public long _childID { get; set; }
        public string _childFname { get; set; }
        public DateTime _birthday { get; set; }
        public bool _isSpecialNeed { get; set; }
        public string _specialNeeds { get; set; }
        public bool _isAlergic { get; set; }  // alergies
        public string _alergies { get; set; }

        public Child duplicate()
        {
            Child dupChild = new Child();

            dupChild._momID = this._momID;
            dupChild._childID = this._childID;
            dupChild._childFname = this._childFname;
            dupChild._birthday = this._birthday;
            dupChild._isSpecialNeed = this._isSpecialNeed;
            dupChild._specialNeeds = this._specialNeeds;
            dupChild._isAlergic = this._isAlergic; // alergies
            dupChild._alergies = this._alergies;
            return dupChild;
        }
        public Child ()
        {
            _birthday = DateTime.Now;
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
