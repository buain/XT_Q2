using System;

namespace _1._3_another_triangle
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
                    for (int i = 0; i < n; i++)
                    {
                        for(int j = i; j < n; j++)
                        {
                            Console.Write(" ");
                        }
                        for(int z = n; z > n-(2*i)-1; z--)
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
