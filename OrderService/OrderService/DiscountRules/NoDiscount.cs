﻿namespace OrderService.DiscountRules
{
    public class NoDiscount : BaseDiscount
    {
        public override decimal CalculateDiscount(OrderLine orderLine)
        {
            return orderLine.TotalPrice;
        }

        public override bool IsMatch(OrderLine orderLine)
        {
            return true;
        }
    }
}