using System;

namespace BE
{
    public class Address
    {
        public Address()
        {
            city = null;
            street = null;
            building_number = -1;
        }

        public Address(string _street, int _building_number,string _city)
        {
            city = _city;
            street = _street;
            building_number = _building_number;

        }
        public override string ToString()
        {
            return city + "!" + street + "!" + building_number.ToString() + "!";
        }

        string city;
        string street;
        int building_number;
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public int Building_number { get => building_number; set => building_number = value; }
    }
}
