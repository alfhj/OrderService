using Newtonsoft.Json;
using OrderService.Entities;

namespace OrderService.ReceiptFormats
{
	public class JsonReceiptGenerator : IReceiptGenerator
	{
		public string GenerateReceipt(CalculatedOrder calculatedOrder)
		{
			return JsonConvert.SerializeObject(calculatedOrder);
		}
	}
}
