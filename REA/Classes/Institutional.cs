using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    public enum Institutionals
    {
        School,
        University
    }

    public enum StudyField
    {
        computer_science,
        teaching,
        engineering,
    }

    public class Institutional : Estate
    {
        private StudyField studyField;

        public Institutional() { }

        public Institutional(StudyField sf)
        {
            studyField = sf;
        }

        public StudyField StudyField
        {
            get { return studyField; }
            set { studyField = value; }
        }
    }
}