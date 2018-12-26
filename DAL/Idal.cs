using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DAL
{
    interface Idal
    {
        void add_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise,int _max_way);// add teste
        void remove_tester(int _id);
        void update_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise);
        void add_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons);
        void remove_trainee(int _id);
        void update_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons);
        void add_test(int _id_tester, int _id_trainee, DateTime _dateAndHour, Address _address);
        void update_test(int id, int id_tester, int id_trainee, DateTime date, Address address, bool distance, bool reverse, bool mirrors, bool signals, bool grade, string mention);
        List<Tester> all_tester();
        List<Trainee> all_trainee();
        List<Test> all_test();
    }
}
