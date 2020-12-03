using OrderService.DiscountRules;

namespace OrderService
{
    public class OrderLine
    {


        public decimal TotalPrice { get; set; }
        public Product Product { get; }
        public int Quantity { get; }
        public int Discount { get; }

        public OrderLine(Product product, int quantity, int discount)
        {
            Product = product;
            Quantity = quantity;
            Discount = discount;
            TotalPrice = Quantity * Product.Price;
        }
    }
}