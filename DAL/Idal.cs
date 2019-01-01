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
        bool have_licenes_by_id(int _id);/// <summary>
        /// recogonize the trainee by id and check if he had a license to something
        /// </summary>
        /// 
        /// <param name="_id"></param>
        /// <param name="_lastname"></param>
        /// <param name="_firstname"></param>
        /// <param name="_date_of_birth"></param>
        /// <param name="_Gender"></param>
        /// <param name="_phone"></param>
        /// <param name="_address"></param>
        /// <param name="_expirence"></param>
        /// <param name="_max_testPerWeek"></param>
        /// <param name="_tester_expertise"></param>
        /// <param name="_work_time"></param>
        /// <param name="_max_way"></param>
        void add_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise,bool [,] _work_time,int _max_way);/// <summary>
         /// get parameters and add a tester
        /// </summary>
        /// 
        /// <param name="_id"></param>
        void remove_tester(int _id);/// <summary>
        /// recogonize the tester by the id and remove him
        /// </summary>
        /// 
        /// <param name="_id"></param>
        /// <param name="_lastname"></param>
        /// <param name="_firstname"></param>
        /// <param name="_date_of_birth"></param>
        /// <param name="_Gender"></param>
        /// <param name="_phone"></param>
        /// <param name="_address"></param>
        /// <param name="_expirence"></param>
        /// <param name="_max_testPerWeek"></param>
        /// <param name="_tester_expertise"></param>
        /// <param name="_work_time"></param>
        /// <param name="_max_way"></param>
        void update_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise,bool [,] _work_time,int _max_way);/// <summary>
        /// can change the parameters of the tester
        /// </summary>
        /// 
        /// <param name="_id"></param>
        /// <param name="_last_name"></param>
        /// <param name="_first_name"></param>
        /// <param name="_date_of_birth"></param>
        /// <param name="_Gender"></param>
        /// <param name="_phone"></param>
        /// <param name="_address"></param>
        /// <param name="_learn_vehicle"></param>
        /// <param name="_gearbox"></param>
        /// <param name="_school"></param>
        /// <param name="_teacher_name"></param>
        /// <param name="_numOfLessons"></param>
        void add_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons);/// <summary>
        /// take parameters and create a new trainee
        /// </summary>
        /// 
        /// <param name="_id"></param>
        void remove_trainee(int _id);/// <summary>
        /// recogonize the trainee by the id and remove him
        /// </summary>
        /// 
        /// <param name="_id"></param>
        /// <param name="_last_name"></param>
        /// <param name="_first_name"></param>
        /// <param name="_date_of_birth"></param>
        /// <param name="_Gender"></param>
        /// <param name="_phone"></param>
        /// <param name="_address"></param>
        /// <param name="_learn_vehicle"></param>
        /// <param name="_gearbox"></param>
        /// <param name="_school"></param>
        /// <param name="_teacher_name"></param>
        /// <param name="_numOfLessons"></param>
        void update_trainee(int _id, string _last_name, string _first_name, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, vehicle _learn_vehicle, kind_of_gearbox _gearbox, string _school, string _teacher_name, int _numOfLessons);/// <summary>
        /// can change the trainee's parameters
        /// </summary>
        /// 
        /// <param name="_id_tester"></param>
        /// <param name="_id_trainee"></param>
        /// <param name="_dateAndHour"></param>
        /// <param name="_address"></param>
        void add_test(int _id_tester, int _id_trainee, DateTime _dateAndHour, Address _address); /// <summary>
        /// create a new test
        /// </summary>
        /// 
        /// <param name="id"></param>
        /// <param name="id_trainee"></param>
        /// <param name="distance"></param>
        /// <param name="reverse"></param>
        /// <param name="mirrors"></param>
        /// <param name="signals"></param>
        /// <param name="crosswalk"></param>
        /// <param name="grade"></param>
        /// <param name="mention"></param>
        void update_test(int id,int id_trainee, bool? distance, bool? reverse, bool? mirrors, bool? signals, bool? crosswalk, bool? grade, string mention); /// <summary>
        ///  after the test we update some parameters
        /// </summary>
        ///
        /// <param name="_id"></param>
        /// <returns></returns>
        bool id_alredy_exsits(int _id); /// <summary>
        /// check if the id already exsits
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        bool id_tests_exsits(int _id); /// <summary>
        /// Checks if a test ID number exists in the data base
        /// </summary>
        /// <returns></returns>
        List<Tester> all_tester(); /// <summary>
                                   /// Returns a list of all testers in data base.
                                   /// </summary>
                                   /// <returns></returns>
        List<Trainee> all_trainee(); /// <summary>
                                     /// Returns a list of trainees in data base.
                                     /// </summary>
                                     /// <returns></returns>
        List<Test> all_test(); /// <summary>
                               /// Returns a list of all tests in the data base.
                               /// </summary>
                               /// <param name="id"></param>
                               /// <returns></returns>
        Tester tester_by_id(int id); /// <summary>
                                     /// Search a cpecific tester by an ID number.
                                     /// </summary>
                                     /// <param name="id"></param>
                                     /// <returns></returns>
        Trainee trainee_by_id(int id); /// <summary>
                                       /// Search a cpecific trainee by an ID number
                                       /// </summary>
                                       /// <param name="id"></param>
                                       /// <returns></returns>
        Test test_by_id(int id);/// <summary>
        /// find a test by id and return it
        /// </summary>
        /// <param name="trainee"></param>
        /// <returns></returns>
        int num_test(Trainee trainee);/// <summary>
                                      /// return how many tests the trainee did
                                      /// </summary>
                                      /// <param name="date_and_hour"></param>
                                      /// <param name="_testser_id"></param>
                                      /// <returns></returns>
        bool is_tester_available(DateTime date_and_hour, int _testser_id);
        
    }
}
