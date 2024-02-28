using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.CofeeDecorator
{
    public abstract class CoffeeDecorator
        :Coffee
    {
        protected readonly Coffee _decoratee;

        public CoffeeDecorator(Coffee decoratee)
        {
            _decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }


    }
}
