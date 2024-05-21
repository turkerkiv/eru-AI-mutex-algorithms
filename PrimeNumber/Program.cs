internal class Program
{
    private static void Main(string[] args)
    {
        bool isNum = int.TryParse(Console.ReadLine(), out int num);
        bool isPrimeNum = true;
        if (!isNum)
        {
            System.Console.WriteLine("Please enter a number.");
            return;
        }

        if (num == 2)
        {
            System.Console.WriteLine($"{num} is a prime number.");
            return;
        }

        if (num % 2 != 0)
        {
            int sqrtNum = (int)Math.Sqrt(num);
            for (int i = 3; i <= sqrtNum; i += 2)
            {
                if (num % i == 0)
                {
                    isPrimeNum = false;
                    break;
                }
            }
        }
        else
        {
            isPrimeNum = false;
        }

        if (isPrimeNum)
        {
            System.Console.WriteLine($"{num} is a prime number.");
        }
        else
        {
            System.Console.WriteLine($"{num} is not a prime number.");
        }
    }
}