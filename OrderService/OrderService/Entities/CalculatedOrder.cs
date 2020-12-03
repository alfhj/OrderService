using System.Collections.Generic;

namespace OrderService.Entities
{
	public class CalculatedOrder
	{
		public string Company { get; set; }
		public IEnumerable<CalculatedOrderLine> OrderLines { get; set; }
		public decimal Subtotal { get; set; }
		public decimal MVA { get; set; }
		public decimal Total { get; set; }
	}
}
