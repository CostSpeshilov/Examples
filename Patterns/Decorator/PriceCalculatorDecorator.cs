using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public abstract class PriceCalculatorDecorator : PriceCalculator
    {
        // декорируемый объект
        protected readonly PriceCalculator decoratee;

        public PriceCalculatorDecorator(PriceCalculator decoratee)
        {
            this.decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }
    }
}
