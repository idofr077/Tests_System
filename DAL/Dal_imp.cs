﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    class Dal_imp : Idal
    {
        //done
        public void add_test( int _id_tester, int _id_trainee, DateTime _date, Address _address)
        {
            Test Temp = new Test(Configuration.id_test, _id_tester, _id_trainee, _date.Date, _date, _address);
            Configuration.id_test++;
            DataSource.Tests.Add(Temp);
        }

        public void add_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise)
        {
            Tester temp = new Tester();
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
            DataSource.testers.Add(temp);
        }

        public void add_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons)
        {
            Trainee Temp = new Trainee(_id, _last_name, _first_name, _date_of_birth, _Gender, _phone, _address, _learn_vehicle, _gearbox, _school, _teacher_name, _numOfLessons);
            DataSource.Trainees.Add(Temp);
        }

        public List<Test> all_test()
        {
            List<Test> tests = new List<Test>();
            for (int i = 0; i < DataSource.Tests.Count; i++)
            {
                Test a = new Test(DataSource.Tests[i]);
                tests.Add(a);
            }
            return tests;
        }

        public List<Tester> all_tester()
        {
            List<Tester> tester = new List<Tester>();
            for (int i = 0; i < DataSource.testers.Count; i++)
            {
                Tester a = new Tester(DataSource.testers[i]);
                tester.Add(a);
            }
            return tester;
        }
        //done
        public List<Trainee> all_trainee()
        {
            List<Trainee> trainees = new List<Trainee>();
            for (int i = 0; i < DataSource.Trainees.Count; i++)
            {
                Trainee a = new Trainee(DataSource.Trainees[i]);
                trainees.Add(a);
            }
            return trainees;
        }
        //done
        public void remove_tester(int _id)
        {
            Tester temp = DataSource.testers.Find(x => x.id.CompareTo(_id) == 0);
            DataSource.testers.Remove(temp);
        }

        public void remove_trainee(int _id)
        {
            Trainee temp = DataSource.Trainees.Find(x => x.id.CompareTo(_id) == 0);
            DataSource.Trainees.Remove(temp);
        }

        public void update_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise)
        {
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
        public void update_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons)
        {
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
        void Idal.update_test(int _id, int _id_tester, int _id_trainee, DateTime _date, Address _address, bool _distance, bool _reverse, bool _mirrors, bool _signals, bool _grade, string _mention)
        {

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
            temp.grade = _grade;
            temp.mention = _mention;
        }
    }
}
