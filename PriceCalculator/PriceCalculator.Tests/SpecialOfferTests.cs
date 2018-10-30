using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using PriceCalculator.Domain;
using PriceCalculator.Domain.Models;

namespace PriceCalculator.Tests
{
    [TestFixture]
    public class SpecialOfferTests
    {
        [Test]
        public void MultibuyConstructorTest()
        {
            var productName = "Cheese";
            var numberNeeded = 1;
            var offer = new MultibuyOffer(productName, numberNeeded);
            Assert.AreEqual(productName, offer.ProductName);
            Assert.AreEqual(numberNeeded, offer.NumRequired);
        }

        [Test]
        public void BonusProductConstructorTest()
        {
            var productName = "Cheese";
            var numberNeeded = 1;
            var discountProduct = "Bread";
            var productDiscount = 1.5m;
            var offer = new BonusProductOffer(productName, numberNeeded, discountProduct, productDiscount);
            Assert.AreEqual(productName, offer.ProductName);
            Assert.AreEqual(numberNeeded, offer.NumRequired);
            Assert.AreEqual(discountProduct, offer.DiscountProductName);
            Assert.AreEqual(productDiscount, offer.DiscountAmount);
        }

        static object[] GetMultiBuyTests =
        {
            new object[] { 3, -0.5m},
            new object[] { 5, -0.5m},
            new object[] { 7, -1m}
        };

        [Test, TestCaseSource("GetMultiBuyTests")]
        public void MultibuyDetermineOfferTest(int cheeseCount, decimal expectedDiscountValue)
        {
            var productName = "Cheese";
            var numberNeeded = 3;
            var offer = new MultibuyOffer(productName, numberNeeded);

            var products = new Dictionary<Product, int>();
            products.Add(new Product("Cheese", 0.5m), cheeseCount);
            
            var expectedDiscountProduct = new Product("Cheese Multibuy", expectedDiscountValue);


            var discountedProduct = offer.DetermineSpecialOffer(products);
            Assert.AreEqual(expectedDiscountProduct, discountedProduct);
        }

        static object[] GetBonusProductTests =
        {
            new object[] { 3, 1, -0.25m},
            new object[] { 5, 2, -0.25m},
            new object[] { 7, 1, -0.25m},
            new object[] { 7, 2, -0.5m},
        };

        [Test, TestCaseSource("GetBonusProductTests")]
        public void BonusProductDetermineOfferTest(int cheeseCount, int breadCount, decimal expectedDiscountValue)
        {
            var productName = "Cheese";
            var numberNeeded = 3;
            var bonusProduct = "Bread";
            var bonusDiscount = 0.5m;

            var offer = new BonusProductOffer(productName, numberNeeded, bonusProduct, bonusDiscount);

            var products = new Dictionary<Product, int>();
            products.Add(new Product("Cheese", 0.5m), cheeseCount);
            products.Add(new Product("Bread", 0.5m), breadCount);

            var expectedDiscountProduct = new Product("Discount on Bread", expectedDiscountValue);

            
            var discountedProduct = offer.DetermineSpecialOffer(products);
            Assert.AreEqual(expectedDiscountProduct, discountedProduct);
        }

        static int[] GetMultiBuyNoOfferTests =
        {
            0,
            2
        };

        [Test, TestCaseSource("GetMultiBuyNoOfferTests")]
        public void MultibuyNoOfferTest(int cheeseCount)
        {
            var productName = "Cheese";
            var numberNeeded = 3;
            var offer = new MultibuyOffer(productName, numberNeeded);

            var products = new Dictionary<Product, int>();
            products.Add(new Product("Cheese", 0.5m), cheeseCount);

            var discountedProduct = offer.DetermineSpecialOffer(products);
            Assert.IsNull(discountedProduct);
        }


        static object[] GetBonusProductNoOfferTests =
        {
            new object[] { 2, 1},
            new object[] { 5, 0}
        };

        [Test, TestCaseSource("GetBonusProductNoOfferTests")]
        public void BonusProductNoOfferTest(int cheeseCount, int breadCount)
        {
            var productName = "Cheese";
            var numberNeeded = 3;
            var bonusProduct = "Bread";
            var bonusDiscount = 0.5m;

            var offer = new BonusProductOffer(productName, numberNeeded, bonusProduct, bonusDiscount);

            var products = new Dictionary<Product, int>();
            products.Add(new Product("Cheese", 0.5m), cheeseCount);
            products.Add(new Product("Bread", 0.5m), breadCount);

            var discountedProduct = offer.DetermineSpecialOffer(products);
            Assert.IsNull(discountedProduct);
        }
    }
}
