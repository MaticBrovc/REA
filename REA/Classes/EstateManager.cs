using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REA.Classes
{
    class EstateManager
    {
        //Creates new list of estates
        private List<Estate> estates_list;

        //default constructor
        public EstateManager()
        {
            estates_list = new List<Estate>();
        }

        //Function that empties all the entries(makes a new list)
        public void Empty()
        {
            estates_list = new List<Estate>();
        }

        //Function to add a new estate
        public void Add(Estate e)
        {
            estates_list.Add(e);
        }

        //function that returns all the values in their string form
        public string[] GetValues()
        {
            string[] values = new string[estates_list.Count];
            for(int i = 0; i < values.Length; i++)
            {
                values[i] = estates_list[i].ToString();
            }
            return values;
        }

        //function that returns the last created object
        public Estate getLastEntry()
        {
            if(estates_list.Count > 0)
            {
                return estates_list[estates_list.Count - 1];
            }
            return null;
        }
        //function that updates the last entry
        public void updateLast(Estate e)
        {
            if (estates_list.Count > 0)
            {
                estates_list[estates_list.Count - 1] = e;
            }
        }

        //function that deletes the last(current) object and returns if deleted or not.
        public bool deleteCurrent()
        {
            //To prevent exception(check if there is any entries)
            if (estates_list.Any())
            {
                //remove the last element
                estates_list.RemoveAt(estates_list.Count - 1);
                return true;
            }
            return false;
        }
    }
}
