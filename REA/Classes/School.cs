﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    public class School : Institutional
    {
        //Default constructor
        public School() { }

        //Constructor that gets the study field as a property
        public School(StudyField sf)
        {
            StudyField = sf;
        }
    }
}