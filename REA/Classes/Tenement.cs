using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    [Serializable]
    public class Tenement : Appartment
    {
        //Default constructor
        public Tenement() { }

        //Constructor that gets the number of rooms in the estate
        public Tenement(int rooms)
        {
            NumberOfRooms = rooms;
        }
    }
}