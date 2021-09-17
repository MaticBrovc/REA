using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    public enum Comercials
    {
        Shop,
        Warehouse
    }

    public enum ShopType
    {
        electronic,
        food,
        bike,
    }

    public class Commercial : Estate
    {
        private ShopType shopType;
        private int size;

        public Commercial() { }

        public ShopType ShopType
        {
            get { return shopType; }
            set { shopType = value; }
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public Commercial(ShopType st, int s)
        {
            shopType = st;
            size = s;
        }
    }
}