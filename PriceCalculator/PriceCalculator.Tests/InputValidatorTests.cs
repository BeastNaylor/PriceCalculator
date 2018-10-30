using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PriceCalculator.Domain;
using PriceCalculator.Domain.Models;
using PriceCalculator.Domain.Interfaces;
using System.Linq;

namespace PriceCalculator.Tests
{
    [TestFixture]
    public class InputValidatorTests
    {
        static object[] GetValidInput =
        {
            //new string[] {"Bread"},
            new string[] {"Milk", "Bread", "Milk"},
            new string[] {"bread", "MILK"},
            new string[] {"Milk ", " Bread"},
        };

        static object[] GetInvalidInput =
        {
            new string[] {""},
            new string[] {"Bred"},
            new string[] {"Milk", "x", "Butter"}
        };

        IInputValidator validator;

        [SetUp]
        public void Init()
        {
            var mock = new Mock<IProductLoader>();
            mock.Setup(m => m.GetProducts()).Returns(new List<Product>() { new Product("Bread", 1m), new Product("Milk", 2m) });
            validator = new InputValidator(mock.Object);
        }

        [Test, TestCaseSource("GetValidInput")]
        public void InputValidatorValidInput(string[] input)
        {
            Assert.IsTrue(validator.ValidateInput(input));
        }

        [Test, TestCaseSource("GetInvalidInput")]
        public void InputValidatorInvalidInput(string[] input)
        {
            Assert.IsFalse(validator.ValidateInput(input));
        }

        [Test]
        public void CallValidProductsTooEarlyGivesError()
        {
            Assert.Throws<InvalidOperationException>(() => validator.GetValidatedProducts());
        }

        [Test, TestCaseSource("GetValidInput")]
        public void CallValidProductsAfterLoadGivesProducts(string[] input)
        {
            validator.ValidateInput(input);
            var validProducts = validator.GetValidatedProducts();
            //check that for each item we have inputted, it appears the correct number of times
            foreach (var inputItem in input.GroupBy(i => i))
            {
                var product = validProducts.Keys.Where(k => k.ProductName.ToLower() == inputItem.Key.Trim().ToLower()).Single();
                Assert.AreEqual(inputItem.Count(), validProducts[product]);
            }
        }
    }
}
