using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
        static Idal idal =null;
        public static Idal getDal()
        {
           if(idal==null)
                idal=new Dal_imp();
           return idal;
        }
    }
}
