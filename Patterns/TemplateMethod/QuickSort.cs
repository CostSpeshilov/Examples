using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.TemplateMethod
{
    // Т - обобщение, которое будет уточнено в потомках
    internal abstract class QuickSort<T>
    {
        // Сам алгоритм
        public List<T> Sort(List<T> unsorted)
        {
            if (unsorted.Count == 0)
            {
                return unsorted;
            }
           
            List<T> lesser = new List<T>();
            List<T> equal = new List<T>();
            List<T> greater = new List<T>();

            T first = unsorted[0];

            foreach (T item in unsorted)
            {
                int compareResult = Compare(item, first);
                if (compareResult < 0)
                {
                    lesser.Add(item);
                }
                else if (compareResult == 0)
                {
                    equal.Add(item);
                }
                else
                {
                    greater.Add(item);
                }
            }
            List<T> sortedLesser = Sort(lesser);
            List<T> sortedGreater = Sort(greater);
            List<T> sorted = new List<T>();
            sorted.AddRange(sortedLesser);
            sorted.AddRange(equal);
            sorted.AddRange(sortedGreater);
            return sorted;
        }

        // Конкретный шаг, который будет переопределён в потомках
        protected abstract int Compare(T item, T first);
    }
}
