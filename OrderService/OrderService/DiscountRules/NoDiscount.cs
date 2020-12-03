namespace OrderService.DiscountRules
{
    public class NoDiscount : BaseDiscount
    {
        public override void ApplyDiscount(OrderLine orderLine)
        {
            orderLine.TotalPrice = orderLine.TotalPrice;
        }

        public override bool IsMatch(OrderLine orderLine)
        {
            return true;
        }
    }
}