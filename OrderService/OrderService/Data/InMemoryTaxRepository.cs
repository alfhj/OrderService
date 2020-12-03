namespace OrderService.Data
{
	public class InMemoryTaxRepository : ITaxRepository
	{
		public decimal GetTax() => 0.25M;
	}
}
