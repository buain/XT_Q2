using System;

namespace _2._8_game
{
    //interface Field // Поле игры
    //{
    //    int Width { get; set; }
    //    int Height { get; set; }
    //}
    interface IPoint // Координата объекта
    {
        int X { get; set; }
        int Y { get; set; }
    }
    interface IMovable // Перемещение
    {
        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.MoveDown();
            Apple apple = new Apple();
            player.Eat();
            Bear bear = new Bear();
            bear.MoveDown();
            bear.Damage();

            Console.ReadKey(); //Delay
        }
    }
}
