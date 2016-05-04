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

        [TestMethod]
        public void CalculatePriceTest_PriceOfTwoDifferentBooks_Get5PercentOff_Is190Dollars()
        {
            var cart = new List<PotterBook>()
            {
                new PotterBook(){
                    Series = 1
                },
                new PotterBook(){
                    Series = 2
                } 
            };
            decimal expected = 190;
            var target = new ShoppingCart();
            decimal actual = target.CalculatePrice(cart);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePriceTest_PriceOfTwoSameBooks_No5PercentOff_Is200Dollars()
        {
            var cart = new List<PotterBook>()
            {
                new PotterBook(){
                    Series = 1
                },
                new PotterBook(){
                    Series = 1
                } 
            };
            decimal expected = 200;
            var target = new ShoppingCart();
            decimal actual = target.CalculatePrice(cart);

            Assert.AreEqual(expected, actual);
        }
    }

    public class ShoppingCart
    {
        public decimal CalculatePrice(List<PotterBook> cart)
        {
            return cart.Count>=2? 190: 100;
        }
    }

    public class PotterBook
    {
        public int Series { get; set; }
    }
}
