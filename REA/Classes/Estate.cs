using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    public enum Estates
    {
        Residential,
        Commercial,
        Institutional
    }


    public abstract class Estate : IEstate
    {
        private int t_ID;

        private Address t_address;

        public int ID
        {
            get { return t_ID; }
            set { t_ID = value; }
        }
        public Address Address
        {
            get { return t_address; }
            set { t_address = value; }
        }

        public Estate() { }

        public Estate(int id, Address a)
        {
            t_ID = id;
            t_address = a;
        }


        public double Cost()
        {
            throw new NotImplementedException();
        }

        public string getAddress()
        {
            return t_address.ToString();
        }

        public override string ToString()
        {
            return "" + ID + " " + t_address.ToString();
        }
    }
}