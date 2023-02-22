using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Strategy
{
    public interface IPriceCalculationStategy
    {
        double CalculatePrice(Order order);
    }
}
