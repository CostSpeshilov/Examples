using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Observer
{
    // Классический интерфейс наблюдаемого объекта
    // Метод оповещения наблюдателей не включён в интерфейс
    public interface IProgressObservable
    {
        void AddObserver(IProgressObserver observer);
        void RemoveObserver(IProgressObserver observer);
    }
}
