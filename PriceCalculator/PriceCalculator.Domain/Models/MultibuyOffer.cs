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

        public Product DetermineSpecialOffer(IDictionary<Product, int> products)
        {
            //check if the products contains the item on offer.
            var discountProducts = products.Where(p => p.Key.ProductName == ProductName).SingleOrDefault();
            if (discountProducts.Value > 0)
            {
                //if we have the products, check how many should be free by / by the num required
                var numProductsFree = discountProducts.Value / NumRequired;
                if (numProductsFree > 0)
                {
                    //return an item of that is the price of the discount
                    var finalDiscountValue = decimal.Round(-1 * numProductsFree * discountProducts.Key.Price, 2);
                    return new Product($"{discountProducts.Key.ProductName} Multibuy", finalDiscountValue);
                }
            }
            // if there are no items returning, we have no discount
            return null;
        }

        public override bool Equals(object value)
        {
            if (value == null || GetType() != value.GetType())
                return false;

            MultibuyOffer offer = value as MultibuyOffer;

            return (offer != null)
                && (ProductName == offer.ProductName);
        }

        public override int GetHashCode()
        {
            return ProductName.GetHashCode();
        }
    }
}
