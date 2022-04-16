using System;
using System.Threading.Tasks;

namespace AsyncFiniteStateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private static async Task<Type1> Method1Async() { await Task.Delay(1000); return new Type1(); }
        private static async Task<Type2> Method2Async() { await Task.Delay(1000); return new Type2(); }

        private static async Task<string> MyMethodAsync(int argument)
        {
            int local = argument;
            Type1 result1 = default(Type1);
            try
            {
                result1 = await Method1Async();
                for (int i = 0; i < local; i++)
                {
                    Type2 result2 = await Method2Async();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Catch");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
            return $"Done{local}{result1}";
        }

        
    }

    public sealed class Type1 { }
    public sealed class Type2 { }
}
