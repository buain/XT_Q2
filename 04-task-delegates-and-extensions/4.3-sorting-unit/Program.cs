using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace _4._3_sorting_unit
{
    class Program
    {
        delegate int[] delegate_sort<T>(int[] items);

        //public delegate void Sort_Handler(string message);
        //public event Sort_Handler EndSort; // 3-Event
        
        private static int[] Sort(int[] items) // 1-Sorting array
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
                        Thread.Sleep(400);
                    }
                }
            }
            //if (EndSort != null)
            //{
            //    EndSort("Sorting is done...");
            //}
            //EndSort?.Invoke("Sorting is done...");
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

            delegate_sort<int> sort = Sort;
            int[] sorted_array = sort(array);
            

            Console.WriteLine("\nSorted array:");
            foreach (int i in sorted_array)
            {
                Console.Write(i + " ");
            }

            //Anonymous method
            delegate_sort<int> handler = delegate (int[] items)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    items[i] = items[i] * 2;
                    Thread.Sleep(500);
                }
                return items;
            };
            handler(array);

            //ThreadStart _handler = new ThreadStart(handler);
            Thread myThread = new Thread(handler);
            myThread.Start();

            

            Console.ReadKey(); //Delay;
        }
    }
}
