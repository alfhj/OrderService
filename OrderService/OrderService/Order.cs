using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderService
{
    // receipt klasse - sende inn order
    // Receipt factory
    // Slå sammen receipt generering
    // Decimal price
    // fjerne Prices klasse?
    // produkt type


    public class Order
    {
        private readonly DiscountEngine discountEngine;
        private readonly IList<OrderLine> _orderLines = new List<OrderLine>();
        public IEnumerable<OrderLine> OrderLines => _orderLines;

        public Order(string company)
        {
            discountEngine = new DiscountEngine.Builder()
                .HundreKronerDiscount();
            Company = company;
        }

        public string Company { get; set; }

        public void AddLine(OrderLine orderLine)
        {
            discountEngine.ApplyDiscound(orderLine);
            _orderLines.Add(orderLine);
        }
    }
}