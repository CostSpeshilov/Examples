using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public class EveningPriceDecorator: PriceCalculatorDecorator
    {
        public EveningPriceDecorator(PriceCalculator decoratee) : base(decoratee)
        {
        }

        public override double CalculatePrice(Order order)
        {
            return decoratee.CalculatePrice(order) * 1.09;
        }
    }
}
