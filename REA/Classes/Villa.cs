using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    public class Villa : Residential
    {
        public Villa() { }

        public Villa(int rooms)
        {
            NumberOfRooms = rooms;
        }
    }
}