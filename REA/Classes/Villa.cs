using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    [Serializable]
    public class Villa : Residential
    {
        //Default constructor
        public Villa() { }

        //Constructor that gets the number of rooms in the estate
        public Villa(int rooms)
        {
            NumberOfRooms = rooms;
        }
    }
}