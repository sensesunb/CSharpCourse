using NUnit.Framework;
using CoffeeShop;

namespace TestSuite
{
    [TestFixture]
    public class CoffeeTest
    {
        #region Coffee tests
        [Test]
        public void TestCoffeePrice()
        {
            Coffee coffee = new Coffee("black", 2.50);
            Assert.AreEqual(2.50, coffee.Price);
        }

        [Test]
        public void TestCoffeeWithNegativePrice()
        {
            Assert.Throws<System.ArgumentException>(() => new Coffee("black", -1));
        }

        [Test]
        public void TestCoffeeWithInvalidDescription()
        {
            Assert.Throws<System.ArgumentException>(() => new Coffee("", 10.0));
        }
        #endregion

        #region Menu tests
        [Test]
        public void TestIfMenuLoads()
        {
            Menu menu = new Menu(@"C:\Users\cris\Documents\work\IEEE\CSharpCourse\dunkindonuts.txt");
            Assert.AreEqual(5, menu.Options.Count);
        }

        [Test]
        public void TestIfGottenDescriptionsHaveTheSameLengthOfMenuItems()
        {
            string[] descriptions = Menu.GetDescriptions();
            int lengthOfMenu = Menu.Options.Count;
            int lengthOfDescriptions = descriptions.Length;
            Assert.AreEqual(lengthOfDescriptions, lengthOfMenu);
        }

        [Test]
        public void TestIfGottenPricesHaveTheSameLengthOfMenuItems()
        {
            double[] descriptions = Menu.GetPrices();
            int lengthOfMenu = Menu.Options.Count;
            int lengthOfPrices = descriptions.Length;
            Assert.AreEqual(lengthOfPrices, lengthOfMenu);
        }

        [Test]
        public void TestGetValidCoffeeFromMenu()
        {
            Coffee coffee = Menu.GetCoffee(3);
            Assert.AreEqual(coffee.Name, "Frozen");
            coffee = Menu.GetCoffee("Café Gelado");
            Assert.AreEqual(5, coffee.Price);
        }

        [Test]
        public void TestGetInvalidCoffeeFromMenu()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => Menu.GetCoffee(-1));
            Coffee coffee = Menu.GetCoffee("FSCK");
            Assert.Null(coffee);
        }
        #endregion

        #region Cashier tests
        [Test]
        public void TestInitialOrderState()
        {
            Cashier cashier = new Cashier();
            cashier.Start();
            Assert.AreEqual(0, cashier.Size);
        }

        [Test]
        public void TestAddDifferentCoffeeToOrder()
        {
            Cashier cashier = new Cashier();
            int limit = Menu.Options.Count;
            cashier.Start();
            for (int i = 0; i < limit; ++i)
            {
                cashier.Add(Menu.GetCoffee(i));
            }
            Assert.AreEqual(limit, cashier.Size);
        }

        [Test]
        public void TestAddEqualCoffeesToOrder()
        {
            Cashier cashier = new Cashier();
            int limit = 10;
            cashier.Start();
            for (int i = 0; i < limit; ++i)
            {
                cashier.Add(Menu.GetCoffee(0));
            }
            Assert.AreEqual(limit, cashier.Size);
        }

        [Test]
        public void TestDoSomethingWithoutStartingOrder()
        {
            Cashier cashier = new Cashier();
            Assert.Throws<System.InvalidOperationException>(() => cashier.Add(Menu.GetCoffee(0)));
            Assert.Throws<System.InvalidOperationException>(() => cashier.Finish());
        }

        [Test]
        public void TestOrderWorks()
        {
            Cashier cashier = new Cashier();
            int limit = Menu.Options.Count;
            double total = 0;
            cashier.Start();
            for (int i = 0; i < limit; ++i)
            {
                var coffee = Menu.GetCoffee(i);
                total += coffee.Price;
                cashier.Add(coffee);
            }
            cashier.Finish();
            Assert.AreEqual(total, cashier.Total);
            Assert.AreEqual(limit, cashier.Description.Length);
        }
        #endregion

        static Menu Menu = new Menu(@"C:\Users\cris\Documents\work\IEEE\CSharpCourse\dunkindonuts.txt");
    }
}
