using System;
using System.Collections;
using System.Collections.Generic;

namespace _3._2_word_frequency
{
    class Program
    {
        public static void Clear(string items) // Clear string from punctuation and other simbols
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
            //AddList(array_words);
            AddDict(array_words);
        }
        //public static void AddList(string[] items) // Add array to list
        //{
        //    List<string> list_text = new List<string>();

        //    foreach (var i in items)
        //    {
        //        list_text.Add(i);
        //    }

        //}
        public static void AddDict(string[] items) // Add array to Dict
        {
           // Dictionary<string, int> dict = new Dictionary<string, int>();
            int count = 0;
            for(int i = 0; i < items.Length; i++)
            {
                if(items[i] == "and")
                {
                    count++;
                }
                Console.WriteLine($"Слово {items} повторялось {count} раз");
            }
        }


        static void Main(string[] args)
        {
            string text = "My cat eat meat and drink milk. And my dog eat meat and drink milk too. I like my cat and dog";
            Console.WriteLine($"Предложение: {text}");
            string low_text = text.ToLower(); //Перевод всех слов в нижний регистр
            Clear(low_text);
            

            //var list_text = low_text.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(x => x.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).ToList())
            //    .ToList();//Преобразование предложения в список


            //Console.WriteLine(list_text);
            

            Console.ReadKey();//Delay
        }
    }
}
