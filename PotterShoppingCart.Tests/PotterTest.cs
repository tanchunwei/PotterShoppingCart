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
            decimal actual = target.CalculatePrice(cart);

            Assert.AreEqual(expected, actual);
        }
    }

    public class ShoppingCart
    {
        public decimal CalculatePrice(List<PotterBook> cart)
        {
            return 100;
        }
    }

    public class PotterBook
    {
        public int Series { get; set; }
    }
}
