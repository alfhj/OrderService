namespace OrderService.Entities
{
	public class CalculatedOrderLine
	{
		public int Quantity { get; set; }
		public string Product { get; set; }
		public decimal Price { get; set; }
	}
}
