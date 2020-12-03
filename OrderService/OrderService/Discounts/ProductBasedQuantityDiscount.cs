using OrderService.Entities;

namespace OrderService.Discounts
{
	public class ProductBasedQuantityDiscount : BaseDiscount
	{
		private readonly ProductType _allowedProductType;
		private readonly ProductClass _allowProductClass;
		private readonly int _quantityNeeded;
		private readonly decimal _factor;

		public ProductBasedQuantityDiscount(ProductType allowedProductType, ProductClass allowProductClass, int quantityNeeded, decimal factor)
		{
			_allowedProductType = allowedProductType;
			_allowProductClass = allowProductClass;
			_quantityNeeded = quantityNeeded;
			_factor = factor;
		}

		public override bool IsMatch(OrderLine orderLine)
		{
			return orderLine.Product.ProductType == _allowedProductType
				   && orderLine.Product.ProductClass == _allowProductClass
				   && orderLine.Quantity >= _quantityNeeded;
		}

		public override decimal CalculateDiscount(OrderLine orderLine)
		{
			return orderLine.Quantity * orderLine.Product.Price * _factor;
		}
	}
}