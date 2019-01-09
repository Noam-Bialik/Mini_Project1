using System;
using System.Collections.Generic;
using BE;
using DAL;
using System.Linq;
namespace BL
{


    internal class Bl_imp : Ibl
    {
        private Idal dal;
        public Bl_imp()
        {
            dal = FactoryDal.GetInstance();
        }
        private int distance(Address a, Address b)//return in km
        {
            Random r = new Random();
            return r.Next(0, 500);
        } 

        public void AddTest(Test test)
        {
            if (test.Trainee_id == null || test.Preferred_treinee_time == null || test.Preferred_treinee_address == null)
            {
                throw new Exception("missing details");
            }
            string id = test.Trainee_id;
            //find the diffrence between the last test and the preferred treinee time
            var a = from t in GetTests(t=>t.Trainee_id == id)
                    select t.Preferred_treinee_time;
            DateTime last = a.Max();
            TimeSpan diffrence = test.Preferred_treinee_time - last;
            if (diffrence.Days <= 30)
                throw new Exception("the interval time between the test must be at least 30 days");
            //info adding

            List<Tester> optionalTestersTime = Intime(test.Preferred_treinee_time);
            List<Tester> optionalTestersDistance = GetTesters(t => distance(t._Address, test.Preferred_treinee_address) < t.Max_range);
            if (optionalTestersDistance.Count == 0)
                throw new Exception("there isn't tester in this area");
            //create list of al the available testers
            var available = from t in optionalTestersTime
                            from d in optionalTestersDistance
                            where t.Id == d.Id
                            select t;
            //remove all the testers which have to many test
            available = from av in available
                        where av._Schedule.TestsInWeek(test.Preferred_treinee_time) < av.Max_tests_per_week
                        select av;
            if (available.Count() == 0)
                throw new Exception("there isn't tester in this time");


            //add the test
            try
            {
                available.First().AddTest(test.Preferred_treinee_time);
                test.Tester_id = available.First().Id;
                dal.AddTest(test);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddTester(Tester tester)
        {
            //calculte tester age -throw if tester age less then 40.
            DateTime tmp = tester.Birthdate;
            if (tmp.AddYears(40) > DateTime.Now)
                throw new Exception("Tester age is less then 40");
            try
            {
                dal.AddTester(tester);
            }
            catch
            {
                throw;
            }


        }

        public void AddTrainee(Trainee trainee)
        {
            //calculte trainee age - throw if trainee age is less then 18.
            DateTime tmp = trainee.Birthdate;
            if (tmp.AddYears(18) > DateTime.Now)
                throw new Exception("Trainee age is less then 18");
            try
            {
                dal.AddTrainee(trainee);
            }
            catch
            {
                throw;
            }

        }

        public Test GetTest(long id)
        {
            try
            {
                return dal.GetTest(id);
            }
            catch
            {
                throw;
            }
        }

        public Tester GetTester(string id)
        {
            try
            {

                return dal.GetTester(id);
            }
            catch
            {
                throw;
            }
        }

        public Trainee GetTrainee(string id)
        {
            try
            {
                var tmp = dal.GetTrainee(id);
                if (tmp.Id != id)
                    throw new Exception("somthing got wrong");
                return tmp;
            }
            catch
            {
                throw;
            }
        }

        public List<Tester> GetTesters(Predicate<Tester> condision = null)
        {
            return dal.GetTesters().FindAll(condision);
        }

        public List<Test> GetTests(Predicate<Test> condision = null)
        {
            return dal.GetTests().FindAll(condision);
        }


        public List<Trainee> GetTrainees(Predicate<Trainee> condision = null)
        {
            return dal.GetTrainees().FindAll(condision);
        }

        public void RemoveTester(Tester tester)
        {
            try
            {
                dal.RemoveTester(tester);
            }
            catch
            {
                throw;
            }
        }

        public void RemoveTester(string id)
        {
            try
            {
                dal.RemoveTester(id);
            }
            catch
            {
                throw;
            }
        }

        public void RemoveTrainee(Trainee trainee)
        {
            try
            {
                dal.RemoveTrainee(trainee);
            }
            catch
            {
                throw;
            }
        }

        public void RemoveTrainee(string id)
        {
            try
            {
                dal.RemoveTrainee(id);
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateTest(string tester_id, string trainee_id, int grade, string note)
        {
            try
            {
                if (grade > 100 || grade <= 0)
                    throw new Exception("Inapposite grade");
                if (note == null)
                    note = "nothing";
                //check if the tester or the trainee exist 
                Tester tester = dal.GetTester(tester_id);
                Trainee trainee = dal.GetTrainee(tester_id);
                if (tester == null || trainee == null)// (evethough that dal soppused to throw exception)
                    throw new Exception("there is no such ids in the system");
                //Find the test according 
                Test test = dal.GetTests().Find(t => trainee_id == t.Trainee_id && tester_id == t.Trainee_id);

                return dal.UpdateTest(test.Test_id, grade, note);
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateTester(Tester e)
        {
            Tester a = GetTesters().Find(t => e.Id == t.Id);
            if (a == null)
                return false;
            try
            {
                dal.RemoveTester(e);
                dal.AddTester(e);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateTrainee(Trainee e)
        {
            Trainee a = GetTrainees().Find(t => e.Id == t.Id);
            if (a == null)
                return false;
            try
            {
                dal.RemoveTrainee(e);
                dal.AddTrainee(e);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Tester> InRadius(Address address, float km)
        {
            try
            {
                return GetTesters(t => distance(address, t._Address) <= km);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Tester> Intime(DateTime time)
        {
            try
            {
                return GetTesters(t=>t.RightTime(time));
            }
            catch (Exception)
            {

                throw;
            }
        }
        // not in the inteface
        public IEnumerable<IGrouping<Vehicle, Tester>> GetTestersBySpeciality(bool sort = false)
        {
            try
            {
                if (sort)
                {
                    return from t in GetTesters()
                           orderby t.Speciality
                           group t by t.Speciality;
                }
                else
                {
                    return from t in GetTesters()
                           group t by t.Speciality;
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// return testers in groups by cities.
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        public IEnumerable<IGrouping<string,Tester>> GetTestersByLocation(bool sort = false)
        {
            try
            {
                if (sort)
                {
                    return from t in GetTesters()
                           orderby t._Address.City
                           group t by t._Address.City;
                }
                else
                {


                    return from t in GetTesters()
                           group t by t._Address.City;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
