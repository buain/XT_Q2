using System;

namespace _1._10_2d_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int[,] array = new int[8, 9];
            Random ran = new Random();
            Console.WriteLine("Random two-dimensional array:");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    array[i, j] = ran.Next(25, 80);
                    Console.Write("{0}\t", array[i,j]);
                    if((i + j) % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Sum of numbers with even sum of position: {sum}");
            Console.ReadKey();//Delay
        }
    }
}
