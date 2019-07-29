using System;
using System.Linq;

namespace _4._6_i_seek_you
{
    class Program
    {
        delegate void SearchOverDelegate(int[] mass);
        static void PositiveSearch(int[] items) // 1-Simple method of search
        {
            Console.WriteLine("Positive integers in array:");
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] > 0)
                {
                    Console.Write(items[i] + ", ");
                }
            }
            Console.WriteLine();
        }
        static void DisplayOriginalArray(int[] items)
        {
            Console.WriteLine("Original array:");
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write(items[i] + ", ");
            }
        }
        static void Main(string[] args)
        {
            int[] arr = { 56, 74, -98, 0, 53, -5, 9, -15 };
            PositiveSearch(arr);
            // 2-Delegate instance:
            SearchOverDelegate del = PositiveSearch;
            del?.Invoke(arr);
            // 3-Anonymous method:
            SearchOverDelegate handler = delegate (int[] items)
            {
                Console.WriteLine("Anonymous method. Negative integers in array:");
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] < 0)
                    {
                        Console.Write(items[i] + ", ");
                    }
                }
                Console.WriteLine();
            };
            handler(arr);
            // 4-Lambda expression:
            SearchOverDelegate lambda = (massive) => DisplayOriginalArray(arr);
            lambda(arr);
            // 5-Using LINQ
            int array_min = arr.Min();
            Console.WriteLine($"\nMin in array: {array_min}");

            Console.ReadKey(); //Delay;
         }
    }
}
