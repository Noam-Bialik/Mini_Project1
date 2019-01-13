using System;
using System.Collections.Generic;
using BE;
using System.Linq;
namespace BL
{
    public interface Ibl
    {

        void AddTester(Tester tester);// add the tester just if dont exist Tester with the same ID
        void  RemoveTester(Tester tester);//remove (Tester) and return the removed.
        void RemoveTester(string id); //remove (id) and return the removed.    
        Tester GetTester(string id);//return the Tester with out removing.
        bool UpdateTester(Tester e);//update the Tester with the same id return true if succeed.

        void AddTrainee(Trainee trainee);//add the trainee just if dont exist with the same ID.
        void RemoveTrainee(Trainee trainee);//Remove (by Trainee) and return the removed.
        void RemoveTrainee(string id);// Remove (by id) and return the removed;
        Trainee GetTrainee(string id);//return the Trainee with out removing.
        bool UpdateTrainee(Trainee e);//update the Trainee with the same id return true if succeed.


        void AddTest(Test test); // Add test after cheking. 
        Test GetTest(long id);//return the Test with out removing.
        bool UpdateTest(string tester_id,string trainee_id, int grade, string note);//update the test after the test with the same id return true if succeed.


        List<Tester> GetTesters(Predicate<Tester> condision = null);// return list of all Testers.
        List<Trainee> GetTrainees(Predicate<Trainee> condision = null);//return list of all Trainees.
        List<Test> GetTests(Predicate<Test> condision = null);//return list of all Tests.


         List<Tester> InRadius(Address address, float km);//return list of testers that far more then "km".
         List<Tester> Intime(DateTime time);//return list of all testers that free in that time.
         IEnumerable<IGrouping<Vehicle, Tester>> GetTestersBySpeciality(bool sort = false);//return testers in grups by spaciality.
        IEnumerable<IGrouping<string, Tester>> GetTestersByLocation(bool sort = false);//return testers in groups by cities.

    }
}
