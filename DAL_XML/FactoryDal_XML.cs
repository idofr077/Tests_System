using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_XML
{
    class FactoryDal_XML
    {
        static Idal_XML idal = null;
        public static Idal_XML getDal()
        {
            if (idal == null)
                idal = new DAL_XML_imp();
            return idal;
        }
    }
}
