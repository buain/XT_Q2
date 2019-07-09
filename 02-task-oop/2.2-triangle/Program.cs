using System;

namespace _2._2_triangle
{
    class Triangle
    {
        public int a;
        public int A
        {
            get { return a; }
            set { a = value; }
        }

        static void Perimeter(int a, int b, int c)
        {
            int p = 0;
            p = a + b + c;
            Console.WriteLine($"Периметр треугольника: {p}");
        }
        static void Square(int a, int b, int c, int p)
        {
            double square;
            square = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine($"Площадь треугольника: {square}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Triangle a = new Triangle { a = 6 };
            Triangle instance = new Triangle();
            instance.a = 6;
            instance.b = 9;
            instance.c = 12;



            //instance.
            Console.WriteLine($"Стороны треугольника: ", instance.a, instance.b, instance.c);
            Console.ReadKey(); //Delay
        }
    }
}
