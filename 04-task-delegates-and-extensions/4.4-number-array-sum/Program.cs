using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._4_number_array_sum
{
    public static class SumExtention
    {
        public static int Sum(this int[] collection, int[] condition)
        {
            int sum = 0;
            var items = new int[collection.Length + condition.Length];
            //Add arrays collection and condition to array items:
            collection.CopyTo(items, 0);
            condition.CopyTo(items, collection.Length);

            foreach (var i in items)
            {
                sum += i;
            }
            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 45, 89, 52, 7, 63 };
            int[] array2 = { 8, 9, 6, 4, 7, 6, 5, 2 };
            int sum_array = array1.Sum(array2);
            Console.WriteLine($"Sum of arrays: {sum_array}");
            Console.ReadKey(); //Delay;
        }
    }
}
