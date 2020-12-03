using OrderService.Entities;

namespace OrderService.Discounts
{
	public class FlatDiscount : BaseDiscount
	{
		private readonly ProductType _allowedProductType;
		private readonly ProductClass _allowProductClass;
		private readonly decimal _amount;

		public FlatDiscount(ProductType allowedProductType, ProductClass allowProductClass, decimal amount)
		{
			_allowedProductType = allowedProductType;
			_allowProductClass = allowProductClass;
			_amount = amount;
		}

		public override bool IsMatch(OrderLine orderLine)
		{
			return orderLine.Product.ProductType == _allowedProductType
			       && orderLine.Product.ProductClass == _allowProductClass;
		}

		public override decimal CalculateDiscount(OrderLine orderLine)
		{
			return _amount;
		}
	}
}
