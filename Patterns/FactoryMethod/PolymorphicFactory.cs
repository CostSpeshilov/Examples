using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.FactoryMethod.Polymorphic
{
    // Цель класса - создание объектов. Других функций нет
    // Является частным случаем стратегии
    internal abstract class PolymorphicFactory
    {
        // Фабрика может использоваться во многих местах
        public abstract Product CreateProduct(string name, int weight);
    }

    internal class Product1Factory : PolymorphicFactory
    {
        public override Product CreateProduct(string name, int weight)
        {
            return new Product1(name, weight);
        }
    }

    internal class Product2Factory : PolymorphicFactory
    {
        public override Product CreateProduct(string name, int weight)
        {
            return new Product2(name, weight);
        }
    }
}
