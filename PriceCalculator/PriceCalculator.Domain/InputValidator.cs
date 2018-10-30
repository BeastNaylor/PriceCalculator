using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Domain.Interfaces;
using PriceCalculator.Domain.Models;

namespace PriceCalculator.Domain
{
    public class InputValidator : IInputValidator
    {
        private IProductLoader _loader;
        private IDictionary<Product, int> _inputProducts;
        private bool _hasBeenValidated;


        public InputValidator(IProductLoader loader)
        {
            _loader = loader;
        }

        public IDictionary<Product, int> GetValidatedProducts()
        {
            //if we haven't Validated any input successfully, throw an exception
            if (!_hasBeenValidated) { throw new InvalidOperationException("No products have been loaded."); }
            return _inputProducts;
        }

        public bool ValidateInput(ICollection<string> input)
        {
            _inputProducts = new Dictionary<Product, int>();

            //compare the input we have received with the validProducts
            foreach (string inputItem in input)
            {
                var product = _loader.GetProducts().Where(p => p.ProductName.ToLower() == inputItem.ToLower()).SingleOrDefault();
                if (product != null)
                {
                    if (!_inputProducts.ContainsKey(product))
                    {
                        _inputProducts.Add(product, 0);
                    }

                    _inputProducts[product]++;
                }
                else
                {
                    //once we find a bad input, no point in continuing, so return
                    return false;
                }
            }
            //mark we have some validatedProducts to process
            _hasBeenValidated = true;
            return true;
        }
    }
}
