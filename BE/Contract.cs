using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        private long  _contractID { get; set; }
        public long _nannyID { get; set; }
        public long _childID { get; set; }
        public bool _didMeet { get; set; }
        public bool _didSign { get; set; }
        public double _ratePerHour { get; set; }
        public double _ratePerMonth { get; set; }
        public bool _isHour { get; set; }
        public DateTime _beginWork { get; set; }
        public DateTime _endWork { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
