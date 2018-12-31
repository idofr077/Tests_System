
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
            Console.WriteLine("0-quit \n 1-add trainee \n 2-add tester \n 3-add test \n 4-update trainee \n 5-update tester \n 6-update test \n 7-all trainees \n 8-all testers \n 9-all tests \n 10-testers in area \n 11-testers available on time \n 12- numner of tests for trainee \n 13-to check if a trainee have a license \n 14-to get all the test by a date \n 15-all testers by expertice \n 16-all trainees by school \n 17-all trainees by teacher \n 18-all trainees by tests number \n 19-all tests that done ");
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
                            Console.WriteLine("enter trainee's date of birth:(dd/mm/yy)");
                            DateTime date_of_birth = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("enter trainee's gender:");
                            gender Gender = Enum.Parse(gender,);
                            Console.WriteLine("enter trainee's phone number:");
                            long phone=long.Parse(Console.ReadLine());
                            Console.WriteLine("enter trainee's address:");
                            Address address=Address.Parse(Console.ReadLine());
                            Console.WriteLine("which vehicle the trainee learn?");
                            vehicle learn_vehicle;
                            Console.WriteLine("what kind of gearbox?");
                            kind_of_gearbox gearbox;
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
                            string _gender = Console.ReadLine();
                            gender fdsfs = gender.
                            gender Gender = gender.Parse(gender,_gender);
                            Console.WriteLine("enter tester's phone number:");
                            long phone = long.Parse(Console.ReadLine());
                            Console.WriteLine("enter tester's address:");
                            Address address = Address.Parse(Console.ReadLine());
                            Console.WriteLine("how many expirence the tester have?");
                            float expirence=float.Parse(Console.ReadLine());
                            Console.WriteLine("how many tests the tester can do in a week?");
                            int max_test_per_week=int.Parse(Console.ReadLine());
                            Console.WriteLine("enter tester's expertise:");
                            vehicle tester_expertise = Enum.Parse(,Console.ReadLine());
                            Console.WriteLine("enter tester's work time (true/false) ");
                            bool[,] work_time = new bool[5, 6]; 
                            for (int i = 0; i < 5; i++)
                            {
                                Console.WriteLine("at" + (DayOfWeek)i);
                                for (int j = 0; j < 6; j++)
                                {
                                    Console.WriteLine((j+9)+":00 ?");
                                    work_time[i, j] = bool.Parse(Console.ReadLine());
                                }
                            }
                            Console.WriteLine("enter tester's max way to go");
                            int max_way = int.Parse(Console.ReadLine());

                            bl.add_tester(id, last_name, first_name, date_of_birth, Gender, phone, address, expirence, max_test_per_week, tester_expertise, work_time, max_way);
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
                            DateTime date_and_hour = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("enter the address of the test:");
                            Address address = DateTime.Parse(Console.ReadLine());

                            bl.add_test(teseter_id, trainee_id, date_and_hour, address);
                            }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("enter again trainee's id:");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter again trainee's last name:");
                            string last_name = Console.ReadLine();
                            Console.WriteLine("enter again trainee's first name:");
                            string first_name = Console.ReadLine();
                            Console.WriteLine("enter again trainee's date of birth:");
                            DateTime date_of_birth = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("enter trainee's gender:");
                            gender Gender = Console.ReadLine();
                            Console.WriteLine("enter again trainee's phone number:");
                            long phone = long.Parse(Console.ReadLine());
                            Console.WriteLine("enter again trainee's address:");
                            Address address = Address.Parse(Console.ReadLine());
                            Console.WriteLine("which vehicle the trainee learn?");
                            vehicle learn_vehicle;
                            Console.WriteLine("what kind of gearbox?");
                            kind_of_gearbox gearbox;
                            Console.WriteLine("enter again trainee's school:");
                            string school = Console.ReadLine();
                            Console.WriteLine("enter again trainee's teacher name:");
                            string teacher_name = Console.ReadLine();
                            Console.WriteLine("how many lessons the trainee did?");
                            int num_of_lessons = int.Parse(Console.ReadLine());

                            bl.update_trainee(id, last_name, first_name, date_of_birth, Gender, phone, address, learn_vehicle, gearbox, school, teacher_name, num_of_lessons);
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
                            gender Gender = Console.ReadLine();
                            Console.WriteLine("enter tester's phone number:");
                            long phone = long.Parse(Console.ReadLine());
                            Console.WriteLine("enter tester's address:");
                            Address address = Address.Parse(Console.ReadLine());
                            Console.WriteLine("how many expirence the tester have?");
                            float expirence = float.Parse(Console.ReadLine());
                            Console.WriteLine("how many tests the tester can do in a week?");
                            int max_test_per_week = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter tester's expertise:");
                            vehicle tester_expertise = Enum.Parse(, Console.ReadLine());
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
                            Console.WriteLine("enter trainee's id:");
                            int id_trainee = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter true or false \n the trainee take good distance?");
                            bool distance = bool.Parse(Console.ReadLine());
                            Console.WriteLine("enter true or false \n the trainee did reverse well?");
                            bool reverse = bool.Parse(Console.ReadLine());
                            Console.WriteLine("enter true or false \n the trainee use the mirrors?");
                            bool mirrors = bool.Parse(Console.ReadLine());
                            Console.WriteLine("enter true or false \n the trainee use the signals?");
                            bool signals = bool.Parse(Console.ReadLine());
                            Console.WriteLine("enter true or false \n the trainee did well at crosswalks?");
                            bool crosswalk = bool.Parse(Console.ReadLine());
                            Console.WriteLine("enter true or false \n the trainee should pass?");
                            bool grade = bool.Parse(Console.ReadLine());
                            Console.WriteLine("you can enter a mention if you want to");
                            string mention = Console.ReadLine();

                            bl.update_test(id, id_trainee, distance, reverse, mirrors, signals, crosswalk, grade, mention);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 7:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 8:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 9:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 10:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 11:
                        try
                        {

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

       