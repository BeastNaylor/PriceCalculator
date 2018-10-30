using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Domain.Interfaces;
using PriceCalculator.Domain.Models;

namespace PriceCalculator.Domain
{
    public class SpecialOfferLoader : ISpecialOfferLoader
    {
        public ICollection<ISpecialOffer> LoadCurrentOffers()
        {
            return new List<ISpecialOffer>()
            {
                new MultibuyOffer("Milk", 4),
                new BonusProductOffer("Butter", 2, "Bread", 0.5m)
            };
        }
    }
}
