using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderService.Entities;

namespace OrderService.ReceiptFormats
{
	public class HtmlReceiptGenerator : TemplateReceiptGenerator
	{
		public override string PrintHeader(string company)
		{
			return $"<html><body><h1>Order receipt for '{company}'</h1>";
		}

		public override string PrintOrderLines(IEnumerable<CalculatedOrderLine> orderLines)
		{
			IEnumerable<CalculatedOrderLine> lines = orderLines.ToList();
			if (!lines.Any()) return "";

			StringBuilder builder = new StringBuilder();
			builder.Append("<ul>");
			foreach (CalculatedOrderLine line in lines)
			{
				builder.Append($"<li>{line.Quantity} x {line.Product} = {line.Price:C}</li>");
			}
			builder.Append("</ul>");

			return builder.ToString();
		}

		public override string PrintFooter(CalculatedOrder calculatedOrder)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append($"<h3>Subtotal: {calculatedOrder.Subtotal:C}</h3>");
			builder.Append($"<h3>MVA: {calculatedOrder.MVA:C}</h3>");
			builder.Append($"<h2>Total: {calculatedOrder.Total:C}</h2>");
			builder.Append("</body></html>");
			return builder.ToString();
		}
	}
}
