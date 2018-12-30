﻿using System;

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
        public string Phone_number { get => phone_number; set => phone_number = value; }
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
        public virtual string ToString()
        {
            return "id: " + Id + "first name: " + First_name + "last name: " + Last_name;
        }
    }
}