using System;

namespace _1._4_x_mas_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input number of triangles more then 1:");
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
                        for (int j = 0; j < i; j++)
                        {
                            string branch = new String('*', j);
                            Console.WriteLine(branch.PadLeft(n + 3) + "*" + branch);
                        }
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
