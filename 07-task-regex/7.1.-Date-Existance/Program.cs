using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _7._1._Date_Existance
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\d{2}-\d{2}-\d{4}";
            Console.WriteLine("Введите текст в формате dd-mm-yyyy: ");
            string text = Console.ReadLine();//"2016 год наступит 01-01-2016";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(text) == true)
            {
                Console.WriteLine("В тексте \"{0}\" содержится дата", text);
            }
            Console.ReadKey();//Delay
        }
    }
}
