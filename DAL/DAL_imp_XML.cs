using BE;
using DS;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    class DAL_imp_XML
    {

        public void addNanny(Nanny thisNany)
        {
            var index = (from n in XML_Source.Nannys.Elements()
                         where Convert.ToInt32(n.Element("id").Value) == thisNany._nannyID
                         select n).FirstOrDefault();
            // if FindIndex method returns -1 so thisNany doesn't exist
            if (index != null)
                throw new Exception("ID already exist in the system");

            else
            {
                XML_Source.Nannys.Add(thisNany);
                XML_Source.SaveNannys();
            }


        }
    }
}
