using System;
using System.Collections;
using System.Collections.Generic;

namespace _4._5_to_int_or_not_to_int
{
    public static class FindInt
    {
        public static string LookForInt(this char[] items)
        {
            string result = null;
            for (int i = 0; i < items.Length; i++)
            {
                if(
                    items[i] == '0' ||
                    items[i] == '1' ||
                    items[i] == '2' ||
                    items[i] == '3' ||
                    items[i] == '4' ||
                    items[i] == '5' ||
                    items[i] == '6' ||
                    items[i] == '7' ||
                    items[i] == '8' ||
                    items[i] == '9'
                    )
                {
                    result += items[i];
                }
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "sfdkhv 8hfvjv 97743bbk";
            Console.WriteLine($"String: {sentence}");

            char[] symbols = sentence.ToCharArray();
            string integers = symbols.LookForInt();

            Console.WriteLine("Integers in string: ");
            for (int i = 0; i < integers.Length; i++)
            {
                Console.Write(integers[i] + ",  ");
            }
            Console.ReadKey(); //Delay;
        }
    }
}
