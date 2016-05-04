using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PotterShoppingCart.Tests
{
    [TestClass]
    public class PotterTest
    {
        [TestMethod]
        public void CalculatePriceTest_PriceOfOneBook_Is100Dollars()
        {
            var cart = new List<PotterBook>()
            {
                new PotterBook(){
                    Series = 1
                } 
            };
            decimal expected = 100;
            var target = new ShoppingCart();
            decimal actual = target.calculatePrice(cart);

            Assert.AreEqual(expected, actual);
        }
    }
}
