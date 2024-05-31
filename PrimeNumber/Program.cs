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

        //bug
        num1 = num1 < 3 ? 3 : num1;
        System.Console.Write("2 ");

        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();

        int threadCount = 2;
        for (int i = 0; i < threadCount; i++)
        {
            int rangeStep = (num2 - num1) / threadCount;
            //*** beginning ve end için float veya double ile çok daha iyi olabilir + 1 eklemeye gerek kalmaz ve daha doğru sonuçlar alınır
            //mesela 1000-2000 arasında 2 thread çalışacaksa 1000-1500 ve 1500-2000 aralıklarında çalışacak şekilde ayarlanır. en sondaki ende eklenen rangestep + 1 sayı kaçırmamak için
            Thread checkPrimeThread = new Thread(() => PrintIfPrime(num1 + i * rangeStep, num1 + rangeStep + i * rangeStep + 1));
            checkPrimeThread.Start();
            checkPrimeThread.Join();
        }

        System.Console.WriteLine();
        watch.Stop();
        Console.WriteLine($"Runtime: {watch.ElapsedMilliseconds} ms");
    }

    static void PrintIfPrime(int beginning, int end)
    {
        beginning = beginning % 2 == 0 ? beginning + 1 : beginning;
        for (int i = beginning; i <= end; i += 2)
        {
            bool isPrime = true;
            int sqrtNum = (int)Math.Sqrt(i);
            for (int j = 3; j <= sqrtNum; j += 2)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                }
            }

            if (isPrime)
            {
                Console.Write(i + " ");
            }
        }
    }
}