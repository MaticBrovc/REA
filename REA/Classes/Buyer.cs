using REA.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    public class Buyer : Person
    {

        private EstateManager boughtEstates = new EstateManager();

        public Buyer() { }

        public void Buy(Estate e)
        {
            boughtEstates.Add(e);
        }
    }
}