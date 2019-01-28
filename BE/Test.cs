using System;

namespace BE
{
    public class Test
    {
       

        private long test_id;
        private string tester_id;
        private string trainee_id;
        private DateTime preferred_treinee_time;
       // private DateTime real_time;
        private Vehicle type;
        private Address preferred_treinee_address;
        private Address start_address;
        private Address end_Address;
        private int grade;// the diffult is _1_ 
        private string note;//the diffult is _null_

        public Test(string traineeId,Address address , DateTime date, long testId = -1)
        {
            trainee_id = traineeId;

            test_id = testId;
            Preferred_treinee_address = address;
            Preferred_treinee_time = date;
        }

        public Test(string trainee_id, DateTime preferred_treinee_time, Vehicle type, Address preferred_treinee_address, Address start_address = null, Address end_Address = null, string tester_id = null,int grade = -1,string note = null ,long test_id = -1)
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
                Grade = grade;
                Note = note;
                Test_id = test_id;
            }
            catch(Exception)
            { throw; }
        }

        public Test()
        {
            test_id =-1;
            tester_id = null;
            trainee_id = null;
            preferred_treinee_time = new DateTime(0);
            type = Vehicle.Private;
            preferred_treinee_address =new Address(null,0,null);
            start_address = new Address(null, 0, null);
            end_Address = new Address(null, 0, null);
            grade = -1;
            note = null;
        }

        public long Test_id { get => test_id; set => test_id = value; }
        public string Tester_id { get => tester_id; set => tester_id = value; }
        public string Trainee_id { get => trainee_id; set => trainee_id = value; }
        public DateTime Preferred_treinee_time { get => preferred_treinee_time; set => preferred_treinee_time = new DateTime(value.Year,value.Month,value.Day,value.Hour,value.Minute,value.Second); }
      //  public DateTime Real_time { get => real_time; set => real_time = value; }
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