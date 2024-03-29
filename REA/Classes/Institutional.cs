﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    //enumerator used for the available types of institutional estates
    public enum Institutionals
    {
        School,
        University
    }

    //Enumerator for the combobox of study to define all the available study fields
    public enum StudyField
    {
        computer_science,
        teaching,
        engineering,
    }

    public class Institutional : Estate
    {
        //Private variables of the class
        private StudyField studyField;

        //Getters and Setters
        public StudyField StudyField
        {
            get { return studyField; }
            set { studyField = value; }
        }

        public override double Cost()
        {
            //Completly basic calculation based on fixed value * (index of enum + 1)
            int fixedCost = 15000;
            int index = Array.IndexOf(Enum.GetValues(StudyField.GetType()), studyField) + 1;
            double cost = fixedCost + (5000*index);

            return cost;
        }

        public override string ToString()
        {
            return "(" + ID + ") " + this.GetType().Name + " - " + Address.ToString() + " Study Field: " + studyField.ToString();
        }
    }
}