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

        if (num1 > num2)
        {
            System.Console.WriteLine("The beginning of the range must be less than the end of the range.");
            return;
        }

        if (num1 < 3)
        {
            num1 = 3;
            System.Console.Write("2 ");
        }

        //countdownEvent kullanarak threadlerin bitmesini bekleyebiliriz.
        //burada kaç tane iş oluşacağını önceden belirtiyoruz.
        var countdownEvent = new CountdownEvent((int)Math.Ceiling((num2 - num1) / 2d));

        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();

        for (int i = num1; i <= num2; i += 2)
        {
            //araştırınca thread kullanırken anonim fonksiyon içinde methoda parametre verince valuetype bile olsa reference gönderiyormuş.
            //yani localI tanımlamazsam birçok sorun çıkıyor. Mesela aynı sayının 2 3 defa prime mı diye kontrol edilmesi ve print edilmesi.
            int localI = i;
            //------------------------------------- 2. YÖNTEM -------------------------------------
            ThreadPool.QueueUserWorkItem((state) =>
            {
                PrintIfPrime(localI, countdownEvent);
            });
        }

        countdownEvent.Wait(); //Tüm işler sinyalleninceye kadar main thread bekliyor.
        System.Console.WriteLine();
        watch.Stop();
        Console.WriteLine($"Runtime: {watch.ElapsedMilliseconds} ms");
    }

    static void PrintIfPrime(long num, CountdownEvent cde)
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

        cde.Signal(); //Her iş bittiğinde sinyalliyor.
    }
}