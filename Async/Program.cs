﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    /// <summary>
    /// Класс демонстрирует работу с ключевыми словами <see langword="async"/> и <see langword="await"/> 
    /// </summary>
    class Program
    {
        public static bool finished = false;
        /// <summary>
        /// Раскомментируйте необходимые строчки по одной
        /// Следите за порядком вывода сообщений на консоль
        /// Каждый метод запускайте по нескольку раз и следите за изменениями в выводе
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Start of Programm");
           
            Cancellation can = new Cancellation();
            List<Action> actions = new List<Action>()
            {
                GreetingAsync,
                CallerWithAsyncStart,
                CallerWithAsync2,
                CallerWithAsync3,
                CallerWithAsync4,
                CallerWithContinuationTask,
                MultipleAsyncMethods,
                MultipleAsyncMethodsWithCombinators1,
                MultipleAsyncMethodsWithCombinators2,
                can.NotCancel,
                can.Cancel,
                can.CancelMethod,
                can.CancelRegister,
                can.CancelMultipleTasks,
                can.SingleTaskCancellation,
                ErrorHandling.DontHandle,
                ErrorHandling.HandleOneError,
                ErrorHandling.StartTwoTasks,
                ErrorHandling.StartTwoTasksParallel,
                ErrorHandling.ShowAggregatedException,
                Creation.CreateTaskUsingRun,
                Creation.CreateTaskUsingAnInlineAction,
                Creation.CreateTaskUsingFactory,
                CombinatorsWhenAnyWhenAll,
                CombinatorsWaitAnyWaitAll,

                ContinuationContinuationOptional,
                ContinuationContinuationChains,
            };

            for (int i = 0; i < actions.Count; i++)
            {
                Console.WriteLine($"{i} - {actions[i].Method.Name}");
            }
            var chosenActionIndex = Convert.ToInt32( Console.ReadLine());
            var chosenAction = actions[chosenActionIndex];



            chosenAction.Invoke();

            

            Console.WriteLine("end of Programm");


            while (!finished)
            {
                Console.WriteLine($"not finished in thread {Thread.CurrentThread.ManagedThreadId},{Task.CurrentId}");
                var readKey = Console.ReadKey();
                if (readKey.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }

            Console.ReadLine();
        }

        private static void GreetingAsync()
        {
            Console.WriteLine(GreetingAsync("john"));
        }

        private static void CombinatorsWhenAnyWhenAll()
        {
            Combinators.WhenAnyWhenAll();
        }

        private static void CombinatorsWaitAnyWaitAll()
        {
            Combinators.WaitAnyWaitAll();
        }

        private static void ContinuationContinuationOptional()
        {
            Continuation.ContinuationOptional();
        }

        private static void ContinuationContinuationChains()
        {
            Continuation.ContinuationChains();
        }

        /// <summary>
        /// Последовательный запуск нескольких асинхронных методов
        /// Приветствия Matthias не произойдет до того, пока не будет поприветствована Stephanie
        /// </summary>
        private static async void MultipleAsyncMethods()
        {
            string s1 = await GreetingAsync("Stephanie");

            Console.WriteLine("between awaits MultipleAsyncMethods in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

            string s2 = await GreetingAsync("Matthias");
            Console.WriteLine("Finished both methods.\n Result 1: {0}\n Result 2: {1}", s1, s2);

            Console.WriteLine("end MultipleAsyncMethods in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        }

        /// <summary>
        /// Параллельный запуск нескольких асинхронных методов.
        /// Порядок приветствий не определен.
        /// Результат выполнения асинхронного метода хранится в свойстве Result класса Task
        /// </summary>
        private static async void MultipleAsyncMethodsWithCombinators1()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            Task<string> t2 = GreetingAsync("Matthias");
            await Task.WhenAny(t1, t2);
            Console.WriteLine("Finished both methods.\n Result 1: {0}\n Result 2: {1}", t1.Result, t2.Result);
        }

        /// <summary>
        /// Параллельный запуск нескольких асинхронных методов.
        /// Порядок приветствий не определен.
        /// Результат выполнения асинхронных методов может быть получен напрямую
        /// </summary>
        private static async void MultipleAsyncMethodsWithCombinators2()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            Task<string> t2 = GreetingAsync("Matthias");
            string[] result = await Task.WhenAll(t1, t2);
            Console.WriteLine("Finished both methods.\n Result 1: {0}\n Result 2: {1}", result[0], result[1]);
        }

        /// <summary>
        /// Определение метода. который должен быть вызван после завершения асинхронного метода
        /// </summary>
        private static void CallerWithContinuationTask()
        {
            Console.WriteLine("started CallerWithContinuationTask in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

            Task<string> t1 = GreetingAsync("Stephanie");


            t1.ContinueWith(t =>
            {
                string result = t.Result;
                Console.WriteLine(result);
                Console.WriteLine("finished CallerWithContinuationTask in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            });

        }

        private static void CallerWithAsyncStart()
        {
            CallerWithAsync();
        }

        /// <summary>
        /// Вызов одного асинхронного метода. 
        /// Выполнение метода не будет прожолжено  пока не завершится работа асинхронного метода 
        /// </summary>
        private static async Task CallerWithAsync()
        {
            Console.WriteLine("started CallerWithAsync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

            string result = GreetingAsync("Stephanie").Result;

            Console.WriteLine(result);
            Console.WriteLine("finished CallerWithAsync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        }

        /// <summary>
        /// Вызов одного асинхронного метода
        /// c# позволяет встраивать вызов асинхронных методов 
        /// </summary>
        private static async void CallerWithAsync2()
        {
            Console.WriteLine("started CallerWithAsync2 in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);


            string result = await GreetingAsync("Stephanie");

            Console.WriteLine(result);
            Console.WriteLine("finished CallerWithAsync2 in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            finished = true;
        }

        /// <summary>
        /// Вызов одного асинхронного метода. 
        /// Выполнение метода не будет прожолжено  пока не завершится работа асинхронного метода 
        /// </summary>
        private static void CallerWithAsync3()
        {
            Console.WriteLine("start CallerWithAsync3 in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

            Task.Run(async () =>
            {
                Console.WriteLine("start task in CallerWithAsync3 in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                await CallerWithAsync();
                Console.WriteLine("end task in CallerWithAsync3 in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            }).Wait();
            finished = true;
            Console.WriteLine("end CallerWithAsync3 in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        }

        private static async void CallerWithAsync4()
        {
            Console.WriteLine("start CallerWithAsync4 in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

            Task t = Task.Run(CallerWithAsync);

            Console.WriteLine("after task run CallerWithAsync4 in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

            await t;
            finished = true;
            Console.WriteLine("end CallerWithAsync4 in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        }

        /// <summary>
        /// Определение асинхронного метода приветствия
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static Task<string> GreetingAsync(string name)
        {
            Console.WriteLine("running greetingasync in thread {0} and task {1}, {2}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId, name);
            //Для получения эффекта асинхронности используется класс Task
            return Task.Run<string /*возвращаемый тип*/>(() =>
            {
                Console.WriteLine("running task in greetingasync in thread {0} and task {1}, {2}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId, name);
                //вызов синхронного метода
                return Greeting(name);
            });


        }

        /// <summary>
        /// Синхронный метод приветствия
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static string Greeting(string name)
        {
            Console.WriteLine("running greeting in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

            Thread.Sleep(3000);

            return $"Hello, {name}";
        }

        static void BlockingOperations()
        {
            Task<List<int>> taskWithFactoryAndState1 = Task.Factory.StartNew<List<int>>((stateObj) =>
            {
                Console.WriteLine("Внутри Task");
                List<int> ints = new List<int>();
                for (int i = 0; i < (int)stateObj; i++)
                {
                    ints.Add(i);
                }
                Task.Delay(1000).Wait();
                return ints;
            }, 10000);

            Console.WriteLine("После запуска");
            taskWithFactoryAndState1.Wait();            // Блокирующее ожидание выполнения Task. Блокируется тот поток, который выполняет этот метод
            taskWithFactoryAndState1.Dispose();
            Console.WriteLine("После завершения");      // Это сообщение всегда будет последним

            Stopwatch watch = new Stopwatch();
            watch.Start();                          // замеряем время выполнения операций
            // create the task
            Task<List<int>> taskWithFactoryAndState2 = Task.Factory.StartNew<List<int>>((stateObj) =>
            {
                List<int> ints = new List<int>();
                for (int i = 0; i < (int)stateObj; i++)
                {
                    ints.Add(i);
                    Thread.Sleep(10000);
                }
                return ints;
            }, 1);

            // Task.StartNew не блокирует вызывающий поток, прошло 0 мс
            Console.WriteLine(string.Format("После запуска, have waited {0}ms",
                watch.ElapsedMilliseconds));


            var result = taskWithFactoryAndState2.Result;

            // Свойство экземпляра Result блокирует вызывающий поток, прошло ~10 с
            Console.WriteLine(string.Format("После окончания, have waited {0}ms",
                watch.ElapsedMilliseconds));

            taskWithFactoryAndState2.Dispose();
            Console.ReadLine();
        }
    }
}
