using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using REA.Classes;

namespace REA
{
    public interface IEstate
    {
        //Define the variables
        int ID { get; set; }
        Address Address { get; set; }

        string ImagePath { get; set; }

        double Cost();
        //Cost of the estate function that could vary by different residental status.
    }

    public class Address
    {
        /* Properties of the class */
        string street;
        string zip;
        string city;
        Countries country;

        //Constructor that gets all the necessary data to create an object with a full Address
        public Address(string street, string zip, string city, Countries country)
        {
            this.street = street;
            this.zip = zip;
            this.city = city;
            this.country = country;
        }

        //Function to update the address on already created address object.
        public void update(string street, string zip, string city, Countries country)
        {
            this.street = street;
            this.zip = zip;
            this.city = city;
            this.country = country;
        }
        //Tostring methods that defines the format of the address
        public override string ToString()
        {
            return street + " " + zip + " " + city + " " + country.ToString();
        }
    }
}