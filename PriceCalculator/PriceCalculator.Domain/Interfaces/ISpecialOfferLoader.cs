using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator.Domain.Interfaces
{
    public interface ISpecialOfferLoader
    {
            ICollection<ISpecialOffer> LoadCurrentOffers();
    }
}
