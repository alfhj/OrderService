using System;
using OrderService.Entities;

namespace OrderService.ReceiptFormats
{
	public static class ReceiptGenerator
	{
		public static string GenerateReceipt(CalculatedOrder calculatedOrder, ReceiptType receiptType)
		{
			return receiptType switch
			{
				ReceiptType.Text => new TextReceiptGenerator().GenerateReceipt(calculatedOrder),
				ReceiptType.Html => new HtmlReceiptGenerator().GenerateReceipt(calculatedOrder),
				ReceiptType.Json => new JsonReceiptGenerator().GenerateReceipt(calculatedOrder),
				_ => throw new ArgumentOutOfRangeException(nameof(receiptType), receiptType, null)
			};
		}
	}
}
