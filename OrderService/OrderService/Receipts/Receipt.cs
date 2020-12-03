using System.Linq;
using System.Text;

namespace OrderService.Receipts
{
    public abstract class Receipt
    {
        protected readonly Order Order;
        protected readonly StringBuilder Builder = new StringBuilder();

        public decimal Subtotal { get; }
        public decimal Tax => Subtotal * (decimal)Product.Prices.TaxRate;
        public decimal Total => Subtotal + Tax;

        protected Receipt(Order order)
        {
            Order = order;
            Subtotal = CalculateSubtotal();
        }

        private decimal CalculateSubtotal() => Order.OrderLines
            .Sum(orderLine => orderLine.TotalPrice);

        public abstract void GenerateReceipt();

        public override string ToString()
        {
            return Builder.ToString();
        }
    }
}