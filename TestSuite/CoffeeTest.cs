using NUnit.Framework;
using CoffeeShop;

namespace TestSuite
{
    [TestFixture]
    public class CoffeeTest
    {
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

        [Test]
        public void TestIfMenuLoads()
        {
            Menu menu = new Menu(@"C:\Users\cris\Documents\work\IEEE\CSharpCourse\dunkindonuts.txt");
            Assert.AreEqual(5, menu.Options.Count);
        }

        [Test]
        public void TestIfGottenDescriptionsHaveTheSameLengthOfMenuItems()
        {
            Menu menu = new Menu(@"C:\Users\cris\Documents\work\IEEE\CSharpCourse\dunkindonuts.txt");
            string[] descriptions = menu.GetDescriptions();
            int lengthOfMenu = menu.Options.Count;
            int lengthOfDescriptions = descriptions.Length;
            Assert.AreEqual(lengthOfDescriptions, lengthOfMenu);
        }

        [Test]
        public void TestIfGottenPricesHaveTheSameLengthOfMenuItems()
        {
            Menu menu = new Menu(@"C:\Users\cris\Documents\work\IEEE\CSharpCourse\dunkindonuts.txt");
            double[] descriptions = menu.GetPrices();
            int lengthOfMenu = menu.Options.Count;
            int lengthOfPrices = descriptions.Length;
            Assert.AreEqual(lengthOfPrices, lengthOfMenu);
        }

        // TODO Implement Cashier class
    }
}
