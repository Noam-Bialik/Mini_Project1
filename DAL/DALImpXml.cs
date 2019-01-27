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
            throw new NotImplementedException();
        }

        public void AddTester(Tester tester)
        {
            XElement help1 = (from a in testers.Elements()
                              where a.Element("Id").Value == tester.Id
                              select a).FirstOrDefault();
            XElement help2 = (from a in trainees.Elements()
                              where a.Element("Id").Value == tester.Id
                              select a).FirstOrDefault();
            ///////////לבדוק 

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
            throw new NotImplementedException();
        }

        public Test GetTest(long id)
        {
            throw new NotImplementedException();
        }

        public Tester GetTester(string id)
        {
            throw new NotImplementedException();
        }

        public List<Tester> GetTesters()
        {
            throw new NotImplementedException();
        }

        public List<Test> GetTests()
        {
            throw new NotImplementedException();
        }

        public Trainee GetTrainee(string id)
        {
            throw new NotImplementedException();
        }

        public List<Trainee> GetTrainees()
        {
            throw new NotImplementedException();
        }

        public void RemoveTester(Tester tester)
        {
            throw new NotImplementedException();
        }

        public void RemoveTester(string id)
        {
            throw new NotImplementedException();
        }

        public void RemoveTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public void RemoveTrainee(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTest(long test_id, int grade, string note)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTester(Tester e)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTrainee(Trainee e)
        {
            throw new NotImplementedException();
        }
    }
}
