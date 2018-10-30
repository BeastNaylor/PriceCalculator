using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Domain.Interfaces;

namespace PriceCalculator.Domain.Models
{
    public class MultibuyOffer : ISpecialOffer
    {
        public readonly string ProductName;
        public readonly int NumRequired;

        public MultibuyOffer(string productName, int numRequiredForFree)
        {
            ProductName = productName;
            NumRequired = numRequiredForFree;
        }

        public Product DetermineSpecialOffer(IEnumerable<Product> _products)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object value)
        {
            if (value == null || GetType() != value.GetType())
                return false;

            MultibuyOffer offer = value as MultibuyOffer;

            return (offer != null)
                && (ProductName == offer.ProductName)
                && (NumRequired == offer.NumRequired);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
