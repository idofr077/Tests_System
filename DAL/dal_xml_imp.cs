using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
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
        public void add_test(int _id_tester, int _id_trainee, DateTime _dateAndHour, Address _address)
        {
            //שורות קוד שמוסיפות מבחן
            SaveToXML<int>(Test.id_Tests, Configuration.FILE_CONFIGURATIONS);
        }

        public void add_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise, bool[,] _work_time, int _max_way)
        {
            throw new NotImplementedException();
        }

        public void add_trainee(Trainee trainee)
        {
            List<Trainee> trainees = LoadFromXML<List<Trainee>>(Configuration.FILE_TRAINEE);
            trainees.Add(trainee);
            SaveToXML<Trainee>(trainee, Configuration.FILE_TRAINEE);

        }

        public List<Test> all_test()
        {

            throw new NotImplementedException();
        }

        public List<Tester> all_tester()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void remove_trainee(int _id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void update_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, long _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise, bool[,] _work_time, int _max_way)
        {
            throw new NotImplementedException();
        }

        public void update_trainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }
    }
}
