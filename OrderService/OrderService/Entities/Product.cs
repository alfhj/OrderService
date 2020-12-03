namespace OrderService.Entities
{
    public class Product
    {
	    public Product(ProductType productType, ProductClass productClass, decimal price)
        {
            ProductType = productType;
            ProductClass = productClass;
            Price = price;
        }

        public ProductType ProductType { get; }
        public ProductClass ProductClass { get; }
        public decimal Price { get; }

        public override string ToString()
        {
	        return $"{ProductType} Insurance {ProductClass}";
        }
    }
}