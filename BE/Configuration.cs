using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
   public class Configuration //a class of all the consts.
    {
       public static int min_lessons=20;
       public static float min_AgeOfTester=40;
       public static float min_AgeOfTrainee=18;
        static public int id_test=0;
        public const string FILE_TRAINEE = "trainee_file.xml";
        public const string FILE_CONFIGURATIONS = "configurations_file.xml";
        //we need to ask about the date

    }
}
