using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BE
{
    /// <summary>
    /// //a class of all the consts.
    /// //we need to ask about the date
    /// </summary>
    public class Configuration 
    {
       public static int min_lessons=20;
       public static float min_AgeOfTester=40;
       public static float min_AgeOfTrainee=18;
        public static  int id_test=0;
        public const string FILE_TRAINEE = @"trainee_file.xml";
        public static XElement trainee_root = new XElement("trainees");
        public const string FILE_TESTER = @"tester_file.xml";
        public static XElement testers_root = new XElement("testers");
        public const string FILE_CONFIGURATIONS = @"configurations_file.xml";
        public static XElement configurations_root = new XElement("configurations");
        public static class xmlsample
        {
            public static XElement tests_root = new XElement("tests");
            public static string tests_path = @"test_file.xml";
        }

        //we need to ask about the date

    }
}
