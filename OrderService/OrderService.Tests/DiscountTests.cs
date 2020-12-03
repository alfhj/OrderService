using NUnit.Framework;
using OrderService.Calculation;
using OrderService.Data;
using OrderService.Entities;

namespace OrderService.Tests
{
	public class DiscountTests
	{
		private static object[] _productCases =
		{
			new object[] {TestProducts.MotorBasic, 1, 1000M},
			new object[] {TestProducts.MotorSuper, 1, 2000M},
			new object[] {TestProducts.DisabilityBasic, -10, 0M},
			new object[] {TestProducts.DisabilitySuper, 1, 2900M}
		};

		private readonly PriceCalculator _priceCalculator;

		public DiscountTests()
		{
			_priceCalculator = new PriceCalculator(new InMemoryTaxRepository());
		}

		[Test]
		[TestCaseSource(nameof(_productCases))]
		public void TestPriceCalculation(Product product, int quantity, decimal expectedSubTotal)
		{
			Order order = new Order("Test Company");
			order.AddLine(new OrderLine(product, quantity));

			CalculatedOrder calculatedOrder = _priceCalculator.CalculatePrice(order);

			Assert.AreEqual(expectedSubTotal, calculatedOrder.Subtotal);
		}
	}
}