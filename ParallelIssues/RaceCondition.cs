using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelIssues
{
    class RaceCondition
    {

        public static void Start()
        {
            Sum();
            Sum();
            Sum();
            Sum();
            Sum();
        }

        private static void Sum()
        {
            int numTasks = 20;
            var state = new SharedState();

            object _sync = new object();
            var tasks = new Task[numTasks];
            for (int i = 0; i < numTasks; i++)
            {
                tasks[i] = Task.Run(() => new Job(state, _sync).DoTheJob());
            }
            Task.WaitAll(tasks);
            Console.WriteLine($"summarized {state.State}");
        }
    }

    public class SharedState
    {
        private int state = 0;

        public int State { get; set; }


    }

    public class Job
    {
        object _sync;
        private SharedState _sharedState;

        public Job(SharedState sharedState, object sync)
        {
            _sync = sync;
            _sharedState = sharedState;
        }
        public void DoTheJob()
        {
            for (int i = 0; i < 50000; i++)
            {
                lock (_sync)
                {
                    _sharedState.State += 1;
                }
            }
        }
    }
}

