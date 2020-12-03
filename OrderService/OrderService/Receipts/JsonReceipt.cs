using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace OrderService.Receipts
{
    public class JsonReceipt : Receipt
    {
        private record OrderLine(int Quantity, string ProductType, string ProductName, decimal TotalPrice);
        private record ReceiptObject(string Company, IEnumerable<OrderLine> OrderLines, decimal Subtotal, decimal MVA, decimal Total);

        public JsonReceipt(Order order) : base(order)
        {
            GenerateReceipt();
        }

        public sealed override void GenerateReceipt()
        {
            var orderLines = Order.OrderLines
                .Select(orderLine => new OrderLine(orderLine.Quantity, orderLine.Product.ProductType, orderLine.Product.ProductName, orderLine.TotalPrice));
            var receiptObject = new ReceiptObject(Order.Company, orderLines, Subtotal, Tax, Total);
            var receiptString = JsonSerializer.Serialize(receiptObject);

            Builder.Append(receiptString);
        }
    }
}