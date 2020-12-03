using System.Collections.Generic;

namespace OrderService.DiscountRules
{
    public class DiscountEngine
    {
        private readonly IList<BaseDiscount> _rules;

        private DiscountEngine(IList<BaseDiscount> rules)
        {
            _rules = rules;
        }

        public void ApplyDiscount(Product product)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsMatch(product))
                {
                    rule.UpdatePrice(product);
                    break;
                }
            }
        }

        public class Builder
        {
            private IList<BaseDiscount> _discounts = new List<BaseDiscount>();

            public Builder WithHundreKroner()
            {
                _discounts.Add(new HundreKronerDiscount());
                return this;
            }

            public RuleEngineBuilder Build()
            {
                _builderRules.Add(new NoDiscount());
                return new RuleEngineBuilder(_discounts);
            }
        }
    }
}