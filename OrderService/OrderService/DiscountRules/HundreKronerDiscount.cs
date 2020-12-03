namespace OrderService.DiscountRules
{
    public class HoundredKronerDiscount : BaseDiscount
    {
        public override decimal CalculateDiscount(OrderLine orderLine)
        {
            return orderLine.TotalPrice - 100;
        }

        public override bool IsMatch(OrderLine orderLine)
        {
            return orderLine.Discount == 100;
        }
    }
}