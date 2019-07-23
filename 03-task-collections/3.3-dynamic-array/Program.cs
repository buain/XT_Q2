using System;

namespace _3._3_dynamic_array
{
    public class DynamicArray<T>
    {
        private int count { get; set; }
        private int user_count { get; set; }
        public DynamicArray() //конструктор без параметров
        {
            count = 8; // Ёмкость массива
        }
        public DynamicArray(int User_count) //конструктор с одним целочисленным параметром
        {
            user_count = User_count; // 
        }
        public DynamicArray(IEnumerable<T> collection)
        {
            EnumArray = new T(collection.Count);
        }
    }
    class Program
    {
        static void Main(string[] args)
        { 
            DynamicArray<int> dynamicArray = new DynamicArray<int>(); // Создание динамического массива
            int User_count = 16; // Указанная ёмкость массива
            DynamicArray<int> user_dynamicArray = new DynamicArray<int>(User_count); // Создание массива указанной ёмкости
            Console.WriteLine("Hello World!");
        }
    }
}
