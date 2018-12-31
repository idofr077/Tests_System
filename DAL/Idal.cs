using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    public interface Idal
    {
        bool have_licenes_by_id(int _id);
        void add_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise,bool [,] _work_time,int _max_way);
        void remove_tester(int _id);
        void update_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise);
        void add_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons);
        void remove_trainee(int _id);
        void update_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons);
        void add_test(int _id_tester, int _id_trainee, DateTime _dateAndHour, Address _address); //Add new test.
        void update_test(int id,int id_trainee, bool? distance, bool? reverse, bool? mirrors, bool? signals, bool? crosswalk, bool? grade, string mention); //Update if a given test was successful. 
        bool id_alredy_exsits(int _id); //Checks if an ID number of a trainee or a tester already exists in data base.
        bool id_tests_exsits(int _id); //Checks if a test ID number exists in the data base.
        List<Tester> all_tester(); //Returns a list of all testers in data base.
        List<Trainee> all_trainee(); //Returns a list of trainees in data base.
        List<Test> all_test(); //Returns a list of all tests in the data base.
        Tester tester_by_id(int id); //Search a cpecific tester by an ID number.
        Trainee trainee_by_id(int id); //Search a cpecific trainee by an ID number.
        Test test_by_id(int id);
        
        
    }
}
