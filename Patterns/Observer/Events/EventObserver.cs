using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Observer.Events
{
    public class EventObserver
    {
        public static void WordCounterEvents_ProgressNotified(object sender, WordProgressEventArgs e)
        {
            Console.Clear();
            Console.WriteLine($" Done {e.Progress} %, Current file is {e.CurrentFileName}");
        }
    }
}
