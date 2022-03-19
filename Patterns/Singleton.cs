using System;
using System.Text;

namespace Patterns
{
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> _instance =
        new Lazy<Singleton>(() => new Singleton());
        Singleton() { }
        public static Singleton Instance { get { return _instance.Value; } }

    }


    static class SingletonExtensions
    {
        public  static int MyExt(this Singleton singleton, int t)
        {
            return t;
        }
    }
    





    public sealed class Singleton1
    {
        private static  Singleton1 _instance;
        Singleton1() { }
        public static Singleton1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton1();
                }
                return
                      _instance;
            }
        }

    }
}
