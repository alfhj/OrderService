namespace OrderService
{
    public class Product
    {
        public Product(string productType, string productName, decimal price)
        {
            ProductType = productType;
            ProductName = productName;
            Price = price;
        }

        public string ProductType { get; }
        public string ProductName { get; }
        public decimal Price { get; }

        public class Prices
        {
            public const decimal OneThousand = 1000M;
            public const decimal TwoThousand = 2000M;
            public const double TaxRate = .25d;
        }
    }
}