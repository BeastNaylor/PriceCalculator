using System;
using System.Linq;
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
    }
}
