using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelIssues
{
    class ParallelForSums
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

        public static long PrimeSumSequential(int len)
        {
            long total = 0;

            for (var i = 1; i <= len; ++i)
            {
                if (IsPrime(i))
                    total += i;
            }

            return total;
        }

        /// <summary>
        /// Возможна ошибка распараллеливания, так как есть запись в разделяемый ресурс (total)
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static long PrimeSumParallel(int len)
        {
            long total = 0;

            Parallel.For(1, len, i =>
            {
                if (IsPrime(i))
                {
                    total += i;
                }
            });
            return total;
        }

        /// <summary>
        /// Нет ошибки распараллеливания, так как запись в разделяемый ресурс (total) 
        /// находится внутри блока синхронизации (lock)
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static long PrimeSumParallelWithLock(int len)
        {
            long total = 0;
            object lockObject = new object(); // любой ссылочный объект

            Parallel.For(0, len, i =>
            {
                if (IsPrime(i))
                {
                    lock (lockObject)
                    {
                        total += i;
                    }
                }
            });
            return total;
        }

        /// <summary>
        /// Нет ошибки распараллеливания, так как запись в разделяемый ресурс (total) 
        /// производится как атомарная операция (Interlocked.Add)
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static long PrimeSumParallelWithInterlocked(int len)
        {
            long total = 0;

            Parallel.For(0, len, i =>
            {
                if (IsPrime(i))
                {
                    Interlocked.Add(ref total, i);
                }
            });
            return total;
        }

        /// <summary>
        /// Нет ошибки распараллеливания, так как в третьем делегате вся работа ведётся с 
        /// локальными значениями, а в четвёртом запись в разделяемый ресурс производится как
        /// атомарная операция
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static long PrimeSumParallelThreadLocal(int len)
        {

            long total = 0;

            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 2;

            Parallel.For(
                0,  //начальное значение счётчика итераций i = 0 в обычном for
                len, // конечное значение счётчика итераций i < n в обычном for
                options,
                () => 0, //начальное значение для локальной суммы

                (int i, ParallelLoopState loopState, long tlsValue) // делегат, который будет выполняться для каждой итерации
                    => IsPrime(i) ? tlsValue += i : tlsValue,       // i - текущая итерация, loopState - текущее состояние цикла (например, прерван)
                                                                    // tlsValue - текущее локальное значение суммы

                value => Interlocked.Add(ref total, value)); // делегат, который будет вызван после токо, как поток обработает свои данные
                                                             // value - конечная локальная сумма

            return total;
        }

        /// <summary>
        /// Нет ошибки распараллеливания, так как запись в разделяемый ресурс (total) 
        /// производится как атомарная операция (Interlocked.Add)
        /// </summary>
        /// <param name="partitioner"></param>
        /// <returns></returns>
        public static long PrimeSumParallelPartitioner(OrderablePartitioner<Tuple<int, int>> partitioner)
        {
            long total = 0;
            Parallel.ForEach(partitioner,
                (range) =>
                {
                    long partialSum = 0;
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        if (IsPrime(i))
                        {
                            partialSum += i;
                        }

                    }
                    Interlocked.Add(ref total, partialSum);
                });

            return total;
        }

        /// <summary>
        /// Параллельно вычисляются суммы всех простых чисел до 5000
        /// и всех простых чисел до 10000.
        /// Разделяемых ресурсов нет
        /// </summary>
        public void ParallelInvoke()
        {
            Parallel.Invoke(
                () => PrimeSumSequential(5000),
                () => PrimeSumSequential(10000)
                );
        }

    }
}
