﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    public class Rental : Appartment
    {
        //Default Constructor
        public Rental() { }

        //Constructor that gets the number of rooms.
        public Rental(int rooms)
        {
            NumberOfRooms = rooms;
        }

    }
}