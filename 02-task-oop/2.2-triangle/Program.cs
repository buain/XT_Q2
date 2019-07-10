using System;

namespace _2._2_triangle
{
    class Triangle
    {
        private int a;
        public int A
        {
            get { return a; }
            set { a = value; }
        }
        private int b;
        public int B
        {
            get { return b; }
            set { b = value; }
        }
        private int c;
        public int C
        {
            get { return c; }
            set { c = value; }
        }
        public int Perimeter()
        {
            return A + B + C;
        }
        public double Square(int P)
        {
            return Math.Sqrt(P * (P - A) * (P - B) * (P - C));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Triangle a = new Triangle { a = 6 };
            Triangle instance = new Triangle();
            instance.A = 6;
            instance.B = 9;
            instance.C = 12;

            int P = instance.Perimeter();
            double square = instance.Square(P);

            Console.WriteLine($"Стороны треугольника:  {instance.A}, {instance.B}, {instance.C}");
            Console.WriteLine($"Периметр треугольника: {P}");
            Console.WriteLine($"Площадь треугольника: {square}");

            Console.ReadKey(); //Delay
        }
    }
}
