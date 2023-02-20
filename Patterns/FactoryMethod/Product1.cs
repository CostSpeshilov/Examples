using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.FactoryMethod
{
    internal class Product1 : Product
    {
        public Product1(string name, double weight) : base(name, weight)
        {
        }
    }
}
