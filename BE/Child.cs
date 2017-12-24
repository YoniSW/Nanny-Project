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

        public Child duplicate()
        {
            Child dupChild = new Child();

            dupChild._momID = this._momID;
            dupChild._childID = this._childID;
            dupChild._childFname = this._childFname;
            dupChild._birthday = this._birthday;
            dupChild._isSpecialNeed = this._isSpecialNeed;
            dupChild._specialNeeds = this._specialNeeds;

            return dupChild;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
