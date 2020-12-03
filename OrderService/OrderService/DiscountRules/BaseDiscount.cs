namespace OrderService.DiscountRules
{
    public abstract class BaseDiscount
    {
        public void UpdatePrice(OrderLine orderLine)
        {
            ApplyDiscount(orderLine);
        }

        public abstract void ApplyDiscount(OrderLine orderLine);

        public abstract bool IsMatch(OrderLine orderLine);
    }
}