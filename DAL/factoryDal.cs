using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // factoryDal is a special class that allows the BL layer to use and change classes in DAL layer
    // without mentioning the new class name, beacuse we have the getDal function.
    // if we will want in the future to change the DAL calss to 'Dal_imp2' so the only thing we 
    // will need to change is 'return new Dal_imp2();' at line 18
    // this will allow BL layer to use the new wanted class
    public class factoryDal
    {
        public static Idal getDal()
        {
            return new Dal_imp();
        }
    } 
}
