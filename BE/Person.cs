﻿using System;

namespace BE
{
    public class Person
    {

        private string id;
        private string first_name;
        private string last_name;
        private DateTime birthdate;
        private Gender Gender;
        private string phone_number;
        private Address address;

        public string Id
        {
            get => id;
            set
            {
                /*if (value.Length == 9)
                    throw new Exception("the id must be 9 digits");
                try
                {
                    int.Parse(value);
                }
                catch (Exception)
                {
                    throw new Exception("the id must contain only digits");
                }
                int sum = 0;
                int counter = 1;
                foreach (var item in value)
                {
                    sum += (item - '0') * counter;
                    if (counter == 1)
                        counter = 2;
                    if (counter == 2)
                        counter = 1;
                }
                if (sum % 10 != 0)
                    throw new Exception("the id wrong");*/
                //correct id
                id = value;
            }
        }
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
        public Gender _Gender { get => Gender; set => Gender = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }        
        public Address _Address { get => address; set => address = value; }


        public Person(string id, string first_name, string last_name, DateTime birthdate, Gender Gender, string phone_number, Address address)
        {
            Id = id;
            First_name = first_name;
            Last_name = last_name;
            Birthdate = birthdate;
            _Gender = Gender;
            Phone_number = phone_number;
            _Address = address;
        }
        public Person(Person e)
        {
            Id = e.Id;
            copy(e);
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
            return "id: " + Id + " first name: " + First_name + " last name: " + Last_name;
        }
    }
}