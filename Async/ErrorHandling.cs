using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    /// <summary>
    /// Пример, показывыающий способы обработки исклюючений, возникающих в асинхронных методах
    /// Для проверки разных вариантов раскомментируйте соответствующую строчку в методе Main
    /// </summary>
    internal class ErrorHandling
    {
        /// <summary>
        /// Метод показывает правильный способ обработки несколькох исключений,
        /// которые могут возникнуть в нескольких асинхронных методах
        /// </summary>
        internal static async void ShowAggregatedException()
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
        internal static async void StartTwoTasksParallel()
        {
            Task t1 = null;
            try
            {
                t1 = ThrowAfter(2000, "first");
                Task t2 = ThrowAfter(1000, "second");
                await Task.WhenAll(t1, t2); // Оба исключения будут выброшены
            }
            catch (Exception ex)
            {
                // На экран будет выведено сообщение только о первом возникшем исключении
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
        internal static async void StartTwoTasks()
        {
            try
            {
                await ThrowAfter(2000, "first");
                await ThrowAfter(1000, "second"); // Второе исключение не будет выброшено, так как этот метод не будет вызван
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
        internal static void DontHandle()
        {
            try
            {
                ThrowAfter(200, "first");
                // Исключение не будет поймано, так как блок try завершится до того, как исключение будет выброшено
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
        internal static async void HandleOneError()
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
