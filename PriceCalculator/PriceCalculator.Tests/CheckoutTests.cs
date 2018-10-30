using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using PriceCalculator.Domain;
using PriceCalculator.Domain.Models;
using PriceCalculator.Domain.Interfaces;

namespace PriceCalculator.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        ICollection<ISpecialOffer> offers;

        [SetUp]
        public void Init()
        {
            var mock = new Mock<ISpecialOffer>();
            mock.Setup(m => m.DetermineSpecialOffer(It.IsAny<Dictionary<Product, int>>())).Returns(new Product("Sample Offer", -1m));
            offers = new List<ISpecialOffer>()
            {
                mock.Object
            };
        }

        [Test]
        public void CheckoutSingleProductSubTotalIsCorrect()
        {
            var products = new Dictionary<Product, int>();
            products.Add(new Product("Butter", 0.8m), 1);
            var expectedSubtotal = 0.8m;

            var checkout = new Checkout(products);
            Assert.AreEqual(expectedSubtotal, checkout.DetermineSubtotal());
        }

        [Test]
        public void CheckoutMultipleProductSubTotalIsCorrect()
        {
            var products = new Dictionary<Product, int>();
            products.Add(new Product("Butter", 2.3m), 2);
            products.Add(new Product("Cheese", 1.5m), 1);
            var expectedSubtotal = 6.1m;

            var checkout = new Checkout(products);
            Assert.AreEqual(expectedSubtotal, checkout.DetermineSubtotal());
        }

        [Test]
        public void CheckoutProcessSpecialOfferIsCorrect()
        {
            var products = new Dictionary<Product, int>();
            products.Add(new Product("Butter", 2.3m), 2);
            products.Add(new Product("Cheese", 1.5m), 4);

            var checkout = new Checkout(products);
            checkout.ProcessSpecialOffers(offers);

            var expectedOffer = new Product("Sample Offer", -1m);
            Assert.AreEqual(1, checkout.DiscountedProducts.Count());
            Assert.Contains(expectedOffer, checkout.DiscountedProducts);

            
        }

    }
}



