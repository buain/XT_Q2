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
            //foreach(var x in array_words)
            //{
            //    Console.WriteLine(x);
            //}
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

        //}
        public static void AddDict(string[] items) // Add array to Dict
        {
            //Dictionary<string, int> dict = new Dictionary<string, int>();
            var dict = new Dictionary<string, int>();
            //int count;
            int j = 1;
            int k = 1;
            for (int i = 1; i < items.Length; i++)
            {

                if (!dict.ContainsKey(items[i]))
                {
                    //dict.Remove(items[i]);
                    //j++;
                    создать метод, когда повторяющийся элемент перезаписывается
                    //j++;

                    //dict[items[i]] = j++;
                    //dict.TryAdd(items[i], j++);
                }

                else
                {
                    dict.Add(items[i], k);
                }

            }
            foreach (KeyValuePair<string, int> kv in dict)
            {
                Console.WriteLine($"{kv}  ");
            }
            Exist(dict);
        }
        
        public static void Exist(Dictionary<string, int> items)
        {
            //int result = items.ContainsValue("and");
            int result = 0;
            //foreach(var i in items)
            //{
            if (items.ContainsKey("and"))
            {
                result++;
            }

            //}
            Console.WriteLine($"Слово \"and\" повторялось {result} раз");




        }

        static void Main(string[] args)
        {
            string text = "My cat eat meat and drink milk. And my dog eat meat and drink milk too. I like my cat and my dog";
            Console.WriteLine($"Предложение: {text}");
            string low_text = text.ToLower(); //Перевод всех слов в нижний регистр
            Clear(low_text);
            //Console.WriteLine(low_text);

            //var list_text = low_text.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(x => x.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).ToList())
            //    .ToList();//Преобразование предложения в список


            //Console.WriteLine(list_text);


            Console.ReadKey();//Delay
        }
    }
}
