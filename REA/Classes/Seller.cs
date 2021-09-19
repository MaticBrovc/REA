using REA.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REA
{
    public class Seller : Person
    {
        private EstateManager estatesForSale = new EstateManager();

        public Seller() { }

        public void Sell(Estate e) {
            estatesForSale.Add(e);
        }




    }
}