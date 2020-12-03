namespace OrderService.DiscountRules
{
    public class HoundredKronerDiscount : BaseDiscount
    {
        public override void ApplyDiscount(OrderLine orderLine)
        {
            orderLine.TotalPrice -= 100;
        }

        public override bool IsMatch(OrderLine orderLine)
        {
            if (orderLine.Discount = 100)
            {
                return true;
            }
        }
    }
}