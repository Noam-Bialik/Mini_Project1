using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public interface Idal
    {
        
        bool AddTester(Tester tester);// add the tester just if dont exist Tester with the same ID
        Tester RemoveTester(Tester tester);//remove (Tester) and return the removed.
        Tester RmoveTester(string id); //remove (id) and return the removed.
        Tester GetTester(string id);//return the Tester with out removing.
        bool UpdateTester(Tester e);//return true if succeed.

        bool AddTrainee(Trainee trainee);//add the trainee just if dont exist with the same ID.
        Trainee RemoveTrainee(Trainee trainee);//Remove (by Trainee) and return the removed.
        Trainee removeTrainee(string id);// Remove (by id) and return the removed;
        Trainee GetTrainee(string id);//return the Trainee with out removing.
        bool UpdateTrainee(Trainee e);//return true if succeed.


        bool AddTest(Test test); // Add test after cheking. 
        Test GetTest(int id);//return the Test with out removing.
        bool UpdateTest(Test e);//return true if succeed.


        List<Tester> GetTesters();// return list of all Testers.
        List<Trainee> GetTrainees();//return list of all Trainees.
        List<Test> GetTests();//return list of all Tests/



    }
}
