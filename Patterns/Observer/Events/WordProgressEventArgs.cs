using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Observer.Events
{
    // Класс для передчи информации о событии от издателя подписчику
    public class WordProgressEventArgs : EventArgs
    {
        public double Progress { get; set; }
        public string CurrentFileName { get; set; }
    }
}
