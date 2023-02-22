using System;

namespace Patterns.Strategy
{
    public class DeliveryService
    {
        private readonly IPriceCalculationStategy priceCalculationStategy;

        public DeliveryService(IPriceCalculationStategy priceCalculationStategy)
        {
            this.priceCalculationStategy = priceCalculationStategy ?? throw new ArgumentNullException(nameof(priceCalculationStategy));
        }

        public double CalculatePrice(Order order)
        {
            return priceCalculationStategy.CalculatePrice(order);
        }
    }
}