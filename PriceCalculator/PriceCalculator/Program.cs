using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Domain;

namespace PriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var productLoader = new ProductLoader();
            var inputValidator = new InputValidator(productLoader);

            Console.WriteLine("Please enter the products to calculate as CSV (i.e. 'Milk,Bread,Butter':");
            var input = Console.ReadLine().Split(',');
            if (!inputValidator.ValidateInput(input))
            {
                //TODO: could return which of the inputs were invalid
                Console.WriteLine("Invalid input received.");
                return;
            }
            //load the specialOffers and pass to the checkout to determine savings
            var specialOfferLoader = new SpecialOfferLoader();
            var checkout = new Checkout(inputValidator.GetValidatedProducts());
            checkout.ProcessSpecialOffers(specialOfferLoader.LoadCurrentOffers());

            Console.Write($"These products come to £{checkout.DetermineTotal().ToString("0.00")}");
            Console.ReadKey();
        }
    }
}
