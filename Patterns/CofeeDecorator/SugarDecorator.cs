using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.CofeeDecorator
{
    public class SugarDecorator
        : CoffeeDecorator
    {
        public SugarDecorator(Coffee decoratee) : base(decoratee)
        {
        }

        public override int Price => _decoratee.Price + 10;

        public override string GetDescription()
        {
            return _decoratee.GetDescription() + " с сахаром";
        }
    }
}
