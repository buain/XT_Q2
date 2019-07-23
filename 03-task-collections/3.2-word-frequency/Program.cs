using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3._2_word_frequency
{
    class Program
    {

        static void Main(string[] args)
        {
            string text = 
                "My cat eat meat and drink milk. And my dog eat meat and drink milk too. I like my cat and dog";
            string low_text = text.ToLower(); //Перевод всех слов в нижний регистр


            var list_text = low_text.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).ToList())
                .ToList();//Преобразование предложения в список


            Console.ReadKey();//Delay
        }
    }
}
