using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    internal class Continuation
    {
        public static void SimpleContinuation()
        {
            // Задача, которая всегда выполняется правильно
            Task<int> task = Task.Run(() =>
            {
                Task.Delay(1000).Wait();
                return 0;
            });


            // Это продолжение будет запущено всегда после того как завершится задача task
            task.ContinueWith(t => { Console.WriteLine(t.Result); }); // t - это task в состоянии после выполнения
        }

        public static void ContinuationChains()
        {
            Console.WriteLine($"метод SimpleContinuationTaskIdShown до создания задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
            // Задача, которая всегда выполняется правильно
            Task<int> task = Task.Run(() =>
            {
                Console.WriteLine($"task запущен в TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(1000).Wait();
                return 0;
            });

            Console.WriteLine($"метод SimpleContinuationTaskIdShown после запуска задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
            // Это продолжение будет запущено всегда после того как завершится задача task
            task.ContinueWith(t =>  // t - это task в состоянии после выполнения
            { 
                Console.WriteLine(t.Result);
                Console.WriteLine($"продолжение запущено в TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
                return "new result";
            }).ContinueWith(t =>  // t - это предыдущее продолжение в состоянии после выполнения
            {
                Console.WriteLine(t.Result);
                Console.WriteLine($"продолжение запущено в TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
            });
        }

        public static void ContinuationOptional ()
        {
            //Создаём задачу, которая может выполниться правильно, а может с ошибкой
            Task<int> t1 = new Task<int>(() =>
            {
                Task.Delay(1000).Wait();
                Random rnd = new Random();
                if (rnd.Next(2) == 0)
                {
                    throw new NotImplementedException();
                }
                return 1;
            });

            // Задача, которая всегда выполняется правильно
            Task<int> t2 = new Task<int>(() =>
            {
                Task.Delay(1000).Wait();
                return 0;
            });


            t1.Start();
            t2.Start();

            // Это продолжение будет запущено только если t1 завершится с ошибкой
            t1.ContinueWith(t =>
            {
                Console.WriteLine(t.Exception.Message);

            }, TaskContinuationOptions.OnlyOnFaulted);

            // Это продолжение будет запущено только если t1 завершится правильно
            t1.ContinueWith(t =>
            {
                Console.WriteLine(t.Result);

            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            // Это продолжение будет запущено только если t2 завершится правильно
            t1.ContinueWith(t =>
            {
                Console.WriteLine(t.Result);

            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            // Это продолжение будет запущено всегда
            t2.ContinueWith(t => { Console.WriteLine(t.Result); });
        }
    }
}
