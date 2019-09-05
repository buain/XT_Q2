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
            string pattern_email = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

            Console.WriteLine("Введите строку, содержащую валидный адрес электронной почты E-mail: ");
            string input = "Иван: ivan@mail.ru, Петр: p_ivanov@mail.rol.ru";
            //string input = Console.ReadLine();

            Regex regex = new Regex(pattern_email);

            //
            Match email1 = Regex.Match(input, pattern_email);
            Match email2 = email1.NextMatch();
            Console.WriteLine($"Найденные адреса электронной почты: {email1} , {email2}");

            Console.ReadKey();//Delay
        }
    }
}
