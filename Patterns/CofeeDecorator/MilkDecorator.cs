using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.CofeeDecorator
{
    public class MilkDecorator
        : CoffeeDecorator
    {
        public MilkDecorator(Coffee decoratee) : base(decoratee)
        {
        }

        public override int Price => _decoratee.Price * 2;
        public override string GetDescription()
        {
            return _decoratee.GetDescription() + " cо сливками";
        }
    }
}
