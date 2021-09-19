using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    public abstract class Person
    {
        private string fname;

        private string lname;

        public string FName
        {
            get { return fname; }
            set { fname = value; }
        }

        public string LName
        {
            get { return lname; }
            set { lname = value; }
        }

    }
}