namespace OrderService.Entities
{
    public class OrderLine
    {
        public OrderLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity > 0 ? quantity : 0;
        }

        public Product Product { get; }
        public int Quantity { get; }
    }
}