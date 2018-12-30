using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DS
{
    public class DataSource
    {
        public static List<Test> Tests;
        public static List<Tester> testers;
        public static List<Trainee> Trainees;

        public DataSource()
        {
            Tests = new List<Test>();
            testers = new List<Tester>();
            Trainees = new List<Trainee>();

        }
    }
}
