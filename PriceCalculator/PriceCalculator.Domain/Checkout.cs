using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Domain.Interfaces;
using PriceCalculator.Domain.Models;

namespace PriceCalculator.Domain
{
    public class Checkout : ICheckout
    {
        public readonly IDictionary<Product, int> SelectedProducts;
        public List<Product> DiscountedProducts{ get; private set; }

        public Checkout(IDictionary<Product, int> products)
        {
            SelectedProducts = products;
        }

        public decimal DetermineSubtotal()
        {
            return SelectedProducts.Sum(p => p.Key.Price * p.Value);
        }

        public decimal DetermineTotal()
        {
            return DetermineSubtotal() + DiscountedProducts.Sum(p => p.Price);
        }

        public void ProcessSpecialOffers(ICollection<ISpecialOffer> offers)
        {
            DiscountedProducts = new List<Product>();
            foreach (ISpecialOffer offer in offers)
            {
                var discountProduct = offer.DetermineSpecialOffer(SelectedProducts);
                if (discountProduct != null)
                {
                    DiscountedProducts.Add(discountProduct);
                }
            }
        }
    }
}
