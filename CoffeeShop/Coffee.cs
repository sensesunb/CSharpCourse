using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    public class Coffee
    {
        #region Properties
        private string _Name_ { get; set; } = null;
        public string Name
        {
            get
            {
                return _Name_;
            }
            set
            {
                if (_Name_ == null)
                {
                    if (value.Length > 0)
                    {
                        _Name_ = value;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
            }
        }
        private double _Price_ { get; set; } = 0;
        public double Price
        {
            get
            {
                return _Price_;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                else if (_Price_ <= 0)
                {
                    _Price_ = value;
                }
            }
        }
        #endregion

        #region Constructor
        public Coffee(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
        #endregion
    }
}
