using System.Collections.Generic;

namespace OrderService.Entities
{
    public class Order
    {
        public Order(string company)
        {
            Company = company;
            OrderLines = new List<OrderLine>();
        }

        public string Company { get; }
        public IList<OrderLine> OrderLines { get; }

        public void AddLine(OrderLine orderLine)
        {
	        OrderLines.Add(orderLine);
        }
    }
}