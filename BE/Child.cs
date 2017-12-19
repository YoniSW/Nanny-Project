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
        public DateTime _birthdayKid { get; set; }
        public bool _isSpecialNeed { get; set; }
        public string _specialNeeds { get; set; }

        public override string ToString()
        {
            return base.ToString();
            /////////////// test //////////////////////
        }
    }
}
