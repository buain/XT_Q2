using System;

namespace _1._5_sum_of_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int Sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                    if (i % 3 == 0 || i % 5 == 0)
                    {
                        Sum += i;
                    }
            }
            Console.WriteLine($"Sum of numbers: {Sum}");
            Console.ReadKey();//Delay
        }
    }
}
