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

        num1 = num1 < 2 ? 2 : num1;

        List<Thread> threads = new List<Thread>();
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();

        for (int i = num1; i <= num2; i++)
        {
            //araştırınca thread kullanırken anonim fonksiyon içinde methoda parametre verince valuetype bile olsa reference gönderiyormuş.
            //yani localI tanımlamazsam birçok sorun çıkıyor. Mesela aynı sayının 2 3 defa prime mı diye kontrol edilmesi ve print edilmesi.
            int localI = i;
            Thread checkPrimeThread = new Thread(() => PrintIfPrime(localI));
            checkPrimeThread.Start(); //foreach içinde çağırınca performans olarak kötüleşiyor. burda yazınca performans daha iyi.
            threads.Add(checkPrimeThread);
        }

        foreach (var thread in threads)
        {
            // thread.Start();
            thread.Join();
        }

        watch.Stop();
        Console.WriteLine($"Runtime: {watch.ElapsedMilliseconds} ms");
    }

    static void PrintIfPrime(int num)
    {
        bool isPrime = true;

        if (num == 2)
        {
            isPrime = true;
            return;
        }

        if (num % 2 != 0)
        {
            int sqrtNum = (int)Math.Sqrt(num);
            for (int i = 3; i <= sqrtNum; i += 2)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                }
            }
        }
        else
        {
            isPrime = false;
        }

        if (isPrime)
        {
            Console.WriteLine(num + " ");
        }
    }
}