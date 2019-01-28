using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;

namespace DAL
{
    class DALImpXml : Idal
    {
        string path;
        XElement root;
        XElement testers;
        XElement trainees;
        XElement tests;
        public DALImpXml()
        {
            path = @"DSxml.xml";
            if (!File.Exists(path))
            {
                testers = new XElement("Tsters");
                trainees = new XElement("Trainees");
                tests = new XElement("Tests");
                root = new XElement("Root", testers, trainees, tests);
                root.Save(path);
            }
            else
            {
                root = XElement.Load(path);
            }

        }
        public void AddTest(Test test)
        {
            try
            {
                //creating the id
                Random rnd = new Random();
                long num = rnd.Next(888888800, 888888899);
                XElement help1 = (from a in tests.Elements()
                                  where a.Element("Id").Value == num.ToString()
                                  select a).FirstOrDefault();
                if (help1 != null)
                {
                    for (int i = 1; help1 != null; i++)
                    {
                        num += i;
                        help1 = (from a in tests.Elements()
                                 where a.Element("Id").Value == num.ToString()
                                 select a).FirstOrDefault();
                    }
                }

                test.Test_id = num;

                XElement TestId = new XElement("TestId", test.Test_id.ToString());
                XElement TraineeId = new XElement("TraineeId", test.Trainee_id);
                XElement TesterId = new XElement("TesterId", test.Tester_id);
                XElement PreferredTraineeTime = new XElement("PreferredTraineeTime", test.Preferred_treinee_time);
                XElement EndAddress = new XElement("EndAddress", test.End_Address);
                XElement StartAddress = new XElement("StartAddress", test.Start_address);
                XElement PreferredTraineeAddress = new XElement("PreferredTraineeAddress", test.Preferred_treinee_address);
                XElement Grade = new XElement("Grade", test.Grade);
                XElement Vehicle = new XElement("Vehicle", test.Type);
                XElement Note = new XElement("Note", test.Note);

                XElement Test = new XElement("Test", TestId, TraineeId, TesterId, Grade, PreferredTraineeTime, PreferredTraineeAddress, StartAddress, EndAddress, Vehicle, Note);
                testers.Add(Test);
                root.Save(path);



            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        public void AddTester(Tester tester)
        {
            XElement help1 = (from a in testers.Elements()
                              where a.Element("Id").Value == tester.Id
                              select a).FirstOrDefault();
            XElement help2 = (from a in trainees.Elements()
                              where a.Element("Id").Value == tester.Id
                              select a).FirstOrDefault();
            if (help1 != null || help2 != null)
            {
                throw new Exception("The same Id is allready in the system");
            }


            XElement Id = new XElement("Id", tester.Id);
            XElement FirstName = new XElement("FirstName", tester.First_name);
            XElement LastName = new XElement("LastName", tester.Last_name);
            XElement Birthdate = new XElement("Birthdate", tester.Birthdate);
            XElement Experience = new XElement("Experience", tester.Experience);
            XElement MaxRange = new XElement("MaxRange", tester.Max_range);
            XElement MaxTestsPerWeek = new XElement("MaxTestsPerWeek", tester.Max_tests_per_week);
            XElement PhoneNumber = new XElement("PhoneNumber", tester.Phone_number);
            XElement Speciality = new XElement("Speciality", tester.Speciality);
            XElement Address = new XElement("Address", tester._Address);
            XElement Gender = new XElement("Gender", tester._Gender);
            XElement Schedule = new XElement("Schedule", tester._Schedule);

            XElement Tester = new XElement("Tester", Id, FirstName, LastName, PhoneNumber, Birthdate, Experience, MaxRange, MaxTestsPerWeek, Speciality, Address, Gender, Schedule);

            testers.Add(Tester);
            root.Save(path);


        }

        public void AddTrainee(Trainee trainee)
        {

            XElement help1 = (from a in trainees.Elements()
                              where a.Element("Id").Value == trainee.Id
                              select a).FirstOrDefault();
            XElement help2 = (from a in testers.Elements()
                              where a.Element("Id").Value == trainee.Id
                              select a).FirstOrDefault();
            if (help1 != null || help2 != null)
            {
                throw new Exception("The same Id is allready in the system");
            }

            XElement Id = new XElement("Id", trainee.Id);
            XElement FirstName = new XElement("FirstName", trainee.First_name);
            XElement LastName = new XElement("LastName", trainee.Last_name);
            XElement Birthdate = new XElement("Birthdate", trainee.Birthdate);
            XElement PhoneNumber = new XElement("PhoneNumber", trainee.Phone_number);
            XElement Address = new XElement("Address", trainee._Address);
            XElement Gender = new XElement("Gender", trainee._Gender);
            XElement LessonsCount = new XElement("LessonsCount", trainee.Lessons_count);
            XElement TeacherName = new XElement("TeacherName", trainee.Teacher_name);
            XElement Specialty = new XElement("Specialty", trainee._Speciality);
            XElement Gearbox = new XElement("Gearbox", trainee._Gearbox);
            XElement SchoolName = new XElement("SchoolName", trainee.School_name);


            XElement Trainee = new XElement("Trainee", Id, FirstName, LastName, PhoneNumber, Birthdate, Address, Gender, LessonsCount, TeacherName, Specialty, Gearbox, SchoolName);
            trainees.Add(Trainee);
            root.Save(path);
        }

        public Test GetTest(long id)
        {
            try
            {
                XElement help = (from a in tests.Elements()
                                 where a.Element("TestId").Value == id.ToString()
                                 select a).FirstOrDefault();
                if (help == null)
                    throw new Exception("the Test not exist");

                string TestId = help.Element("TestId").Value;
                string TraineeId = help.Element("TraineeId").Value;
                string TesterId = help.Element("TesterId").Value;
                string PreferredTraineeTime = help.Element("PreferredTraineeTime").Value;
                string EndAddress = help.Element("EndAddress").Value;
                string StartAddress = help.Element("StartAddress").Value;
                string PreferredTraineeAddress = help.Element("PreferredTraineeAddress").Value;
                string Grade = help.Element("Grade").Value;
                string Vehicle = help.Element("Vehicle").Value;
                string Note = help.Element("Note").Value;

                Test test = new Test(TraineeId, GetDate(PreferredTraineeTime), GetVehicle(Vehicle), GetAddress(PreferredTraineeAddress), GetAddress(StartAddress), GetAddress(EndAddress), TesterId, int.Parse(Grade), Note, long.Parse(TestId));
                return test;
            }
            catch
            {
                throw new Exception("problem in loading Test (GetTest)");
            }
        }

        public Tester GetTester(string testerId)
        {
            try
            {
                XElement help = (from a in testers.Elements()
                                 where a.Element("Id").Value == testerId
                                 select a).FirstOrDefault();
                if (help == null)
                    throw new Exception("the Tester not exist");

                string Id = help.Element("Id").Value;
                string FirstName = help.Element("FirstName").Value;
                string LastName = help.Element("LastName").Value;
                string Birthdate = help.Element("Birthdate").Value;
                string Experience = help.Element("Experience").Value;
                string MaxRange = help.Element("MaxRange").Value;
                string MaxTestsPerWeek = help.Element("MaxTestsPerWeek").Value;
                string PhoneNumber = help.Element("PhoneNumber").Value;
                string Speciality = help.Element("Speciality").Value;
                string Address = help.Element("Address").Value;
                string Gender = help.Element("Gender").Value;
                string Schedule = help.Element("Schedule").Value;
                bool[][] arr = new bool[5][];
                for (int i = 0; i < 5; i++)
                {
                    arr[i] = new bool[6];
                    for (int j = 0; j < 6; j++)
                    {
                        arr[i][j] = true;
                    }
                }

                Tester tester = new Tester(Id, FirstName, LastName, GetDate(Birthdate), GetGender(Gender), PhoneNumber, GetAddress(Address), int.Parse(Experience), int.Parse(MaxTestsPerWeek), double.Parse(MaxRange), GetVehicle(Speciality),arr);
                return tester;
            }
            catch (Exception)
            {

                throw new Exception("problem in loading Tester");
            }
        }

        public List<Tester> GetTesters()
        {
            List<Tester> list;
            try
            {
                
              list   = (from t in testers.Elements()
                                     select new Tester()
                                     {
                                         //Person
                                         Id = t.Element("Id").Value,
                                         First_name = t.Element("FirstName").Value,
                                         Last_name = t.Element("LastName").Value,
                                         Birthdate = GetDate(t.Element("Birthdate").Value),
                                         _Gender = GetGender(t.Element("Gender").Value),
                                         Phone_number = t.Element("PhoneNumber").Value,
                                         _Address = GetAddress(t.Element("Address").Value),
                                         //other
                                         Experience = int.Parse(t.Element("Experience").Value),
                                         Max_tests_per_week = int.Parse(t.Element("MaxTestsPerWeek").Value),
                                         Max_range = double.Parse(t.Element("MaxTestsPerWeek").Value),
                                         Speciality = GetVehicle(t.Element("Speciality").Value),
                                         _Schedule= GetSchedule(t.Element("Schedule").Value)
                                     }).ToList();
                
                 
                return list;
            }
            catch (Exception)
            {

                return list =null;
            }
        }
      
        public List<Test> GetTests()
        {
            try
            {
                List<Test> list = (from t in tests.Elements()
                                     select new Test()
                                     {
                                         Test_id = long.Parse(t.Element("TestId").Value),
                                         Tester_id = t.Element("TesterId").Value,
                                         Trainee_id = t.Element("TraineeId").Value,
                                         Preferred_treinee_time = GetDate(t.Element("PreferredTraineeTime").Value),
                                         Type = GetVehicle(t.Element("Vehicle").Value),
                                         Start_address = GetAddress(t.Element("StartAddress").Value),
                                         Preferred_treinee_address =GetAddress(t.Element("PreferredTraineeAddress").Value),
                                         End_Address = GetAddress(t.Element("EndAddress").Value),
                                         Grade = int.Parse(t.Element("Grade").Value),
                                         Note = t.Element("Note").Value,
                                     }).ToList();
                
                return list;
            }
            catch (Exception)
            {

                throw new Exception("Problem in loading Testss");
            }
        }

        public Trainee GetTrainee(string id)
        {
            try
            {
                Trainee trainee = (from t in trainees.Elements()
                                   where t.Element("Id").Value == id.ToString()
                                   select new Trainee()
                                   {
                                       //Person
                                       Id = t.Element("Id").Value,
                                       First_name = t.Element("FirstName").Value,
                                       Last_name = t.Element("LastName").Value,
                                       Birthdate = GetDate(t.Element("Birthdate").Value),
                                       _Gender = GetGender(t.Element("Gender").Value),
                                       Phone_number = t.Element("PhoneNumber").Value,
                                       _Address = GetAddress(t.Element("Address").Value),
                                       //other
                                       _Speciality = GetVehicle(t.Element("Specialty").Value),
                                       _Gearbox = GetGearbox(t.Element("Gearbox").Value),
                                       School_name = t.Element("SchoolName").Value,
                                       Teacher_name = t.Element("TeacherName").Value,
                                       Lessons_count = int.Parse(t.Element("LessonsCount").Value)
                                   }).FirstOrDefault();
                if (trainee != null)
                    return trainee;
                else throw new Exception(" ");
            }
            catch
            {
                throw new Exception("problem in loading Test (GetTest)");

            }
        }

        public List<Trainee> GetTrainees()
        {
            List<Trainee> list;
            try
            {
               list = (from t in trainees.Elements()
                                      select new Trainee()
                                      {
                                          //Person
                                          Id = t.Element("Id").Value,
                                          First_name = t.Element("FirstName").Value,
                                          Last_name = t.Element("LastName").Value,
                                          Birthdate = GetDate(t.Element("Birthdate").Value),
                                          _Gender = GetGender(t.Element("Gender").Value),
                                          Phone_number = t.Element("PhoneNumber").Value,
                                          _Address = GetAddress(t.Element("Address").Value),
                                          //other
                                          _Speciality = GetVehicle(t.Element("Specialty").Value),
                                          _Gearbox = GetGearbox(t.Element("Gearbox").Value),
                                          School_name = t.Element("SchoolName").Value,
                                          Teacher_name = t.Element("TeacherName").Value,
                                          Lessons_count = int.Parse(t.Element("LessonsCount").Value)
                                      }).ToList();
              
                return list;
            }
            catch (Exception)
            {

                return list = null;
            }
        }

        public void RemoveTester(Tester tester)
        {
            XElement tes;
            try
            {
                tes = (from t in testers.Elements()
                       where t.Element("Id").Value == tester.Id
                                  select t).FirstOrDefault();
                tes.Remove();
                root.Save(path);              
            }
            catch
            {
                throw new Exception("Ereorr in remove Tester");
            }
        }

        public void RemoveTester(string id)
        {
            XElement tes;
            try
            {
                tes = (from t in testers.Elements()
                       where t.Element("Id").Value == id
                       select t).FirstOrDefault();
                tes.Remove();
                root.Save(path);
            }
            catch
            {
                throw new Exception("Ereorr in remove Tester");
            }
        }

        public void RemoveTrainee(Trainee trainee)
        {
            XElement tr;
            try
            {
                tr = (from t in  trainees.Elements()
                       where t.Element("Id").Value == trainee.Id
                       select t).FirstOrDefault();
                tr.Remove();
                root.Save(path);
            }
            catch
            {
                throw new Exception("Ereorr in remove Trainee");
            }
        }

        public void RemoveTrainee(string id)
        {
            XElement tr;
            try
            {
                tr = (from t in trainees.Elements()
                      where t.Element("Id").Value == id
                      select t).FirstOrDefault();
                tr.Remove();
                root.Save(path);
            }
            catch
            {
                throw new Exception("Ereorr in remove Trainee");
            }
        }

        public bool UpdateTest(long test_id, int grade, string note)
        {
            try
            {


                XElement test = (from t in tests.Elements()
                                 where long.Parse(t.Element("TestId").Value) == test_id
                                 select t).FirstOrDefault();
                if (test == null)
                    return false;
                test.Element("Grade").Value = grade.ToString();
                test.Element("Note").Value = note;


                test.Save(path);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool UpdateTester(Tester e)
        {
            try
            {


                XElement tester = (from t in testers.Elements()
                                 where t.Element("Id").Value == e.Id
                                 select t).FirstOrDefault();
                if (tester == null)
                    return false;

                //Person
                tester.Element("Id").Value = e.Id;
                tester.Element("FirstName").Value = e.First_name ;
                tester.Element("LastName").Value = e.Last_name;
                tester.Element("Birthdate").Value = e.Birthdate.ToString();
                tester.Element("Gender").Value = e._Gender.ToString();
                tester.Element("PhoneNumber").Value = e.Phone_number;
                tester.Element("Address").Value = e._Address.ToString();
                //other
                tester.Element("Experience").Value= e.Experience.ToString();
                tester.Element("MaxTestsPerWeek").Value = e.Max_tests_per_week.ToString();
                tester.Element("MaxRange").Value = e.Max_range.ToString();
                tester.Element("Speciality").Value = e.Speciality.ToString();
                tester.Element("Schedule").Value = "not working";


                tester.Save(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTrainee(Trainee e)
        {
            try
            {


                XElement trainee = (from t in trainees.Elements()
                                   where t.Element("Id").Value == e.Id
                                   select t).FirstOrDefault();
                if (trainee == null)
                    return false;

                //Person
                trainee.Element("Id").Value = e.Id;
                trainee.Element("FirstName").Value = e.First_name;
                trainee.Element("LastName").Value = e.Last_name;
                trainee.Element("Birthdate").Value = e.Birthdate.ToString();
                trainee.Element("Gender").Value = e._Gender.ToString();
                trainee.Element("PhoneNumber").Value = e.Phone_number;
                trainee.Element("Address").Value = e._Address.ToString();
                //other
                trainee.Element("LessonsCount").Value = e.Lessons_count.ToString();
                trainee.Element("TeacherName").Value = e.Teacher_name;
                trainee.Element("Specialty").Value = e._Speciality.ToString();
                trainee.Element("Gearbox").Value = e._Gearbox.ToString();
                trainee.Element("SchoolName").Value = e.School_name;


                trainee.Save(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    
        /// <summary>
        /// from string to DateTime
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DateTime GetDate(string str)
        {
            try
            {
                string year = null;
                string month = null;
                string day = null;
                int i = 0;
                for (; str[i] != '-'; i++)
                {
                    year += str[i];
                }
                i++;
                for (; str[i] != '-'; i++)
                {
                    month += str[i];
                }
                i++;
                for (; str[i] != 'T'; i++)
                {
                    day += str[i];
                }
                return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            }
            catch
            {
                throw new Exception("unsecced louding DateTime from xml");
            }
        }
        /// <summary>
        /// from strinh to Vehicle
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Vehicle GetVehicle(string str)
        {
            Vehicle v;
            if (str[0] == 'p')
            {
                v = Vehicle.Private;
                return v;
            }
            if (str[0] == 'H')
            {
                v = Vehicle.HeavyTruck;
                return v;
            }
            if (str[0] == 'T')
            {
                v = Vehicle.TwoWheeles;
                return v;
            }
            if (str[0] == 'M')
            {
                v = Vehicle.MediumTruck;
                return v;
            }
            throw new Exception("unsecced louding Vehicle from xml");

        }
        /// <summary>
        /// from string to Address
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Address GetAddress(string str)
        {
            try
            {
                Address a = new Address();
                int i = 0;
                for (; str[i] != '!'; i++)
                    a.City += str[i];
                i++;
                for (; str[i] != '!'; i++)
                    a.Street += str[i];
                i++;
                string num = null;
                for (; str[i] != '!'; i++)
                    num += str[i];
                a.Building_number = int.Parse(num);

                return a;
            }
            catch
            {
                throw new Exception("unsecced louding Address from xml");
            }
        }
        /// <summary>
        /// from string to Gender
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Gender GetGender(string str)
        {
            try
            {
                Gender g;
                if (str[0] == 'F')
                {
                    g = Gender.Female;
                    return g;
                }
                if (str[0] == 'M')
                {
                    g = Gender.Male;
                    return g;
                }
                throw new Exception();
            }
            catch
            {
                throw new Exception("unsecced loading Address from xml");
            }
        }
        /// <summary>
        /// from string to Shcedule , for now it return like the tester agree to work in all hours.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Schedule GetSchedule(String str = null)
        { 
            bool[][] arr = new bool[5][];
            for (int i = 0; i < 5; i++)
            {
                arr[i] = new bool[6];
                for (int j = 0; j < 6; j++)
                {
                    arr[i][j] = true;
                }
            }

            return new Schedule(arr);
        }
        /// <summary>
        /// from string to Gearbox
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Gearbox GetGearbox(string str)
        {
            try
            {
                if (str[0] == 'A')
                    return Gearbox.Automaton;
                if (str[0] == 'M')
                    return Gearbox.Manual;
                throw new Exception(" ");
            }
            catch
            {
                throw new Exception("unsecced loading Gearbox from xml");
            }
        }


        
    }
}
