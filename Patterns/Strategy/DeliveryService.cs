using System;

namespace Patterns.Strategy
{
    public class DeliveryService
    {
        private IPriceCalculationStategy priceCalculationStategy;

        public DeliveryService(IPriceCalculationStategy priceCalculationStategy)
        {
            this.PriceCalculationStategy = priceCalculationStategy ?? throw new ArgumentNullException(nameof(priceCalculationStategy));
        }

        public IPriceCalculationStategy PriceCalculationStategy { get => priceCalculationStategy; set => priceCalculationStategy = value; }

        public double CalculatePrice(Order order)
        {
            var result = PriceCalculationStategy.CalculatePrice(order);

            return result;
        }
    }
}