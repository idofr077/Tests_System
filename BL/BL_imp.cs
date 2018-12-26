using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class BL_imp : IBL
    {
        Dal_imp effector=new Dal_imp();
        void add_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, Gender _Gender, int _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise,int _max_way)
            {
                DateTime Temp;
                Temp=DateTime.now-_date_of_birth;
                if (Temp.Year<=40)
                 {
                     throw new my_exception("Tetser must be  at least 40 years old.");
                 }//under 40 check
                
                effector.add_tester( _id,  _lastname,  _firstname,  _date_of_birth,  _Gender,  _phone,  _address,  _expirence,  _max_testPerWeek,  _tester_expertise,_max_way);

            }
       
        void remove_tester(int _id)
            {}
       
        void update_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise);
       
        void add_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons)
            {
                DateTime Temp;
                Temp=DateTime.now-_date_of_birth;
                if (Temp.Year<=40)
                 {
                     throw new my_exception("Trainee must be  at least 18 years old.");
                 }// under 18 check
                effector.add_trainee( _id,  _lastname,  _firstname,  _date_of_birth,  _Gender,  _phone,  _address,  _expirence,  _max_testPerWeek,  _tester_expertise,_max_way);
            }

        
        void remove_trainee(int _id);
     
        void update_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons);
     
        void add_test(int _id_tester, int _id_trainee, DateTime _dateAndHour, Address _address)
        {
            DateTime Temp;
            Temp=DateTime.Now-lafjsid;
        }
     
        void update_test(int id, int id_tester, int id_trainee, DateTime date, Address address, bool distance, bool reverse, bool mirrors, bool signals, bool grade, string mention);
   
        List<Tester> all_tester();
     
        List<Trainee> all_trainee();
     
        List<Test> all_test(); 
    }
}
