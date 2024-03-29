﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    internal class MaxWeigthVolumeStrategy
        : IPriceCalculationStategy
    {
        private readonly int _priceForKg;

        public MaxWeigthVolumeStrategy(int priceForKg, int priceForCubicMeter)
        {
            _priceForKg = priceForKg;
            _priceForCubicMeter = priceForCubicMeter;
        }

        private readonly int _priceForCubicMeter;

        public double CalculatePrice(Order order)
        {
            double weightPrice = order.Weight * _priceForKg;
            double volumePrice = order.Lenght * order.Width * order.Height * _priceForCubicMeter;
            return Math.Max(weightPrice, volumePrice);
        }
    }
}
