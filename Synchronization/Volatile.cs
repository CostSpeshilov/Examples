using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Synchronization
{
    internal class Strange
    {
        private static bool s_stopWorker = false;

        internal static void Run()
        {
            Console.WriteLine("Запустим работу на 5 секунд");
            Thread thread = new Thread(Worker);
            thread.Start();
            Thread.Sleep(5000);
            s_stopWorker= true;
            Console.WriteLine("Ждём окончания второго потока");
            thread.Join(); 
        }

        // Запустить данный метод нужно при включённой оптимизации
        // например в режиме Any CPU Release
        // с отключенной оптимизацией код будет работать так, как ожидается
        private static void Worker(object state)
        {
            int x = 0;
            while (!s_stopWorker) // при оптимизации кода цикл будет работать бесконечно
            {
                x++;
            }
            Console.WriteLine($"Worker остановился при x = {x}");

            // вот во что превратится код при оптимизации
            //int x = 0;
            //while (true) // компилятор увидит, что значение s_stopWorker не меняется всё время работы метода
            //{            // поэтому вычислит его заранее при входе в метод
            //    x++;
            //}
            //Console.WriteLine($"Worker остановился при x = {x}");
        }
    }


    internal class ThreadSharing
    {
        private int m_flag = 0;
        private int m_value = 0;

        // При оптимизации компилятор может поменять местами присвоения m_value и m_flag
        public void Thread1()
        {
            m_value = 5;
            m_flag = 1;
        }

        
        public void Thread2()
        {
            // поле m_value может быть прочитано до m_flag
            if (m_flag == 1) 
            {
                Console.WriteLine(m_value);
            }
        }

        public void Thread1Volatile()
        {
            m_value = 5;   // Более раннее присвоение делается до m_flag;
            Volatile.Write(ref m_flag, 1);
        }


        public void Thread2Volitile()
        {
            if (Volatile.Read(ref m_flag) == 1)
            {
                Console.WriteLine(m_value);  // Более позднее чтение производится после m_flag
            }
        }

        public static class Interlocked
        {
            //     прибавляет value к location и возвращает новое значение
            public static int Add(ref int location1, int value) { throw new NotImplementedException(); }

            //     Присваивает значение value переменной location, только если location == comparand
            //     и возвращает исходное значение location
            public static int CompareExchange(ref int location1, int value, int comparand)
            { throw new NotImplementedException(); }

            //     Уменьшает на 1 значение location и возвращает новое значение
            public static int Decrement(ref int location)
            { throw new NotImplementedException(); }

            //     Присваивает значение value переменной location и возвращает исходное значение location
            public static int Exchange(ref int location1, int value)
            { throw new NotImplementedException(); }

            //     Увеличивает на 1 значение location и возвращает новое значение
            public static int Increment(ref int location)
            { throw new NotImplementedException(); }

        }
    }
}
