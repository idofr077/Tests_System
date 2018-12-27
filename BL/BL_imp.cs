using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using DS;
namespace BL
{
    class BL_imp : IBL
    {
        Idal effector = new Dal_imp();
        void add_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise, int _max_way)
        {
            TimeSpan Temp;
            Temp = DateTime.Now - _date_of_birth;
            if (Temp.Days / 365 <= 40)
            {
                throw new Exception("Tetser must be  at least 40 years old.");
            }
            effector.add_tester(_id, _lastname, _firstname, _date_of_birth, _Gender, _phone, _address, _expirence, _max_testPerWeek, _tester_expertise, _max_way);

        }

        void remove_tester(int _id)
        { }

        void update_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise)
        { }

        void add_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons)
        {
            TimeSpan Temp;
            Temp = DateTime.Now - _date_of_birth;
            if (Temp.Days / 365 <= 18)
            {
                throw new Exception("Trainee must be  at least 18 years old.");
            }
            effector.add_trainee(_id, _last_name, _first_name, _date_of_birth, _Gender, _phone, _address, _learn_vehicle, _gearbox, _school, _teacher_name, _numOfLessons);
        }


        void remove_trainee(int _id)
        { }

        void update_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons)
        { }

        void add_test(int _id_tester, int _id_trainee, DateTime _dateAndHour, Address _address)
        {
            Trainee trainee = DataSource.Trainees.Find(x => x.id.CompareTo(_id_trainee) == 0);
            Tester tester = DataSource.testers.Find(x => x.id.CompareTo(_id_tester) == 0);
            if (trainee.numOfLessons <= 20)
                throw new Exception("Trainee must do at least 20 lessons");
            if ((DateTime.Now - trainee.LastTest).Days < 7)
                throw new Exception("must pass 7 days after the previous test");
            if (_dateAndHour.Hour < 9 || _dateAndHour.Hour > 15)
                throw new Exception("the official time of the test is only from 9 am to 3 pm.");
            if (trainee.waiting_for_test)
                throw new Exception("you already Registered for a test.");
            if (trainee.learn_vehicle != tester.tester_expertice)
                throw new Exception("you didn't chose a tester with the right expertice.");
            
            {
                throw new Exception("the time of the test is unavailable .");
            }
            trainee.waiting_for_test = true;
            effector.add_test(_id_tester, _id_trainee, _dateAndHour, _address);
        }

        void update_test(int id, int id_tester, int id_trainee, DateTime date, Address address, bool distance, bool reverse, bool mirrors, bool signals, bool crosswalk, bool grade, string mention)
        {
            Trainee trainee = DataSource.Trainees.Find(x => x.id.CompareTo(id_trainee) == 0);
            Tester tester = DataSource.testers.Find(x => x.id.CompareTo(id_tester) == 0);

            if (false == distance) { }
            else if (true == distance) { }
            else
                throw new Exception("tester must put value to distance");

            if (false == reverse) { }
            else if (true == reverse) { }
            else
                throw new Exception("tester must put value to reverse");

            if (false == mirrors) { }
            else if (true == mirrors) { }
            else
                throw new Exception("tester must put value to mirrors");

            if (false == signals) { }
            else if (true == signals) { }
            else
                throw new Exception("tester must put value to signals");

            if (false == crosswalk) { }
            else if (true == crosswalk) { }
            else
                throw new Exception("tester must put value to crosswalk");

            if (false == grade) { }
            else if (true == grade) { }
            else
                throw new Exception("tester must put value to grade");
            if (string.IsNullOrEmpty(mention))
                throw new Exception("tester must put mention");

            for (int i = 0; i < 4; i++)
            {
                if (trainee.license[i] == tester.tester_expertice)
                    throw new Exception("alredy have license to this vehicle");
            }


            effector.update_test(id, id_tester, id_trainee, date, address, distance, reverse, mirrors, signals, crosswalk, grade, mention);
            trainee.waiting_for_test = false;
        }

        List<Tester> all_tester()
        {
            return effector.all_tester();
        }
        List<Trainee> all_trainee()
        {
            return effector.all_trainee();
        }


        List<Test> all_test()
        {
            return effector.all_test();
        }
    }
}
