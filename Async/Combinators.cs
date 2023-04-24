using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    internal class Combinators
    {

        /// <summary>
        /// Запуск нескольких задач и асинхронное ожидание первой завершившейся
        /// </summary>
        internal static async Task WhenAnyWhenAll()
        {
            Task[] tasks = new Task[3];
            tasks[0] = new Task(() =>
            {
                Console.WriteLine($"Запуск первой задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(2000).Wait() ;
                Console.WriteLine($"Выход из первой задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}\"");
            });

            // Эта задача должна закончиться раньше остальных
            tasks[1] = new Task(() =>
            {
                Console.WriteLine($"Запуск второй задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(100).Wait();
                Console.WriteLine($"Выход из второй задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}\"");
            });
            tasks[2] = new Task(() =>
            {
                Console.WriteLine($"Запуск третьей задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(1010).Wait();
                Console.WriteLine($"Выход из третьей задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}\"");
            });

            Console.WriteLine($"метод WhenAnyWhenAll после создания задач TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");

            ShowTaskStatuses(tasks, "перед Start");

            // запускаем задачи
            foreach (var task in tasks)
            {
                task.Start();
            }

            ShowTaskStatuses(tasks, "перед WhenAny");

            // Асинхронно дожидаемя первой завершившейся задачи
            // Метод WhenAny возвращает задачу, которая закончилась раньше других
            Task firstFinished = await Task.WhenAny(tasks);

            Console.WriteLine($"метод WhenAnyWhenAll после создания задач TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
            
            ShowTaskStatuses(tasks, "сразу после WhenAny");
            Task.Delay(1).Wait();
            ShowTaskStatuses(tasks, "чуть-чуть подождав");

            // Асинхронно дожидаемся выполнения всех оставшихся задач
            await Task.WhenAll(tasks);
            Console.WriteLine($"выход из метода WhenAnyWhenAll TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
            Program.finished = true;
        }


        /// <summary>
        /// Запуск нескольких задач и асинхронное ожидание первой завершившейся
        /// </summary>
        internal static async Task WaitAnyWaitAll()
        {
            Task[] tasks = new Task[3];
            tasks[0] = new Task(() =>
            {
                Console.WriteLine($"Запуск первой задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(2000).Wait();
                Console.WriteLine($"Выход из первой задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}\"");
            });

            // Эта задача должна закончиться раньше остальных
            tasks[1] = new Task(() =>
            {
                Console.WriteLine($"Запуск второй задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(100).Wait();
                Console.WriteLine($"Выход из второй задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}\"");
            });
            tasks[2] = new Task(() =>
            {
                Console.WriteLine($"Запуск третьей задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(1010).Wait();
                Console.WriteLine($"Выход из третьей задачи TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}\"");
            });

            Console.WriteLine($"метод WaitAnyWaitAll после создания задач TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");

            ShowTaskStatuses(tasks, "перед Start");

            // запускаем задачи
            foreach (var task in tasks)
            {
                task.Start();
            }

            ShowTaskStatuses(tasks, "перед WaitAny");

            // Синхронно дожидаемя первой завершившейся задачи
            // Метод WaitAny возвращает индекс задачи, которая закончилась раньше других
            int firstFinishedIndex = Task.WaitAny(tasks);

            Console.WriteLine($"Индекс завершившейся задачи равен {firstFinishedIndex}");
            Console.WriteLine($"метод WaitAnyWaitAll после создания задач TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");

            ShowTaskStatuses(tasks, "сразу после WaitAny");
            Task.Delay(1).Wait();
            ShowTaskStatuses(tasks, "чуть-чуть подождав");

            // Синхронно дожидаемся выполнения всех оставшихся задач
            Task.WaitAll(tasks);
            Console.WriteLine($"выход из метода WaitAnyWaitAll TaskId = {Task.CurrentId}, Thread = {Thread.CurrentThread.ManagedThreadId}");
            Program.finished = true;
        }

        private static void ShowTaskStatuses(Task[] tasks, string when)
        {
            Console.WriteLine(when);
            for (int i = 0; i < tasks.Length; i++)
            {
                Task task = tasks[i];
                Console.WriteLine($"статус задачи #{i} - {task.Status}");
            }
        }
    }
}
