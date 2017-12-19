using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
        //private long _nannyID { get; set; } // cannot change this proparty

        //public string _nannyLname { get; set; }
        //public string _nannyFname { get; set; }

        public DateTime _nannyBirth { get; set; }
        public long _nannyPhone { get; set; }
        public string _nannyAdress { get; set; }
        public bool _isElevator { get; set; }
        public int _floor { get; set; }
        public double _yearsOfExp { get; set; }
        public int _maxKidsAmount { get; set; }
        public int _minMonthAge { get; set; }
        public int _maxMonthAge { get; set; }
        public bool _acceptByHour { get; set; }
        public double _rateByHour { get; set; }
        public double _rateByMonth { get; set; }
        public bool[] _workDays { get; set; }
        public DateTime[,] _workTime {get; set;}
        bool _isTamatNanny { get; set; }
        string _recommendation { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }



    }
}
