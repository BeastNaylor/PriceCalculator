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

        public Product DetermineSpecialOffer(IDictionary<Product, int> products)
        {
            //first, check there are both products involved in the offer in products
            if (products.Select(p => p.Key.ProductName).Intersect(new string[] { ProductName, DiscountProductName }).Count() == 2)
            {
                //we have both items in the basket, so determine the maximum offers we can get
                var numReqProducts = products.Where(p => p.Key.ProductName == ProductName).Single().Value;
                var numOfferProducts = products.Where(p => p.Key.ProductName == DiscountProductName).Single().Value;
                var offeredProductPrice = products.Where(p => p.Key.ProductName == DiscountProductName).Single().Key.Price;

                //work out how many offers we can redeem
                var maxNumOffers = numReqProducts / NumRequired;
                //take the lower of the maxOffers or numProducts (as two 50% off bread doesn't mean a free bread)
                var actualOffers = Math.Min(maxNumOffers, numOfferProducts);
                
                //if we have any products to discount, then return a product of their value
                if (actualOffers > 0)
                {
                    decimal finalDiscountValue = decimal.Round(-1 * actualOffers * DiscountAmount * offeredProductPrice, 2);
                    return new Product($"Discount on {DiscountProductName}", finalDiscountValue);
                }
            }
            return null;
        }

        public override bool Equals(object value)
        {
            if (value == null || GetType() != value.GetType())
                return false;

            BonusProductOffer offer = value as BonusProductOffer;

            return (offer != null)
                && (ProductName == offer.ProductName)
                && (DiscountProductName == offer.DiscountProductName);
        }

        public override int GetHashCode()
        {
            int hashCode = 17;
            hashCode = (hashCode * 23) + ProductName.GetHashCode();
            hashCode = (hashCode * 23) + DiscountProductName.GetHashCode();
            return hashCode;
        }
    }
}
