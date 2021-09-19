using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    //Enumerator with available choices for comercial estates
    public enum Comercials
    {
        Shop,
        Warehouse
    }

    //An enumerator that declares what type of Shop/Warehouse it is.
    public enum ShopType
    {
        electronic,
        food,
        bike,
    }

    public abstract class Commercial : Estate
    {
        //Define private variables
        private ShopType shopType;
        private int size;

        //Getters and Setters
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

        public override double Cost()
        {
            //Completly basic calculation based on size and fixed value
            int fixedCost = 15000;
            double cost = fixedCost + (size * 25);

            return cost;
        }

        public override string ToString()
        {
            return "(" + ID + ") " + this.GetType().Name + " - " + Address.ToString() + " Size: " + size + "m^2 Type: " + shopType.ToString();
        }


    }
}