using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        System.Console.WriteLine("Enter the beginning point of range.");
        bool isNum1 = int.TryParse(Console.ReadLine(), out int num1);
        System.Console.WriteLine("Enter the ending point of range.");
        bool isNum2 = int.TryParse(Console.ReadLine(), out int num2);

        if (!isNum1 && !isNum2)
        {
            System.Console.WriteLine("Please enter a number.");
            return;
        }

        System.Console.WriteLine("--------------------");
        var watch = new Stopwatch();
        watch.Start();

        for (int i = num1 < 2 ? 2 : num1; i <= num2; i++)
        {
            if (isPrime(i))
            {
                Console.Write(i + ", ");
            }
        }

        System.Console.WriteLine();
        watch.Stop();
        System.Console.WriteLine("Runtime: {0} ms", watch.ElapsedMilliseconds);
    }

    static bool isPrime(int num)
    {
        if (num == 2)
        {
            return true;
        }

        if (num % 2 != 0)
        {
            int sqrtNum = (int)Math.Sqrt(num);
            for (int i = 3; i <= sqrtNum; i += 2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }
}