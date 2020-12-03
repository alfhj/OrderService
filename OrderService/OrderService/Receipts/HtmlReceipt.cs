using System.Linq;

namespace OrderService.Receipts
{
    public class HtmlReceipt : Receipt
    {
        public HtmlReceipt(Order order) : base(order)
        {
        }

        public override void GenerateReceipt()
        {
            Builder.Append($"<html><body><h1>Order receipt for '{Order.Company}'</h1>");
            Builder.Append($"<h3>Subtotal: {Subtotal:C}</h3>");

            if (Order.OrderLines.Any())
            {
                Builder.Append("<ul>");
                Order.OrderLines.Select(orderLine
                    => Builder.Append($"<li>{orderLine.Quantity} x {orderLine.Product.ProductType} {orderLine.Product.ProductName} = {orderLine.TotalPrice:C}</li>"));
                Builder.Append("</ul>");
            }

            Builder.Append($"<h3>MVA: {Tax:C}</h3>");
            Builder.Append($"<h2>Total: {Total:C}</h2>");
            Builder.Append("</body></html>");
        }
    }
}