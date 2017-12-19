using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace BE
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
        public DateTime[,] _hoursRequestMom { get; set; }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
