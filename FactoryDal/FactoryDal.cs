using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class FactoryDal
    {
        static Idal instance = null;
        public static Idal GetInstance()
        {
            if (instance == null)
                instance = new Dal_imp();
            return instance;
        }
    }
}
