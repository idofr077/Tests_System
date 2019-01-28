using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BL
{
    public class BL_imp : IBL
    {
        Idal effector = DAL.FactoryDal.getDal();
        public void add_tester(Tester tester)
        {
            TimeSpan Temp;
            Temp = DateTime.Now - tester.date_of_birth;
            if (Temp.Days / 365 <= Configuration.min_AgeOfTester)
            {
                throw new Exception("Tetser must be  at least 40 years old.");
            }
            effector.add_tester(tester);

        }

        public void remove_tester(int _id)
        {
            if (!effector.id_alredy_exsits(_id))
            {
                throw new Exception("the id is not exsits");
            }
            effector.remove_tester(_id);
        }

        public void update_tester(Tester tester)
        {
            if (!effector.id_alredy_exsits(tester.id))
            {
                throw new Exception("the id is not exsits");
            }
            effector.update_tester(tester);
        }

        public void add_trainee(Trainee trainee)
        {
            TimeSpan Temp;
            Temp = DateTime.Now - trainee.date_of_birth;
            if (Temp.Days / 365 < Configuration.min_AgeOfTrainee)
            {
                throw new Exception("Trainee must be  at least 18 years old.");
            }
            if (trainee.num_of_lessons  < Configuration.min_lessons)
            {
                throw new Exception("Trainee must be  do at least 20 lessons before the test.");
            }
            effector.add_trainee(trainee);
        }

        public void remove_trainee(int _id)
        {
            if (!effector.id_alredy_exsits(_id))
            {
                throw new Exception("the id is not exsits");
            }
            effector.remove_trainee(_id);
        }

        public void update_trainee(Trainee trainee)
        {
            if (!effector.id_alredy_exsits(trainee.id))
            {
                throw new Exception("the id is not exsits");
            }
            effector.update_trainee(trainee);
        }

        public void add_test(int _id_tester, int _id_trainee, DateTime _dateAndHour, Address _address)
        {
            if (!effector.id_alredy_exsits(_id_trainee))
            {
                throw new Exception("the id is not exsits");
            }
            if (!effector.id_alredy_exsits(_id_tester))
            {
                throw new Exception("the id is not exsits");
            }
            Trainee trainee = effector.trainee_by_id(_id_trainee);
            Tester tester = effector.tester_by_id(_id_tester);
            if (_dateAndHour.Hour < 9 || _dateAndHour.Hour > 15)
                throw new Exception("the official time of  tests is only from 9 am to 3 pm.");
            if (!effector.is_tester_available(_dateAndHour, _id_tester))
                throw new Exception("the tester is not available in this date and hour.");
            if (trainee.num_of_lessons < Configuration.min_lessons)
                throw new Exception("Trainee must do at least 20 lessons");
            if ((_dateAndHour - trainee.LastTest).Days < 7)
                throw new Exception("must pass 7 days after the previous test");

            if (trainee.waiting_for_test)
                throw new Exception("you already Registered for a test.");
            if (trainee.learn_vehicle != tester.tester_expertice)
                throw new Exception("you didn't chose a tester with the right expertise.");
            if (tester.Tests_Determined.Exists(X => X == _dateAndHour))
                throw new Exception("the date and time are not avialible .");
            var test_on_week = from DateTime item in tester.Tests_Determined
                               let a = (DateTime.Now - item).Days
                               where (a < 7)
                               select item;
            if (test_on_week.Count() >= tester.max_testPerWeek)
                throw new Exception("the tester fill  his tests for week amount.");
            if(distance.Getdistane(_address.ToString(),tester.address.ToString())>tester.max_way)
                throw new Exception("the tester is not willing to drive so far.");
            bool flag = false;
            for (int i = 0; i < trainee.num_of_licenses; i++)
            {
                if (tester.tester_expertice == trainee.license[i])
                    flag = true;
            }
            if (flag)
                throw new Exception("the trainee had already license for this type of vehicle");

           
            effector.add_test(_id_tester, _id_trainee, _dateAndHour, _address);
        }

        public void update_test(int id, int id_trainee, bool? distance, bool? reverse, bool? mirrors, bool? signals, bool? crosswalk, bool? grade, string mention)
        {
            if (!effector.id_tests_exsits(id))
            {
                throw new Exception("the id of the test is not exsits");
            }
            Test temp = effector.test_by_id(id);
            Trainee trainee = effector.trainee_by_id(temp.id_trainee);
            Tester tester = effector.tester_by_id(temp.id_tester);

            if (null == distance)
                throw new Exception("tester must put value to distance");

            if (null == reverse)
                throw new Exception("tester must put value to reverse");

            if (null == mirrors)
                throw new Exception("tester must put value to mirrors");

            if (null == signals)
                throw new Exception("tester must put value to signals");

            if (null == crosswalk)
                throw new Exception("tester must put value to crosswalk");

            if (null == grade)
                throw new Exception("tester must put value to grade");
            if (string.IsNullOrEmpty(mention))
                throw new Exception("tester must put mention");





            effector.update_test(id, id_trainee, distance, reverse, mirrors, signals, crosswalk, grade, mention);
            trainee.waiting_for_test = false;
        }

        public List<Tester> all_tester()
        {
            return effector.all_tester();
        }

        public List<Trainee> all_trainee()
        {
            return effector.all_trainee();
        }

        public List<Test> all_test()
        {
            return effector.all_test();
        }

        public List<Tester> testers_area(Address address)
        {
           

            IEnumerable<Tester> testers = from item in all_tester()
                                          let y = distance.Getdistane(address.ToString(),item.address.ToString())
                                          where y < item.max_way
                                          select item;
            return testers.ToList();
        }
        public List<Tester> tester_time(DateTime dateAndHour)
        {
            IEnumerable<Tester> testers = from t in effector.all_tester()
                                          where effector.is_tester_available(dateAndHour, t.id)
                                          select t;

            return testers.ToList();

        }//
        public List<Test> find_all_tests(Predicate<Test> cond)
        {
            IEnumerable<Test> tests = from item in all_test()
                                      where cond(item)
                                      select item;
            return tests.ToList();
        }
        public int? trainee_tests(int id)
        { return effector.num_test(effector.trainee_by_id(id)); }
        public bool? pass(int id)
        { return effector.have_licenes_by_id(id); }
        public List<Test> test_on_date(DateTime date)
        {
            IEnumerable<Test> list = from item in all_test()
                                     orderby item.id
                                     where item.date == date.Date
                                     select item;
            return list.ToList<Test>();
        }
        public List<IGrouping<vehicle, Tester>> by_tester_expertice(bool sort)
        {
            if (sort)
            {
                IEnumerable<IGrouping<vehicle, Tester>> tester_group = from t in effector.all_tester()
                                                                       orderby t.last_name
                                                                       group t by t.tester_expertice into new_group
                                                                       select new_group;
                return tester_group.ToList();
            }
            else
            {
                IEnumerable<IGrouping<vehicle, Tester>> tester_group = from t in effector.all_tester()
                                                                       group t by t.tester_expertice into new_group
                                                                       select new_group;
                return tester_group.ToList();
            }

        }
        public List<IGrouping<string, Trainee>> by_school(bool sort)
        {
            if (sort)
            {
                IEnumerable<IGrouping<string, Trainee>> trainee_group = from t in effector.all_trainee()
                                                                        orderby t.last_name
                                                                        group t by t.school into new_group
                                                                        select new_group;
                return trainee_group.ToList();
            }
            else
            {
                IEnumerable<IGrouping<string, Trainee>> trainee_group = from t in effector.all_trainee()
                                                                        group t by t.school into new_group
                                                                        select new_group;
                return trainee_group.ToList();
            }
        }
        public List<IGrouping<string, Trainee>> by_teacher(bool sort)
        {
            if (sort)
            {
                IEnumerable<IGrouping<string, Trainee>> trainee_group = from t in effector.all_trainee()
                                                                        orderby t.last_name
                                                                        group t by t.teacher_name into new_group
                                                                        select new_group;
                return trainee_group.ToList();
            }
            else
            {
                IEnumerable<IGrouping<string, Trainee>> trainee_group = from t in effector.all_trainee()                                                                       
                                                                        group t by t.teacher_name into new_group
                                                                        select new_group;
                return trainee_group.ToList();

            }
        }
        public List<IGrouping<int, Trainee>> by_tests_num(bool sort)
        {
            if (sort)
            {
                IEnumerable<IGrouping<int, Trainee>> trainee_group = from t in effector.all_trainee()
                                                                     orderby t.last_name
                                                                     group t by t.num_of_test into new_group
                                                                     select new_group;
                return trainee_group.ToList();
            }
            else
            {
                IEnumerable<IGrouping<int, Trainee>> trainee_group = from t in effector.all_trainee()
                                                                     group t by t.num_of_test into new_group
                                                                     select new_group;
                return trainee_group.ToList();
            }
        }
    }
}