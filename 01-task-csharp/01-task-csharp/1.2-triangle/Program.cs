using System;

namespace _1._2_triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input any positive number more then 1:");
            int n;
            if (Int32.TryParse(Console.ReadLine(), out n))
            {
                if (n == 0 || n == 1)  //Mindless input
                {
                    Console.WriteLine("Mindless input");
                }
                else if (n < 0)
                {
                    Console.WriteLine($"The {n} is a negative number!");
                }
                else
                {
                    for (int i = 1; i <= n; i++)
                    {
                        Console.Write("*");
                        for (int j = 2; j <= i; j++)
                        {
                            Console.Write("*");
                        }
                        Console.Write("\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }            
            Console.ReadKey();//Delay
        }
    }
}
