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
        private ICollection<Product> _inputProducts;
        private bool _hasBeenValidated;


        public InputValidator(IProductLoader loader)
        {
            _loader = loader;
        }

        public ICollection<Product> GetValidatedProducts()
        {
            //if we haven't Validated any input successfully, throw an exception
            if (!_hasBeenValidated) { throw new InvalidOperationException("No products have been loaded."); }
            return _inputProducts;
        }

        public bool ValidateInput(IEnumerable<string> input)
        {
            _inputProducts = new List<Product>();

            //compare the input we have received with the validProducts
            foreach (string inputItem in input)
            {
                var product = _loader.GetProducts().Where(p => p.ProductName.ToLower(new System.Globalization.CultureInfo("en-GB")) == inputItem.ToLower(new System.Globalization.CultureInfo("en-GB"))).SingleOrDefault();
                if (product != null)
                {
                    _inputProducts.Add(product);
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
