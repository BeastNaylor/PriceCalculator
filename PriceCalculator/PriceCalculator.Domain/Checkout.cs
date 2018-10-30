using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Domain.Interfaces;
using PriceCalculator.Domain.Models;

namespace PriceCalculator.Domain
{
    class Checkout : ICheckout
    {
        public decimal DetermineSubtotal()
        {
            throw new NotImplementedException();
        }

        public decimal DetermineTotal()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetSpecialOffers()
        {
            throw new NotImplementedException();
        }

        public void ProcessSpecialOffers(IEnumerable<ISpecialOfferLoader> products)
        {
            throw new NotImplementedException();
        }
    }
}
