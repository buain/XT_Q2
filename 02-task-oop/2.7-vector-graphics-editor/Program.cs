using System;

namespace _2._7_vector_graphics_editor
{
    class Figure //класс Фигура
    {
        private int koord_x1;
        public int koord_X1
        {
            get
            {
                return koord_x1;
            }
            set
            {
                koord_x1 = value;
            }
        }
        private int koord_y1;
        public int koord_Y1
        {
            get
            {
                return koord_y1;
            }
            set
            {
                koord_y1 = value;
            }
        }
        public virtual void Drow()
        {
            Console.WriteLine($"Начальная координата: {koord_X1}:{koord_Y1}");
        }
    }
    class Line : Figure //класс Линия 
    {
        private int koord_x2;
        public int koord_X2
        {
            get
            {
                return koord_x2;
            }
            set
            {
                koord_x2 = value;
            }
        }
        private int koord_y2;
        public int koord_Y2
        {
            get
            {
                return koord_y2;
            }
            set
            {
                koord_y2 = value;
            }
        }
        //public Line(int line.koord_X2, int line.koord_Y2)
        //    :base(line.koord_X1, line.koord_Y1)
        //{
        //    line.koord_X2 = line.koord_x2;
        //    line.koord_Y2 = line.koord_y2;
        //}
        public override void Drow()
            
        {
            Console.WriteLine($"Линия: {koord_X1}:{koord_Y1} --- {koord_X2}:{koord_Y2}");
        }

    }
    class Circle : Figure //класс Окружность
    {
        private int radiusC;
        public int RadiusC
        {
            get
            {
                return radiusC;
            }
            set
            {
                radiusC = value;
            }
        }
        public override void Drow()

        {
            Console.WriteLine($"Окружность с радиусом: {RadiusC}, длина окружности:{2*Math.PI*RadiusC}");
        }
    }
    class Round : Circle //класс Круг 
    {
        private int radiusR;
        public int RadiusR
        {
            get
            {
                return radiusR;
            }
            set
            {
                radiusR = value;
            }
        }
        public override void Drow()

        {
            Console.WriteLine($"Круг с радиусом: {RadiusR}, площадь круга:{Math.PI * RadiusR * RadiusR}");
        }
    }
    class Ring : Figure //класс Кольцо
    {
        private int radiusIn;
        public int RadiusIn
        {
            get
            {
                return radiusIn;
            }
            set
            {
                radiusIn = value;
            }
        }
        private int radiusOut;
        public int RadiusOut
        {
            get
            {
                return radiusOut;
            }
            set
            {
                radiusOut = value;
            }
        }
        public override void Drow()

        {
            Console.WriteLine($"Кольцо с площадью: {Math.PI * (RadiusOut * RadiusOut - RadiusIn * RadiusIn)}");
        }
    }
    class Rectangle : Figure //класс Прямоугольник
    {
        private int sideA;
        public int SideA
        {
            get
            {
                return sideA;
            }
            set
            {
                sideA = value;
            }
        }
        private int sideB;
        public int SideB
        {
            get
            {
                return sideB;
            }
            set
            {
                sideB = value;
            }
        }
        public override void Drow()

        {
            Console.WriteLine($"Прямоугольник с периметром: {2 * (SideA + SideB)}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Figure figure = new Figure();
            figure.koord_X1 = 50;
            figure.koord_Y1 = 60;
            figure.Drow();

            Line line = new Line();
            //Line line = new Line(20, 30, 75, 100);
            line.koord_X1 = 20;
            line.koord_Y1 = 30;
            line.koord_X2 = 75;
            line.koord_Y2 = 100;
            line.Drow();

            Circle circle = new Circle();
            circle.RadiusC = 20;
            circle.Drow();

            Round round = new Round();
            round.RadiusR = 25;
            round.Drow();

            Ring ring = new Ring();
            ring.RadiusOut = 80;
            ring.RadiusIn = 50;
            ring.Drow();

            Rectangle rectangle = new Rectangle();
            rectangle.SideA = 45;
            rectangle.SideB = 54;
            rectangle.Drow();

            Console.ReadKey(); //Delay
        }
    }
}
