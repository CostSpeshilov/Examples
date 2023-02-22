using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public class SaleClientDecorator : PriceCalculatorDecorator
    {
        private readonly double _salePercent;

        public SaleClientDecorator(PriceCalculator decoratee, double salePercent) : base(decoratee)
        {
            _salePercent = salePercent;
        }

        // обязательно вызываем метод у декорируемого объекта. 
        // дополняем деятельность декорируемого объекта новой функциональностью
        public override double CalculatePrice(Order order)
        {
            return decoratee.CalculatePrice(order) * _salePercent;
        }
    }
}
