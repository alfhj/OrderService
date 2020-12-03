using OrderService.Entities;

namespace OrderService.Discounts
{
	public class QuantityDiscount : BaseDiscount
	{
		private readonly int _quantityNeeded;
		private readonly decimal _factor;

		public QuantityDiscount(int quantityNeeded, decimal factor)
		{
			_quantityNeeded = quantityNeeded;
			_factor = factor;
		}

		public override bool IsMatch(OrderLine orderLine)
		{
			return orderLine.Quantity >= _quantityNeeded;
		}

		public override decimal CalculateDiscount(OrderLine orderLine)
		{
			return orderLine.Quantity * orderLine.Product.Price * _factor;
		}
	}
}