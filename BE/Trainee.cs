using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Trainee : Person
    {

        private Vehicle speciality;
        private Gearbox gearbox;
        private string school_name;
        private string teacher_name;
        private int lessons_count;

        public Vehicle _Speciality { get => speciality; set => speciality = value; }
        public Gearbox _Gearbox { get => gearbox; set => gearbox = value; }
        public string School_name { get => school_name; set => school_name = value; }
        public string Teacher_name { get => teacher_name; set => teacher_name = value; }
        public int Lessons_count
        {
            get => lessons_count;
            set
            {
                if (value >= 0)
                    lessons_count = value;
                else
                    throw new Exception("the trainee can't do a negative number of lessons");
            }
        }

        public Trainee(string id, string first_name, string last_name, DateTime birthdate, Gender gender, string phone_number, Address address, Vehicle speciality, Gearbox gearbox, string school_name, string teacher_name, int lessons_count) : base(id, first_name, last_name, birthdate, gender, phone_number, address)
        {
            _Speciality = speciality;
            _Gearbox = gearbox;
            School_name = school_name;
            Teacher_name = teacher_name;
            Lessons_count = lessons_count;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
