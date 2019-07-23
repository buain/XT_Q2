using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3._1_lost
{
    class Program
    {
        static void Display(IEnumerable<int> numbers)
        {
            foreach (var i in numbers)
                Console.Write(i + "  ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Display(numbers.ToList());
            while (numbers.Count > 1)
            {
                numbers = numbers.Where((x, i) => i % 2 == 0).ToList();
                Display(numbers);
            }
            Console.ReadKey(); //Delay
        }
    }
}
