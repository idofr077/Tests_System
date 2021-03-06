﻿using System;
using System.Collections.Generic;
using System.Text;
using BE;
namespace DAL_XML
{
    class DAL_XML_imp :Idal_XML
    {
        public bool have_licenes_by_id(int _id)
        {
            Trainee trainee = trainee_by_id(_id);
            return trainee.have_licenses;
        }
        public Tester tester_by_id(int _id)
        {
            Tester tester = new Tester(DataSource.testers.Find(x => x.id.CompareTo(_id) == 0));
            return tester;
        }
        public Test test_by_id(int _id)
        {
            Test test = new Test(DataSource.Tests.Find(x => x.id.CompareTo(_id) == 0));
            return test;
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
        public void add_test(int _id_tester, int _id_trainee, DateTime _date, Address _address)
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
            trainee.waiting_for_test = true;
            Tester tester = DataSource.testers.Find(x => x.id.CompareTo(_id_tester) == 0);
            tester.Tests_Determined.Add(_date);

        }

        public void add_tester(Tester tester)
        {

            if (DataSource.testers.Exists(x => x.id.CompareTo(tester.id) == 0))
            {
                throw new Exception("the id is already in use");
            }
            DataSource.testers.Add(tester);
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
            var temp = from item in DataSource.Tests
                       where true
                       select new Test(item);
            return temp.ToList<Test>();
        }

        public List<Tester> all_tester()
        {
            var temp = from Tester item in DataSource.testers
                       where true
                       select new Tester(item);
            return temp.ToList<Tester>();
        }
        //done
        public List<Trainee> all_trainee()
        {
            var temp = from Trainee item in DataSource.Trainees
                       where true
                       select new Trainee(item);
            return temp.ToList<Trainee>();
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

        public void update_tester(Tester tester)
        {
            if (!DataSource.testers.Exists(x => x.id.CompareTo(tester.id) == 0))
            {
                throw new Exception("the id is not exsits");
            }
            Tester temp = DataSource.testers.Find(x => x.id.CompareTo(tester.id) == 0);
            temp.id = tester.id;
            temp.last_name = tester.last_name;
            temp.first_name = tester.first_name;
            temp.date_of_birth = tester.date_of_birth;
            temp.Gender = tester.Gender;
            temp.phone = tester.phone;
            temp.address = tester.address;
            temp.expirence = tester.expirence;
            temp.max_testPerWeek = tester.max_testPerWeek;
            temp.tester_expertice = tester.tester_expertice;
            temp.work_time = tester.work_time;
            temp.max_way = tester.max_way;
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
            Temp.num_of_lessons = _numOfLessons;
        }

        //done
        public void update_test(int _id, int _id_trainee, bool? _distance, bool? _reverse, bool? _mirrors, bool? _signals, bool? _crosswalk, bool? _grade, string _mention)
        {
            if (!DataSource.Tests.Exists(x => x.id.CompareTo(_id) == 0))
            {
                throw new Exception("the id is not exsits");
            }
            Test temp = DataSource.Tests.Find(x => x.id.CompareTo(_id) == 0);
            temp.distance = _distance;
            temp.reverse = _reverse;
            temp.mirrors = _mirrors;
            temp.signals = _signals;
            temp.crosswalk = _crosswalk;
            temp.grade = _grade;
            temp.mention = _mention;
            Trainee temp2 = DataSource.Trainees.Find(x => x.id.CompareTo(temp.id_trainee) == 0);
            temp2.waiting_for_test = false;
            temp2.num_of_test++;
            int count = 0;
            if (_distance == false)
            {
                count++;
            }
            if (_crosswalk == false)
            {
                count++;

            }
            if (_reverse == false)
            {
                count++;
            }
            if (_mirrors == false)
            {
                count++;
            }
            if (_signals == false)
            {
                count++;
            }
            if (count > 2 && _grade == true)
                throw new Exception("the trainee cannot pass the test since he fail in most of categories");
            if (_grade == true)
            {
                temp2.license[temp2.num_of_licenses] = temp2.learn_vehicle;
                temp2.have_licenses = true;
                temp2.num_of_licenses++;
            }
        }
        public int num_test(Trainee trainee)
        {
            return trainee.num_of_test;
        }
        public bool is_tester_available(DateTime date_and_hour, int _testser_id)
        {
            Tester tester = tester_by_id(_testser_id);
            for (int i = 0; i < tester.Tests_Determined.Count; i++)
            {
                if (tester.Tests_Determined[i] == date_and_hour)
                    return false;
            }
            if (!((int)date_and_hour.DayOfWeek < 5 && (date_and_hour.Hour < 15) && date_and_hour.Hour > 8))
                return false;
            if (!(tester.work_time[(int)date_and_hour.DayOfWeek, date_and_hour.Hour - 9]))
                return false;
            return true;
        }
    }
}
}
