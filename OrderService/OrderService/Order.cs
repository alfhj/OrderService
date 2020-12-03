using System.Collections.Generic;
using OrderService.DiscountRules;

namespace OrderService
{
    // fjerne Prices klasse?
    // produkt type

    public class Order
    {
        private readonly DiscountEngine _discountEngine;
        private readonly IList<OrderLine> _orderLines = new List<OrderLine>();
        public IEnumerable<OrderLine> OrderLines => _orderLines;

        public Order(string company)
        {
            _discountEngine = new DiscountEngine.Builder()
                .WithHundreKroner()
                .TenPercent()
                .TwentyPercent()
                .FiftyPercent()
                .Build();

            Company = company;
        }

        public string Company { get; set; }

        public void AddLine(OrderLine orderLine)
        {
            _discountEngine.ApplyDiscount(orderLine);
            _orderLines.Add(orderLine);
        }
    }
}