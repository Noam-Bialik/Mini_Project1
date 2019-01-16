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
        private static Ibl bl = FactoryBL.GetInstance();
        static bool done(Test t)
        {
            if (t.Grade==-1)
                return true;
            else
                return false;
        }
        private static int InPutNum()
        {
            int x;
            Console.WriteLine("0-quit \n 1-add trainee \n 2-add tester \n 3-add test \n 4-update trainee \n 5-update tester \n 6-update test \n 7-all trainees \n 8-all testers \n 9-all tests \n 10-testers in area \n 11-testers available on time \n 12- auto adding trainees\n 13-to check if a trainee have a license **not available in this version**  \n 14-to get all the tests by Preferred_treinee_time \n 15-all testers by expertise **not available in this version**  \n 16-all trainees in spesific school \n 17-all trainees by teacher **not available in this version**  \n 18-all trainees by tests number  **not available in this version**   \n 19-all tests that done \n 20-remove trainee \n 21- remove tester ");
            string a = Console.ReadLine();
            x = int.Parse(a);
            return x;
        }
        static void Main(string[] args)
        {

            int num;
            do
            {
                num = InPutNum();

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
                            Console.WriteLine("enter trainee's Gender:");
                            string _Gender = Console.ReadLine();
                            Gender Gender = (Gender)Enum.Parse(typeof(Gender), _Gender);
                            Console.WriteLine("enter trainee's phone number:");
                            string phone = Console.ReadLine();
                            Console.WriteLine("the address of the test: \n");
                            Console.WriteLine("enter city");
                            string city = Console.ReadLine();
                            Console.WriteLine("enter street");
                            string street = Console.ReadLine();
                            Console.WriteLine("enter house number");
                            int house_number = int.Parse(Console.ReadLine());
                            Address address = new Address(street, house_number, city);
                            Console.WriteLine("which Vehicle the trainee learn?(Privte, TwoWheeles, MediumTruck, HeavyTruck)");
                            string _learn_Vehicle = Console.ReadLine();
                            Vehicle learn_Vehicle = (Vehicle)Enum.Parse(typeof(Vehicle), _learn_Vehicle);
                            Console.WriteLine("what kind of gearbox? (Manual, Automaton)");
                            string _gearbox = Console.ReadLine();
                            Gearbox gearbox = (Gearbox)Enum.Parse(typeof(Gearbox), _gearbox);
                            Console.WriteLine("enter trainee's school:");
                            string school = Console.ReadLine();
                            Console.WriteLine("enter trainee's teacher name:");
                            string teacher_name = Console.ReadLine();
                            Console.WriteLine("how many lessons the trainee did?");
                            int num_of_lessons = int.Parse(Console.ReadLine());
                            Trainee trainee = new Trainee(id.ToString(), first_name, last_name, date_of_birth, Gender, phone, address, learn_Vehicle, gearbox, school, teacher_name, num_of_lessons);
                            bl.AddTrainee(trainee);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//add trainee
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
                            Console.WriteLine("enter tester's Gender:");
                            string _Gender = Console.ReadLine();
                            Gender Gender = (Gender)Enum.Parse(typeof(Gender), _Gender);
                            Console.WriteLine("enter phone number:");
                            string phone = Console.ReadLine();
                            Console.WriteLine("the address of the tester: \n");
                            Console.WriteLine("enter city");
                            string city = Console.ReadLine();
                            Console.WriteLine("enter street");
                            string street = Console.ReadLine();
                            Console.WriteLine("enter house number");
                            int house_number = int.Parse(Console.ReadLine());
                            Address address = new Address(street, house_number, city);
                            Console.WriteLine("how many expirence the tester have?");
                            float expirence = float.Parse(Console.ReadLine());
                            Console.WriteLine("how many tests the tester can do in a week?");
                            int max_test_per_week = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter tester's expertise:");
                            string _tester_expertise = Console.ReadLine();
                            Vehicle tester_expertise = (Vehicle)Enum.Parse(typeof(Vehicle), _tester_expertise);
                            Console.WriteLine("enter tester's work time (true/false) ");
                            bool[][] work_time = new bool[5][];
                            for (int i = 0; i < 5; i++)
                            {
                                Console.WriteLine("at" + (DayOfWeek)i);
                                for (int j = 0; j < 6; j++)
                                {
                                    work_time[i] = new bool[6];
                                    Console.WriteLine((j + 9) + ":00 ?");
                                    work_time[i][j] = bool.Parse(Console.ReadLine());
                                }
                            }
                            Console.WriteLine("enter tester's max way to go");
                            int max_way = int.Parse(Console.ReadLine());
                            Tester tester = new Tester(id.ToString(), first_name, last_name, date_of_birth, Gender, phone, address, (int)expirence, max_test_per_week, max_way, tester_expertise, work_time);
                            bl.AddTester(tester);
                        }//
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//add tester
                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine("enter trainee's id:");
                            string trainee_id = Console.ReadLine();
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
                            Address address = new Address(street, house_number, city);
                            Test test = new Test(trainee_id, address, temp);
                            bl.AddTest(test);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//add test
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
                            Console.WriteLine("enter trainee's Gender:");
                            string _Gender = Console.ReadLine();
                            Gender Gender = (Gender)Enum.Parse(typeof(Gender), _Gender);
                            Console.WriteLine("enter trainee's phone number:");
                            string phone = Console.ReadLine();
                            Console.WriteLine("the address of the test: \n");
                            Console.WriteLine("enter city");
                            string city = Console.ReadLine();
                            Console.WriteLine("enter street");
                            string street = Console.ReadLine();
                            Console.WriteLine("enter house number");
                            int house_number = int.Parse(Console.ReadLine());
                            Address address = new Address(street, house_number, city);
                            Console.WriteLine("which Vehicle the trainee learn?(private_Vehicle,two_weels_Vehicle,medium_track, heavy_track)");
                            string _learn_Vehicle = Console.ReadLine();
                            Vehicle learn_Vehicle = (Vehicle)Enum.Parse(typeof(Vehicle), _learn_Vehicle);
                            Console.WriteLine("what kind of gearbox? (auto or manual )");
                            string _gearbox = Console.ReadLine();
                            Gearbox gearbox = (Gearbox)Enum.Parse(typeof(Gearbox), _gearbox);
                            Console.WriteLine("enter trainee's school:");
                            string school = Console.ReadLine();
                            Console.WriteLine("enter trainee's teacher name:");
                            string teacher_name = Console.ReadLine();
                            Console.WriteLine("how many lessons the trainee did?");
                            int num_of_lessons = int.Parse(Console.ReadLine());
                            Trainee trainee = new Trainee(id.ToString(), first_name, last_name, date_of_birth, Gender, phone, address, learn_Vehicle, gearbox, school, teacher_name, num_of_lessons);
                            bl.UpdateTrainee(trainee);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//update trainee
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
                            Console.WriteLine("enter tester's Gender:");
                            string _Gender = Console.ReadLine();
                            Gender Gender = (Gender)Enum.Parse(typeof(Gender), _Gender);
                            string phone = Console.ReadLine();
                            Console.WriteLine("the address of the test: \n");
                            Console.WriteLine("enter city");
                            string city = Console.ReadLine();
                            Console.WriteLine("enter street");
                            string street = Console.ReadLine();
                            Console.WriteLine("enter house number");
                            int house_number = int.Parse(Console.ReadLine());
                            Address address = new Address(street, house_number, city);
                            Console.WriteLine("how many expirence the tester have?");
                            float expirence = float.Parse(Console.ReadLine());
                            Console.WriteLine("how many tests the tester can do in a week?");
                            int max_test_per_week = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter tester's expertise:");
                            string _tester_expertise = Console.ReadLine();
                            Vehicle tester_expertise = (Vehicle)Enum.Parse(typeof(Vehicle), _tester_expertise);
                            Console.WriteLine("enter tester's work time (true/false) ");
                            bool[][] work_time = new bool[5][];
                            for (int i = 0; i < 5; i++)
                            {
                                Console.WriteLine("at" + (DayOfWeek)i);
                                for (int j = 0; j < 6; j++)
                                {
                                    work_time[i] = new bool[6];
                                    Console.WriteLine((j + 9) + ":00 ?");
                                    work_time[i][j] = bool.Parse(Console.ReadLine());
                                }
                            }
                            Console.WriteLine("enter tester's max way to go");
                            int max_way = int.Parse(Console.ReadLine());
                            Tester tester = new Tester(id.ToString(), first_name, last_name, date_of_birth, Gender, phone, address, (int)expirence, max_test_per_week, max_way, tester_expertise, work_time);

                            bl.UpdateTester(tester);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//update tester
                        break;
                    case 6:
                        try
                        {
                            Console.WriteLine("enter tester's id:");//אני החלפתי (הוא ביקש את המס' מבחן ואני את מספר בוחן)י
                            string id_tester = Console.ReadLine();
                            Console.WriteLine("enter trainee's id:");
                            string id_trainee = Console.ReadLine();
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
                            bool passed = bool.Parse(Console.ReadLine());
                            Console.WriteLine("you can enter a mention if you want to");
                            string mention = Console.ReadLine();
                            int grade = 0;
                            if (passed)
                                grade = 100;
                            bool worked = bl.UpdateTest(id_tester.ToString(), id_trainee.ToString(), grade, mention);
                            if (worked == false)
                                Console.WriteLine("!!  NOT FOUND  !!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//update test
                        break;
                    case 7:
                        try
                        {
                            List<Trainee> allTrainee = bl.GetTrainees();
                            if (allTrainee.Count == 0)
                                throw new Exception("no traine");
                            for (int i = 0; i < allTrainee.Count; i++)
                            {
                                Console.WriteLine(allTrainee[i] + "\n");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return all trainees
                        break;
                    case 8:
                        try
                        {
                            List<Tester> allTesters = bl.GetTesters();
                            if (allTesters.Count == 0)
                                throw new Exception("no tester");
                            for (int i = 0; i < allTesters.Count; i++)
                            {
                                Console.WriteLine(allTesters[i] + "\n");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return all testers
                        break;
                    case 9:
                        try
                        {
                            List<Test> allTests = bl.GetTests();
                            if (allTests.Count == 0)
                                throw new Exception("no test");
                            for (int i = 0; i < allTests.Count; i++)
                            {
                                Console.WriteLine(allTests[i] + "\n");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return all tests
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
                            Console.WriteLine("enter distance in km");
                            int x = int.Parse(Console.ReadLine());
                            List<Tester> testers = bl.InRadius(new Address(street, house_number, city), x);
                            if (testers == null)
                                throw new Exception("no tester in the current radius");
                            for (int i = 0; i < testers.Count; i++)
                            {
                                Console.WriteLine(testers[i] + "\n");
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return the testers in the area
                        break;
                    case 11:
                        try
                        {
                            Console.WriteLine("enter date and hour (2/16/2008 12:00:00 PM you must write PM or AM!!!).");
                            string date_and_hour = Console.ReadLine();
                            DateTime temp = new DateTime();
                            temp = DateTime.Parse(date_and_hour);

                            List<Tester> testers = bl.Intime(temp);
                            if (testers == null)
                                throw new Exception("no tester in the current time");
                            for (int i = 0; i < testers.Count; i++)
                            {
                                Console.WriteLine(testers[i]);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return the testers that are available at the time
                        break;
                    case 12:
                        {
                            try
                            {
                                Trainee a;
                                DateTime h = new DateTime(2000, 03, 01);
                                Address j = new Address("grizim", 2, "kedumim");
                                a = new Trainee("323447747", "shmuel", "garber", h, Gender.Female, "0525067534", j, Vehicle.HeavyTruck, Gearbox.Automaton, "lev", "desht", 60);
                                bl.AddTrainee(a);
                                h = new DateTime(1995, 03, 20);
                                j = new Address("grizim", 2, "kedumim");
                                a = new Trainee("323362967", "david", "ginger", h, Gender.Male, "05255556699", j, Vehicle.MediumTruck, Gearbox.Automaton, "lev", "desht", 100);
                                bl.AddTrainee(a);
                                h = new DateTime(2000, 01, 01);
                                j = new Address("havaad haleumi", 223, "jerusalem");
                                a = new Trainee("329990047", "moshe", "haimi", h, Gender.Male, "05255556699", j, Vehicle.Private, Gearbox.Manual, "lev", "kidron", 45);
                                bl.AddTrainee(a);
                                h = new DateTime(1996, 01, 01);
                                j = new Address("leumi", 92, "Tel aviv");
                                a = new Trainee("129500047", "ariel", "sharir", h, Gender.Male, "05253356699", j, Vehicle.Private, Gearbox.Manual, "lev", "kidron", 150);
                                bl.AddTrainee(a);



                                bool[][] k = new bool[5][];
                                for (int i = 0; i < 5; i++)
                                {
                                    k[i] = new bool[6];
                                    for (int ii = 0; ii < 6; ii++)
                                    {
                                        k[i][ii] = true;
                                    }
                                }
                                h = new DateTime(1956, 01, 01);
                                j = new Address("leumi", 92, "Tel aviv");
                                Tester b = new Tester("325469525", "moshe", "klein", h, Gender.Female, "0565854444", j, 10, 10, 30, Vehicle.Private, k);

                            }
                            catch (Exception)
                            {

                                
                            }
                        }//add trainees
                        break;
                    case 13:
                        try
                        {
                            throw new Exception("not available in this version");
                            /*Console.WriteLine("enter trainee's id");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine(bl.pass(id));*/
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//check if the trainee already have the license
                        break;
                    case 14:
                        try
                        {
                            Console.WriteLine("enter a date:(dd//mm/yy)");
                            DateTime date = DateTime.Parse(Console.ReadLine());
                            List<Test> tests = bl.GetTests(t => t.Preferred_treinee_time == date);
                            if (tests == null)
                                throw new Exception("didn't find any Preferred_treinee_time! ");
                            for (int i = 0; i <tests.Count; i++)
                            {
                                Console.WriteLine(tests[i]);
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return all the test by date
                        break;
                    case 15:
                        try
                        {
                            throw new Exception("not available in this version! ");
                            /*
                            Console.WriteLine("do you want to sort by tester's expertise? (true/false)");
                            bool sort = bool.Parse(Console.ReadLine());
                            foreach (var item in bl.by_tester_expertice(sort))
                            {
                                Console.WriteLine(item.Key + ":");
                                foreach (Tester t in item)
                                {
                                    Console.WriteLine(t);
                                }
                            }*/
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return all test by expertise
                        break;
                    case 16:
                        try
                        {
                            Console.WriteLine("please write the school name:");
                            string school_name  = Console.ReadLine();
                            List<Trainee> trainees = bl.GetTrainees(t => t.School_name == school_name);
                            if (trainees == null)
                                throw new Exception(school_name + " have no trainees");
                            foreach (var item in trainees)
                            {
                                Console.WriteLine(item);
                               
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return all trainees in apesific school
                        break;
                    case 17:
                        try
                        {
                            throw new Exception("not available in this version! ");
                            /*
                            Console.WriteLine("do you want to sort by teacher? (true/false)");
                            bool sort = bool.Parse(Console.ReadLine());
                            foreach (var item in bl.by_teacher(sort))
                            {
                                Console.WriteLine(item.Key + ":");
                                foreach (Trainee t in item)
                                {
                                    Console.WriteLine(t);
                                }
                            }*/

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return all trainees by teacher
                        break;
                    case 18:
                        try
                        {
                            throw new Exception("not available in this version! ");
                            /*
                            Console.WriteLine("do you want to sort by test number? (true/false)");
                            bool sort = bool.Parse(Console.ReadLine());
                            foreach (var item in bl.by_tests_num(sort))
                            {
                                Console.WriteLine(item.Key + ":");
                                foreach (Trainee t in item)
                                {
                                    Console.WriteLine(t);
                                }
                            }
                            */
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return all trainees by number of test
                        break;
                    case 19:
                        try
                        {
                            List<Test> tests = bl.GetTests(t => t.Grade != -1);//-1 is the default.
                            if (tests.Count == 0)
                                throw new Exception("no test have done in the system");
                            for (int i = 0; i < tests.Count; i++)
                            {
                                Console.WriteLine(tests[i]);
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return all test that done
                        break;
                    case 20:
                        try
                        {
                            Console.WriteLine("enter id:");
                            string x = Console.ReadLine();
                            bl.RemoveTrainee(x);                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//remove trainee by id
                        break;
                    case 21:
                        try
                        {
                            Console.WriteLine("enter id:");
                            int x = int.Parse(Console.ReadLine());
                            bl.RemoveTester(x.ToString());
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
    //
}
