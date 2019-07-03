using System;

namespace _1._7_array_processing
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] array = new int[15];
            Random ran = new Random();
            Console.WriteLine("Random array:");
            //Random array:
            for (int i = 0; i < array.Length; i++)
            {
                    array[i] = ran.Next(1, 100);
                    Console.Write($"{array[i]} ");
            }
            Console.WriteLine(" \nSorted Array:");
            int temp = 0;
            //Sorting array:
            for (int i = 0; i < array.Length-1; i++)
            {
                for(int j = i + 1; j < array.Length; j++)
                {
                    if(array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            //Print sorted array:
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine($" \nMax number of array: {array[array.Length-1]}");
            Console.WriteLine($"Min number of array: {array[0]}");
            
            Console.ReadKey();//Delay
        }
    }
}
