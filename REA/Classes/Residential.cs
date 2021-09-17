using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    public enum Residentials
    {
        Villa,
        Rental,
        Tenement,
        Townhouse
    }
    public class Residential : Estate
    {
        private int numberOfRooms;

        public Residential() { }

        public Residential(int nr)
        {
            numberOfRooms = nr;
        }

        public int NumberOfRooms
        {
            get { return numberOfRooms; }
            set { numberOfRooms = value; }
        }
    }
}