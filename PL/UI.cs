
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

                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message+"\n");
                        }
                        break;
                    case 2:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 3:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 4:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 5:
                        try
                        {

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 6:
                        try
                        {

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

       