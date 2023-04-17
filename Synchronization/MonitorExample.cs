using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronization
{
    internal class MonitorExample
    {
        void MethodWithExplicitMonitor()
        {
            object obj = new object();
            bool taken = false;
            try
            {
                Monitor.Enter(obj, ref taken);
            }
            finally
            {
                // Проверяем был ли захвачен монитор. Если в блоке try будет выброшено исключение
                // до вызова Monitor.Enter, то не нужно освобождать монитор
                if (taken)
                {
                    Monitor.Exit(obj);
                }
            }
        }

        void MethodWithLock()
        {
            object obj = new object();
            lock (obj)
            {

            }
        }
    }
}
