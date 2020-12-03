using System.Collections.Generic;
using System.Text;
using OrderService.Entities;

namespace OrderService.ReceiptFormats
{
	public abstract class TemplateReceiptGenerator : IReceiptGenerator
	{
		public string GenerateReceipt(CalculatedOrder calculatedOrder)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(PrintHeader(calculatedOrder.Company));
			builder.Append(PrintOrderLines(calculatedOrder.OrderLines));
			builder.Append(PrintFooter(calculatedOrder));
			return builder.ToString();
		}

		public abstract string PrintHeader(string company);
		public abstract string PrintOrderLines(IEnumerable<CalculatedOrderLine> orderLines);
		public abstract string PrintFooter(CalculatedOrder calculatedOrder);
	}
}
