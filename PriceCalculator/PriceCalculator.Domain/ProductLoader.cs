using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Domain.Interfaces;
using PriceCalculator.Domain.Models;

namespace PriceCalculator.Domain
{
    public class ProductLoader : IProductLoader
    {
        public ICollection<Product> GetProducts()
        {
            //this should be pulled from an external source, but for now we'll just list the products here
            return new List<Product>() { new Product("Butter", 0.8m), new Product("Milk", 1.15m), new Product("Bread", 1m) };
        }
    }
}
