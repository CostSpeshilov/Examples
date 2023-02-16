using Patterns;
using Strategy;
using Strategy.Delegates;
using System;

namespace PatternsConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Builder
            //Console.WriteLine("Hello World!");

            //Product.ProductBuilder builder = Product.Builder;


            //Product product = builder.AddName("john")
            //    .AddOptionalProperty(8)
            //    .AddOptionalStringProperty("gg")
            //       .Build(); 
            #endregion

            #region Strategy

            Order order = new Order() { Weight = 10, Height = 1, Lenght = 2, Width = 3 };
            DeliveryService NskDelivery= new DeliveryService(new WeightPriceCalculationStrategy(10));

            Console.WriteLine($"price n = {NskDelivery.CalculatePrice(order)}");


            DeliveryService BerdskDelivery = new DeliveryService(new VolumePriceCalculationStrategy(15));


            Console.WriteLine($"price b = {BerdskDelivery.CalculatePrice(order)}");
            #endregion


            #region StrategyDelegates

            Order order1 = new Order() { Weight = 10, Height = 1, Lenght = 2, Width = 3 };
            DeliveryServiceDelegate  NskDelivery1 = new DeliveryServiceDelegate((order) => order.Weight * 10);

            Console.WriteLine($"price n = {NskDelivery.CalculatePrice(order)}");


            DeliveryServiceDelegate BerdskDelivery1 = new DeliveryServiceDelegate((order) => order.Width * order.Height * order.Lenght * 12 );


            Console.WriteLine($"price b = {BerdskDelivery.CalculatePrice(order)}");
            #endregion
            Console.ReadLine();
        }
    }
}
