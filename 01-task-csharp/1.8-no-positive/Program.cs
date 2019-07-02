using System;

namespace _1._8_no_positive
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array[2,3,3]:
            int[,,] matrix = { 
                {
                    { 56, -45, 23 }, 
                    { -68, 73, -91 }, 
                    { 46, 25, -32 }
                } , 
                { 
                    { -21, 24, -95 }, 
                    { 43, 47, 88 }, 
                    { -18, -50, 16} }
            };
            Console.WriteLine("Array before replace:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix.GetLength(2); k++)
                    {
                        Console.Write($"{matrix[i, j, k]}  ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix.GetLength(2); k++)
                    {
                        if (matrix[i, j, k] > 0)
                        {
                            matrix[i, j, k] = 0;
                        }
                    }
                }
            }
            Console.WriteLine("Array after replace:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix.GetLength(2); k++)
                    {
                        Console.Write($"{matrix[i, j, k]}  ");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();//Delay
        }
    }
}
