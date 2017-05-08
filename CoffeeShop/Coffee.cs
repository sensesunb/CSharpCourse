using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    public class Coffee
    {
        public string Name { get; private set; }
        public double Price { get; private set; }

        public Coffee(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
