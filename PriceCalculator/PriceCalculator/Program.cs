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
            if (!inputValidator.ValidateInput(args))
            {
                //TODO: could return which of the inputs were invalid
                Console.WriteLine("Invalid input received.");
                return;
            }
            decimal cost = 0;

            Console.Write($"These products come to £{cost}");
            Console.ReadKey();
        }
    }
}
