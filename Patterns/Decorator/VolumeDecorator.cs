using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public class VolumeDecorator : PriceCalculatorDecorator
    {
        public VolumeDecorator(PriceCalculator decoratee) : base(decoratee)
        {
        }

        public override double CalculatePrice(Order order)
        {
            return decoratee.CalculatePrice(order) + order.Height * order.Width * order.Lenght * 70;
        }
    }
}
