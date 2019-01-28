using System;
using System.Collections.Generic;
using BE;
using DAL;
using System.Linq;
using System.Net;
using System.Xml;
using System.IO;

namespace BL
{


    internal class Bl_imp : Ibl
    {
        private Idal dal;
        public Bl_imp()
        {
            dal = FactoryDal.GetInstance();
        }
        private double distance(Address a, Address b)//distance in km
        {
            return CalcDistance(a.City,a.Street,a.Building_number,b.City,b.Street,b.Building_number);
        }
        public static double CalcDistance(string city1, string street1, int num1, string city2, string street2, int num2)
        {
            string firstAddress = street1 + " " + num1 + " st. " + city1 + " ci. Israel";
            string secondAddresss = street2 + " " + num2 + " st. " + city2 + " ci. Israel";
            string KEY = @"SCQY2qj4j3aaF5jfdfTHydqPIGvh1MFt";
            string url = @"https://www.mapquestapi.com/directions/v2/route" +
             @"?key=" + KEY +
             @"&from=" + firstAddress +
             @"&to=" + secondAddresss +
             @"&outFormat=xml" +
             @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
             @"&enhancedNarrative=false&avoidTimedConditions=false";
            //request from MapQuest service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            //we have the expected answer
            {
                //display the returned distance
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);
                return (distInMiles * 1.609344);
            }
            else/* if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")*/
            //we have an answer that an error occurred, one of the addresses is not found busy network or other error...
            {
                return 5;
            }
        }

        public void AddTest(Test test)
        {
            if (test.Trainee_id == null || test.Preferred_treinee_time == null || test.Preferred_treinee_address == null)
            {
                throw new Exception("missing details");
            }
            //check the hours
            DayOfWeek day = test.Preferred_treinee_time.DayOfWeek;
            int hour = test.Preferred_treinee_time.Hour;
            if ((int)day < 0 || (int)day > 4)
                throw new Exception("the day must be between sunday to thursday");
            hour -= 9;
            if (hour < 0 || hour > 5)
                throw new Exception("the hour must be between 9:00 to 14:00");
            string id = test.Trainee_id;
            //find the diffrence between the last test and the preferred treinee time
            var a = from t in GetTests(t => t.Trainee_id == id)
                    select t.Preferred_treinee_time;
            if (a.Count() != 0)
            {
                DateTime last = a.Max();
                TimeSpan diffrence = test.Preferred_treinee_time - last;
                if (last >= DateTime.Now)
                    throw new Exception("alredy have a test");
                if (diffrence.Days <= 30)
                    throw new Exception("the interval time between the test must be at least 30 days");
            }
            //info adding

            List<Tester> optionalTestersTime = Intime(test.Preferred_treinee_time);
            List<Tester> optionalTestersDistance = GetTesters(t => distance(t._Address, test.Preferred_treinee_address) < t.Max_range);
            if (optionalTestersDistance.Count == 0)
                throw new Exception("there isn't tester in this area");
            //create list of al the available testers
            var available = (from t in optionalTestersTime
                             from d in optionalTestersDistance
                             where t.Id == d.Id
                             select t).ToList();
            if (available == null || available.Count() == 0)
                throw new Exception("there isn't tester in this place and time");

            //remove all the testers which have to many test
            available = (from av in available
                         where av._Schedule.TestsInWeek(test.Preferred_treinee_time) < av.Max_tests_per_week
                         select av).ToList();
            if (available == null || available.Count() == 0)
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
            catch(Exception e)
            {
                throw e;
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

        public List<Tester> GetTesters(Predicate<Tester> condition = null)
        {
            List<Tester> ret = dal.GetTesters();
            if (condition == null)
                return ret;
            try
            {
                return ret.FindAll(condition);
            }
            catch (Exception)
            {

                return new List<Tester>();
            }
        }

        public List<Test> GetTests(Predicate<Test> condition = null)
        {
            List<Test> ret = dal.GetTests();
            if (condition == null)
                return ret;
            try
            {
                return ret.FindAll(condition);
            }
            catch (Exception)
            {

                return new List<Test>();
            }
        }

        public List<Trainee> GetTrainees(Predicate<Trainee> condition = null)
        {
            List<Trainee> ret = dal.GetTrainees();
            if (condition == null)
                return ret;
            try
            {
                return ret.FindAll(condition);
            }
            catch (Exception)
            {

                return new List<Trainee>();
            }
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

        public bool UpdateTest(long test_id, int grade, string note)
        {
            try
            {
                if (grade > 100 || grade <= 0)
                    throw new Exception("Inapposite grade");
                if (note == null)
                    note = "nothing";
                //check if the tester or the trainee exist 
                return dal.UpdateTest(test_id, grade, note);
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
        /// <summary>
        /// return testers in grups by spaciality
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
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
