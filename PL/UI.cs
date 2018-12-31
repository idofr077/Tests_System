
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;
namespace SimpleUI
{
    class UI
    {
        private static IBL bl = BL.FactoryBl.getBl();

        private static int InPutNum()
        {
            int x;
            Console.WriteLine("0-quit \n 1-add trainee \n 2-add tester \n 3-add test \n 4-update trainee \n 5-update tester \n 6-update test \n 7-all trainees \n 8-all testers \n 9-all tests \n 10-testers in area \n 11-testers available on time \n 12- number of tests for trainee \n 13-to check if a trainee have a license \n 14-to get all the test by a date \n 15-all testers by expertice \n 16-all trainees by school \n 17-all trainees by teacher \n 18-all trainees by tests number \n 19-all tests that done ");
            string a = Console.ReadLine();
            x = int.Parse(a);
            return x;
        }
        static void Main(string[] args)
        {

            int num;
            do
            {
                num= InPutNum();

                switch (num)
                {
                    case 0:
                        Console.WriteLine("bye!");
                        break;
                    case 1:
                        try
                        {
                            Console.WriteLine("enter trainee's id:");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter trainee's last name:");
                            string last_name = Console.ReadLine();
                            Console.WriteLine("enter trainee's first name:");
                            string first_name = Console.ReadLine();
                            Console.WriteLine("enter trainee's date of birth:");
                            DateTime date_of_birth = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("enter trainee's gender:");
                            string _Gender = Console.ReadLine();
                            gender Gender = (gender)Enum.Parse(typeof(gender), _Gender);  
                            Console.WriteLine("enter trainee's phone number:");
                            long phone=long.Parse(Console.ReadLine());
                            Console.WriteLine("the address of the test: \n");
                            Console.WriteLine("enter city");
                            string city = Console.ReadLine();
                            Console.WriteLine("enter street");
                            string street = Console.ReadLine();
                            Console.WriteLine("enter house number");
                            int house_number = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter distance");
                            int x = int.Parse(Console.ReadLine());
                            Address address = new Address(street, house_number, city);
                            Console.WriteLine("which vehicle the trainee learn?");
                            string _learn_vehicle=Console.ReadLine();
                            vehicle learn_vehicle = (vehicle)Enum.Parse(typeof(vehicle), _learn_vehicle);
                            Console.WriteLine("what kind of gearbox? (auto or manual ");
                            string _gearbox=Console.ReadLine();
                            kind_of_gearbox gearbox = (kind_of_gearbox)Enum.Parse(typeof(kind_of_gearbox), _Gender);
                            Console.WriteLine("enter trainee's school:");
                            string school= Console.ReadLine();
                            Console.WriteLine("enter trainee's teacher name:");
                            string teacher_name=Console.ReadLine();
                            Console.WriteLine("how many lessons the trainee did?");
                            int num_of_lessons=int.Parse(Console.ReadLine());

                            bl.add_trainee(id, last_name, first_name, date_of_birth, Gender, phone, address, learn_vehicle, gearbox, school, teacher_name, num_of_lessons);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message+"\n");
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("enter tester's id:");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter tester's last name:");
                            string last_name = Console.ReadLine();
                            Console.WriteLine("enter tester's first name:");
                            string first_name = Console.ReadLine();
                            Console.WriteLine("enter tester's date of birth:");
                            DateTime date_of_birth = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("enter tester's gender:");
                            string _Gender = Console.ReadLine();
                            gender Gender = (gender)Enum.Parse(typeof(gender), _Gender);
                            long phone = long.Parse(Console.ReadLine());
                            Console.WriteLine("the address of the test: \n");
                            Console.WriteLine("enter city");
                            string city = Console.ReadLine();
                            Console.WriteLine("enter street");
                            string street = Console.ReadLine();
                            Console.WriteLine("enter house number");
                            int house_number = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter distance");
                            int x = int.Parse(Console.ReadLine());
                            Address address = new Address(street, house_number, city);
                            Console.WriteLine("how many expirence the tester have?");
                            float expirence=float.Parse(Console.ReadLine());
                            Console.WriteLine("how many tests the tester can do in a week?");
                            int max_test_per_week=int.Parse(Console.ReadLine());
                            Console.WriteLine("enter tester's expertise:");
                            string _tester_expertise = Console.ReadLine();
                            vehicle tester_expertise = (vehicle)Enum.Parse(typeof(vehicle), _tester_expertise);
                            Console.WriteLine("enter tester's work time");
                             = Console.ReadLine();// idk
                            Console.WriteLine("enter tester's max way to go");
                            int max_way = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine("enter tester's id:");
                            int teseter_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter trainee's id:");
                            int trainee_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter the date and the hour of the test:");
                            Console.WriteLine("enter date and hour (2/16/2008 12:00:00 PM you must write pm or am!!!).");
                            string date_and_hour = Console.ReadLine();
                            DateTime temp = new DateTime();
                            temp = DateTime.Parse(date_and_hour); ;
                            Console.WriteLine("the address of the test: \n");
                            Console.WriteLine("enter city");
                            string city = Console.ReadLine();
                            Console.WriteLine("enter street");
                            string street = Console.ReadLine();
                            Console.WriteLine("enter house number");
                            int house_number = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter distance");
                            int x = int.Parse(Console.ReadLine());
                            Address address = new Address(street, house_number, city);
                            bl.add_test(teseter_id, trainee_id, temp, address);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("enter trainee's id:");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter trainee's last name:");
                            string last_name = Console.ReadLine();
                            Console.WriteLine("enter trainee's first name:");
                            string first_name = Console.ReadLine();
                            Console.WriteLine("enter trainee's date of birth:");
                            DateTime date_of_birth = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("enter trainee's gender:");
                            string _Gender = Console.ReadLine();
                            gender Gender = (gender)Enum.Parse(typeof(gender), _Gender);
                            Console.WriteLine("enter trainee's phone number:");
                            long phone = long.Parse(Console.ReadLine());
                            Console.WriteLine("the address of the test: \n");
                            Console.WriteLine("enter city");
                            string city = Console.ReadLine();
                            Console.WriteLine("enter street");
                            string street = Console.ReadLine();
                            Console.WriteLine("enter house number");
                            int house_number = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter distance");
                            int x = int.Parse(Console.ReadLine());
                            Address address = new Address(street, house_number, city);
                            Console.WriteLine("which vehicle the trainee learn?");
                            string _learn_vehicle = Console.ReadLine();
                            vehicle learn_vehicle = (vehicle)Enum.Parse(typeof(vehicle), _learn_vehicle);
                            Console.WriteLine("what kind of gearbox? (auto or manual ");
                            string _gearbox = Console.ReadLine();
                            kind_of_gearbox gearbox = (kind_of_gearbox)Enum.Parse(typeof(kind_of_gearbox), _Gender);
                            Console.WriteLine("enter trainee's school:");
                            string school = Console.ReadLine();
                            Console.WriteLine("enter trainee's teacher name:");
                            string teacher_name = Console.ReadLine();
                            Console.WriteLine("how many lessons the trainee did?");
                            int num_of_lessons = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 5:
                        try
                        {
                            Console.WriteLine("enter tester's id:");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter tester's last name:");
                            string last_name = Console.ReadLine();
                            Console.WriteLine("enter tester's first name:");
                            string first_name = Console.ReadLine();
                            Console.WriteLine("enter tester's date of birth:");
                            DateTime date_of_birth = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("enter tester's gender:");
                            string _Gender = Console.ReadLine();
                            gender Gender = (gender)Enum.Parse(typeof(gender), _Gender);
                            Console.WriteLine("enter tester's phone number:");
                            long phone = long.Parse(Console.ReadLine());
                            Console.WriteLine("the address of the test: \n");
                            Console.WriteLine("enter city");
                            string city = Console.ReadLine();
                            Console.WriteLine("enter street");
                            string street = Console.ReadLine();
                            Console.WriteLine("enter house number");
                            int house_number = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter distance");
                            int x = int.Parse(Console.ReadLine());
                            Address address = new Address(street, house_number, city);
                            Console.WriteLine("how many expirence the tester have?");
                            float expirence = float.Parse(Console.ReadLine());
                            Console.WriteLine("how many tests the tester can do in a week?");
                            int max_test_per_week = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter tester's expertise:");
                            string _tester_expertise = Console.ReadLine();
                            vehicle tester_expertise = (vehicle)Enum.Parse(typeof(vehicle), _tester_expertise);
                            Console.WriteLine("enter tester's work time");
                             = Console.ReadLine();// idk
                            Console.WriteLine("enter tester's max way to go");
                            int max_way = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 6:
                        try
                        {
                            Console.WriteLine("enter test's id:");
                            int id = int.Parse(Console.ReadLine());
                            int id_trainee = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 7:
                        try
                        {
                            for (int i = 0; i < bl.all_trainee().Count; i++)
                            {
                                Console.WriteLine(bl.all_trainee()[i]+"\n");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 8:
                        try
                        {
                            for (int i = 0; i < bl.all_tester().Count; i++)
                            {
                                Console.WriteLine(bl.all_tester()[i] + "\n");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 9:
                        try
                        {
                            for (int i = 0; i < bl.all_test().Count; i++)
                            {
                                Console.WriteLine(bl.all_test()[i] + "\n");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 10:
                        try
                        {
                            Console.WriteLine("enter city");
                            string city = Console.ReadLine();
                            Console.WriteLine("enter street");
                            string street = Console.ReadLine();
                            Console.WriteLine("enter house number");
                            int house_number = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter distance");
                            int x = int.Parse(Console.ReadLine());
                            for (int i = 0; i < bl.testers_area(new Address(street, house_number, city), x).Count; i++)
                            {
                                Console.WriteLine(bl.testers_area(new Address(street, house_number, city), x)[i]+"\n");
                            }
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message +"\n");
                        }
                        break;
                    case 11:
                        try
                        {
                            Console.WriteLine("enter date and hour (2/16/2008 12:00:00 PM you must write pm or am!!!).");
                            string date_and_hour = Console.ReadLine();
                            DateTime temp = new DateTime();
                            temp = DateTime.Parse(date_and_hour);
                            for (int i = 0; i < bl.test_on_date(temp).Count; i++)
                            {
                                Console.WriteLine(bl.test_on_date(temp)[i]);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 12:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 13:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 14:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 15:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 16:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 17:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 18:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 19:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    default:
                        break;
                }
            }
            while (num != 0);
        }
    }
}

       