using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
namespace BL
{
  public interface IBL
    {
        void add_tester(Tester tester);/// <summary>
        /// check if the addded of the tester was ok and without errors
        /// </summary>
        /// <param name="_id"></param>
        void remove_tester(int _id);/// <summary>
                                    /// check if the removed of the tester was ok and without errors
                                    /// </summary>
                                    /// 
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
        void update_tester(Tester tester);/// <summary>
        /// check if the updated of the tester was ok and without errors
        /// </summary>
        /// 
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
        /// check if the added of the trainee was ok and without errors
        /// </summary>
        /// create a new trainee
        /// <param name="_id"></param>
        void remove_trainee(int _id);/// <summary>
                                     /// check if the removed of the trainee was ok and without errors
                                     /// </summary>
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
        /// check if the updated of the trainee was ok and without errors
        /// </summary>
        /// <param name="_id_tester"></param>
        /// <param name="_id_trainee"></param>
        /// <param name="_dateAndHour"></param>
        /// <param name="_address"></param>
        void add_test(int _id_tester, int _id_trainee, DateTime _dateAndHour, Address _address);/// <summary>
        /// check if the added of the test was ok and without errors
        /// </summary>
        /// <param name="id"></param>
        /// <param name="id_trainee"></param>
        /// <param name="distance"></param>
        /// <param name="reverse"></param>
        /// <param name="mirrors"></param>
        /// <param name="signals"></param>
        /// <param name="crosswalk"></param>
        /// <param name="grade"></param>
        /// <param name="mention"></param>
        void update_test(int id,int id_trainee, bool? distance, bool? reverse, bool? mirrors, bool? signals, bool? crosswalk, bool? grade, string mention);/// <summary>
        /// check if the updated of the test was ok and without errors
        /// </summary>
        /// <returns></returns>
        List<Tester> all_tester();/// <summary>
        /// return a list with all the testers
        /// </summary>
        /// <returns></returns>
        List<Trainee> all_trainee();
        /// <summary>
        /// return a list with all the trainees
        /// </summary>
        /// <returns></returns>
        List<Test> all_test();/// <summary>
        /// return a list with all the tests
        /// </summary>
        /// <param name="address"></param>
        /// <param name="x"></param>
        /// <returns></returns>       
        List<Tester> testers_area(Address address,int x);
        /// <summary>
        /// return a list with all the testers in the radar of x
        /// </summary>
        /// <param name="dateAndHour"></param>
        /// <returns></returns>
        List<Tester> tester_time(DateTime dateAndHour);
        /// <summary>
        /// return a list withe all the testers that avialible in a dateandhour
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        List<Test> find_all_tests(Predicate<Test> cond);
        /// <summary>
        /// return a list with all the tests that have a parameter condition
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int? trainee_tests(int id);
        /// <summary>
        /// return the num of tests yo trainee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool? pass(int id);/// <summary>
        /// is a trainee hace a license
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        List <Test> test_on_date (DateTime date);/// <summary>
        /// list with all the tests on this date
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        List<IGrouping<vehicle, Tester>> by_tester_expertice(bool sort);/// <summary>
                                                                        /// list of groups by tester_expertice
                                                                        /// </summary>
                                                                        /// <param name="sort"></param>
                                                                        /// <returns></returns>
        List<IGrouping<string, Trainee>> by_school(bool sort);/// <summary>
                                                              /// list of groups by school
                                                              /// </summary>
                                                              /// <param name="sort"></param>
                                                              /// <returns></returns>
        List<IGrouping<string, Trainee>> by_teacher(bool sort);
        /// <summary>
        /// list of groups by teacher name
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        List<IGrouping<int, Trainee>> by_tests_num(bool sort);/// <summary>
                                                              /// list of groups by num of tests that the trainee did
                                                              /// </summary>
                                                              /// <param name="sort"></param>
                                                              /// <returns></returns>
    }

}
