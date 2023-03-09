using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Observer
{
    // Реализация наблюдателя. Он ничего не делает и ждёт, когда
    // объект за которым он наблюдает сообщит ему информацию
    public class WordCountProgressObserver : IProgressObserver
    {
        private readonly ConsoleColor color;

        public WordCountProgressObserver(ConsoleColor color)
        {
            this.color = color;
        }

        public void Notify(double progress, string currentFileName)
        {

            Console.ForegroundColor = color;
            //Console.Clear();
            Console.WriteLine($" Done {progress} %, Current file is {currentFileName}");
        }
    }
}
