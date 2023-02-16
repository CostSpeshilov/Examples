using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Delegates
{
    public class DeliveryServiceDelegate
    {
        readonly Func<Order, double> _calculatePrice;

        public DeliveryServiceDelegate(Func<Order, double> calculatePrice)
        {
            _calculatePrice = calculatePrice;
        }

        public double CalculatePrice(Order order)
        {
            return _calculatePrice(order);
        }
    }
}
