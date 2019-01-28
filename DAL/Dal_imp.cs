using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    internal class Dal_imp : Idal
    {

        //add functions
        public void AddTest(Test test)
        {
            if (test.Test_id == -1)
            {
                //initialize test id
                if (DS.DS.Tests.Count == 0)
                    test.Test_id = 0;
                else
                {
                    //looking the smallest free id 
                    var ids = from i in DS.DS.Tests
                            orderby i.Test_id
                            select i.Test_id;
                    long[] ids1 = ids.ToArray();

                    for (long i = 0; i < ids1.Length; i++)
                    {
                        if(ids1[i] != i)
                        {
                            test.Test_id = i;
                            break;
                        }
                    }
                }

            }
            else
            {
                //check if exist test with the same id
                Test help = DS.DS.Tests.Find(t => t.Test_id == test.Test_id);
                if (help != null)
                    throw new Exception("test with the same id already exist");
            }

            //if the id don't exist add the test
            DS.DS.Tests.Add(test);
        }
        public void AddTester(Tester tester)
        {
            //check if exist tester with the same id
            Tester help = DS.DS.Testers.Find(t => t.Id == tester.Id);
            if (help != null)
                throw new Exception("tester with the same id already exist");

            //if the id don't exist add the test
            DS.DS.Testers.Add(tester);
        }
        public void AddTrainee(Trainee trainee)
        {
            //check if exist trainee with the same id
            Trainee help = DS.DS.Trainees.Find(t => t.Id == trainee.Id);
            if (help != null)
                throw new Exception("trainee with the same id already exist");

            //if the id don't exist add the test
            DS.DS.Trainees.Add(trainee);
        }

        //get functions
        public Test GetTest(long id)
        {
            //looking for test with the same id
            Test ret = DS.DS.Tests.Find(t => t.Test_id == id);
            //throw Exception if the id wasn't found
            if (ret == null)
                throw new Exception("test with the same id dosent exist");

            return ret;
        }
        public Tester GetTester(string id)
        {
            //looking for tester with the same id
            Tester ret = DS.DS.Testers.Find(t => t.Id == id);
            //throw Exception if the id wasn't found
            if (ret == null)
                throw new Exception("tester with the same id dosent exist");

            return ret;
        }
        public Trainee GetTrainee(string id)
        {
            //looking for trainee with the same id
            Trainee ret = DS.DS.Trainees.Find(t => t.Id == id);
            //throw Exception if the id wasn't found
            if (ret == null)
                throw new Exception("trainee with the same id dosent exist");

            return ret;
        }
        /// <summary>
        /// return the list that in DAL (and not more)
        /// </summary>
        /// <returns></returns>
        public List<Tester> GetTesters()
        {
           
            return new List<Tester>(DS.DS.Testers);
        }
        /// <summary>
        /// return the list that in DAL (and not more)
        /// </summary>
        /// <returns></returns>
        public List<Test> GetTests()
        {
            return new List<Test>(DS.DS.Tests);
        }
        /// <summary>
        /// return the list that in DAL (and not more)
        /// </summary>
        /// <returns></returns>
        public List<Trainee> GetTrainees()
        {
            return DS.DS.Trainees;
        }

        /// <summary>
        /// return true if removed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void RemoveTrainee(string id)
        {
            int help = DS.DS.Trainees.RemoveAll(tester => id == tester.Id);
            if (help == 0)
                throw new Exception("the trainee not exist");
        }
        /// <summary>
        /// return true if removed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void RemoveTrainee(Trainee trainee)
        {
            bool help = DS.DS.Trainees.Remove(trainee);
            if (help == false)
                throw new Exception("the trainee not exist");
        }
        /// <summary>
        /// return true if removed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void RemoveTester(Tester tester)
        {
            bool help = DS.DS.Testers.Remove(tester);
            if (help == false)
                throw new Exception("the tester not exist");
        }
        /// <summary>
        /// return true if removed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void RemoveTester(string id)
        {
            int help = DS.DS.Testers.RemoveAll(tester => tester.Id == id);
            if (help == 0)
                throw new Exception("the tester not exist");
        }



        //update function
        public bool UpdateTest(long test_id, int grade, string note)
        {
            Test help = DS.DS.Tests.Find(t => t.Test_id == test_id);
            if (help == null)
                return false;
            help.EndTest(grade, note);
            return true;
        }
        public bool UpdateTester(Tester e)
        {
            //search the tester
            Tester help = DS.DS.Testers.Find(t => t.Id == e.Id);
            if (help == null)
                return false;
            //if the tester was found copy him
            help.copy(e);
            return true;
        }
        public bool UpdateTrainee(Trainee e)
        {
            //search the trainee
            Trainee help = DS.DS.Trainees.Find(t => t.Id == e.Id);
            if (help == null)
                return false;
            //if the trainee was found copy him
            help.copy(e);
            return true;
        }

       
    }
}
