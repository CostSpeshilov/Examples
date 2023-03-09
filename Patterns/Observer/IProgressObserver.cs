using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Observer
{
    // Классический интерфейс наблюдателя состоит из единственного метода
    public interface IProgressObserver
    {
        void Notify(double progress, string currentFileName);
    }
}
