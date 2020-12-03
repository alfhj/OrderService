namespace OrderService.DiscountRules
{
    public class TenPercent : BaseDiscount
    {
        public override void ApplyDiscount(OrderLine orderLine)
        {
            orderLine.TotalPrice * 0.9M;
        }

        public override bool IsMatch(OrderLine orderLine)
        {
            if (orderLine.Quan = 100)
            {
                return true;
            }
        }
    }
}