using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tester
    {
        int _id;
        string _last_name;
        string _first_name;
        DateTime _date_of_birth;
        gender _Gender;
        long _phone;
        Address _address;
        float _expirence;
        int _max_testPerWeek;
        vehicle _tester_expertise;
        bool[,] _work_time;
        List<DateTime> _Tests_Determined;
        int _max_way;
        public int max_way
        {
            get { return _max_way; }
            set { _max_way = value; }
        }


        //ToString
        public override string ToString()
        {
            return first_name + " " + last_name + "/n" + id + "/n" + date_of_birth + "/n" + Gender + "/n" + phone + "/n" + address + "/n" + expirence + "/n";
        }
        //פרופרטים
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string last_name
        {
            get { return _last_name; }
            set { _last_name = value; }
        }
        public string first_name
        {
            get { return _first_name; }
            set { _first_name = value; }
        }
        public DateTime date_of_birth
        {
            get { return _date_of_birth; }
            set { _date_of_birth = value; }
        }
        public gender Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        public long phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public Address address
        {
            get { return _address; }
            set { _address = value; }
        }
        public float expirence
        {
            get { return _expirence; }
            set { _expirence = value; }
        }
        public int max_testPerWeek
        {
            get { return _max_testPerWeek; }
            set { _max_testPerWeek = value; }
        }
        public vehicle tester_expertice
        {
            get { return _tester_expertise; }
            set { _tester_expertise = value; }
        }

        public bool[,] work_time { get => _work_time; set => _work_time = value; }
        public List<DateTime> Tests_Determined { get => _Tests_Determined; set => _Tests_Determined = value; }

        //construction
        public Tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender,long _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise, bool[,] _worktime, int _max_way)
        {
            id = _id;
            last_name = _lastname;
            first_name = _first_name;
            date_of_birth = _date_of_birth;
            Gender = _Gender;
            phone = _phone;
            address = _address;
            expirence = _expirence;
            max_testPerWeek = _max_testPerWeek;
            tester_expertice = _tester_expertise;
            max_way = _max_way;
            work_time = _worktime;
            Tests_Determined = new List<DateTime>();
        }
        public Tester()
        { }
        public Tester(Tester tester)
        {
            id = tester.id;
            last_name = tester.last_name;
            first_name = tester.first_name;
            date_of_birth = tester.date_of_birth;
            Gender = tester.Gender;
            phone = tester.phone;
            address = tester.address;
            expirence = tester.expirence;
            max_testPerWeek = tester.max_testPerWeek;
            tester_expertice = tester.tester_expertice;
            max_way = tester.max_way;
            work_time = tester.work_time;
            Tests_Determined = new List<DateTime>();
            for (int i = 0; i < tester.Tests_Determined.Count; i++)
            {
                Tests_Determined.Add(tester.Tests_Determined[i]);
            }

        }
    }

}
