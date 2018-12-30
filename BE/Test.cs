using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Test
    {
        int _id;
        int _id_tester;
        int _id_trainee;
        DateTime _date;
        Address _address;
        bool? _distance;
        bool? _reverse;
        bool? _mirrors;
        bool? _signals;
        bool? _crosswalk;
        bool? _grade;
        string _mention;
         
        //C_Tors:
        public Test(Test test)
        {
            id= test.id;
            id_tester=test.id_tester;
            id_trainee=test.id_trainee;
            date=test.date;
            date_and_hour=test.date_and_hour;
            address=test.address;
            distance = null;
            reverse = null;
            mirrors = null;
            signals = null;
            crosswalk = null;
            mention= null;
        }

        public Test(int id, int id_tester, int id_trainee, DateTime date, DateTime date_and_hour, Address address)
        {
            this.id = id;
            this.id_tester = id_tester;
            this.id_trainee = id_trainee;
            this.date = date;
            this.date_and_hour = date_and_hour;
            this.address = address;
        }

        public Test(int id, int id_tester, int id_trainee, DateTime date, Address address, bool distance, bool reverse, bool mirrors, bool signals, bool grade, string mention)
        {
            this.id = id;
            this.id_tester = id_tester;
            this.id_trainee = id_trainee;
            this.date = date;
            this.address = address;
            this.distance = distance;
            this.reverse = reverse;
            this.mirrors = mirrors;
            this.signals = signals;
            this.crosswalk= crosswalk;
            this.grade = grade;
            this.mention = mention;
        }    
        //Properties:
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int id_tester
        {
            get { return _id_tester; }
            set { _id_tester = value; }
        }
        public int id_trainee
        {
            get { return _id_trainee; }
            set { _id_trainee = value; }
        }
        public DateTime date
        {
            get { return _date.Date; }
            set { _date = value; }
        }
        public DateTime date_and_hour
        {
            get { return _date; }
            set { _date = value; }
        }
        public Address address
        {
            get { return _address; }
            set { _address = value; }
        }
        public bool? distance
        {
            get { return _distance; }
            set { _distance = value; }
        }
        public bool? reverse
        {
            get { return _reverse; }
            set { _reverse = value; }
        }
        public bool? mirrors
        {
            get { return _mirrors; }
            set { _mirrors = value; }
        }
        public bool? signals
        {
            get { return _signals; }
            set { _signals = value; }
        }
        public bool? crosswalk
        {
            get { return _crosswalk; }
            set { _crosswalk = value; }
        }
        public bool? grade
        {
            get { return _grade; }
            set { _grade = value; }
        }
        public string mention
        {
            get { return _mention; }
            set { _mention = value; }
        }
        //ToString
        public override string ToString()
        {
            string temp = null;
            if (grade == true)
                temp = "pass";
            else if (grade == false)
                temp = "fail";
            else temp = "didn't happened yet";
            return (id + "\n" + "id tester: " + id_tester + "\n" + "id trainee: " + id_trainee + "\n" + temp + "\n" + mention + "\n");
           
        }
    }
}
