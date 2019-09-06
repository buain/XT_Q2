using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _7._2._HTML_Replacer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст с тегами HTML\n");
            //string input = "<b>Это</b>текст<i>с</i><font color=\"red\">HTML</font>кодами";
            string input = Console.ReadLine();

            Console.WriteLine("Исходный текст: {0}\n", input);

            //delete "":
            string pattern_quotes = @"""([^""]|"""")*""";
            string no = "";
            Regex regex_quotes = new Regex(pattern_quotes);
            string without_quotes = regex_quotes.Replace(input, no);
            //Console.WriteLine("Результат без кавычек: {0}\n", without_quotes);

            //delete =:
            string pattern_equally = @"[=]";
            Regex regex_equally = new Regex(pattern_equally);
            string without_equally = regex_equally.Replace(without_quotes, no);
            //Console.WriteLine("Результат без знака равно: {0}\n", without_equally);

            //Replace backspase:
            string pattern_backspace = @"\s+";
            string item = "_";
            Regex regex_backspace = new Regex(pattern_backspace);
            string without_backspace = regex_backspace.Replace(without_equally, no);
            //Console.WriteLine("Результат без пробела: {0}\n", without_backspace);

            //Replace tags to _:
            string pattern1 = @"(<\W*\w*>\W*)(<\W*\w*>\W*)";
            //string pattern = @"(<\W*.+?>\W*)";
            Regex regex1 = new Regex(pattern1);
            string result1 = regex1.Replace(without_backspace, item);

            string pattern = @"(<\W*\w*>\W*)";
            //string pattern = @"(<\W*.+?>\W*)";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(result1, item);

            Console.WriteLine("Результат замены: {0}\n", result);
            Console.ReadKey();//Delay
        }
    }
}
