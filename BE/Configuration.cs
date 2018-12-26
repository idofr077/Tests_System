using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
   public class Configuration
    {
        static int min_lessons;
        static float max_AgeOfTester;
        static float min_AgeOfTrainee;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
        static public int id_test=0;

        //we need to ask about the date

    }
}
