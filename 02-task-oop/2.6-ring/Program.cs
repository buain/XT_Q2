using System;

namespace _2._6_ring
{
    class Ring
    {
        private int x; //координата х
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y; //координата y
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        private int outerRadius; //внешний радиус
        public int OuterRadius
        {
            get { return outerRadius; }
            set
            {
                if (value > 0) // проверка на корректность внешнего радиуса
                {
                    outerRadius = value;
                }
                else
                {
                    Console.WriteLine("Внешний радиус кольца не может быть меньшим или равным нулю");
                }
            }
        }
        private int innerRadius; //внутренний радиус
        public int InnerRadius
        {
            get { return innerRadius; }
            set
            {
                if (value < 0) // проверка на корректность внутреннего радиуса
                {
                    Console.WriteLine("Внешний радиус кольца не может быть меньшим или равным нулю");
                }
                else if(value > outerRadius)
                {
                    Console.WriteLine("Внутрений радиус кольца не может быть больше, чем внешний");
                }
                else
                {
                    innerRadius = value;
                }
            }
        }
        public double Area() //площадь кольца
        {
            return Math.PI * (OuterRadius * OuterRadius - InnerRadius * InnerRadius);
        }
        public double Circuit() //длина окружности
        {
            return 2 * Math.PI * OuterRadius;
        }
        public double innerCircuit() //длина внутренней окружности кольца
        {
            return 2 * Math.PI * InnerRadius;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Ring ring = new Ring();
            ring.X = 55;
            ring.Y = 55;
            ring.OuterRadius = 20;
            ring.InnerRadius = 15;

            double area = ring.Area();
            double circuit = ring.Circuit();
            double circuitRing = ring.innerCircuit();

            Console.WriteLine($"Площадь кольца: {area}");
            Console.WriteLine($"Сумма длин окружностей кольца: {circuit + circuitRing}");

            Console.ReadKey(); //Delay
        }
    }
}
