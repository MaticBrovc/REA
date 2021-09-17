using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REA.Classes
{
    class EstateManager
    {
        private List<Estate> estates_list;

        public EstateManager()
        {
            estates_list = new List<Estate>();
        }

        public void Empty()
        {
            estates_list = new List<Estate>();
        }

        public void Add(Estate e)
        {
            estates_list.Add(e);
        }

        public string[] GetValues()
        {
            string[] values = new string[estates_list.Count];
            for(int i = 0; i < values.Length; i++)
            {
                values[i] = estates_list[i].ToString();
            }
            return values;
        }
    }
}
