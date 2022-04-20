using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    class Creation
    {
        public static void CreateTaskUsingAnInlineAction()
        {
            // Task создаётся, но не запускается сразу.
            Task<List<int>> taskWithInLineAction = new Task<List<int>>(() =>
            {
                List<int> ints = new List<int>();
                for (int i = 0; i < 1000; i++)
                {
                    ints.Add(i);
                }
                return ints;

            });

            // Для запуска необходимо вызвать метод экземпляра Start
            taskWithInLineAction.Start();

            // свойство Result позволяет получить результат работы Task
            var taskWithInLineActionResult = taskWithInLineAction.Result;
            Console.WriteLine(string.Format(
                "The task with inline Action<T> returned a Type of {0}, with {1} items",
            taskWithInLineActionResult.GetType(), taskWithInLineActionResult.Count));

            // Task больше не нужен. Можно даь команду на освобождение ресурсов
            taskWithInLineAction.Dispose();
        }


        public static void CreateTaskUsingFactory()
        {
            //task создаётся и сразу же запускается
            Task<List<int>> taskWithFactoryAndState = Task.Factory.StartNew<List<int>>(
                // первый параметр - это Action, который будет запускаться в Task
                (stateObj) =>    // параметр Action (2000, которые переданы как второй параметр метода StartNew)
            {
                List<int> ints = new List<int>();
                for (int i = 0; i < (int)stateObj; i++)
                {
                    ints.Add(i);
                }
                return ints;
            }, 
                // второй параметр метода StartNew - object, который будет передан в качестве параметра в Action, переданный в первом параметре
                2000);

            var taskWithFactoryAndStateResult = taskWithFactoryAndState.Result;
            Console.WriteLine(string.Format(
                "The task with Task.Factory.StartNew<List<int>> returned a Type of {0}, with {1} items",
            taskWithFactoryAndStateResult.GetType(), taskWithFactoryAndStateResult.Count));
            taskWithFactoryAndState.Dispose();
        }

        public static void CreateTaskUsingRun()
        {
            // Task создаётся и запускается сразу.
            Task<List<int>> taskWithRun = Task.Run(() =>
            {
                List<int> ints = new List<int>();
                for (int i = 0; i < 1000; i++)
                {
                    ints.Add(i);
                }
                return ints;
            });

            // свойство Result позволяет получить результат работы Task
            var taskWithInLineActionResult = taskWithRun.Result;
            Console.WriteLine(string.Format(
                "The task with inline Action<T> returned a Type of {0}, with {1} items",
            taskWithInLineActionResult.GetType(), taskWithInLineActionResult.Count));

            // Task больше не нужен. Можно даь команду на освобождение ресурсов
            taskWithRun.Dispose();
        }
    }
}
