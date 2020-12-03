using System.Collections.Generic;
using System.Linq;

namespace OrderService.DiscountRules
{
    public class DiscountEngine
    {
        private readonly IList<BaseDiscount> _rules;

        private DiscountEngine(IList<BaseDiscount> rules)
        {
            _rules = rules;
        }

        public void ApplyDiscount(OrderLine orderLine)
        {
            var newPrice = _rules
                .Where(rule => rule.IsMatch(orderLine))
                .Min(rule => rule.CalculateDiscount(orderLine));

            orderLine.TotalPrice = newPrice;
        }

        public class Builder
        {
            private readonly IList<BaseDiscount> _discounts = new List<BaseDiscount>();

            public Builder WithHundreKroner()
            {
                _discounts.Add(new HoundredKronerDiscount());
                return this;
            }

            public Builder TenPercent()
            {
                _discounts.Add(new TenPercentWhenPriceIsThousand());
                return this;
            }

            public Builder TwentyPercent()
            {
                _discounts.Add(new TwentyPercentWhenPriceIsTwoThousand());
                return this;
            }

            public Builder FiftyPercent()
            {
                _discounts.Add(new FiftyPercent());
                return this;
            }

            public DiscountEngine Build()
            {
                _discounts.Add(new NoDiscount());
                return new DiscountEngine(_discounts);
            }
        }
    }
}