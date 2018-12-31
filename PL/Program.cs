using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;
namespace PL
{
    class Program
    {
        private static IBL bl = factoryBL.FactoryBL.GetBL();
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
                        DoActionWithCheck(addTrainee);
                        break;
                    case 2:
                        DoActionWithCheck(addTester);
                        break;
                    case 3:
                        DoActionWithCheck(AddTest);
                        break;
                    case 4:
                        DoActionWithCheck(updateTrainee);
                        break;
                    case 5:
                        DoActionWithCheck(updateTester);
                        break;
                    case 6:
                        DoActionWithCheck(finishTest);
                        break;
                    case 7:
                        foreach (var item in bl.GetAllTrainees())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 8:
                        foreach (var item in bl.GetAllTesters())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 9:
                        foreach (var item in bl.GetAllTests())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 10:
                        try
                        {
                            List<Test> list = bl.GetTestsByTesters(bl.GetTesterById(int.Parse(input("id"))));
                            list.ForEach(test => Console.WriteLine(test));

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ERROR!! {0}", e.Message);
                        }
                        break;
                    case 11:
                        DoActionWithCheck(deleteTrainee);
                        break;
                    case 12:
                        DoActionWithCheck(deleteTester);
                        break;
                    case 13:
                        DoActionWithCheck(GetllTraineesByLicense);
                        break;
                    case 14:
                        DoActionWithCheck(GetTraineesBySchoolName);
                        break;
                    case 15:
                        DoActionWithCheck(GetTraineesByTeacher);
                        break;
                    case 16:
                        DoActionWithCheck(GetTestersByCarType);
                        break;
                    case 17:
                        DoActionWithCheck(GetTraineseByNumOfTesters);
                        break;
                    case 18:
                        DoActionWithCheck(GetAllSuccessfullTestsByTester);
                        break;
                    default:
                        break;
                }
            }
            while (num != 0);
        }
        //
        private static void GetTraineseByNumOfTesters()
        {
            foreach (IGrouping<int, Trainee> group in bl.GetTraineseByNumOfTesters(true))
            {
                bool first = true;
                foreach (Trainee item in group)
                {
                    if (first)
                    {
                        Console.WriteLine("{0}: ", bl.GetTestsByTrainee(item).Count);
                        first = false;
                    }
                    Console.WriteLine(item);
                }
            }

            /*static void Main(string[] args)
            {
                bool[,] tomer_work = new bool[5, 6];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        tomer_work[i, j] = true;
                    }
                }
                IBL run = new BL_imp();

                run.add_trainee(212147870, "friedman", "ido", new DateTime(1990, 1, 1), gender.male, 587724233, new Address("ytziat erupa", 4, "zichron yakov"), vehicle.private_vehicle, kind_of_gearbox.manual, "hadera school", "tomer", 30);
                run.add_trainee(21167752, "lion", "yair", new DateTime(1879, 1, 1), gender.other, 587724233, new Address("ythak modai", 26, "givat shmuel"), vehicle.private_vehicle, kind_of_gearbox.auto, "hadera school", "tomer", 998);
                run.add_tester(2, "ploni", "tomer", new DateTime(1970, 1, 1), gender.male, 587724243, new Address("helem", 4, "madim"), (float)8.8, 20, vehicle.private_vehicle, tomer_work, 50);
                run.add_test(2, 212147870, new DateTime(2019, 1, 1, 10, 0, 0), new Address("zimbabue", 19, "moon"));
                run.add_test(2, 21167752, new DateTime(2018, 12, 31, 10, 0, 0), new Address("erezt leulam lo", 40, "pupik shel peer"));
                run.add_trainee(212947870, "friedman", "ido", new DateTime(1990, 1, 1), gender.male, 587724233, new Address("ytziat erupa", 4, "zichron yakov"), vehicle.private_vehicle, kind_of_gearbox.manual, "hadera school", "tomer", 30);
                run.add_trainee(21169752, "lion", "yair", new DateTime(1879, 1, 1), gender.other, 587724233, new Address("ythak modai", 26, "givat shmuel"), vehicle.private_vehicle, kind_of_gearbox.auto, "hadera school", "tomer", 998);
                run.add_test(2, 212947870, new DateTime(2019, 1, 1, 11, 0, 0), new Address("zimbabue", 19, "moon"));
                run.add_test(2, 21169752, new DateTime(2019, 1, 1, 12, 0, 0), new Address("erezt leulam lo", 40, "pupik shel peer"));
               for (int i = 0; i < run.all_test().Count; i++)
                {
                    Console.WriteLine(run.all_test()[i]);
                }
                try
                {
                    run.add_trainee(212147870, "hhh", "ido", new DateTime(1990, 1, 1), gender.male, 587724233, new Address("ytziat erupa", 4, "zichron yakov"), vehicle.private_vehicle, kind_of_gearbox.manual, "hadera school", "tomer", 30);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                for (int i = 0; i < run.test_on_date(new DateTime(2019,1,1)).Count; i++)
                {
                    Console.WriteLine(run.test_on_date(new DateTime(2019, 1, 1))[i]);
                }
                run.update_test(0, 212147870, true, true, true, true, true, true, "good");
                for (int i = 0; i < run.test_on_date(new DateTime(2019, 1, 1)).Count; i++)
                {
                    Console.WriteLine(run.test_on_date(new DateTime(2019, 1, 1))[i]);
                }
                for (int i = 0; i < run.all_trainee().Count; i++)
                {
                    Console.WriteLine(run.all_trainee()[i]);
                }
                run.remove_trainee(21167752);
                            for (int i = 0; i < run.all_trainee().Count; i++)
                {
                    Console.WriteLine(run.all_trainee()[i]);
                }
                for (int i = 0; i < run.all_tester().Count; i++)
                {
                    Console.WriteLine(run.all_tester()[i]);
                }
                for (int i = 0; i < run.all_test().Count; i++)
                {
                    Console.WriteLine(run.all_test()[i]);
                }
                for (int i = 0; i < run.testers_area(new Address("zimbabue", 19, "moon"),50).Count; i++)
                {
                    Console.WriteLine(run.testers_area(new Address("zimbabue", 19, "moon"), 50)[i]);
                }

            }*/
        }
    }
}