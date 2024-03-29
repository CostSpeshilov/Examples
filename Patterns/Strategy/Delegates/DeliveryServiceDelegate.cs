﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Strategy.Delegates
{
    public class DeliveryServiceDelegate
    {
        readonly Func<Order, double> _calculatePrice;

        int orderCOunt = 0;

        public DeliveryServiceDelegate(
            Func<Order, double> calculatePrice)
        {
            _calculatePrice = calculatePrice;
        }

        public double CalculatePrice(Order order)
        {
            return _calculatePrice(order);
        }
    }
}
