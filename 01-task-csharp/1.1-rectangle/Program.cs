using System;

namespace _1._1_rectangle
{
    class Program
    {
        public static int Square(int a, int b)
        {
            return a * b;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input a:");
            int a = 0;
            int b = 0;
            if (Int32.TryParse(Console.ReadLine(), out a))
            {
                if(a <= 0)
                {
                    Console.WriteLine("Wrong input!");          
                }
                else
                {
                    Console.WriteLine("Input b:");
                    if (Int32.TryParse(Console.ReadLine(), out b))
                    {
                        if (b <= 0)
                        {
                            Console.WriteLine("Wrong input!");
                        }
                        else
                        {
                            int result = Square(a, b);
                            Console.WriteLine($"Square of rectangle: {result}");
                        }  
                    }
                }
            }          
            Console.ReadKey(); //Delay
        }
    }
}
