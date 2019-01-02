using System;
using System.Collections.Generic;
using BE;
using DAL;
using System.Linq;
namespace Bl_imp
{
    public class Bl_imp : Ibl.Ibl
    {
        private Idal dal;
        public Bl_imp()
        {
            dal = FactoryDal.GetInstance();
        }
        private long distance(Address a,Address b)
        {
            //check the distance between the adrsses
        }


        private List<Tester> optional_testers_distance(Address a)
        {

            var x = from t in DS.DS.Testers
                    where distance(a, t._Address) < t.Max_range
                    select t;
            return x.ToList();
        }
        private List<Tester> optional_testers_time(DateTime d)
        {
            var x = from tester in DS.DS.Testers
                    from t in DS.DS.Tests
                    where tester.Id == t.Tester_id
                    select tester;
            return x.ToList();
        }
        public void AddTest(Test test)
        {
            if(test.Trainee_id == null || test.Preferred_treinee_time == null || test.Preferred_treinee_address == null)
            {
                throw new Exception("missing details");
            }
            string id = test.Trainee_id;
            //find the diffrence between the last test and the preferred treinee time
            var a = from t in dal.GetTests()
                    where t.Trainee_id == id
                    select t.Preferred_treinee_time;
            DateTime last = a.Max();
            TimeSpan diffrence = test.Preferred_treinee_time - last;
            if (diffrence.Days <= 30)
                throw new Exception("the interval time between the test must be at least 30 days");
            //info adding
            List<Tester> optionalTestersTime = optional_testers_time(test.Preferred_treinee_time);
            List<Tester> optionalTestersDistance = optional_testers_distance(test.Preferred_treinee_address);
            if (optionalTestersDistance.Count == 0)
                throw new Exception("there isn't tester in this area");

            //add the test
            try
            {
                dal.AddTest(test);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddTester(Tester tester)
        {
            throw new NotImplementedException();
        }

        public void AddTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public Test GetTest(int id)
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

        public bool UpdateTest(string tester_id, string trainee_id, int grade, string note)
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
