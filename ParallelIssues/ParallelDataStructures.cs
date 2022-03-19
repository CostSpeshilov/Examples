using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelIssues
{
    class ParallelDataStructures
    {
        private static bool IsPrime(int n)
        {
            if (n == 1) return false;
            if (n == 2) return true;
            var boundary = (int)Math.Floor(Math.Sqrt(n));
            for (int i = 2; i <= boundary; ++i)
                if (n % i == 0) return false;
            return true;
        }

        public static IEnumerable<int> SearchAllPrimeNumbersSequential(IEnumerable<int> numbers)
        {
            List<int> result = new List<int>();
            foreach (var number in numbers)
            {
                if (IsPrime(number))
                    result.Add(number);
            }
            return result;
        }


        public static IEnumerable<int> SearchAllPrimeNumbersParallel(IEnumerable<int> numbers)
        {
            List<int> result = new List<int>();
            Parallel.ForEach(numbers,
            (number) =>
            {
                if (IsPrime(number))
                    result.Add(number);
            });
            return result;
        }

        /// <summary>
        /// Возможна ошибка, так как есть изменяемое разделяемое состояние
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static IEnumerable<int> SearchAllPrimeNumbersParallelThreadSafe(IEnumerable<int> numbers)
        {
            List<int> result = new List<int>(numbers.Count());
            Parallel.ForEach(
                numbers, 

            () => new List<int>(),

            (number, state, localRes) =>
            {
                if (IsPrime(number))
                    localRes.Add(number);
                return localRes;
            },

             localRes => result.AddRange(localRes)

            );
            return result;
        }


        public static IEnumerable<int> SearchAllPrimeNumbersParallelConcurrentBag(IEnumerable<int> numbers)
        {
            ConcurrentBag<int> result = new ConcurrentBag<int>();
            
            Parallel.ForEach(numbers, (number) =>
            {
                if (IsPrime(number))
                    result.Add(number);
            });

            return result;
        }


        public static IEnumerable<int> SearchAllPrimeNumbersParallelImmutableList(IEnumerable<int> numbers)
        {
            ImmutableList<int> result = ImmutableList.Create<int>();
            Parallel.ForEach(numbers, (number) =>
            {
                if (IsPrime(number))
                    result = result.Add(number);
            });
            return result;
        }

        public static IEnumerable<int> SearchAllPrimeNumbersParallelImmutableListInterlocked(IEnumerable<int> numbers)
        {
            ImmutableList<int> result = ImmutableList.Create<int>();
            Parallel.ForEach(numbers, (number) =>
            {
                if (IsPrime(number))
                    ImmutableInterlocked.Update(ref result,
                        (result12) => result12.Add(number));
            });
            return result;
        }


        private static IEnumerable<int> GetAllDivisors(int n)
        {
            List<int> result = new List<int>();
            result.Add(1);
            result.Add(n);
            var boundary = (int)Math.Floor(Math.Sqrt(n));
            for (int i = 2; i <= boundary; ++i)
                if (n % i == 0)
                {
                    result.Add(i);
                    if (i != n / i)
                    {
                        result.Add(n / i);
                    }
                }

            return result;
        }

        public static IDictionary<int, int> CountDivisorsSequential(IEnumerable<int> numbers)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            foreach (var number in numbers)
            {
                var divs = GetAllDivisors(number);
                foreach (var div in divs)
                {
                    if (result.ContainsKey(div))
                    {
                        result[div]++;
                    }
                    else
                    {
                        result.Add(div, 1);
                    }
                }
            }
            return result;
        }

        public static IDictionary<int, int> CountDivisorsConcurrentDictionary(IEnumerable<int> numbers)
        {
            ConcurrentDictionary<int, int> result = new ConcurrentDictionary<int, int>();
            foreach (var number in numbers)
            {
                var divs = GetAllDivisors(number);
                foreach (var div in divs)
                {
                    result.AddOrUpdate(
                        div, 
                        1, 
                        (_, old) => old + 1);

                }
            }
            return result;
        }

        public static IDictionary<int, int> CountDivisorsParallelConcurrentDictionary(IEnumerable<int> numbers)
        {
            ConcurrentDictionary<int, int> result = new ConcurrentDictionary<int, int>();
            Parallel.ForEach(numbers,
                (number) =>
                {
                    var divs = GetAllDivisors(number);
                    foreach (var div in divs)
                    {
                        result.AddOrUpdate(
                            div,                        //ключ, который хотим добавить или изменить
                            1,                          // значение которое нужно добавить, если ключа нет
                            (key, old) => old + 1);     // как следует изменить значение, если ключ есть

                    }
                });
            return result;
        }


        public static IDictionary<int, int> CountDivisorsParallelImmutableDictionary(IEnumerable<int> numbers)
        {
            ImmutableDictionary<int, int> result = ImmutableDictionary.Create<int, int>();
            Parallel.ForEach(numbers,
                (number) =>
                {
                    var divs = GetAllDivisors(number);
                    foreach (var div in divs)
                    {
                        ImmutableInterlocked.AddOrUpdate(
                            ref result, 
                            div, 
                            1, 
                            (key, old) => old + 1);
                    }
                });
            return result;
        }
    }
}
