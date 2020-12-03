using OrderService.Entities;

namespace OrderService.Discounts
{
	public class NoDiscount : BaseDiscount
	{
		public override bool IsMatch(OrderLine orderLine)
		{
			return true;
		}

		public override decimal CalculateDiscount(OrderLine orderLine)
		{
			return 0;
		}
	}
}
