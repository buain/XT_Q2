using System;

namespace _2._1_round
{
    class Round
    {
        public int x; // координата x
        public int X
        {
            get { return x; }
            set
            {
                if(value > 0)    //проверка на 0 и -
                {
                    x = value;
                };
            }
        }
        public int y;  // координата y
        public int Y
        {
            get { return y; }
            set
            {
                if (value > 0)    //проверка на 0 и -
                {
                    y = value;
                };
            }
        }
        public int radius; // радиус окружности
        public int Radius
        {
            get { return radius; }
            set
            {
                if (value > x || value > y)    //проверка на выход за границы координат
                {
                    Console.WriteLine("Слишком большой радиус"); 
                }
                else
                {
                    radius = value;
                };
            }
        }
        public double Circuit() //длина окружности
        {
            return 2 * Math.PI * radius;
        }
        public double Area() //площадь круга
        {
            return Math.PI * radius * radius;
        }
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            //Round round = new Round();

            //round.x = -100;
            //round.y = -150;
            //round.radius = 175;

            Round round = new Round
            {
                x = -100,
                y = 150,
                radius = 175
            };
            //!!! НЕ РАБОТАЮТ ПРОВЕРКИ!!!
            double circuit = round.Circuit();
            double area = round.Area();

            Console.WriteLine($"Длина окружности: {circuit}");
            Console.WriteLine($"Площадь круга: {area}");
            
            Console.ReadKey(); //Delay
        }
    }
}
