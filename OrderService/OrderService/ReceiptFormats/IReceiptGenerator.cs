using OrderService.Entities;

namespace OrderService.ReceiptFormats
{
	interface IReceiptGenerator
	{
		string GenerateReceipt(CalculatedOrder calculatedOrder);
	}
}
