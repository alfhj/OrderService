using System.Linq;

namespace OrderService.Receipts
{
    public class TextReceipt : Receipt
    {
        public TextReceipt(Order order) : base(order)
        {
        }

        public override void GenerateReceipt()
        {
            Builder.AppendLine($"Order receipt for '{Order.Company}'");
            Builder.AppendLine();

            Order.OrderLines.Select(orderLine
                => Builder.AppendLine(
                    $"\t{orderLine.Quantity} x {orderLine.Product.ProductType} {orderLine.Product.ProductName} = {orderLine.TotalPrice:C}"));

            Builder.AppendLine($"Subtotal: {Subtotal:C}");
            Builder.AppendLine($"MVA: {Tax:C}");
            Builder.Append($"Total: {Total:C}");
        }
    }
}