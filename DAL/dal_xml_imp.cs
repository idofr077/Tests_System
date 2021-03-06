﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;
using BE;

namespace DAL
{
    class dal_xml_imp : Idal
    {
     
        public dal_xml_imp()
        {
            //open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            //open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);
            Configuration.id_test = getTestId();

        }
        
        public void open_test_file(string path, XElement root)
        {
            if (!File.Exists(path))
            {
                root = new XElement("ArrayOfTests");
                root.Save(path);
            }
        }
        public void open_configuration_file(string path, XElement root)
        {
            if (!File.Exists(path))
            {
                root = new XElement("numberTest");
                root.Value = "0";
                root.Save(path);
            }
        }

      /*  public string ToXML<T>(T obj)
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }*/

        public static void SaveToXML<T>(T source,string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source); file.Close();
        }
        public static void SaveListTestersToXML(List<Tester> list, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(list.GetType());
            xmlSerializer.Serialize(file, list); file.Close();
        }
        public static List<Trainee> LoadListTraineeFromXML(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Trainee>));
            List<Trainee> list = (List<Trainee>)xmlSerializer.Deserialize(file);
            file.Close();
            return list;
         }
        public static List<Tester> LoadListTesterFromXML(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Tester>));
            List<Tester> list = (List<Tester>)xmlSerializer.Deserialize(file);
            file.Close();
            return list;
        }
        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close();
            return result;
        }

        public void SaveConfigurationLinq()
        {
            Configuration.configurations_root.Value = Configuration.id_test.ToString();
            Configuration.configurations_root.Save(Configuration.FILE_CONFIGURATIONS);
        }

        private void LoadData_configuration()
        {
            try
            {
                Configuration.configurations_root = XElement.Load(Configuration.FILE_CONFIGURATIONS);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }


        public int getTestId()
        {
            LoadData_configuration();
            try
            {
                Configuration.id_test = int.Parse(Configuration.configurations_root.Element("numberTest").Value);
            }
            catch { Configuration.id_test = 0; }
            return Configuration.id_test;
        }
        public void SaveTestListLinq(List<Test> TestList)
        {
            Configuration.xmlsample.tests_root = new XElement("Tests",
                                    from p in TestList
                                    select new XElement("test",
                                    new XElement("ids",
                                        new XElement("id", p.id),
                                       new XElement("id_tester",p.id_tester),
                                            new XElement("id_trainee", p.id_trainee)
                                            ),
                                            new XElement("date", p.date), 
                                            new XElement("date_and_hour", p.date_and_hour),
                                            new XElement("address", 
                                            new XElement("street", p.address.street),
                                            new XElement("num", p.address.num),
                                            new XElement("city", p.address.city)
                                            ),

                                            new XElement("grades",
                                            new XElement("distance",p.distance),
                                            new XElement("reverse", p.reverse),
                                            new XElement("mirrors", p.mirrors),
                                            new XElement("signals", p.signals),
                                            new XElement("crosswalk", p.crosswalk),
                                            new XElement("mention", p.mention),
                                            new XElement("grade", p.grade)
                                            )
                                        )
                                    );
            Configuration.xmlsample.tests_root.Save(Configuration.xmlsample.tests_path);
        }

        private void LoadData()
        {
            try
            {
                Configuration.xmlsample.tests_root = XElement.Load(Configuration.xmlsample.tests_path);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        private bool? stringToBool(string str)
        {
            if (str == string.Empty)
                return null;
            if (str == "True")
                return true;
            return false;
        }
        public List<Test> GetTestList()
        {
            LoadData();
            List<Test> tests;
            try
            {
                tests = (from p in Configuration.xmlsample.tests_root.Elements()
                         select new Test()
                         {
                             id = int.Parse(p.Element("ids").Element("id").Value),
                             id_tester = int.Parse(p.Element("ids").Element("id_tester").Value),
                             id_trainee = int.Parse(p.Element("ids").Element("id_trainee").Value),
                             date = DateTime.Parse(p.Element("date").Value),
                             date_and_hour = DateTime.Parse(p.Element("date_and_hour").Value),
                             address = new Address(p.Element("address").Element("street").Value,
                                int.Parse(p.Element("address").Element("num").Value),
                             p.Element("address").Element("city").Value),
                                distance = stringToBool(p.Element("grades").Element("distance").Value),
                                reverse = stringToBool(p.Element("grades").Element("reverse").Value),
                                mirrors = stringToBool(p.Element("grades").Element("mirrors").Value),
                                signals = stringToBool(p.Element("grades").Element("signals").Value),
                                crosswalk = stringToBool(p.Element("grades").Element("crosswalk").Value),
                                mention= p.Element("grades").Element("mention").Value,
                               
                                grade = stringToBool(p.Element("grades").Element("grade").Value),
                               

                         }).ToList();
            }
            catch(Exception ex)
            {
                tests = new List<Test>();
            }
            return tests;
        }

        public void add_test(int _id_tester, int _id_trainee, DateTime _dateAndHour, Address _address)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = LoadListTraineeFromXML(Configuration.FILE_TRAINEE);
            List<Tester> testers =LoadListTesterFromXML(Configuration.FILE_TESTER);
            List<Test> tests = GetTestList();
            if (!trainees.Exists(x => x.id.CompareTo(_id_trainee) == 0))
            {
                throw new Exception("the id of the trainee isnt exsist");
            }
            if (!testers.Exists(x => x.id.CompareTo(_id_tester) == 0))
            {
                throw new Exception("the id of the tester isnt exsist");
            }
         
            Test test = new Test(Configuration.id_test, _id_tester, _id_trainee, _dateAndHour.Date, _dateAndHour, _address);
            Trainee trainee = trainees.Find(x => x.id.CompareTo(_id_trainee) == 0);
            trainee.LastTest = _dateAndHour.Date;
            trainee.waiting_for_test = true;
            Tester tester = testers.Find(x => x.id.CompareTo(_id_tester) == 0);
            tester.Tests_Determined.Add(_dateAndHour.Date);
            testers.RemoveAll(temp => temp.id == tester.id);
            testers.Add(tester);
            trainees.RemoveAll(temp => temp.id == trainee.id);
            trainees.Add(trainee);
            Configuration.id_test++;
            tests.Add(test);
            SaveTestListLinq(tests);
            //שורות קוד שמוסיפות מבחן
            SaveConfigurationLinq();
            }
        //
        public void add_tester(Tester tester)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Tester> testers = File.Exists(Configuration.FILE_TESTER)?LoadFromXML<List<Tester>>(Configuration.FILE_TESTER):new List<Tester>();
            List<Trainee> trainees = File.Exists(Configuration.FILE_TRAINEE) ? LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE):new List<Trainee>();


            if (testers.Exists(x => x.id.CompareTo(tester.id) == 0))
            {
                throw new Exception("the id is already in use");
            }
            if (trainees.Exists(x => x.id.CompareTo(tester.id) == 0))
            {
                throw new Exception("the id is already in use");
            }


            testers.Add(tester);
            SaveToXML<List<Tester>>(testers, Configuration.FILE_TESTER);
        }

        public void add_trainee(Trainee trainee)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = File.Exists(Configuration.FILE_TRAINEE) ? LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE) : new List<Trainee>();;
            List<Tester> testers = File.Exists(Configuration.FILE_TESTER) ? LoadFromXML<List<Tester>>(Configuration.FILE_TESTER) : new List<Tester>();
            ;

            if (trainees.Exists(x => x.id.CompareTo(trainee.id) == 0))
            {
                throw new Exception("the id is already in use");
            }
            if (testers.Exists(x => x.id.CompareTo(trainee.id) == 0))
            {
                throw new Exception("the id is already in use");
            }
            trainees.Add(trainee);
            //ToXML<List<Trainee>>(trainees);
            SaveToXML<List<Trainee>>(trainees, Configuration.FILE_TRAINEE);
        }

        public List<Test> all_test()
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Test> tests = GetTestList();
            return tests;
        }

        public List<Tester> all_tester()
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Tester> testers = LoadListTesterFromXML(Configuration.FILE_TESTER);
            return testers;
        }

        public List<Trainee> all_trainee()
        {
            //    open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            //    open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            //    open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            //    open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = File.Exists(Configuration.FILE_TRAINEE) ? LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE) : new List<Trainee>() ;
            return trainees;
        }

        public bool have_licenes_by_id(int _id)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = LoadListTraineeFromXML(Configuration.FILE_TRAINEE);
            Trainee trainee = trainees.Find(x => x.id.CompareTo(_id) == 0);
            return trainee.have_licenses;
        }

        public bool id_alredy_exsits(int _id)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = LoadListTraineeFromXML(Configuration.FILE_TRAINEE);
            List<Tester> testers = LoadListTesterFromXML(Configuration.FILE_TESTER);

            if (trainees.Exists(x => x.id.CompareTo(_id) == 0))
            {
                    return true;
            }

            if (testers.Exists(x => x.id.CompareTo(_id) == 0))
            {
                    return true;
            }
                return false;
        }

        public bool id_tests_exsits(int _id)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Test> tests = GetTestList();
            if (tests.Exists(x => x.id.CompareTo(_id) == 0))
            {
                return true;
            }
            else
                return false;
        }

        public bool is_tester_available(DateTime date_and_hour, int _testser_id)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

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

        public int num_test(Trainee trainee)
        {
            return trainee.num_of_test;
        }

        public void remove_tester(int _id)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Tester> testers = LoadListTesterFromXML(Configuration.FILE_TESTER);
            Tester tester = testers.Find(x => x.id.CompareTo(_id) == 0);
            testers.Remove(tester);
            SaveToXML<List<Tester>>(testers, Configuration.FILE_TESTER);
        }

        public void remove_trainee(int _id)
        {


            //open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
           

            List<Trainee> trainees = LoadListTraineeFromXML(Configuration.FILE_TRAINEE);
            Trainee trainee = trainees.Find(x => x.id.CompareTo(_id) == 0);
            trainees.Remove(trainee);
            SaveToXML<List<Trainee>>(trainees, Configuration.FILE_TRAINEE);
        }

        public Tester tester_by_id(int id)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Tester> testers = LoadListTesterFromXML(Configuration.FILE_TESTER);
            Tester tester = new Tester(testers.Find(x => x.id.CompareTo(id) == 0));
            return tester;

        }

        public Test test_by_id(int id)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Test> tests = GetTestList();
            Test test = new Test(tests.Find(x => x.id.CompareTo(id) == 0));
            return test;

        }

        public Trainee trainee_by_id(int id)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = LoadListTraineeFromXML(Configuration.FILE_TRAINEE);
            Trainee trainee = new Trainee(trainees.Find(x => x.id.CompareTo(id) == 0));
            return trainee;

        }

        public void update_test(int id, int id_trainee, bool? distance, bool? reverse, bool? mirrors, bool? signals, bool? crosswalk, bool? grade, string mention)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Test> tests = GetTestList();
            Test temp = tests.Find(x => x.id.CompareTo(id) == 0);
            temp.distance = distance;
            temp.reverse = reverse;
            temp.mirrors = mirrors;
            temp.signals = signals;
            temp.crosswalk = crosswalk;
            temp.grade = grade;
            temp.mention = mention;
            tests.RemoveAll(temp1 => temp1.id == temp.id);
            tests.Add(temp);
            SaveTestListLinq(tests);
        }

        public void update_tester(Tester tester)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Tester> testers = LoadListTesterFromXML(Configuration.FILE_TESTER);
            testers.RemoveAll(temp => temp.id == tester.id);
            testers.Add(tester);
            SaveToXML<List<Tester>>(testers, Configuration.FILE_TESTER);
        }

        public void update_trainee(Trainee trainee)
        {


            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = LoadListTraineeFromXML(Configuration.FILE_TRAINEE);
            trainees.RemoveAll(temp => temp.id == trainee.id);
            trainees.Add(trainee);
            SaveToXML<List<Trainee>>(trainees, Configuration.FILE_TRAINEE);
        }
    }
}
