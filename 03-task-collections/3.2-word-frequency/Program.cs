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
            AddDict(array_words);
        }
        public static void AddDict(string[] items) // Add array to Dict
        {
            var dict = new Dictionary<string, int>();
            for (int i = 1; i < items.Length; i++)
            {
                if (dict.ContainsKey(items[i]))
                {
                    dict[items[i]]++;
                }
                else
                {
                    dict.Add(items[i], 1);
                } 
            }
            Console.WriteLine("Dictionary:");
            foreach (KeyValuePair<string, int> word in dict) // Displey dictionary
            {
                Console.Write($"{word}  ");
            }
            Exist(dict);
        }
        public static void Exist(Dictionary<string, int> items) // Show consisting word
        {
            items.TryGetValue("and", out int result_and);
            items.TryGetValue("cat", out int result_cat);
            Console.WriteLine($"\nFor example: Word \"and\" repeats {result_and} times");
            Console.WriteLine($"For example: Word \"cat\" repeats {result_cat} times");
        }

        static void Main(string[] args)
        {
            string text = "My cat eat meat and drink milk. And my dog eat meat and drink milk too. I like my cat and my dog";
            Console.WriteLine($"Sentence: \n{text}");
            string low_text = text.ToLower(); // Lower case translation
            Clear(low_text);
            
            Console.ReadKey();//Delay
        }
    }
}
