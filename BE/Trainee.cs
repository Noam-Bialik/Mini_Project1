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

        public Trainee(string id, string first_name, string last_name, DateTime birthdate, Gender Gender, string phone_number, Address address, Vehicle speciality, Gearbox gearbox, string school_name, string teacher_name, int lessons_count) : base(id, first_name, last_name, birthdate, Gender, phone_number, address)
        {
            _Speciality = speciality;
            _Gearbox = gearbox;
            School_name = school_name;
            Teacher_name = teacher_name;
            Lessons_count = lessons_count;
        }
        public Trainee(Trainee source):base(source)
        {
            copy(source);
        }

        public Trainee()
        {
           speciality = Vehicle.Private;
            gearbox = Gearbox.Automaton;
           school_name = null;
           teacher_name =null;
           lessons_count = -1;
        }

        public void copy(Trainee c)//copy c to the object unless the id
        {
            //copy all the person's attributes
            base.copy(c);
            _Speciality = c._Speciality;
            _Gearbox = c._Gearbox;
            School_name = c.School_name;
            Teacher_name = c.Teacher_name;
            Lessons_count = c.Lessons_count;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
