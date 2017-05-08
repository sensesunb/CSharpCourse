using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    public class Menu
    {
        public List<Coffee> Options;

        public Menu()
        {
            Options = new List<Coffee>();
        }

        public void Add(Coffee coffee)
        {
            Options.Add(coffee);
        }
    }
}
