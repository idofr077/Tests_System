using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
  public  class Dal_imp : Idal
    {
        DataSource DS= new DataSource();
        //done
        public Tester tester_by_id(int _id)
        {
            Tester tester = new Tester(DataSource.testers.Find(x => x.id.CompareTo(_id) == 0));
            return tester;
        }
        public Trainee trainee_by_id(int _id)
        {
            Trainee trainee = new Trainee(DataSource.Trainees.Find(x => x.id.CompareTo(_id) == 0));
            return trainee;
        }
        public bool id_tests_exsits(int _id)
        {
            if (DataSource.Tests.Exists(x => x.id.CompareTo(_id) == 0))
            {
                return true;
            }
            else
                return false;


        }
        public bool id_alredy_exsits(int _id)
        {
            if (DataSource.Trainees.Exists(x => x.id.CompareTo(_id) == 0))
            {
                return true;
            }

            if (DataSource.testers.Exists(x => x.id.CompareTo(_id) == 0))
            {
                return true;
            }
            return false;
        }
        public void add_test( int _id_tester, int _id_trainee, DateTime _date, Address _address)
        {
            if (!DataSource.Trainees.Exists(x => x.id.CompareTo(_id_trainee) == 0))
            {
                throw new Exception("the id of the trainee isnt exsist");
            }
            if (!DataSource.testers.Exists(x => x.id.CompareTo(_id_tester) == 0))
            {
                throw new Exception("the id of the tester isnt exsist");
            }
            if (DataSource.Tests.Exists(x => x.id.CompareTo(Configuration.id_test) == 0))
            {
                throw new Exception("the id is already in use");
            }
            Test Temp = new Test(Configuration.id_test, _id_tester, _id_trainee, _date.Date, _date, _address);
            Configuration.id_test++;
            DataSource.Tests.Add(Temp);
            Trainee trainee = DataSource.Trainees.Find(x => x.id.CompareTo(_id_trainee) == 0);
            trainee.LastTest = _date;
            Tester tester = DataSource.testers.Find(x => x.id.CompareTo(_id_tester) == 0);
            tester.Tests_Determined.Add(_date);
            
        }
        
        public void add_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise,bool [,] _work_time,int _max_way)
        {
           
            if ( DataSource.testers.Exists(x => x.id.CompareTo(_id) == 0))
                {
                    throw new Exception("the id is already in use");
                }
            Tester temp = new Tester( _id,  _lastname,  _firstname,  _date_of_birth,  _Gender,  _phone,  _address,  _expirence,  _max_testPerWeek,  _tester_expertise,_work_time,  _max_way);
          
            DataSource.testers.Add(temp);
        }

        public void add_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons)
        {
           
            
                if (DataSource.Trainees.Exists(x => x.id.CompareTo(_id) == 0))
                {
                    throw new Exception("the id is already in use");
                }
            
            Trainee Temp = new Trainee(_id, _last_name, _first_name, _date_of_birth, _Gender, _phone, _address, _learn_vehicle, _gearbox, _school, _teacher_name, _numOfLessons);
            DataSource.Trainees.Add(Temp);
        }

        public List<Test> all_test()
        {
            List<Test> temp = new List<Test>();
            for (int i = 0; i < DataSource.Tests.Count; i++)
            {
                temp.Add(DataSource.Tests[i]);
            }
            return temp;
        }

        public List<Tester> all_tester()
        {
            List<Tester> temp = new List<Tester>();
            for (int i = 0; i < DataSource.Tests.Count; i++)
            {
                temp.Add(DataSource.testers[i]);
            }
            return temp;
        }
        //done
        public List<Trainee> all_trainee()
        {
            List<Trainee> temp = new List<Trainee>();
            for (int i = 0; i < DataSource.Trainees.Count; i++)
            {
                temp.Add(DataSource.Trainees[i]);
            }
            return temp;
        }
        //done
        public void remove_tester(int _id)
        {
            if (!DataSource.testers.Exists(x => x.id.CompareTo(_id) == 0))
            {
                throw new Exception("the id is not exsits");
            }
            Tester temp = DataSource.testers.Find(x => x.id.CompareTo(_id) == 0);
            DataSource.testers.Remove(temp);
        }

        public void remove_trainee(int _id)
        {
         
            if (!DataSource.Trainees.Exists(x => x.id.CompareTo(_id) == 0))
            {
                throw new Exception("the id is not exsits");
            }
            
           
            Trainee temp = DataSource.Trainees.Find(x => x.id.CompareTo(_id) == 0);
            DataSource.Trainees.Remove(temp);
        }

        public void update_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise)
        {
            if (!DataSource.testers.Exists(x => x.id.CompareTo(_id) == 0))
            {
                throw new Exception("the id is not exsits");
            }
            Tester temp = DataSource.testers.Find(x => x.id.CompareTo(_id) == 0);
            temp.id = _id;
            temp.last_name = _lastname;
            temp.first_name = _firstname;
            temp.date_of_birth = _date_of_birth;
            temp.Gender = _Gender;
            temp.phone = _phone;
            temp.address = _address;
            temp.expirence = _expirence;
            temp.max_testPerWeek = _max_testPerWeek;
            temp.tester_expertice = _tester_expertise;
        }
        //done
        public void update_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons)
        {
            if (!DataSource.Trainees.Exists(x => x.id.CompareTo(_id) == 0))
            {
                throw new Exception("the id is not exsits");
            }
            Trainee Temp = DataSource.Trainees.Find(x => x.id.CompareTo(_id) == 0);
            Temp.id = _id;
            Temp.last_name = _last_name;
            Temp.first_name = _first_name;
            Temp.date_of_birth = _date_of_birth;
            Temp.Gender = _Gender;
            Temp.phone = _phone;
            Temp.address = _address;
            Temp.learn_vehicle = _learn_vehicle;
            Temp.gearbox = _gearbox;
            Temp.school = _school;
            Temp.teacher_name = _teacher_name;
            Temp.numOfLessons = _numOfLessons;
        }

        //done
        public void update_test(int _id, int _id_tester, int _id_trainee, DateTime _date, Address _address, bool _distance, bool _reverse, bool _mirrors, bool _signals,bool _crosswalk, bool _grade, string _mention)
        {
            if (!DataSource.Tests.Exists(x => x.id.CompareTo(_id) == 0))
            {
                throw new Exception("the id is not exsits");
            }
            Test temp = DataSource.Tests.Find(x => x.id.CompareTo(_id) == 0);
            temp.id = _id;
            temp.id_tester = _id_tester;
            temp.id_trainee = _id_trainee;
            temp.date = _date;
            temp.address = _address;
            temp.distance = _distance;
            temp.reverse = _reverse;
            temp.mirrors = _mirrors;
            temp.signals = _signals;
            temp.crosswalk = _crosswalk;
            temp.grade = _grade;
            temp.mention = _mention;
            Trainee temp2 = DataSource.Trainees.Find(x => x.id.CompareTo(_id_trainee) == 0);
            temp2.waiting_for_test = false;

        }
    }
}
