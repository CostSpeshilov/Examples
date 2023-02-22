using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Strategy
{
    public class VolumePriceCalculationStrategy
        : IPriceCalculationStategy
    {
        private readonly double _priceForCubicMeter;

        public VolumePriceCalculationStrategy(double priceForCubicMeter)
        {
            _priceForCubicMeter = priceForCubicMeter;
        }

        public double CalculatePrice(Order order)
        {
            double volume = order.Lenght * order.Width * order.Height;
            return volume * _priceForCubicMeter;
        }
    }
}
