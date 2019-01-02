using System;

namespace BE
{
    public class Person
    {

        private string id;
        private string first_name;
        private string last_name;
        private DateTime birthdate;
        private Gender gender;
        private string phone_number;
        private Address address;

        public string Id { get => id; set => id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public DateTime Birthdate
        {
            get => birthdate;
            set
            {
                birthdate = new DateTime(value.Year, value.Month, value.Day);
            }
        }
        public Gender _Gender { get => gender; set => gender = value; }
        public string Phone_number
        {
            get => phone_number;
            set
            {
                if (value.Length != 10)
                    throw new Exception("the phone number must have 10 digits");
                //check if all the string is letters
                foreach (var letter in value.ToCharArray())
                    if (letter < '0' || letter > '9')
                        throw new Exception("the number must contain only digits");
                phone_number = value;
            }
        }
        public Address _Address { get => address; set => address = value; }

        public Person(string id, string first_name, string last_name, DateTime birthdate, Gender gender, string phone_number, Address address)
        {
            Id = id;
            First_name = first_name;
            Last_name = last_name;
            Birthdate = birthdate;
            _Gender = gender;
            Phone_number = phone_number;
            _Address = address;
        }
        public void copy(Person c)//copy c to the object unless the id
        {
            First_name = c.First_name;
            Last_name = c.Last_name;
            Birthdate = c.Birthdate;
            _Gender = c._Gender;
            Phone_number = c.Phone_number;
            _Address = c._Address;
        }
        public override string ToString()
        {
            return "id: " + Id + "first name: " + First_name + "last name: " + Last_name;
        }
    }
}