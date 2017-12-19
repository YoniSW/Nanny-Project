using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Person
    {
        public int _ID { get; set; }
        public string _FirstName { get; set; }
        public string _LastName { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
