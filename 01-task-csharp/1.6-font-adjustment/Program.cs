using System;

namespace _1._6_font_adjustment
{
    class Program
    {
        //public static void Font()
        //{

        //}
        //[Flags]
        //enum Font : int
        //{
        //    None = 1,
        //    bold = 2,
        //    italic = 4,
        //    //bold_italic = 6,
        //    underline = 8//,
        //                 //bold_underline = 10,
        //                 //italic_underline = 12,
        //                 //bold_italic_underline = 14
        //}


        static void Main(string[] args)
        {
            
            //none.ToString()
            //Font none = Font.None;
            Console.WriteLine($"Параметры надписи: {Font.None} ");
            Console.WriteLine("Введите:");
            Console.WriteLine("        1: bold");
            Console.WriteLine("        2: italic");
            Console.WriteLine("        3: underline");

            int input = Int32.Parse(Console.ReadLine());

            string[] font = { "None", "Bold", "Italic", "Underline" };

            string output = null;
            for(int i = 0; i < font.Length; i++)
            {
                if (input == font[i])
                {

                }
            }
            

                //var output = Font.bold | Font.italic | Font.underline; //Содержится или или
                //if (output.HasFlag(Font.bold)) //содержится bold
                //{
                //    Console.WriteLine("Bold");
                //}

                //if (Font.IsDefined(typeof(Font), "bold"))
                //{
                //    Console.WriteLine("Bold");
                //}

                switch (input)
                {
                    case "1":
                        if ()
                            Console.WriteLine();
                        continue;
                }

            Console.ReadKey();//Delay
        }
    }
}
