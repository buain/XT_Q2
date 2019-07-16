using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8_game
{
    public class Player : Bonus, IPoint, IMovable  // Игрок
    {
        int IPoint.X { get; set; }
        int IPoint.Y { get; set; }

        public override void Eat()
            
        {
            Console.WriteLine("Something eat");
        }


        public void MoveDown()
        {
            Console.WriteLine("Player move down 18 pixels ");
        }

        public void MoveLeft()
        {
            Console.WriteLine("Player move left 18 pixels ");
        }

        public void MoveRight()
        {
            Console.WriteLine("Player move right 18 pixels ");
        }

        public void MoveUp()
        {
            Console.WriteLine("Player move up 18 pixels ");
        }
    }
}
