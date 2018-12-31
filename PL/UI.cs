
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
        int inputNum()
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
                num = inputNum();

                switch (num)
                {
                    case 0:
                        Console.WriteLine("bye!");
                        break;
                    case 1:

                        break;
                    case 2:

                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:
                        ;
                        break;
                    case 7:

                        break;
                    case 8:

                    case 9:

                        break;
                    case 10:

                        break;
                    case 11:

                        break;
                    case 12:

                        break;
                    case 13:

                        break;
                    case 14:

                        break;
                    case 15:

                        break;
                    case 16:

                        break;
                    case 17:
                        break;
                    case 18:

                        break;
                    case 19:
                        break;
                    default:
                        break;
                }
            }
            while (num != 0);
        }
    }
}

       