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
        static bool done(Test t)
        {
            if (t.grade != null)
                return true;
            else
                return false;
        }
        private static int InPutNum()
        {
            int x;
            Console.WriteLine("0-quit \n 1-add trainee \n 2-add tester \n 3-add test \n 4-update trainee \n 5-update tester \n 6-update test \n 7-all trainees \n 8-all testers \n 9-all tests \n 10-testers in area \n 11-testers available on time \n 12- number of tests for trainee \n 13-to check if a trainee have a license \n 14-to get all the test by a date \n 15-all testers by expertise \n 16-all trainees by school \n 17-all trainees by teacher \n 18-all trainees by tests number \n 19-all tests that done \n 20-remove trainee \n 21- remove tester ");
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
                            Address address = new Address(street, house_number, city);
                            Console.WriteLine("which vehicle the trainee learn?(private_vehicle,two_weels_vehicle,medium_track, heavy_track)");
                            string _learn_vehicle = Console.ReadLine();
                            vehicle learn_vehicle = (vehicle)Enum.Parse(typeof(vehicle), _learn_vehicle);
                            Console.WriteLine("what kind of gearbox? (auto or manual )");
                            string _gearbox = Console.ReadLine();
                            kind_of_gearbox gearbox = (kind_of_gearbox)Enum.Parse(typeof(kind_of_gearbox), _gearbox);
                            Console.WriteLine("enter trainee's school:");
                            string school = Console.ReadLine();
                            Console.WriteLine("enter trainee's teacher name:");
                            string teacher_name = Console.ReadLine();
                            Console.WriteLine("how many lessons the trainee did?");
                            int num_of_lessons = int.Parse(Console.ReadLine());
                            bl.add_trainee(id, last_name, first_name, date_of_birth, Gender, phone, address, learn_vehicle, gearbox, school, teacher_name, num_of_lessons);
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
                            Console.WriteLine("enter tester's gender:");
                            string _Gender = Console.ReadLine();
                            gender Gender = (gender)Enum.Parse(typeof(gender), _Gender);
                            Console.WriteLine("enter phone number:");
                            long phone = long.Parse(Console.ReadLine());
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
                            vehicle tester_expertise = (vehicle)Enum.Parse(typeof(vehicle), _tester_expertise);
                            Console.WriteLine("enter tester's work time (true/false) ");
                            bool[,] work_time = new bool[5, 6];
                            for (int i = 0; i < 5; i++)
                            {
                                Console.WriteLine("at" + (DayOfWeek)i);
                                for (int j = 0; j < 6; j++)
                                {
                                    Console.WriteLine((j + 9) + " :00 ?");
                                    work_time[i, j] = bool.Parse(Console.ReadLine());
                                }
                            }
                            Console.WriteLine("enter tester's max way to go");
                            int max_way = int.Parse(Console.ReadLine());

                            bl.add_tester(id, last_name, first_name, date_of_birth, Gender, phone, address, expirence, max_test_per_week, tester_expertise, work_time, max_way);
                        }//
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//add tester
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
                            Address address = new Address(street, house_number, city);
                            bl.add_test(teseter_id, trainee_id, temp, address);
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
                            Address address = new Address(street, house_number, city);
                            Console.WriteLine("which vehicle the trainee learn?(private_vehicle,two_weels_vehicle,medium_track, heavy_track)");
                            string _learn_vehicle = Console.ReadLine();
                            vehicle learn_vehicle = (vehicle)Enum.Parse(typeof(vehicle), _learn_vehicle);
                            Console.WriteLine("what kind of gearbox? (auto or manual )");
                            string _gearbox = Console.ReadLine();
                            kind_of_gearbox gearbox = (kind_of_gearbox)Enum.Parse(typeof(kind_of_gearbox), _gearbox);
                            Console.WriteLine("enter trainee's school:");
                            string school = Console.ReadLine();
                            Console.WriteLine("enter trainee's teacher name:");
                            string teacher_name = Console.ReadLine();
                            Console.WriteLine("how many lessons the trainee did?");
                            int num_of_lessons = int.Parse(Console.ReadLine());

                            bl.update_trainee(id, last_name, first_name, date_of_birth, Gender, phone, address, learn_vehicle, gearbox, school, teacher_name, num_of_lessons);
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
                            Address address = new Address(street, house_number, city);
                            Console.WriteLine("how many expirence the tester have?");
                            float expirence = float.Parse(Console.ReadLine());
                            Console.WriteLine("how many tests the tester can do in a week?");
                            int max_test_per_week = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter tester's expertise:");
                            string _tester_expertise = Console.ReadLine();
                            vehicle tester_expertise = (vehicle)Enum.Parse(typeof(vehicle), _tester_expertise);
                            Console.WriteLine("enter tester's work time (true/false) ");
                            bool[,] work_time = new bool[5, 6];
                            for (int i = 0; i < 5; i++)
                            {
                                Console.WriteLine("at" + (DayOfWeek)i);
                                for (int j = 0; j < 6; j++)
                                {
                                    Console.WriteLine((j + 9) + ":00 ?");
                                    work_time[i, j] = bool.Parse(Console.ReadLine());
                                }
                            }
                            Console.WriteLine("enter tester's max way to go");
                            int max_way = int.Parse(Console.ReadLine());

                            bl.update_tester(id, last_name, first_name, date_of_birth, Gender, phone, address, expirence, max_test_per_week, tester_expertise, work_time, max_way);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//update tester
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
                        }//update test
                        break;
                    case 7:
                        try
                        {
                            for (int i = 0; i < bl.all_trainee().Count; i++)
                            {
                                Console.WriteLine(bl.all_trainee()[i] + "\n");
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
                            for (int i = 0; i < bl.all_tester().Count; i++)
                            {
                                Console.WriteLine(bl.all_tester()[i] + "\n");
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
                            for (int i = 0; i < bl.all_test().Count; i++)
                            {
                                Console.WriteLine(bl.all_test()[i] + "\n");
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
                            Console.WriteLine("enter distance");
                            int x = int.Parse(Console.ReadLine());
                            for (int i = 0; i < bl.testers_area(new Address(street, house_number, city), x).Count; i++)
                            {
                                Console.WriteLine(bl.testers_area(new Address(street, house_number, city), x)[i] + "\n");
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
                            for (int i = 0; i < bl.test_on_date(temp).Count; i++)
                            {
                                Console.WriteLine(bl.test_on_date(temp)[i]);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return the testers that are available at the time
                        break;
                    case 12:
                        try
                        {
                            Console.WriteLine("enter trainee's id");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine(bl.trainee_tests(id));

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return how many tests the trainee did
                        break;
                    case 13:
                        try
                        {
                            Console.WriteLine("enter trainee's id");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine(bl.pass(id));
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
                            for (int i = 0; i < bl.test_on_date(date).Count; i++)
                            {
                                Console.WriteLine(bl.test_on_date(date)[i]);
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
                            Console.WriteLine("do you want to sort by tester's expertise? (true/false)");
                            bool sort = bool.Parse(Console.ReadLine());
                            foreach (var item in bl.by_tester_expertice(sort))
                            {
                                Console.WriteLine(item.Key + ":");
                                foreach (Tester t in item)
                                {
                                    Console.WriteLine(t);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return all test by expertise
                        break;
                    case 16:
                        try
                        {
                            Console.WriteLine("do you want to sort by school? (true/false)");
                            bool sort = bool.Parse(Console.ReadLine());
                            foreach (var item in bl.by_school(sort))
                            {
                                Console.WriteLine(item.Key + ":");
                                foreach (Trainee t in item)
                                {
                                    Console.WriteLine(t);
                                }
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return all trainees by school
                        break;
                    case 17:
                        try
                        {
                            Console.WriteLine("do you want to sort by teacher? (true/false)");
                            bool sort = bool.Parse(Console.ReadLine());
                            foreach (var item in bl.by_teacher(sort))
                            {
                                Console.WriteLine(item.Key + ":");
                                foreach (Trainee t in item)
                                {
                                    Console.WriteLine(t);
                                }
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return all trainees by teacher
                        break;
                    case 18:
                        try
                        {
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
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }//return all trainees by number of test
                        break;
                    case 19:
                        try
                        {
                            for (int i = 0; i < bl.find_all_tests(done).Count; i++)
                            {
                                Console.WriteLine(bl.find_all_tests(done)[i]);
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
                            int x = int.Parse(Console.ReadLine());
                            bl.remove_trainee(x);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        break;
                    case 21:
                        try
                        {
                            Console.WriteLine("enter id:");
                            int x = int.Parse(Console.ReadLine());
                            bl.remove_tester(x);
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
