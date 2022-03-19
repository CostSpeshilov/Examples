using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelIssues
{
    class Deadlock
    {
        public static void Start()
        {
            var state1 = new StateObject();
            var state2 = new StateObject();

            var tasks = new Task[2];
            tasks[0] = new Task(new SampleTask(state1, state2).Deadlock1);
            tasks[1] = new Task(new SampleTask(state1, state2).Deadlock2);

            foreach (var task in tasks)
            {
                task.Start();
            }

            Task.WaitAll(tasks);
        }
    }

    public class SampleTask
    {
        public SampleTask(StateObject s1, StateObject s2)
        {
            _s1 = s1;
            _s2 = s2;
        }
        private StateObject _s1;

        private StateObject _s2;
        public void Deadlock1()
        {
            int i = 0;
            while (true)
            {
                lock (_s1)
                {
                    lock (_s2)
                    {
                        _s1.ChangeState(i);
                        _s2.ChangeState(i++);
                        Console.WriteLine($"I still running, {i}");
                    }
                }

                Task.Delay(1).Wait();
            }
        }
        public void Deadlock2()
        {
            //Task.Delay(5000);
            int i = 0;
            while (true)
            {
                lock (_s2)
                {
                    lock (_s1)
                    {
                        _s1.ChangeState(i);
                        _s2.ChangeState(i++);
                        Console.WriteLine($"II still running, {i}");
                    }
                }
                Task.Delay(100).Wait();
            }
        }
    }

    public class StateObject
    {
        private int _state = 5;
        private object _sync = new object();
        public void ChangeState(int loop)
        {
            lock (_sync)
            {
                if (_state == 5)
                {
                    _state++;
                    if (_state != 6)
                    {
                        Console.WriteLine($"Race condition occured after { loop} loops");
                    }
                }
                _state = 5;
            }
        }
    }
}
