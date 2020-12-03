using OrderService.Entities;

namespace OrderService.Discounts
{
	public abstract class BaseDiscount
	{
		public abstract bool IsMatch(OrderLine orderLine);

		public abstract decimal CalculateDiscount(OrderLine orderLine);
	}
}
