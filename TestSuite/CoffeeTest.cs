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
            Menu menu = new Menu("");
            Assert.AreEqual(5, menu.Options.Count);
        }
    }
}
