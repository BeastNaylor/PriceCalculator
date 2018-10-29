
namespace PriceCalculator.Domain.Models
{
    public class Product
    {
        public readonly string ProductName;
        public readonly decimal Price;

        public Product(string productName, decimal price)
        {
            ProductName = productName;
            Price = price;
        }

        public override bool Equals(object value)
        {
            if (value == null || GetType() != value.GetType())
                return false;

            Product product = value as Product;

            return (product != null)
                && (ProductName == product.ProductName)
                && (Price == product.Price);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
