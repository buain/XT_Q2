using System;

namespace _2._1_round
{
    class Round
    {
        private int x; // координата x
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;  // координата y
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        private int radius; // радиус окружности
        public int Radius
        {
            get { return radius; }
            set
            {
                if(value < 0)
                {
                    Console.WriteLine("Радиус не может быть отрицательным");
                }
                else
                {
                    radius = value;
                }
            }
        }
        public void Circuit() //длина окружности
        {
            var result = 2 * Math.PI * Radius;
            Console.WriteLine($"Длина окружности: {result}");
        }
        public void Area() //площадь круга
        {
            var result = Math.PI * Radius * Radius;
            Console.WriteLine($"Площадь круга: {result}");
        }
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            Round round = new Round();

            round.X = -100;
            round.Y = 150;
            round.Radius = 75;

            round.Circuit();
            round.Area();

            Console.ReadKey(); //Delay
        }
    }
}
