using System;

namespace _1._6_font_adjustment
{
    class Program
    {
        public static void Choiсe()
        {
            bool bold = false;
            bool italic = false;
            bool underline = false;
            while (true)
            {
                string result = "";
                if (bold)
                {
                    result += "Bold, ";
                }
                if (italic)
                {
                    result += "Italic, ";
                }
                if (underline)
                {
                    result += "Underline, ";
                }
                if(bold || italic || underline)
                {
                    Font(result.Remove(result.Length - 2));
                }
                else
                {
                    result = "None";
                    Font(result);
                }
                int input = 0;
                if (Int32.TryParse(Console.ReadLine(), out input))
                {
                    if (input == 1)
                    {
                        if (bold)
                        {
                            bold = false;
                        }
                        else
                        {
                            bold = true;
                        }
                    }
                    else if (input == 2)
                    {
                        if (italic)
                        {
                            italic = false;
                        }
                        else
                        {
                            italic = true;
                        }
                    }
                    else if (input == 3)
                    {
                        if (underline)
                        {
                            underline = false;
                        }
                        else
                        {
                            underline = true;
                        }
                    }
                    else if(input <= 0 || input > 3)
                    {
                        Console.WriteLine("\nНеверный ввод. Введите номер шрифта: ");
                    }
                }
            }
        }
        public static void Font(string result)
        {
            Console.WriteLine($"Параметры надписи: {result}");
            Console.WriteLine("Введите:");
            string[] font = { "1: bold", "2: italic", "3: underline" };
            for(int i = 0; i < font.Length; i++)
            {
                Console.WriteLine($"\t{font[i]}");
            }
        }
        static void Main(string[] args)
        {
            Choiсe();

            Console.ReadKey();//Delay
        }
    }
}
