using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Domain.Interfaces;

namespace PriceCalculator.Domain.Models
{
    public class BonusProductOffer : ISpecialOffer
    {
        public readonly string ProductName;
        public readonly int NumRequired;
        public readonly string DiscountProductName;
        public readonly decimal DiscountAmount;

        public BonusProductOffer(string productName, int numRequiredForFree, string discountedProduct, decimal discountAmount)
        {
            ProductName = productName;
            NumRequired = numRequiredForFree;
            DiscountProductName = discountedProduct;
            DiscountAmount = discountAmount;
        }

        public Product DetermineSpecialOffer(IEnumerable<Product> _products)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object value)
        {
            if (value == null || GetType() != value.GetType())
                return false;

            BonusProductOffer offer = value as BonusProductOffer;

            return (offer != null)
                && (ProductName == offer.ProductName)
                && (NumRequired == offer.NumRequired)
                && (DiscountProductName == offer.DiscountProductName)
                && (DiscountAmount == offer.DiscountAmount);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
