using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3._2_word_frequency
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
            ToDict(array_words);
        }
        public static void ToDict(string[] items)
        {

        }

        static void Main(string[] args)
        {
            string text = 
                "My cat eat meat and drink milk. And my dog eat meat and drink milk too. I like my cat and dog";
            Console.WriteLine($"Предложение: {text}");
            string low_text = text.ToLower(); //Перевод всех слов в нижний регистр
            Clear(low_text);

            //var list_text = low_text.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(x => x.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).ToList())
            //    .ToList();//Преобразование предложения в список


            Console.WriteLine(list_text);
            

            Console.ReadKey();//Delay
        }
    }
}
