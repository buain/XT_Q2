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
                //switch (result)
                //{
                //    case "bold":
                //        result += "Bold, ";
                //        continue;
                //    case "italic":
                //        result += "Italic, ";
                //        continue;
                //    case "underline":
                //        result += "Underline, ";
                //        continue;
                //}

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
            }
        }
        public static void Font(string result)
        {
            Console.WriteLine($"Параметры надписи: {result}");
            Console.WriteLine("Введите:");
            string[] font = { "1: bold", "2: italic", "3: underline" };
            for(int i = 0; i < font.Length; i++)
            {
                Console.WriteLine($"\t{i}");
            }
        }
        static void Main(string[] args)
        {
            
            

            int input = Int32.Parse(Console.ReadLine());

            

            string[] output = null;
            for (int i = 0; i < font.Length; i++)
            {
                if (input == i)
                {
                    output.Add(font[i]);
                }
                else
                {
                    Console.WriteLine("Неверный ввод");
                }
            }


            Console.ReadKey();//Delay
        }
    }
}
