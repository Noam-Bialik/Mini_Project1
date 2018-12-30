using System;

namespace BE
{
    public class Address
    {
        string city;
        string street;
        int building_number;
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public int Building_number { get => building_number; set => building_number = value; }
    }
}
