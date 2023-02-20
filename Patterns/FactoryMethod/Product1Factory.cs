using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.FactoryMethod
{
    // Конкретная реализация переопределяет только шаг создания
    internal class Product1Factory : ClassicFactory
    {
        protected override Product GetNextOrder()
        {
            return new Product1(string.Empty, 1);
        }
    }
}
