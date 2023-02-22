using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Strategy
{
    public class WeightPriceCalculationStrategy
        : IPriceCalculationStategy
    {
        private readonly int _priceForKg;

        public WeightPriceCalculationStrategy(int priceForKg)
        {
            _priceForKg = priceForKg;
        }

        public double CalculatePrice(Order order)
        {
            return order.Weight * _priceForKg; ;
        }
    }
}
