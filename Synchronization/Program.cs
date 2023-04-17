using Synchronization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Strange.Run();
        Console.ReadLine();
    }


    /// <summary>
    /// Данный  метод будет оптимизирован. компилятор попытается встроить метод в место вызова,
    /// но так как цикл не будет выполнен ни разу, то метод даже не будет скомпилирован
    /// </summary>
    private static void OptimizedAway()
    {
        int value = (100 - 25 * 2) - (5 * 10);
        for (int i = 0; i < value; i++)
        {
            Console.WriteLine("Some Information");
        }
    }

}