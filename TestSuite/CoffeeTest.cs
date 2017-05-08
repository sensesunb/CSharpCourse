using NUnit.Framework;
using CoffeeShop;

namespace TestSuite
{
    [TestFixture]
    public class CoffeeTest
    {
        [Test]
        public void TestarPrecoDoCafe()
        {
            Coffee coffee = new Coffee("black", 2.50);
            Assert.AreEqual(2.50, coffee.Price);
        }
    }
}
