using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8_game
{
    public abstract class Monsters // Монстры
    {
        public abstract void Damage();

    }
    public class Wolf : Monsters, IMovable, IPoint //Волк
    {
        int IPoint.X { get; set; }
        int IPoint.Y { get; set; }
        public override void Damage()
        {
            Console.WriteLine("Wolf damage you -5 Health");
        }

        public void MoveDown()
        {
            Console.WriteLine("Wolf move down 20 pixels ");
        }

        public void MoveLeft()
        {
            Console.WriteLine("Wolf move left 20 pixels ");
        }

        public void MoveRight()
        {
            Console.WriteLine("Wolf move right 20 pixels ");
        }

        public void MoveUp()
        {
            Console.WriteLine("Wolf move up 20 pixels ");
        }
    }
    public class Bear : Monsters, IMovable, IPoint // Медведь
    {
        int IPoint.X { get; set; }
        int IPoint.Y { get; set; }
        public override void Damage()
        {
            Console.WriteLine("Bear damage you -10 Health");
        }

        public void MoveDown()
        {
            Console.WriteLine("Bear move down 15 pixels ");
        }

        public void MoveLeft()
        {
            Console.WriteLine("Bear move left 15 pixels ");
        }

        public void MoveRight()
        {
            Console.WriteLine("Bear move right 15 pixels ");
        }

        public void MoveUp()
        {
            Console.WriteLine("Bear move up 15 pixels ");
        }
    }
}
