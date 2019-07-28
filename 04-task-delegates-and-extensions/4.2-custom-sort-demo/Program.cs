using System;
using System.Collections;
using System.Collections.Generic;

namespace _4._2_custom_sort_demo
{
    delegate string[] delegate_sort<T>(string[] items);
    //class StringComparer : IComparer<string>
    //{
    //    public int Compare(string item1, string item2)
    //    {
    //        for (int i = 0; i < item1.Length; ++i)
    //        {
    //            if (item1[i] > item2[i])
    //            {
    //                return 1;
    //            }
    //            if (item1[i] < item2[i])
    //            {
    //                return -1;
    //            }
    //        }
    //        return 0;
    //    }
    //}
    class Program
    {
        private static string[] SortOverDelegate(string[] items) // Sorting array
        {
            string temp = null;
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = i + 1; j < items.Length; j++)
                {
                    if (items[i].Length > items[j].Length)
                    {
                        temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                    if (items[i].Length == items[j].Length)
                    {
                        if (CheckEquals(items[i], items[j]))
                        {
                            temp = items[i];
                            items[i] = items[j];
                            items[j] = temp;
                        }
                    }
                        
                }
            }
            return items;
        }
        private static bool CheckEquals(string s1, string s2)
        {
            for(int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
            }
            return false;
        }
        
        static void Main(string[] args)
        {
            string[] string_array = { "wdrt", "asres", "hbjdhks", "oiiu", "iio", "za" };
            
            Console.WriteLine("Unsorted array:");
            foreach (string i in string_array)
            {
                Console.Write(i + "  ");
            }

            delegate_sort<string> sort = SortOverDelegate;
            string[] sorted_array = sort(string_array);

            Console.WriteLine("\nSorted array:");
            foreach (string i in sorted_array)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey(); //Delay;
        }
    }
}
