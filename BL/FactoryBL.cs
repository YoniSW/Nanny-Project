﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BL
{
    public class FactoryBL
    {
        public static IBL bl = null;
        public static IBL GetBL()
        {
            if (bl == null)
                bl = new Bl_imp();
            return bl;
        }
    }
}
