using System;
using System.Linq;
using NUnit.Framework;
using PriceCalculator.Domain;
using PriceCalculator.Domain.Models;

namespace PriceCalculator.Tests
{
    [TestFixture]
    public class ProductLoaderTests
    {
        static Product[] GetProducts =
        {
            new Product("Butter", 0.8m),
            new Product("Milk", 1.15m),
            new Product("Bread", 1m)
        };

        [Test, TestCaseSource("GetProducts")]
        public void ProductLoaderReturnsAllProducts(Product product)
        {
            var loader = new ProductLoader();
            var products = loader.GetProducts();
            Assert.Contains(product, products.ToList());
        }
    }
}
