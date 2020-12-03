namespace OrderService.DiscountRules
{
    public class TenPercentWhenPriceIsThousand : BaseDiscount
    {
        public override decimal CalculateDiscount(OrderLine orderLine)
        {
            return orderLine.TotalPrice * .9M;
        }

        public override bool IsMatch(OrderLine orderLine)
        {
            return orderLine.Quantity >= 5 && orderLine.Product.Price == Product.Prices.OneThousand;

        }
    }
}