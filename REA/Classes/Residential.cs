using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    //Enumerator that has all the available choices for residential estates
    public enum Residentials
    {
        Villa,
        Rental,
        Tenement,
        Townhouse
    }
    public class Residential : Estate
    {
        //private variable
        private int numberOfRooms;

        //Getters and Setters
        public int NumberOfRooms
        {
            get { return numberOfRooms; }
            set { numberOfRooms = value; }
        }

        //To string function that shows entries and their properties.
        public override string ToString()
        {
            return "(" + ID + ") " + this.GetType().Name + " - " + Address.ToString() + " Rooms: " + numberOfRooms; 
        }
    }
}