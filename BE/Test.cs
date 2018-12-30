using System;

namespace BE
{
    public class Test
    {
       

        private static int test_number = 0;
        private int test_id;
        private string tester_id;
        private string trainee_id;
        private DateTime preferred_treinee_time;
        private Vehicle type;
        private Address preferred_treinee_address;
        private Address start_address;
        private Address end_Address;
        private int grade;
        private string note;

        public Test( string tester_id, string trainee_id, DateTime preferred_treinee_time, Vehicle type, Address start_address, Address preferred_treinee_address, Address end_Address, int grade, string note)
        {
            try
            {

                test_number++;
                test_id = test_number.GetHashCode();
                Tester_id = tester_id;
                Trainee_id = trainee_id;
                Preferred_treinee_time = preferred_treinee_time;
                Type = type;
                Start_address = start_address;
                Preferred_treinee_address = preferred_treinee_address;
                End_Address = end_Address;
                Grade = grade;
                Note = note;
            }
            catch(Exception)
            { throw; }
        }
        public int Test_id { get => test_id; }
        public string Tester_id { get => tester_id; set => tester_id = value; }
        public string Trainee_id { get => trainee_id; set => trainee_id = value; }
        public DateTime Preferred_treinee_time { get => preferred_treinee_time; set => preferred_treinee_time = value; }
        public Vehicle Type { get => type; set => type = value; }
        public Address Start_address { get => start_address; set => start_address = value; }
        public Address Preferred_treinee_address { get => preferred_treinee_address; set => preferred_treinee_address = value; }
        public Address End_Address { get => end_Address; set => end_Address = value; }
        public int Grade { get => grade; set => grade = value; }
        public string Note { get => note; set => note = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}