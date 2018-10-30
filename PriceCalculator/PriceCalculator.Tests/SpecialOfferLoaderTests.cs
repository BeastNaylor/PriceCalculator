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
    public class SpecialOfferLoaderTests
    {
        static ISpecialOffer[] GetSpecialOffers =
        {
            new MultibuyOffer("Milk", 4),
            new BonusProductOffer("Butter", 2, "Bread", 0.5m)
        };

        [Test, TestCaseSource("GetSpecialOffers")]
        public void SpecialOfferLoaderReturnsAllOffers(ISpecialOffer offer)
        {
            var specialOfferLoader = new SpecialOfferLoader();
            var specialOffers = specialOfferLoader.LoadCurrentOffers();
            Assert.Contains(offer, specialOffers.ToList());
        }
    }
}
