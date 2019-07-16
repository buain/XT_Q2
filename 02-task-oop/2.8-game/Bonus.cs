using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8_game
{
    public abstract class Bonus // Бонус
    {
        public abstract void Eat();
    }
    public class Apple : Bonus, IPoint // Бонус - яблоко
    {
        int IPoint.X { get; set; }
        int IPoint.Y { get; set; }

        public override void Eat()
        {
            Console.WriteLine("Apple gives +5 Health");
        }
    }
    public class Cherry : Bonus, IPoint // бонус - вишня
    {
        int IPoint.X { get; set; }
        int IPoint.Y { get; set; }
        public override void Eat()
        {
            Console.WriteLine("Cherry gives +3 Health");
        }
    }
}
