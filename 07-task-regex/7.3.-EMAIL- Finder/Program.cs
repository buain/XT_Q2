using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _7._3._EMAIL__Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern_email = @"\b[^_*.+][-\w.]+@([a-z0-9\.-]+)\.([a-z\.]{2,6})\b";

            Console.WriteLine("Введите строку, содержащую валидный адрес электронной почты E-mail: ");
            //string input = "Иван: ivan@mail.ru, Петр: p_ivanov@mail.rol.ru";
            string input = Console.ReadLine();

            Regex regex = new Regex(pattern_email, RegexOptions.IgnoreCase);
            MatchCollection emails = regex.Matches(input);

            Console.WriteLine($"Найденные адреса электронной почты:");
            foreach (Match email in emails)
            {
                Console.WriteLine(email.Value);
            }
            Console.ReadKey();//Delay
        }
    }
}
