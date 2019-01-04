using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBl
    {
        static IBL ibl=null;
        public static IBL getBl()
        {
            if (ibl==null)
                ibl = new BL_imp();
            return ibl;
        }
    }
}
