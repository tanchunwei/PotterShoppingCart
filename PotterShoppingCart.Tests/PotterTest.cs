using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public void CalculatePriceTest_PriceOfThreeDifferentBooks_Get10PercentOff_Is270Dollars()
        {
            var cart = new List<PotterBook>()
            {
                new PotterBook(){
                    Series = 1
                },
                new PotterBook(){
                    Series = 2
                } ,
                new PotterBook(){
                    Series = 3
                } 
            };
            decimal expected = 270;
            var target = new ShoppingCart();
            decimal actual = target.CalculatePrice(cart);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePriceTest_PriceOfFourDifferentBooks_Get20PercentOff_Is320Dollars()
        {
            var cart = new List<PotterBook>()
            {
                new PotterBook(){
                    Series = 1
                },
                new PotterBook(){
                    Series = 2
                } ,
                new PotterBook(){
                    Series = 3
                } ,
                new PotterBook(){
                    Series = 4
                } 
            };
            decimal expected = 320;
            var target = new ShoppingCart();
            decimal actual = target.CalculatePrice(cart);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePriceTest_PriceOfFiveDifferentBooks_Get25PercentOff_Is375Dollars()
        {
            var cart = new List<PotterBook>()
            {
                new PotterBook(){
                    Series = 1
                },
                new PotterBook(){
                    Series = 2
                } ,
                new PotterBook(){
                    Series = 3
                } ,
                new PotterBook(){
                    Series = 4
                } 
                ,
                new PotterBook(){
                    Series = 5
                } 
            };
            decimal expected = 375;
            var target = new ShoppingCart();
            decimal actual = target.CalculatePrice(cart);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePriceTest_PriceOfBooks_1_2_3_3_Is370Dollars()
        {
            var cart = new List<PotterBook>()
            {
                new PotterBook(){
                    Series = 1
                },
                new PotterBook(){
                    Series = 2
                } ,
                new PotterBook(){
                    Series = 3
                } ,
                new PotterBook(){
                    Series = 3
                } 
            };
            decimal expected = 370;
            var target = new ShoppingCart();
            decimal actual = target.CalculatePrice(cart);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePriceTest_PriceOfBooks_1_2_2_3_3_Is460Dollars()
        {
            var cart = new List<PotterBook>()
            {
                new PotterBook(){
                    Series = 1
                },
                new PotterBook(){
                    Series = 2
                } ,
                new PotterBook(){
                    Series = 2
                } ,
                new PotterBook(){
                    Series = 3
                } ,
                new PotterBook(){
                    Series = 3
                } 
            };
            decimal expected = 460;
            var target = new ShoppingCart();
            decimal actual = target.CalculatePrice(cart);

            Assert.AreEqual(expected, actual);
        }
    }

    public class ShoppingCart
    {
        public decimal CalculatePrice(List<PotterBook> cart)
        {
            Dictionary<int, List<PotterBook>> group =  cart.GroupBy(c => c.Series).ToDictionary(c=>c.Key, c=> c.ToList());
            int numberOf5Series = 0;
            if(group.Count >= 5)
                numberOf5Series = group.Min(g => g.Value.Count);

            int numberOf4Series = 0;
            if(group.Count(g => (g.Value.Count - numberOf5Series > 0)) >= 4)
                numberOf4Series = group.Where(g => g.Value.Count - (numberOf5Series) > 0).Min(g => g.Value.Count - (numberOf5Series));
           
            int numberOf3Series = 0;
            if(group.Count(g => (g.Value.Count - (numberOf5Series + numberOf4Series) > 0)) >= 3)
                numberOf3Series = group.Where(g=> g.Value.Count - (numberOf5Series + numberOf4Series) > 0).Min(g =>  g.Value.Count - (numberOf5Series + numberOf4Series));

            int numberOf2Series = 0;
            if(group.Count(g => (g.Value.Count - (numberOf5Series + numberOf4Series + numberOf3Series) > 0)) >= 2)
                numberOf2Series = group.Where(g => g.Value.Count - (numberOf5Series + numberOf4Series + numberOf3Series) > 0).Min(g => g.Value.Count - (numberOf5Series + numberOf4Series + numberOf3Series));

            int numberOf1Series = 0;
            if(group.Count(g => (g.Value.Count - (numberOf5Series + numberOf4Series + numberOf3Series + numberOf2Series) > 0)) >= 1)
                numberOf1Series = group.Where(g => g.Value.Count - (numberOf5Series + numberOf4Series + numberOf3Series + numberOf2Series) > 0).Sum(g => g.Value.Count - (numberOf5Series + numberOf4Series + numberOf3Series + numberOf2Series));

            return (decimal) (((numberOf5Series * 5 * 0.75) + (numberOf4Series * 4 * 0.8) + (numberOf3Series * 3 * 0.9) + (numberOf2Series * 2 * 0.95) + (numberOf1Series)) * 100);
        }
    }

    public class PotterBook
    {
        public int Series { get; set; }
    }
}
