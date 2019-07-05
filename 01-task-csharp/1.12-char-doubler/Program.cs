using System;

namespace _1._12_char_doubler
{
    class Program
    {
        public static string DubbleWord(string first_text, string second_text)
        {

            for (int i = 0; i < first_text.Length; i++)
            {
                if (second_text.Contains(first_text[i]))
                {
                    first_text = first_text.Insert(i + 1, first_text[i++].ToString());
                }
            }
            string dubble_word = first_text;
            return dubble_word;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку:");
            string first_text = Console.ReadLine();

            Console.WriteLine("Введите вторую строку:");
            string second_text = Console.ReadLine();

            DubbleWord(first_text, second_text);
            string dubble_word = DubbleWord(first_text, second_text);

            Console.WriteLine($"Результирующая строка: {dubble_word}");


            Console.ReadKey();//Delay
        }
    }
}
