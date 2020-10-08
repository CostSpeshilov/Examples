using System;
using System.Collections.Generic;

namespace TestExamples
{
    /// <summary>
    /// Класс, который будем тестировать
    /// </summary>
    public class TestedClass
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Div(int a, int b)
        {
            return a / b;
        }

        public int MaxElement(List<int> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }
            if (elements.Count == 0)
            {
                throw new EmptyListException();
            }
            int max = elements[0];
            for (int i = 1; i < elements.Count; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }
            return max;
        }
    }
}
