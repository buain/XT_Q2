using System;

namespace _02_simple
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
                if(n == 0 || n == 1)  // 0 and 1 are not simple numbers
                {
                    Console.WriteLine($"The Number {n} is NOT simple");                   
                }
                else if(n < 0)
                {
                    Console.WriteLine($"The {n} is a negative number!");
                }
                else
                {
                    //Check the number dividing by 2:
                    for (int i = 2; i < n ; i++)
                    {
                        if (n % i == 0)
                        {
                            Console.WriteLine($"The Number {n} is NOT simple");
                        }
                        else
                        {
                            Console.WriteLine($"The Number {n} is simple");
                        }
                        break;
                    }
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
