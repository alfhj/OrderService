namespace OrderService.DiscountRules
{
    public class FiftyPercent : BaseDiscount
    {
        public override decimal CalculateDiscount(OrderLine orderLine)
        {
            return orderLine.TotalPrice * .5M;
        }

        public override bool IsMatch(OrderLine orderLine)
        {
            return orderLine.Quantity >= 10;
        }
    }
}