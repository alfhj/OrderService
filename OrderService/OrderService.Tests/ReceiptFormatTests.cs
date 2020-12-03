using System.Globalization;
using NUnit.Framework;
using OrderService.Calculation;
using OrderService.Data;
using OrderService.Entities;
using OrderService.ReceiptFormats;

namespace OrderService.Tests
{
    [TestFixture]
    public class ReceiptFormatTests
    {
        private readonly PriceCalculator _priceCalculator;

        public ReceiptFormatTests()
        {
	        _priceCalculator = new PriceCalculator(new InMemoryTaxRepository());
        }

        [Test]
        public void can_generate_html_receipt_for_motor_basic()
        {
            Order order = new Order("Test Company");
            order.AddLine(new OrderLine(TestProducts.MotorBasic, 1));

            CalculatedOrder calculatedOrder = _priceCalculator.CalculatePrice(order);
            string actual = ReceiptGenerator.GenerateReceipt(calculatedOrder, ReceiptType.Html);

            string expected =  $"<html><body><h1>Order receipt for 'Test Company'</h1><ul><li>1 x Car Insurance Basic = kr 1{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00</li></ul><h3>Subtotal: kr 1{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00</h3><h3>MVA: kr 250,00</h3><h2>Total: kr 1{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}250,00</h2></body></html>";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void can_generate_html_receipt_for_motor_super()
        {
            Order order = new Order("Test Company");
            order.AddLine(new OrderLine(TestProducts.MotorSuper, 1));

            CalculatedOrder calculatedOrder = _priceCalculator.CalculatePrice(order);
            string actual = ReceiptGenerator.GenerateReceipt(calculatedOrder, ReceiptType.Html);

            string expected = $"<html><body><h1>Order receipt for 'Test Company'</h1><ul><li>1 x Car Insurance Super = kr 2{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00</li></ul><h3>Subtotal: kr 2{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00</h3><h3>MVA: kr 500,00</h3><h2>Total: kr 2{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}500,00</h2></body></html>";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void can_generate_receipt_for_motor_basic()
        {
            Order order = new Order("Test Company");
            order.AddLine(new OrderLine(TestProducts.MotorBasic, 1));

            CalculatedOrder calculatedOrder = _priceCalculator.CalculatePrice(order);
            string actual = ReceiptGenerator.GenerateReceipt(calculatedOrder, ReceiptType.Text);

            string expected = $"Order receipt for 'Test Company'\r\n\t1 x Car Insurance Basic = kr 1{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00\r\nSubtotal: kr 1{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00\r\nMVA: kr 250,00\r\nTotal: kr 1{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}250,00";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void can_generate_receipt_for_motor_super()
        {
            Order order = new Order("Test Company");
            order.AddLine(new OrderLine(TestProducts.MotorSuper, 1));

            CalculatedOrder calculatedOrder = _priceCalculator.CalculatePrice(order);
            string actual = ReceiptGenerator.GenerateReceipt(calculatedOrder, ReceiptType.Text);

            string expected = $"Order receipt for 'Test Company'\r\n\t1 x Car Insurance Super = kr 2{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00\r\nSubtotal: kr 2{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}000,00\r\nMVA: kr 500,00\r\nTotal: kr 2{NumberFormatInfo.CurrentInfo.NumberGroupSeparator}500,00";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void can_generate_json_receipt_for_disability_basic()
        {
            Order order = new Order("Test Company");
            order.AddLine(new OrderLine(TestProducts.DisabilityBasic, 2));

            CalculatedOrder calculatedOrder = _priceCalculator.CalculatePrice(order);
            string actual = ReceiptGenerator.GenerateReceipt(calculatedOrder, ReceiptType.Json);

            string expected = "{\"Company\":\"Test Company\",\"OrderLines\":[{\"Quantity\":2,\"Product\":\"Disability Insurance Basic\",\"Price\":2000.0}],\"Subtotal\":2000.0,\"MVA\":500.00,\"Total\":2500.00}";

            Assert.AreEqual(expected, actual);
        }
    }
}