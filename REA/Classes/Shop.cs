﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    public class Shop : Commercial
    {
        //default constructor
        public Shop() { }

        //constructor that gets the Shop/warehouse type and its size
        public Shop(ShopType st, int s)
        {
            ShopType = st;
            Size = s;
        }

    }
}