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
            int id_test = LoadFromXML<int>(Configuration.FILE_CONFIGURATIONS);
            Test.id_Tests = id_test;

        }
        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }
        public static T LoadFromXML<T>(string path)
        { FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file); file.Close();
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
            Test test = new Test(Configuration.id_test, _id_tester, _id_trainee, _dateAndHour.Date, _dateAndHour, _address);
            List<Test> tests = GetTestList();
            tests.Add(test);
            SaveTestListLinq(tests);
            //שורות קוד שמוסיפות מבחן
            SaveToXML<int>(Test.id_Tests, Configuration.FILE_CONFIGURATIONS);
        }

        public void add_tester(Tester tester)
        {
            List<Tester> testers = LoadFromXML<List<Tester>>(Configuration.FILE_TESTER);
            testers.Add(tester);
            SaveToXML<Tester>(tester, Configuration.FILE_TESTER);
        }

        public void add_trainee(Trainee trainee)
        {
            List<Trainee> trainees = LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE);
            trainees.Add(trainee);
            SaveToXML<Trainee>(trainee, Configuration.FILE_TRAINEE);

        }

        public List<Test> all_test()
        {
            List<Test> tests = GetTestList();
            return tests;
        }

        public List<Tester> all_tester()
        {
            List<Tester> testers = LoadFromXML<List<Tester>>(Configuration.FILE_TESTER);
            return testers;
        }

        public List<Trainee> all_trainee()
        {
            List<Trainee> trainees = LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE);
            return trainees;
        }

        public bool have_licenes_by_id(int _id)
        {
            throw new NotImplementedException();
        }

        public bool id_alredy_exsits(int _id)
        {
            throw new NotImplementedException();
        }

        public bool id_tests_exsits(int _id)
        {
            throw new NotImplementedException();
        }

        public bool is_tester_available(DateTime date_and_hour, int _testser_id)
        {
            throw new NotImplementedException();
        }

        public int num_test(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public void remove_tester(int _id)
        {
            List<Tester> testers = LoadFromXML<List<Tester>>(Configuration.FILE_TESTER);
            Tester tester = testers.Find(x => x.id.CompareTo(_id) == 0);
            testers.Remove(tester);
            SaveToXML<Tester>(tester, Configuration.FILE_TESTER);
        }

        public void remove_trainee(int _id)
        {
            List<Trainee> trainees = LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE);
            Trainee trainee = trainees.Find(x => x.id.CompareTo(_id) == 0);
            trainees.Remove(trainee);
            SaveToXML<Trainee>(trainee, Configuration.FILE_TRAINEE);
        }

        public Tester tester_by_id(int id)
        {
            throw new NotImplementedException();
        }

        public Test test_by_id(int id)
        {
            throw new NotImplementedException();
        }

        public Trainee trainee_by_id(int id)
        {
            throw new NotImplementedException();
        }

        public void update_test(int id, int id_trainee, bool? distance, bool? reverse, bool? mirrors, bool? signals, bool? crosswalk, bool? grade, string mention)
        {
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
            List<Tester> testers = LoadFromXML<List<Tester>>(Configuration.FILE_TESTER);
            testers.RemoveAll(temp => temp.id == tester.id);
            testers.Add(tester);
            SaveToXML<Tester>(tester, Configuration.FILE_TESTER);
        }

        public void update_trainee(Trainee trainee)
        {
            List<Trainee> trainees = LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE);
            trainees.RemoveAll(temp => temp.id == trainee.id);
            trainees.Add(trainee);
            SaveToXML<Trainee>(trainee, Configuration.FILE_TRAINEE);
        }
    }
}
