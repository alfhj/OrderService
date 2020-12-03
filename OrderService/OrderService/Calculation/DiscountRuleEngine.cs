using System.Collections.Generic;
using System.Linq;
using OrderService.Discounts;
using OrderService.Entities;

namespace OrderService.Calculation
{
	public class DiscountRuleEngine
	{
		private readonly IList<BaseDiscount> _discounts;

		private DiscountRuleEngine(IList<BaseDiscount> discounts)
		{
			_discounts = discounts;
		}

		public decimal GetDiscount(OrderLine orderLine)
		{
			return _discounts
				.Where(discount => discount.IsMatch(orderLine))
				.Max(discount => discount.CalculateDiscount(orderLine));
		}

		public class Builder
		{
			private readonly IList<BaseDiscount> _builderDiscounts = new List<BaseDiscount>();

			public Builder WithQuantityDiscount(int quantityNeeded, decimal factor)
			{
				_builderDiscounts.Add(new QuantityDiscount(quantityNeeded, factor));
				return this;
			}

			public Builder WithProductBasedQuantityDiscount(ProductType productType, ProductClass productClass, int quantityNeeded, decimal factor)
			{
				_builderDiscounts.Add(new ProductBasedQuantityDiscount(productType, productClass, quantityNeeded, factor));
				return this;
			}

			public Builder WithFlatDiscount(ProductType productType, ProductClass productClass, decimal amount)
			{
				_builderDiscounts.Add(new FlatDiscount(productType, productClass, amount));
				return this;
			}

			public DiscountRuleEngine Build()
			{
				_builderDiscounts.Add(new NoDiscount());

				return new DiscountRuleEngine(_builderDiscounts);
			}
		}
	}
}