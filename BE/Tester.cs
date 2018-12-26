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
        int _phone;
        Address _address;
        float _expirence;
        int _max_testPerWeek;
        vehicle _tester_expertise;
        bool[,] work_time;
        int max_way;
        public bool[,] MyProperty {
            get { return work_time; }
            set {   work_time=value;}
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
        public int phone
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
        //construction
        public Tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise, bool[,]_worktime )
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
            max_way = 100;
            work_time =_worktime;
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
            max_way = 100;
            
            work_time = tester.work_time;
        }
    }

}
