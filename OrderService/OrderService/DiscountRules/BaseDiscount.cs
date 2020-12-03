namespace OrderService.DiscountRules
{
    public abstract class BaseDiscount
    {
        public abstract decimal CalculateDiscount(OrderLine orderLine);

        public abstract bool IsMatch(OrderLine orderLine);
    }
}