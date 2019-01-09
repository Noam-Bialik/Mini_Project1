using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class FactoryBL 
    {
        public static Ibl GetInstance()
        {
            return new BL.Bl_imp();
        }
    }
}
