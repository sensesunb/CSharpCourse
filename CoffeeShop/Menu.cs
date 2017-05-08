using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    public class Menu
    {
        #region Properties
        public List<Coffee> Options { get; private set; }
        #endregion

        #region Constructor
        public Menu()
        {
            Options = new List<Coffee>();
        }

        public Menu(string menuFilePath) : this()
        {
            string[] lines = File.ReadAllLines(menuFilePath);
            string[] descriptions = lines.Select(it => it.Split(':')[0]).ToArray();
            double[] values = lines.Select(it => double.Parse(it.Split(':')[1].Trim().Substring(1))).ToArray();
            int limit = descriptions.Length;
            for (int i = 0; i < limit; ++i)
            {
                Options.Add(new Coffee(descriptions[i], values[i]));
            }
        }
        #endregion

        #region Methods
        public string[] GetDescriptions()
        {
            return Options.Select(coffee => coffee.Name).ToArray();
        }

        public double[] GetPrices()
        {
            return Options.Select(coffee => coffee.Price).ToArray();
        }
        #endregion
    }
}
