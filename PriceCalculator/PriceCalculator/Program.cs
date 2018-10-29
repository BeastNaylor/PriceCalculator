using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the products to calculate:");
            var input = Console.ReadLine();
            var cost = 1.15m;
            Console.Write($"These products come to £{cost}");
            Console.ReadKey();
        }
    }
}
