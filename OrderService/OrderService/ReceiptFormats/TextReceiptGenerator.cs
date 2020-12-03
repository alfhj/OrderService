using System;
using System.Collections.Generic;
using System.Text;
using OrderService.Entities;

namespace OrderService.ReceiptFormats
{
	public class TextReceiptGenerator : TemplateReceiptGenerator
	{
		public override string PrintHeader(string company)
		{
			return $"Order receipt for '{company}'{Environment.NewLine}";
		}

		public override string PrintOrderLines(IEnumerable<CalculatedOrderLine> orderLines)
		{
			StringBuilder builder = new StringBuilder();
			foreach (CalculatedOrderLine line in orderLines)
			{
				builder.AppendLine($"\t{line.Quantity} x {line.Product} = {line.Price:C}");
			}

			return builder.ToString();
		}

		public override string PrintFooter(CalculatedOrder calculatedOrder)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine($"Subtotal: {calculatedOrder.Subtotal:C}");
			builder.AppendLine($"MVA: {calculatedOrder.MVA:C}");
			builder.Append($"Total: {calculatedOrder.Total:C}");
			return builder.ToString();
		}
	}
}
