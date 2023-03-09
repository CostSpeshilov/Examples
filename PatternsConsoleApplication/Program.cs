using Patterns;
using Patterns.Decorator;
using Patterns.Observer;
using Patterns.Observer.Events;
using Patterns.Strategy;
using Patterns.Strategy.Delegates;
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
            DeliveryService NskDelivery = new DeliveryService(new WeightPriceCalculationStrategy(10));

            Console.WriteLine($"price n = {NskDelivery.CalculatePrice(order)}");


            DeliveryService BerdskDelivery = new DeliveryService(new VolumePriceCalculationStrategy(15));


            Console.WriteLine($"price b = {BerdskDelivery.CalculatePrice(order)}");
            #endregion


            #region StrategyDelegates

            Order order1 = new Order() { Weight = 10, Height = 1, Lenght = 2, Width = 3 };
            DeliveryServiceDelegate NskDelivery1 = new DeliveryServiceDelegate((order) => order.Weight * 10);

            Console.WriteLine($"price n = {NskDelivery.CalculatePrice(order)}");


            DeliveryServiceDelegate BerdskDelivery1 = new DeliveryServiceDelegate((order) => order.Width * order.Height * order.Lenght * 12);


            Console.WriteLine($"price b = {BerdskDelivery.CalculatePrice(order)}");
            #endregion

            #region Decorators

            PriceCalculator priceCalculator = new PriceCalculator();

            PriceCalculator weightCalc = new WeightPriceDecorator(priceCalculator);

            PriceCalculator volumeCalc = new VolumeDecorator(priceCalculator);

            PriceCalculator volumeRegularCalc = new SaleClientDecorator(volumeCalc, 0.9);

            PriceCalculator volumeRegularEveningCalc = new SaleClientDecorator(volumeRegularCalc, 1.09);

            Console.WriteLine($"1 PC = {priceCalculator.CalculatePrice(order)}");
            Console.WriteLine($"2 Weight = {weightCalc.CalculatePrice(order)}");
            Console.WriteLine($"3 volume = {volumeCalc.CalculatePrice(order)}");
            Console.WriteLine($"3 volume reg = {volumeRegularCalc.CalculatePrice(order)}");
            Console.WriteLine($"3 volume reg eve = {volumeRegularEveningCalc.CalculatePrice(order)}");
            Console.WriteLine($"3 volume reg = {volumeRegularCalc.CalculatePrice(order)}");
            #endregion

            #region Observers

            IProgressObserver progressObserver = new WordCountProgressObserver(ConsoleColor.Red);
            IProgressObserver progressObserver1 = new WordCountProgressObserver(ConsoleColor.Green);
            WordCounter wc = new WordCounter();
            wc.AddObserver(progressObserver);
            wc.AddObserver(progressObserver1);
            wc.CountWords(@"H:\");


            // События
            WordCounterEvents wordCounterEvents = new WordCounterEvents();
            // Подписка на событие
            wordCounterEvents.ProgressNotified += EventObserver.WordCounterEvents_ProgressNotified;
            wordCounterEvents.CountWords(@"H:\");
            // Отписка от события
            wordCounterEvents.ProgressNotified -= EventObserver.WordCounterEvents_ProgressNotified;

            #endregion
            Console.ReadLine();
        }
    }
}
