using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.FactoryMethod
{
    internal class Product
    {
        public string Name { get; set; }
        public Product()
        {

        }
        public Product(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public double Weight { get; set; }
    }
}
