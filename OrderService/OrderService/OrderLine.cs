using OrderService.DiscountRules;

namespace OrderService
{
    public class OrderLine
    {


        public decimal TotalPrice { get; set; }
        public Product Product { get; }
        public decimal Quantity { get; }

        public OrderLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            TotalPrice = CalculateDiscountedPrice();
        }


        public decimal CalculateDiscountedPrice()
        {
            var totalPrice = 0M;

            switch (Product.Price)
            {
                case Product.Prices.OneThousand:
                    if (Quantity >= 5)
                        totalPrice += Quantity * Product.Price * .9M;
                    else
                        totalPrice += Quantity * Product.Price;
                    break;
                case Product.Prices.TwoThousand:
                    if (Quantity >= 3)
                        totalPrice += Quantity * Product.Price * .8M;
                    else
                        totalPrice += Quantity * Product.Price;
                    break;
            }

            return totalPrice;

            //var discount = 0;
            //if (Quantity > 0)
            //{
            //    TotalPrice = (TotalPrice * 0.5M);
            //}

        }
    }
}