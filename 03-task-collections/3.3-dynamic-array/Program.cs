using System;
using System.Collections;
using System.Collections.Generic;

namespace _3._3_dynamic_array
{
    public class List<T>
    {

    }
    public class DynamicArray<T> : List<T>
    {
        private T[] mass;
        
        //private int user_count { get; set; }

        public DynamicArray() // 1-constructor without parameters
        {
            mass = new T[8];
        }
        public DynamicArray(int capacity) // 2-constructor with one integer parameter
        {
            mass = new T[capacity];  
        }
        public DynamicArray(IEnumerable<T> collection) // 3-constructor that takes a collection as a parameter
        {
            mass = new T[(collection as ICollection).Count];
            (collection as ICollection).CopyTo(mass, 0);
        }
        //public static T[] Add<T>(T[] array, T item)
        //{
        //    T[] mass = new T[array.Length + 1];
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        mass[i] = array[i];
        //    }
        //    mass[array.Length] = item;
        //    return mass;
        //}

        public void Add(T[] mass, T newvalue) // 4-method that adds one element to the end of the array
        {
            mass
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //var mass = new int[] { }; // массив
            //DynamicArray<int> dynamicArray = new DynamicArray<int>(); // Создание массива
            


            int User_count = 16; // Указанная ёмкость массива
            DynamicArray<int> user_dynamicArray = new DynamicArray<int>(User_count); // Создание массива указанной ёмкости
            //dynamicArray.Add(5);
            Console.WriteLine("Hello World!");
        }
    }
}
