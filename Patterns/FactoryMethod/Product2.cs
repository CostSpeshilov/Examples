using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.FactoryMethod
{
    internal class Product2 : Product
    {
        public Product2(string name, double weight) : base(name, weight)
        {
        }
    }
}
