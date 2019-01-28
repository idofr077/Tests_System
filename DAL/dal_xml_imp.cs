using System;
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
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);
            Configuration.id_test = LoadFromXML<int>(Configuration.FILE_CONFIGURATIONS);

        }
        public void open_trainee_file(string path, XElement root)
        {
            if (!File.Exists(path))
            {
                root = new XElement("trainees");
                root.Save(path);
            }
        }
        public void open_tester_file(string path, XElement root)
        {
            if (!File.Exists(path))
            {
                root = new XElement("testers");
                root.Save(path);
            }
        }
        public void open_test_file(string path, XElement root)
        {
            if (!File.Exists(path))
            {
                root = new XElement("tests");
                root.Save(path);
            }
        }
        public void open_configuration_file(string path, XElement root)
        {
            if (!File.Exists(path))
            {
                root = new XElement("configurations");
                root.Save(path);
            }
        }
        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }
        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close();
            return result;
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
                                distance = bool.Parse(p.Element("grades").Element("distance").Value),
                                reverse= bool.Parse(p.Element("grades").Element("reverse").Value),
                                mirrors= bool.Parse(p.Element("grades").Element("mirrors").Value),
                                signals= bool.Parse(p.Element("grades").Element("signals").Value),
                                crosswalk= bool.Parse(p.Element("grades").Element("crosswalk").Value),
                                mention= p.Element("grades").Element("mention").Value,
                               
                                grade= bool.Parse(p.Element("grades").Element("grade").Value),
                               

                         }).ToList();
            }
            catch
            {
                tests = null;
            }
            return tests;
        }

        public void add_test(int _id_tester, int _id_trainee, DateTime _dateAndHour, Address _address)
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE);
            List<Tester> testers = LoadFromXML<List<Tester>>(Configuration.FILE_TESTER);
            List<Test> tests = GetTestList();
            if (!trainees.Exists(x => x.id.CompareTo(_id_trainee) == 0))
            {
                throw new Exception("the id of the trainee isnt exsist");
            }
            if (!testers.Exists(x => x.id.CompareTo(_id_tester) == 0))
            {
                throw new Exception("the id of the tester isnt exsist");
            }
            if (tests.Exists(x => x.id.CompareTo(Configuration.id_test) == 0))
            {
                throw new Exception("the id is already in use");
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
            SaveToXML<int>(Test.id_Tests, Configuration.FILE_CONFIGURATIONS);
        }

        public void add_tester(Tester tester)
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Tester> testers = LoadFromXML<List<Tester>>(Configuration.FILE_TESTER);

            if (testers.Exists(x => x.id.CompareTo(tester.id) == 0))
            {
                throw new Exception("the id is already in use");
            }

            testers.Add(tester);
            SaveToXML<Tester>(tester, Configuration.FILE_TESTER);
        }

        public void add_trainee(Trainee trainee)
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE);
            if (trainees.Exists(x => x.id.CompareTo(trainee.id) == 0))
            {
                throw new Exception("the id is already in use");
            }

            trainees.Add(trainee);
            SaveToXML<Trainee>(trainee, Configuration.FILE_TRAINEE);

        }

        public List<Test> all_test()
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Test> tests = GetTestList();
            return tests;
        }

        public List<Tester> all_tester()
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Tester> testers = LoadFromXML<List<Tester>>(Configuration.FILE_TESTER);
            return testers;
        }

        public List<Trainee> all_trainee()
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE);
            return trainees;
        }

        public bool have_licenes_by_id(int _id)
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE);
            Trainee trainee = trainees.Find(x => x.id.CompareTo(_id) == 0);
            return trainee.have_licenses;
        }

        public bool id_alredy_exsits(int _id)
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE);
            List<Tester> testers = LoadFromXML<List<Tester>>(Configuration.FILE_TESTER);

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
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
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
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
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
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Tester> testers = LoadFromXML<List<Tester>>(Configuration.FILE_TESTER);
            Tester tester = testers.Find(x => x.id.CompareTo(_id) == 0);
            testers.Remove(tester);
            SaveToXML<Tester>(tester, Configuration.FILE_TESTER);
        }

        public void remove_trainee(int _id)
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE);
            Trainee trainee = trainees.Find(x => x.id.CompareTo(_id) == 0);
            trainees.Remove(trainee);
            SaveToXML<Trainee>(trainee, Configuration.FILE_TRAINEE);
        }

        public Tester tester_by_id(int id)
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Tester> testers = LoadFromXML<List<Tester>>(Configuration.FILE_TESTER);
            Tester tester = new Tester(testers.Find(x => x.id.CompareTo(id) == 0));
            return tester;

        }

        public Test test_by_id(int id)
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Test> tests = GetTestList();
            Test test = new Test(tests.Find(x => x.id.CompareTo(id) == 0));
            return test;

        }

        public Trainee trainee_by_id(int id)
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE);
            Trainee trainee = new Trainee(trainees.Find(x => x.id.CompareTo(id) == 0));
            return trainee;

        }

        public void update_test(int id, int id_trainee, bool? distance, bool? reverse, bool? mirrors, bool? signals, bool? crosswalk, bool? grade, string mention)
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
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
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Tester> testers = LoadFromXML<List<Tester>>(Configuration.FILE_TESTER);
            testers.RemoveAll(temp => temp.id == tester.id);
            testers.Add(tester);
            SaveToXML<Tester>(tester, Configuration.FILE_TESTER);
        }

        public void update_trainee(Trainee trainee)
        {
            open_tester_file(Configuration.FILE_TESTER, Configuration.testers_root);
            open_trainee_file(Configuration.FILE_TRAINEE, Configuration.trainee_root);
            open_configuration_file(Configuration.FILE_CONFIGURATIONS, Configuration.configurations_root);
            open_test_file(Configuration.xmlsample.tests_path, Configuration.xmlsample.tests_root);

            List<Trainee> trainees = LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE);
            trainees.RemoveAll(temp => temp.id == trainee.id);
            trainees.Add(trainee);
            SaveToXML<Trainee>(trainee, Configuration.FILE_TRAINEE);
        }
    }
}
