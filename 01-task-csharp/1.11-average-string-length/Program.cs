using System;

namespace _1._11_average_string_length
{
    class Program
    {
        public static void Clear(string items) //Clear string from punctuation and other simbols
        {
            string clear_words = null;
            for (int i = 0; i < items.Length; i++)
            {
                if (char.IsLetter(items[i]) == true || char.IsSeparator(items[i]) == true)
                {
                    clear_words += items[i];
                }
            }
            string[] array_words = clear_words.Split();
            Sum(array_words);
        }
        public static void Sum(string[] items) //Sum of words
        {
            int count = 0;
            int sum = 0;

            for (int i = 0; i < items.Length; i++)
            {
                sum += items[i].Length;
                count++;
            }
            Calc(sum, count);
        }
        public static void Calc(int sum, int count) //Calc average length
        {
            Console.WriteLine($"\nAverage length of the words: {sum / count}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input some words:");
            string words = Console.ReadLine();

            Clear(words);
            Console.ReadKey();//Delay
        }
    }
}
