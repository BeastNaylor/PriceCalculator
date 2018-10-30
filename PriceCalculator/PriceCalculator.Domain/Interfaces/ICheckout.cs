using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Domain.Models;

namespace PriceCalculator.Domain.Interfaces
{
    interface ICheckout
    {
        decimal DetermineSubtotal();

        void ProcessSpecialOffers(IEnumerable<ISpecialOfferLoader> products);

        IEnumerable<Product> GetSpecialOffers();

        decimal DetermineTotal();
    }
}
