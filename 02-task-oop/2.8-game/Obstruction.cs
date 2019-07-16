using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8_game
{
    public abstract class Obstruction // Препятствие
    {
        public abstract void DontMove();
    }
    public class Tree : Obstruction, IPoint // Дерево 
    {
        int IPoint.X { get; set; }
        int IPoint.Y { get; set; }
        public override void DontMove()
        {
            Console.WriteLine("Stop near the tree for 5 seconds");
        }
    }
    public class Stone : Obstruction, IPoint // Камень
    {
        int IPoint.X { get; set; }
        int IPoint.Y { get; set; }
        public override void DontMove()
        {
            Console.WriteLine("Stop near the tree for 2 seconds");
        }
    }
}
