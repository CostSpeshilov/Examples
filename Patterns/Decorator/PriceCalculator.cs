using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public class PriceCalculator
    {
        public virtual double CalculatePrice(Order order)
        {
            return 10;
        }
    }
}
