using System;

namespace _1._9_non_negative_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int Sum = 0;
            int[] array = {72, -53, 24, -15, 61, 45, 87, -12 };
            Console.Write($"Array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}, ");
            }
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    Sum += array[i];
                }
            }
            Console.WriteLine($"Sum of the positive numbers of array: {Sum}");
           
            Console.ReadKey();//Delay
        }
    }
}
