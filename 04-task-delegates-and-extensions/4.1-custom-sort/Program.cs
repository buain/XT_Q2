using System;
using System.Collections;
using System.Collections.Generic;

namespace _4._1_custom_sort
{
    delegate int[] delegate_sort<T>(int[] items);
    class Program
    {
        private static int[] SortOverDelegate(int[] items) // Sorting array
        {
            int temp = 0;
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = i + 1; j < items.Length; j++)
                {
                    if(items[i] > items[j])
                    {
                        temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                }
            }
            return items;
        }
        static void Main(string[] args)
        {
            int[] array = { 4, 5, 6, 1, 9 };
            Console.WriteLine("Unsorted array:");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
 
            delegate_sort<int> sort = SortOverDelegate;
            int[] sorted_array = sort(array);

            Console.WriteLine("\nSorted array:");
            foreach (int i in sorted_array)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey(); //Delay;
        }
    }
}
