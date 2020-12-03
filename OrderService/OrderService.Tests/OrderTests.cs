using System.Globalization;
using NUnit.Framework;
using OrderService.DiscountRules;
using OrderService.Receipts;

namespace OrderService.Tests
{
    [TestFixture]
    public class OrderTests
    {
        private static readonly Product MotorSuper = new Product("Car Insurance", "Super", Product.Prices.TwoThousand);
        private static readonly Product MotorBasic = new Product("Car Insurance", "Basic", Product.Prices.OneThousand);
        private static readonly Product Disability = new Product("Disability", "Basic", Product.Prices.OneThousand);


        [Test]
        public void Can_generate_html_receipt_for_motor_basic()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorBasic, 1, 0));
            var actual = new HtmlReceipt(order).ToString();

            var expected =
                $"<html><body><h1>Order receipt for 'Test Company'</h1><ul><li>1 x Car Insurance Basic = kr 1{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00</li></ul><h3>Subtotal: kr 1{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00</h3><h3>MVA: kr 250,00</h3><h2>Total: kr 1{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}250,00</h2></body></html>";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_generate_html_receipt_for_motor_super()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorSuper, 1, 0));
            var actual = new HtmlReceipt(order).ToString();

            var expected =
                $"<html><body><h1>Order receipt for 'Test Company'</h1><ul><li>1 x Car Insurance Super = kr 2{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00</li></ul><h3>Subtotal: kr 2{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00</h3><h3>MVA: kr 500,00</h3><h2>Total: kr 2{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}500,00</h2></body></html>";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_generate_receipt_for_motor_basic()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorBasic, 1, 0));
            var actual = new TextReceipt(order).ToString();
            var expected =
                $"Order receipt for 'Test Company'\r\n\t1 x Car Insurance Basic = kr 1{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00\r\nSubtotal: kr 1{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00\r\nMVA: kr 250,00\r\nTotal: kr 1{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}250,00";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_generate_receipt_for_motor_super()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorSuper, 1, 0));
            var actual = new TextReceipt(order).ToString();
            var expected =
                $"Order receipt for 'Test Company'\r\n\t1 x Car Insurance Super = kr 2{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00\r\nSubtotal: kr 2{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00\r\nMVA: kr 500,00\r\nTotal: kr 2{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}500,00";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_generate_json_receipt_for_motor_basic()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorBasic, 1, 0));
            var actual = new JsonReceipt(order).ToString();
            var expected = "{\"Company\":\"Test Company\",\"OrderLines\":[{\"Quantity\":1,\"ProductType\":\"Car Insurance\",\"ProductName\":\"Basic\",\"TotalPrice\":1000}],\"Subtotal\":1000,\"MVA\":250,\"Total\":1250}";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_generate_json_receipt_for_motor_super()
        {
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(MotorSuper, 1, 0));
            var actual = new JsonReceipt(order).ToString();
            var expected = "{\"Company\":\"Test Company\",\"OrderLines\":[{\"Quantity\":1,\"ProductType\":\"Car Insurance\",\"ProductName\":\"Super\",\"TotalPrice\":2000}],\"Subtotal\":2000,\"MVA\":500,\"Total\":2500}";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1, 1000, 100, 900)]
        [TestCase(1, 2000, 100, 1900)]
        [TestCase(2, 1000, 0, 2000)]
        [TestCase(10, 1000, 0, 9000)]
        [TestCase(11, 1000, 0, 5500)]
        [TestCase(2, 2000, 0, 4000)]
        [TestCase(10, 2000, 0, 18000)]
        [TestCase(11, 2000, 0, 11000)]
        public void TestDiscountPrice(int quantity, decimal price, int discount, decimal discountedPrice)
        {
            var engine = new DiscountEngine.Builder()
                .WithHundreKroner()
                .TenPercent()
                .TwentyPercent()
                .FiftyPercent()
                .Build();

            var expected = discountedPrice;
            decimal actual = 0;
            Product TestProduct = new Product("Test Insurance", "Test", price);
            var order = new Order("Test Company");
            order.AddLine(new OrderLine(TestProduct, quantity, discount));



            foreach (var line in order.OrderLines)
            {
                actual += line.TotalPrice;
                engine.ApplyDiscount(line);
            }


            Assert.AreEqual(expected, actual);
        }
    }
}