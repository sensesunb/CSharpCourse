using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    public class Cashier
    {
        #region Properties
        public List<Coffee> Order { get; private set; }
        public double Total { get; private set; } = -1;
        public string[] Description { get; private set; } = null;
        protected bool OrderMode = false;
        public int Size { get { return Order.Count; } }
        #endregion

        #region Methods
        public Cashier()
        {
            Unsetup();
        }

        public void Start()
        {
            Setup();
        }

        protected void Setup()
        {
            Order = new List<Coffee>();
            OrderMode = true;
            Description = null;
            Total = -1;
        }

        protected void Unsetup()
        {
            Order = null;
            OrderMode = false;
        }

        public void Add(Coffee coffee)
        {
            if (!OrderMode) throw new System.InvalidOperationException();
            Order.Add(coffee);
        }

        public void Finish()
        {
            if (OrderMode)
            {
                Total = Order.Aggregate(0.0, (total, coffee) => total + coffee.Price);
                Description = Order.Select(it => it.Name).ToArray();
                Unsetup();
            }
            else
            {
                throw new System.InvalidOperationException();
            }
        }
        #endregion
    }
}
