using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    public class University : Institutional
    {
        //Default constructor
        public University() { }

        //Constructor that gets the study field as a property
        public University(StudyField sf)
        {
            StudyField = sf;
        }
    }
}