using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.FactoryMethod
{
    // Целью класса не является создание объектов
    // Цель в совершении какой-то полезной работы
    // Является частным случаем Шаблонного метода
    internal abstract class ClassicFactory
    {
        // Обязательно наличие метода, в котором создание объекта
        // является одним из шагов
        public double CalculatePriceForNextOrder()
        {
            Product nextOrder = GetNextOrder();
            return nextOrder.Weight * 10;
        }

        // Создание объекта лишь шаг в алгоритме, метод не используется самостоятельно
        protected abstract Product GetNextOrder();
    }
}
