using System.Collections.Generic;
using System.Linq;
using OrderService.Data;
using OrderService.Entities;

namespace OrderService.Calculation
{
	public class PriceCalculator
	{
		private readonly DiscountRuleEngine _ruleEngine;
		private readonly ITaxRepository _taxRepository; 

		public PriceCalculator(ITaxRepository taxRepository)
		{
			_taxRepository = taxRepository;

			DiscountRuleEngine.Builder builder = new DiscountRuleEngine.Builder();
			builder.WithProductBasedQuantityDiscount(ProductType.Car, ProductClass.Basic, 5, 0.1M);
			builder.WithProductBasedQuantityDiscount(ProductType.Car, ProductClass.Super, 3, 0.2M);
			builder.WithQuantityDiscount(10, 0.5M);
			builder.WithFlatDiscount(ProductType.Disability, ProductClass.Super, 100);
			_ruleEngine = builder.Build();
		}

		public CalculatedOrder CalculatePrice(Order order)
		{
			CalculatedOrder calculatedOrder = new CalculatedOrder
			{
				Company = order.Company,
				OrderLines = CalculateOrderLines(order.OrderLines)
			};
			calculatedOrder.Subtotal = calculatedOrder.OrderLines.Sum(orderLine => orderLine.Price);
			calculatedOrder.MVA = calculatedOrder.Subtotal * _taxRepository.GetTax();
			calculatedOrder.Total = calculatedOrder.Subtotal + calculatedOrder.MVA;

			return calculatedOrder;
		}

		private IEnumerable<CalculatedOrderLine> CalculateOrderLines(IEnumerable<OrderLine> lines)
		{
			return lines.Select(CalculateOrderLines);
		}

		private CalculatedOrderLine CalculateOrderLines(OrderLine line)
		{
			return new CalculatedOrderLine
			{
				Product = line.Product.ToString(),
				Quantity = line.Quantity,
				Price = line.Quantity * line.Product.Price - _ruleEngine.GetDiscount(line)
			};
		}
	}
}
