using OrderService.Entities;

namespace OrderService.Tests
{
	public static class TestProducts
	{
		public static readonly Product MotorSuper = new Product(ProductType.Car, ProductClass.Super, 2000);
		public static readonly Product MotorBasic = new Product(ProductType.Car, ProductClass.Basic, 1000);
		public static readonly Product DisabilityBasic = new Product(ProductType.Disability, ProductClass.Basic, 1000);
		public static readonly Product DisabilitySuper = new Product(ProductType.Disability, ProductClass.Super, 3000);
	}
}
