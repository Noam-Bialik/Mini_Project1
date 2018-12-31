using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    public class Dal_imp : Idal
    {
        //add functions
        public void AddTest(Test test)
        {
            //check if exist test with the same id
            Test help = DS.DS.Tests.Find(t => t.Test_id == test.Test_id);
            if (help != null)
                throw new Exception("test with the same id already exist");

            //if the id don't exist add the test
            DS.DS.Tests.Add(test);
        }
        public void AddTester(Tester tester)
        {
            //check if exist tester with the same id
            Tester help = DS.DS.Testers.Find(t => t.Id == tester.Id);
            if (help != null)
                throw new Exception("test with the same id already exist");

            //if the id don't exist add the test
            DS.DS.Testers.Add(tester);
        }
        public void AddTrainee(Trainee trainee)
        {
            //check if exist trainee with the same id
            Trainee help = DS.DS.Trainees.Find(t => t.Id == trainee.Id);
            if (help != null)
                throw new Exception("test with the same id already exist");

            //if the id don't exist add the test
            DS.DS.Trainees.Add(trainee);
        }

        //get functions
        public Test GetTest(int id)
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
        public bool RemoveTrainee(string id)
        {
            int help = DS.DS.Trainees.RemoveAll(tester => id == tester.Id);
            return help == 1;
        }
        /// <summary>
        /// return true if removed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveTrainee(Trainee trainee)
        {
            return DS.DS.Trainees.Remove(trainee);
        }
        /// <summary>
        /// return true if removed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveTester(Tester tester)
        {
         return DS.DS.Testers.Remove(tester);
        }
        /// <summary>
        /// return true if removed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveTester(string id)
        {

            DS.DS.Testers.RemoveAll(tester=>  tester.Id == id );
            return false;
        }

  

        //update function
        public bool UpdateTest(int test_id, int grade, string note)
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
