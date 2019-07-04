using System;

namespace _1._6_font_adjustment
{
    class Program
    {
        enum Font
        {
            None,
            bold,
            italic,
            underline
        }
        static void Main(string[] args)
        {
            Font none = Font.None;
            Console.WriteLine($"Параметры надписи: {none.ToString()} ");

            string[] font = { "None", "bold", "italic", "underline" };
            string[] input;

            int number = Int32.Parse(Console.ReadLine());

            for(int i = 0; i <= font.Length; i++)
            {
                if (number == font[i].IndexOf(font[i]))
                {

                }
            }

            Console.WriteLine("Введите:");
            Console.WriteLine("        1: bold");
            Console.WriteLine("        2: italic");
            Console.WriteLine("        3: underline");

            Console.ReadKey();//Delay
        }
    }
}
