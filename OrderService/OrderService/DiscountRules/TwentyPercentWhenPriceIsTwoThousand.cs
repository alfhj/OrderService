namespace OrderService.DiscountRules
{
    public class TwentyPercentWhenPriceIsTwoThousand : BaseDiscount
    {
        public override decimal CalculateDiscount(OrderLine orderLine)
        {
            return orderLine.TotalPrice * .9M;
        }

        public override bool IsMatch(OrderLine orderLine)
        {
            return (orderLine.Quantity >= 3 && orderLine.Product.Price == Product.Prices.TwoThousand);
        }
    }
}