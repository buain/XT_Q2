using System;

namespace _03_square
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input any positive odd number more then 1: ");
            int n;
            string input = Console.ReadLine();
            string star = "*";
            Console.WriteLine();          
            if (Int32.TryParse(input, out n))
            {
                //Check the odd number:
                if (n == 0 || n == 1)  // 0 and 1 are not simple numbers
                {
                    Console.WriteLine($"The Number {n} is NOT simple");
                }
                else if (n < 0)
                {
                    Console.WriteLine($"The {n} is a negative number!");
                }
                else if (n % 2 != 0 ) 
                {
                    Console.WriteLine("The square:\n");
                    for (int i = 1; i <= n; i++)
                    {                       
                        for (int j = 1; j <= n; j++)
                        {
                            //This is a middle of square:
                            if (i == (n / 2) + 1 && j == (n / 2) + 1)
                            {
                                star = "*".Replace("*", " "); //Replace star to blank
                                Console.Write(star);
                                j++; //Remove last star in this row
                            }
                            star = " ".Replace(" ", "*"); //Replace blank to star
                            Console.Write(star);
                        }
                        Console.Write("\n");
                    }
                }
                else
                {
                    Console.WriteLine($"The number {n} is NOT a odd number!");
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
