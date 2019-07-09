using System;

namespace _2._6_ring
{
    class Circle //Окружность
    {
        public int x; //координата х
        public int y; //координата y
        public int radius; //радиус окружности
        public double Circuit() //длина окружности
        {
            return 2 * Math.PI * radius; 
        }
    }
    class Ring : Circle //кольцо
    {
        public int innerRadius; //внутренний радиус
        public double Area() //площадь кольца
        {
            return Math.PI * (radius * radius - innerRadius * innerRadius);
        }
        public double innerCircuit() //длина внутренней окружности кольца
        {
            return 2 * Math.PI * innerRadius;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Ring ring = new Ring();
            ring.x = 55;
            ring.y = 55;
            ring.radius = 20;
            ring.innerRadius = 15;

            double area = ring.Area();
            double circuit = ring.Circuit();
            double circuitRing = ring.innerCircuit();

            Console.WriteLine($"Площадь кольца: {area}");
            Console.WriteLine($"Сумма длин окружностей кольца: {circuit + circuitRing}");

            Console.ReadKey(); //Delay
        }
    }
}
