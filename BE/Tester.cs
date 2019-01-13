using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace BE
{
    
   public class Tester : Person
    {
        private int experience;//how many years of experience the tester have 
        private int max_tests_per_week;
        private Vehicle speciality;
        private double max_range;
        private Schedule schedule; 
        public int Experience { get => experience; set => experience = value; }
        public int Max_tests_per_week { get => max_tests_per_week; set => max_tests_per_week = value; }
        public double Max_range { get => max_range; set => max_range = value; }
        public Vehicle Speciality { get => speciality; set => speciality = value; }
        public Schedule _Schedule { get => schedule; set => schedule = new Schedule(value); }

        public Tester(string id, string first_name, string last_name, DateTime birthdate, Gender Gender, string phone_number, Address address, int experience, int max_tests_per_week, double max_range, Vehicle speciality, bool[][] schedule) : base(id, first_name, last_name, birthdate, Gender, phone_number, address)
        {

            //try to initialize the variables
            try
            {
                this.schedule = new Schedule(schedule);
                Experience = experience;
                Max_tests_per_week = max_tests_per_week;
                Max_range = max_range;
                Speciality = speciality;
                Phone_number = phone_number;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AddTest(DateTime d)
        {
            schedule.AddTest(d);
        }
        public void copy(Tester c)//copy c to the object exept the id
        {
            //copy all the person's attributes
            base.copy(c);
            Experience = c.Experience;
            Max_tests_per_week = c.Max_tests_per_week;
            _Schedule = c._Schedule;
            Max_range = c.Max_range;
            Speciality = c.Speciality;
        }
        public bool RightTime(DateTime d)
        {
            return schedule.RightTime(d);
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
