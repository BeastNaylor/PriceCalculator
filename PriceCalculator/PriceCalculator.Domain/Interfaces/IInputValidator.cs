using PriceCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator.Domain.Interfaces
{
    public interface IInputValidator
    {
        IDictionary<Product, int> GetValidatedProducts();

        bool ValidateInput(ICollection<string> input);
    }
}
