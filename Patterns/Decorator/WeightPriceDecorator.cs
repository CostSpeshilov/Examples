using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public class WeightPriceDecorator : PriceCalculatorDecorator
    {
        public WeightPriceDecorator(PriceCalculator decoratee) : base(decoratee)
        {
        }

        public override double CalculatePrice(Order order)
        {
            return decoratee.CalculatePrice(order) + order.Weight * 50;
        }
    }
}
