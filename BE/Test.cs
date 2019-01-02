using System;

namespace BE
{
    public class Test
    {
       

        private long test_id;
        private string tester_id;
        private string trainee_id;
        private DateTime preferred_treinee_time;
        private DateTime real_time;
        private Vehicle type;
        private Address preferred_treinee_address;
        private Address start_address;
        private Address end_Address;
        private int grade;// the diffult is _1_ 
        private string note;//the diffult is _null_

        public Test(string trainee_id, DateTime preferred_treinee_time, Vehicle type, Address preferred_treinee_address, Address start_address = null, Address end_Address = null, string tester_id = null)
        {
            try
            {

                test_id = -1;//defulf 
                Tester_id = tester_id;
                Trainee_id = trainee_id;
                Preferred_treinee_time = preferred_treinee_time;
                Type = type;
                Start_address = start_address;
                Preferred_treinee_address = preferred_treinee_address;
                End_Address = end_Address;
                grade = -1;
            }
            catch(Exception)
            { throw; }
        }
       /* public Test(Test test)
        {
            try
            {

               
                test_id = test.test_id;
                Tester_id = test.tester_id;
                Trainee_id = test.trainee_id;
                Preferred_treinee_time = test.preferred_treinee_time;
                Type = test.type;
                Start_address = test.start_address;
                Preferred_treinee_address = test.preferred_treinee_address;
                End_Address = test.end_Address;
                grade = test.grade;
                note = test.note;
            }
            catch (Exception)
            { throw; }
        }*/
        public long Test_id { get => test_id; set => test_id = value; }
        public string Tester_id { get => tester_id; set => tester_id = value; }
        public string Trainee_id { get => trainee_id; set => trainee_id = value; }
        public DateTime Preferred_treinee_time { get => preferred_treinee_time; set => preferred_treinee_time = value; }
        public DateTime Real_time { get => real_time; set => real_time = value; }
        public Vehicle Type { get => type; set => type = value; }
        public Address Start_address { get => start_address; set => start_address = value; }
        public Address Preferred_treinee_address { get => preferred_treinee_address; set => preferred_treinee_address = value; }
        public Address End_Address { get => end_Address; set => end_Address = value; }
        public int Grade { get => grade; set => grade = value; }
        public string Note { get => note; set => note = value; }

        public void EndTest(int grade, string note)//update the grade and the note after the test
        {
            Grade = grade;
            Note = note;
        }
        public override string ToString()
        {
            return "trainee id: " + trainee_id + " grade: " + Grade + " note: " + note;
        }
    }
}