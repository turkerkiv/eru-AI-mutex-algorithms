using System;
using System.Diagnostics;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter the beginning of the range.");
        bool isNum1 = int.TryParse(Console.ReadLine(), out int num1);
        Console.WriteLine("Enter the end of the range.");
        bool isNum2 = int.TryParse(Console.ReadLine(), out int num2);

        if (!isNum1 || !isNum2 || num1 < 2)
        {
            Console.WriteLine("Please enter a valid range starting from 2.");
            return;
        }

        Stopwatch watch = Stopwatch.StartNew();
        PrintPrimesInRange(num1, num2);
        watch.Stop();

        Console.WriteLine($"Runtime: {watch.ElapsedMilliseconds} ms");
    }

    static void PrintPrimesInRange(int start, int end)
    {
        bool[] primes = new bool[end + 1];
        int sqrtEnd = (int)Math.Sqrt(end);

        Parallel.For(2, sqrtEnd + 1, i =>
        {
            if (!primes[i])
            {
                for (int j = i * i; j <= end; j += i)
                {
                    primes[j] = true;
                }
            }
        });

        for (int i = Math.Max(2, start); i <= end; i++)
        {
            if (!primes[i])
            {
                Console.Write(i + ", ");
            }
        }
    }
}
