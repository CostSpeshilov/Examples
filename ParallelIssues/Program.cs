using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ParallelIssues
{
    class Program
    {
        static void Main(string[] args)
        {
            //aceCondition.Start();
            // Deadlock.Start();

            //  Sums();

            //PrimeNumbers();


            int len = 1000000;
            IDictionary<int, int> result;
            Stopwatch watch = new Stopwatch();
            watch.Restart();

            result = ParallelDataStructures.CountDivisorsSequential(Enumerable.Range(2, len));

            watch.Stop();
            Console.WriteLine($"Sequential: \t\t result = {result[2]}, {result[3]}, time elapsed = {watch.Elapsed}");


            watch.Restart();


            //watch.Restart();

            //result = ParallelDataStructures.CountDivisorsConcurrentDictionary(Enumerable.Range(2, len));

            //watch.Stop();
            //Console.WriteLine($"SequentialConcurrentDictionary: \t\t result = {result[2]}, {result[3]}, time elapsed = {watch.Elapsed}");


            watch.Restart();

            result = ParallelDataStructures.CountDivisorsParallelConcurrentDictionary(Enumerable.Range(2, len));

            watch.Stop();
            Console.WriteLine($"ParallelConcurrentDictionary: \t\t result = {result[2]}, {result[3]}, time elapsed = {watch.Elapsed}");


            watch.Restart();

            result = ParallelDataStructures.CountDivisorsParallelImmutableDictionary(Enumerable.Range(2, len));

            watch.Stop();
            Console.WriteLine($"ParallelConcurrentDictionary: \t\t result = {result[2]}, {result[3]}, time elapsed = {watch.Elapsed}");
        }

        private static void PrimeNumbers()
        {

            int len = 10000000;
            IEnumerable<int> result;
            Stopwatch watch = new Stopwatch();
            watch.Restart();

            result = ParallelDataStructures.SearchAllPrimeNumbersSequential(Enumerable.Range(0, len));

            watch.Stop();
            Console.WriteLine($"Sequential: \t\t result = {result.Count()}, time elapsed = {watch.Elapsed}");


            //watch.Restart();

            ////result = ParallelDataStructures.SearchAllPrimeNumbersParallel(Enumerable.Range(0, len));

            //watch.Stop();
            //Console.WriteLine($"Parallel: \t\t result = {result.Count()}, time elapsed = {watch.Elapsed}");


            watch.Restart();

            result = ParallelDataStructures.SearchAllPrimeNumbersParallelThreadSafe(Enumerable.Range(0, len));

            watch.Stop();
            Console.WriteLine($"ParallelThreadSafe: \t result = {result.Count()}, time elapsed = {watch.Elapsed}");


            watch.Restart();

            result = ParallelDataStructures.SearchAllPrimeNumbersParallelConcurrentBag(Enumerable.Range(0, len));

            watch.Stop();
            Console.WriteLine($"ConcurrentBag: \t\t result = {result.Count()}, time elapsed = {watch.Elapsed}");


            watch.Restart();

            result = ParallelDataStructures.SearchAllPrimeNumbersParallelImmutableList(Enumerable.Range(0, len));

            watch.Stop();
            Console.WriteLine($"ImmutableList: \t\t result = {result.Count()}, time elapsed = {watch.Elapsed}");

            watch.Restart();

            result = ParallelDataStructures.SearchAllPrimeNumbersParallelImmutableListInterlocked(Enumerable.Range(0, len));

            watch.Stop();
            Console.WriteLine($"ImmutableList: \t\t result = {result.Count()}, time elapsed = {watch.Elapsed}");
        }

        private static void Sums()
        {

            int len = 10000000;
            long result;
            Stopwatch watch = new Stopwatch();
            watch.Restart();

            result = ParallelForSums.PrimeSumSequential(len);

            watch.Stop();
            Console.WriteLine($"PrimeSumSequential: result = {result}, time elapsed = {watch.Elapsed}");


            watch.Restart();

            result = ParallelForSums.PrimeSumParallel(len);

            watch.Stop();
            Console.WriteLine($"PrimeSumParallel: result = {result}, time elapsed = {watch.Elapsed}");


            watch.Restart();

            result = ParallelForSums.PrimeSumParallelThreadLocal(len);

            watch.Stop();
            Console.WriteLine($"ThreadLocal: result = {result}, time elapsed = {watch.Elapsed}");


            OrderablePartitioner<Tuple<int, int>> partitioner = Partitioner.Create(0, len);
            watch.Restart();

            result = ParallelForSums.PrimeSumParallelPartitioner(partitioner);

            watch.Stop();
            Console.WriteLine($"Partitioner: result = {result}, time elapsed = {watch.Elapsed}");
        }
    }
}
