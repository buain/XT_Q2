using System;

namespace _01_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input any positive number more then 1: ");
            int n;
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out n))
            {
                if(n == 0 || n == 1)  //Mindless input
                {
                    Console.WriteLine("Mindless input");                   
                }
                else if(n < 0)
                {
                    Console.WriteLine($"The {n} is a negative number!");
                }
                else
                {
                    //Output the row of numbers:
                    for (int i = 1; i < n; i++)
                    {
                        Console.Write($"{i}, ");
                    }
                    Console.Write(n);
                }                
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }
            Console.ReadKey(); //Delay
        }
    }
}
