using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Cancellation
    {
        public void NotCancel()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task.Run(async () =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    await Task.Delay(10);
                    Console.WriteLine(i);
                }
            }, token);

            Thread.Sleep(1);
            cancellationTokenSource.Cancel();
        }



        public void Cancel()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task.Run(async () =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(10);
                    Console.WriteLine(i);
                }
            }, token);

            //Thread.Sleep(1000);
            cancellationTokenSource.Cancel();
        }

        public void CancelMethod()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task.Run(() => Method1(token), token);

            Thread.Sleep(1000);
            cancellationTokenSource.Cancel();
        }


        async Task Method(CancellationToken token)
        {
            for (int i = 0; i < 1000000; i++)
            {
                token.ThrowIfCancellationRequested();
                await Task.Delay(10);
                Console.WriteLine(i);
            }
        }

        async Task Method1(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            for (int i = 0; i < 1000000; i++)
            {
                await Task.Delay(10);
                Console.WriteLine(i);
            }
        }


        public void CancelRegister()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task.Run(async () =>
            {
                //token.Register(() => CancelHandler(5));
                for (int i = 0; i < 1000000; i++)
                {
                    token.Register((j) => CancelHandler((int)j), i);
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(10);
                    Console.WriteLine(i);
                }
            }, token);

            Thread.Sleep(1000);
            cancellationTokenSource.Cancel();
        }

        public void CancelMultipleTasks()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            var task1 = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Task.Delay(10).Wait();
                    Console.WriteLine($"{i}  in thread {Thread.CurrentThread.ManagedThreadId} and task {Task.CurrentId}");
                    // Console.WriteLine(i);
                }
            }, token);

            var task2 = Task.Run(async () =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(10);
                    Console.WriteLine($"{i}  in thread {Thread.CurrentThread.ManagedThreadId} and task {Task.CurrentId}");
                    //Console.WriteLine(i);
                }
            }, token);

            cancellationTokenSource.CancelAfter(1000);
        }

        /// <summary>
        /// Метод демонстрирует работу свойств IsCanceled, Status  
        /// </summary>
        public void SingleTaskCancellation()
        {

            // Получение токена отмены операции 
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task<List<int>> taskWithFactoryAndState = Task.Factory.StartNew<List<int>>((stateObj) =>
             {
                 List<int> ints = new List<int>();
                 for (int i = 0; i < (int)stateObj; i++)
                 {
                     ints.Add(i);
                     token.ThrowIfCancellationRequested();
                     Console.WriteLine("taskWithFactoryAndState, создание элемента: {0}", i);
                 }
                 return ints;
             }, 2000, token);

            // Статус выполнения Task можно посмотреть с помощью свойства Status
            Console.WriteLine("Статус {0}", taskWithFactoryAndState.Status);


            taskWithFactoryAndState.Start();
                    
            // Свойство IsCanceled сообщает о том была ли отменена задача
            Console.WriteLine("Task отменён? {0}", taskWithFactoryAndState.IsCanceled); // К этому времени задача не отменена
            Console.WriteLine("Статус Task ? {0}", taskWithFactoryAndState.Status);        // и запущена 
            
            
            // Отменяем задачу
            tokenSource.Cancel();

            Console.WriteLine("Отмена Task ");
            // Раскомментируйте следующую строчку и проследите за изменением вывода
            //Task.Delay(100).Wait();    

            if (!taskWithFactoryAndState.IsCanceled && !taskWithFactoryAndState.IsFaulted)          // Программа не должна заходить в этот блок,
                                                                                                    // так как задача должна быть отменена
            {
                Console.WriteLine("Task cancelled? {0}", taskWithFactoryAndState.IsCanceled);
                Console.WriteLine("Task status? {0}", taskWithFactoryAndState.Status);
                try  // Result может выбросить исключение, если задача была отменена или закончилась аварийно
                {
                    if (!taskWithFactoryAndState.IsFaulted)
                    {
                        Console.WriteLine(string.Format("получено {0} элементов",
                            taskWithFactoryAndState.Result.Count));
                    }
                }
                catch (AggregateException aggEx)
                {
                    foreach (Exception ex in aggEx.InnerExceptions)
                    {
                        Console.WriteLine(string.Format("Поймано исключение '{0}'", ex.Message));   // Получение исключения свидетельствует о том, что отмена Task не моментальна
                    }
                }
                finally
                {
                    taskWithFactoryAndState.Dispose();
                }
            }
            else    // Блок в который программа должна зайти при отмене задания
            {
                Console.WriteLine("Task отменён? {0}", taskWithFactoryAndState.IsCanceled);
                Console.WriteLine("Статус Task? {0}", taskWithFactoryAndState.Status);
            }


            Console.ReadLine();

        }



        private void CancelHandler(int n)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Отменяю {n}");
            }
            Console.WriteLine($"Отменил {n}");
        }

        async Task WaitFor(int ms)
        {
            await Task.Delay(ms);
        }
    }
}
