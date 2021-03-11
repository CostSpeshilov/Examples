using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    /// <summary>
    /// Класс демонстрирует работу с ключевыми словами <see langword="async"/> и <see langword="await"/> 
    /// </summary>
    class Program
    {
        /// <summary>
        /// Раскомментируйте необходимые строчки по одной
        /// Следите за порядком вывода сообщений на консоль
        /// Каждый метод запускайте по нескольку раз и следите за изменениями в выводе
        /// </summary>
        static void Main()
        {
            var ctx = new DispatcherSynchronizationContext();
            Console.WriteLine("Start of Programm");

            // CallerWithAsync3();
            // CallerWithContinuationTask();
            // MultipleAsyncMethods();
            //MultipleAsyncMethodsWithCombinators1();
            // MultipleAsyncMethodsWithCombinators2();

            Cancellation can = new Cancellation();
            //can.NotCancel();
            //can.Cancel();
            //can.CancelMethod();
            // can.CancelRegister();


            //DontHandle();
            //HandleOneError();
            //StartTwoTasks();
            //StartTwoTasksParallel();
            //ShowAggregatedException();

            Console.WriteLine("end of Programm");
            Console.ReadLine();


        }

        /// <summary>
        /// Последовательный запуск нескольких асинхронных методов
        /// Приветствия Matthias не произойдет до того, пока не будет поприветствована Stephanie
        /// </summary>
        private static async void MultipleAsyncMethods()
        {
            string s1 = await GreetingAsync("Stephanie");
            string s2 = await GreetingAsync("Matthias");
            Console.WriteLine("Finished both methods.\n Result 1: {0}\n Result 2: {1}", s1, s2);
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

        /// <summary>
        /// Вызов одного асинхронного метода. 
        /// Выполнение метода не будет прожолжено  пока не завершится работа асинхронного метода 
        /// </summary>
        private static async Task CallerWithAsync()
        {
            Console.WriteLine("started CallerWithAsync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            string result = await GreetingAsync("Stephanie");
            Console.WriteLine(result);
            Console.WriteLine("finished GreetingAsync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        }

        /// <summary>
        /// Вызов одного асинхронного метода
        /// c# позволяет встраивать вызов асинхронных методов 
        /// </summary>
        private static async void CallerWithAsync2()
        {
            Console.WriteLine("started CallerWithAsync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            Console.WriteLine(await GreetingAsync("Stephanie"));
            Console.WriteLine("finished GreetingAsync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        }

        /// <summary>
        /// Вызов одного асинхронного метода. 
        /// Выполнение метода не будет прожолжено  пока не завершится работа асинхронного метода 
        /// </summary>
        private static void CallerWithAsync3()
        {
            Task.Run(async () => await CallerWithAsync()).Wait();
        }


        /// <summary>
        /// Определение асинхронного метода приветствия
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static Task<string> GreetingAsync(string name)
        {
            //Для получения эффекта асинхронности используется класс Task
            return Task.Run<string /*возвращаемый тип*/>(() =>
            {
                Console.WriteLine("running greetingasync in thread {0} and task {1}, {2}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId, name);
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
            return string.Format("Hello, {0}", name);
        }

        /// <summary>
        /// Метод показывает правильный способ обработки несколькох исключений,
        /// которые могут возникнуть в нескольких асинхронных методах
        /// </summary>
        private static async void ShowAggregatedException()
        {
            Task taskResult = null;
            try
            {
                Task t1 = ThrowAfter(2000, "first");
                Task t2 = ThrowAfter(1000, "second");
                await (taskResult = Task.WhenAll(t1, t2));
            }
            catch (Exception ex)
            {
                // just display the exception information of the first task that is awaited within WhenAll
                // в переменной ex хранится только одно исключение - то, которое возникло первым
                Console.WriteLine("handled {0}", ex.Message);


                // в коллекции Exception.InnerExceptions  хранятся все исключения, которые были выброшены всеми ожидаемыми методами
                foreach (var ex1 in taskResult.Exception.InnerExceptions)
                {
                    Console.WriteLine("inner exception {0} from task {1}", ex1.Message, ex1.Source);
                }
            }
            finally
            {
                Console.WriteLine("Done");
            }
        }

        /// <summary>
        /// Метод показывает неправильный способ обработки множественных исключений
        /// </summary>
        private static async void StartTwoTasksParallel()
        {
            Task t1 = null;
            try
            {
                t1 = ThrowAfter(2000, "first");
                Task t2 = ThrowAfter(1000, "second");
                await Task.WhenAll(t1, t2);
            }
            catch (Exception ex)
            {
                // just display the exception information of the first task that is awaited within WhenAll
                Console.WriteLine("handled {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("Done");
            }
        }

        /// <summary>
        /// Метод иллюстрирует ситуацию, когда выбрасывается исключение в методе, который вызывается с ключевым словом await
        /// Исключение будет обработано
        /// </summary>
        private static async void StartTwoTasks()
        {
            try
            {
                await ThrowAfter(2000, "first");
                await ThrowAfter(1000, "second"); // the second call is not invoked because the first method throws an exception
            }
            catch (Exception ex)
            {
                Console.WriteLine("handled {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("Done");
            }
        }

        /// <summary>
        /// Если метод не ожидается, то исключение не будет обработано, так как метод DontHandle уже завершит свою работу
        /// </summary>
        private static void DontHandle()
        {
            try
            {
                ThrowAfter(200, "first");
                // exception is not caught because this method is finished before the exception is thrown
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Done");
            }
        }

        /// <summary>
        /// Исключение будет обработано
        /// </summary>
        private static async void HandleOneError()
        {
            try
            {
                await ThrowAfter(2000, "first");
            }
            catch (Exception ex)
            {
                Console.WriteLine("handled {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("Done");
            }
        }

        static async Task ThrowAfter(int ms, string message)
        {
            await Task.Delay(ms);
            throw new Exception(message);
        }

    }
}
