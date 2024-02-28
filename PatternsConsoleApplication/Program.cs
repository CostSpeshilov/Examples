using Patterns;
using Patterns.CofeeDecorator;
using Patterns.Decorator;
using Patterns.Observer;
using Patterns.Observer.Events;
using Patterns.State;
using Patterns.Strategy;
using Patterns.Strategy.Delegates;
using Patterns.TemplateMethod;
using System;
using System.Collections.Generic;
using System.Linq;

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

            //#region Strategy

            //Order order = new Order() { Weight = 10, Height = 1, Lenght = 2, Width = 3 };

            //DeliveryService NskDelivery = new DeliveryService(new WeightPriceCalculationStrategy(10));

            //Console.WriteLine($"price n = {NskDelivery.CalculatePrice(order)}");


            //DeliveryService BerdskDelivery = new DeliveryService(new VolumePriceCalculationStrategy(10));


            //Console.WriteLine($"price b = {BerdskDelivery.CalculatePrice(order)}");


            //Console.WriteLine($"price new n = {NskDelivery.CalculatePrice(order)}");

            //NskDelivery.PriceCalculationStategy = new MaxWeigthVolumeStrategy(1000, 1000);

            //Console.WriteLine($"price new n 2 = {NskDelivery.CalculatePrice(order)}");
            //#endregion

            //            double byWeight(Order order)
            //            {
            //return order.Weight;
            //            }

            #region StrategyDelegates

            //Order order = new Order() { Weight = 10, Height = 1, Lenght = 2, Width = 3 };

            //DeliveryServiceDelegate NskDelivery = new DeliveryServiceDelegate(
            //    (order) => );

            //DeliveryServiceDelegate nsk2 = new((order) => order.Weight * 10);

            //Console.WriteLine($"price n = {NskDelivery.CalculatePrice(order)}");


            //DeliveryServiceDelegate BerdskDelivery = new DeliveryServiceDelegate(
            //    (order) => order.Width * order.Height * order.Lenght * 12);


            //Console.WriteLine($"price b = {BerdskDelivery.CalculatePrice(order)}");
            #endregion

            //#region Decorators

            //PriceCalculator priceCalculator = new PriceCalculator();

            //PriceCalculator weightCalc = new WeightPriceDecorator(priceCalculator);

            //PriceCalculator volumeCalc = new VolumeDecorator(priceCalculator);

            //PriceCalculator volumeRegularCalc = new SaleClientDecorator(volumeCalc, 0.9);

            //PriceCalculator volumeRegularEveningCalc = new SaleClientDecorator(volumeRegularCalc, 1.09);

            //PriceCalculator regvolCAlc = new VolumeDecorator(new SaleClientDecorator(priceCalculator, 0.9));

            //Console.WriteLine($"1 PC = {priceCalculator.CalculatePrice(order)}");
            //Console.WriteLine($"2 Weight = {weightCalc.CalculatePrice(order)}");
            //Console.WriteLine($"3 volume = {volumeCalc.CalculatePrice(order)}");
            //Console.WriteLine($"3 volume reg = {volumeRegularCalc.CalculatePrice(order)}");
            //Console.WriteLine($"3 reg volume = {regvolCAlc.CalculatePrice(order)}");
            //Console.WriteLine($"3 volume reg eve = {volumeRegularEveningCalc.CalculatePrice(order)}");
            //Console.WriteLine($"3 volume reg = {volumeRegularCalc.CalculatePrice(order)}");
            //#endregion

            #region Coffee

            //Coffee americano = new Coffee()
            //{
            //    Name = "Американо",
            //    Price = 100,
            //};


            //Coffee latte = new Coffee()
            //{
            //    Name = "Латте",
            //    Price = 150
            //};

            //Coffee americanoWithSugar = new SugarDecorator(americano);

            //Coffee americanoWithMilk = new MilkDecorator(americano);

            //Coffee latteWithMilk = new MilkDecorator(latte);


            //Coffee americanoWithMilkAndSugar = new SugarDecorator(americanoWithMilk);

            //Coffee americanoWithSugarMilk = new MilkDecorator(americanoWithSugar);

            //Coffee americanoWithSugarMilkWithSugar = new SugarDecorator(americanoWithSugarMilk);

            //List<Coffee> coffees = new()
            //{
            //    americano,
            //    latte,
            //    latteWithMilk,
            //    americanoWithSugar,
            //    americano,
            //    americanoWithMilk,
            //    americanoWithMilkAndSugar,

            //    americanoWithSugarMilk,
            //    americanoWithSugarMilkWithSugar
            //};
            //foreach (Coffee coffee in coffees)
            //{
            //    Console.WriteLine($"{coffee.GetDescription()} стоит {coffee.Price} рублей");
            //}


            #endregion

            #region Observers

            //IProgressObserver progressObserver = new WordCountProgressObserver(ConsoleColor.Red);

            //IProgressObserver progressObserver1 = new WordCountProgressObserver(ConsoleColor.Green);

            //WordCounter wc = new WordCounter();
            //wc.AddObserver(progressObserver);
            //wc.AddObserver(progressObserver1);
            //wc.CountWords(@"H:\");


            // События
            WordCounterEvents wordCounterEvents = new WordCounterEvents();
            // Подписка на событие
            wordCounterEvents.ProgressNotified += EventObserver.WordCounterEvents_ProgressNotified;
            wordCounterEvents.CountWords(@"H:\");
            // Отписка от события
            wordCounterEvents.ProgressNotified -= EventObserver.WordCounterEvents_ProgressNotified;

            #endregion



            #region State

            //Mario mario = new Mario();
            //Console.WriteLine($"начальное состояние - {mario.CurrentStateName}");

            //mario.EatMushroom();

            //Console.WriteLine($"состояние после грибов - {mario.CurrentStateName}");

            //mario.MeetTurtle();

            //Console.WriteLine($"состояние после первой черепахи - {mario.CurrentStateName}");

            //mario.MeetTurtle();

            //Console.WriteLine($"состояние после второй черепахи - {mario.CurrentStateName}");

            #endregion

            //var squares = Enumerable
            //    .Range(1, 10)
            //    .Select(i => i * i);


            //IEnumerable<int> Change(IEnumerable<int> toChange, Func<int, int> changer)
            //{
            //    foreach (var elem in toChange)
            //    {
            //        yield return changer(elem);
            //    }
            //}

            //var squares1 = Change(new[] { 1, 2, 3 },
            //    x =>
            //    {
            //        Console.WriteLine("in change" + x);

            //        return x * x;
            //    });

            //foreach (var elem in squares1)
            //{
            //    Console.WriteLine(elem);
            //    if (elem == 4) break;
            //}

            Console.ReadLine();
        }
    }
}
