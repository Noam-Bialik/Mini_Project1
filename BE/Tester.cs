using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
   public class Tester : Person
    {
        private int experience;//how many years of experience the tester has 
        private int max_tests_per_week;
        private Vehicle speciality;
        private bool[][] schedule;
        private double max_range;

        public int Experience { get => experience; set => experience = value; }
        public int Max_tests_per_week { get => max_tests_per_week; set => max_tests_per_week = value; }
        public bool[][] Schedule
        {
            get => schedule;
            set
            {
                //check if the value in the correct size
                bool correct_size = true;
                if (value.Length == 5)
                {
                    for (int i = 0; i < 5; i++)
                        if (value[i].Length != 7)
                        {
                            correct_size = false;
                            break;
                        }
                }
                else
                    correct_size = false;
                if (!correct_size)
                    throw new Exception("the array dont on the right size it should have from the shape bool[5][7]");

                //if the input correct we copy it 
                copy_schedule(value);

            }
        }
        public double Max_range { get => max_range; set => max_range = value; }
        public Vehicle Speciality { get => speciality; set => speciality = value; }

        private void copy_schedule(bool[][] value)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 7; j++)
                    schedule[i][j] = value[i][j];
        }
     
        public Tester(string id, string first_name, string last_name, DateTime birthdate, Gender gender, string phone_number, Address address, int experience, int max_tests_per_week, double max_range, Vehicle speciality, bool[][] schedule = null) : base(id, first_name, last_name, birthdate, gender, phone_number, address)
        {
            //create schedule array
            this.schedule = new bool[5][];
            for (int i = 0; i < 5; i++)
            {
                this.schedule[i] = new bool[7];
                for (int j = 0; j < 7; j++)
                    this.schedule[i][j] = false;
            }
            //try to initialize the variables
            try
            {
                Experience = experience;
                Max_tests_per_week = max_tests_per_week;
                Max_range = max_range;
                Speciality = speciality;
                Phone_number = phone_number;
                if (schedule != null)
                    Schedule = schedule;
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        public void copy(Tester c)//copy c to the object unless the id
        {
            //copy all the person's attributes
            base.copy(c);
            Experience = c.Experience;
            Max_tests_per_week = c.Max_tests_per_week;
            copy_schedule(c.Schedule);
            Max_range = c.Max_range;
            Speciality = c.Speciality;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
