using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace _4._3_sorting_unit
{
    delegate int[] delegate_sort<T>(int[] items);
    class Program
    {
        public delegate void Sort_Handler(string message);
        public event Sort_Handler EndSort; // 3-Event
        
        private static int[] SortOverDelegate(int[] items) // 1-Sorting array
        {
            int temp = 0;
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = i + 1; j < items.Length; j++)
                {
                    if (items[i] > items[j])
                    {
                        temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                }
            }
            //if (EndSort != null)
            //{
            //    EndSort("Sorting is done...");
            //}
            EndSort?.Invoke("Sorting is done...");
            return items;
        }
        //public event EventHandler<EventArgs> EndSort
        
        //{

        //}
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
