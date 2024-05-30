using System.Diagnostics;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        System.Console.WriteLine("Enter the beginning of the range.");
        bool isNum1 = int.TryParse(Console.ReadLine(), out int num1);
        System.Console.WriteLine("Enter the end of the range.");
        bool isNum2 = int.TryParse(Console.ReadLine(), out int num2);
        System.Console.WriteLine("--------------------");

        if (!isNum1 && !isNum2)
        {
            System.Console.WriteLine("Please enter a number.");
            return;
        }

        num1 = num1 < 3 ? 3 : num1;

        List<Thread> threads = new List<Thread>();
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();

        System.Console.Write("2 ");

        //------------------------------------- 3. YÖNTEM -------------------------------------
        Parallel.ForEach(Enumerable.Range(num1, num2 + 1).Where(i => i % 2 != 0), i =>
        {
            PrintIfPrime(i);
        });

        System.Console.WriteLine();
        watch.Stop();
        Console.WriteLine($"Runtime: {watch.ElapsedMilliseconds} ms");
    }

    static void PrintIfPrime(long num)
    {
        bool isPrime = true;

        int sqrtNum = (int)Math.Sqrt(num);
        for (int i = 3; i <= sqrtNum; i += 2)
        {
            if (num % i == 0)
            {
                isPrime = false;
            }
        }

        if (isPrime)
        {
            Console.Write(num + " ");
        }
    }
}