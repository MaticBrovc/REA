using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    //Enumerator used for comboboxes and easier navigation through them
    public enum Estates
    {
        Residential,
        Commercial,
        Institutional
    }


    public abstract class Estate : IEstate
    {
        //Define private variables from the Interface
        private int t_ID;

        private Address t_address;

        private string t_imagePath;

        //Getters and Setters for the variables
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

        public string ImagePath
        {
            get { return t_imagePath; }
            set { t_imagePath = value; }
        }

        //Function that will be implemented in other clases
        public double Cost()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "(" +ID + ") " +  t_address.ToString();
        }
    }
}