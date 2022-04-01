using Patterns;
using System;

namespace PatternsConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Product.ProductBuilder builder = Product.Builder;


            Product product = builder.AddName("john")
                .AddOptionalProperty(8)
                .AddOptionalStringProperty("gg")
                   .Build();
        }
    }
}
