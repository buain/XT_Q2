using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace _4._3_sorting_unit
{
    delegate int[] delegate_sort<T>(int[] items);
    static class SortThread
    {
        public static event Action<string> Done;
        public static int[] Sort(int[] items) // 1-Sorting array
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
            return items;
        }
        public static void ThreadSort(int[] items) // 2-Sorting in thread
        {
            Thread myThread = new Thread(() =>
            {
                Sort(items);
                Done?.Invoke("Sorting is done"); // 3-Event indicating the completion of sorting
            });
            myThread.Start();
        } 
    }
    class Program
    {
        static void DoneNotice(string notice)
        {
            Console.WriteLine(notice);
        }
        static void Main(string[] args)
        {
            int[] array = { 4, 5, 6, 1, 9 };
            SortThread.Done += DoneNotice;
            SortThread.ThreadSort(array);

            Console.ReadKey(); //Delay;
        }
    }
}
