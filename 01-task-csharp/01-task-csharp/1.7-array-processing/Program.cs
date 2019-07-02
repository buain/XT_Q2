using System;

namespace _1._7_array_processing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[4, 6];
            Random ran = new Random();
            Console.WriteLine("Random two-dimensional array:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    array[i, j] = ran.Next(1, 100);
                    Console.Write("{0}\t", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();//Delay
        }
    }
}
