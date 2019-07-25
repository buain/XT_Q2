using System;
using System.Collections;
using System.Collections.Generic;

namespace _3._3_dynamic_array
{
    public interface ICollection<T> : IEnumerable<T>, IEnumerable
    {
        //int Capacity { get; }
        IEnumerator GetEnumerator();
    }

    public class DynamicArray<T>
    {
        private T[] mass;
        private int length; //8-getting the number of items
        public int Length
        {
            get
            {
                foreach (var i in mass)
                {
                    length++;
                }
                return length;
            }
            set
            { length = value; }
        }
        private int capacity; //9-getting capacity: the length of the internal array
        public int Capacity
        {
            set { capacity = 16; }
        }
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
        public T[] Add(T[] array, T item) // 4-method that adds one element to the end of the array
        {
            T[] mass = new T[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                mass[i] = array[i];
            }
            mass[array.Length] = item;
            return mass;
        }
        //public void AddRange(IEnumerable<T> collection, IEnumerable<T> new_collection) // 5-method of adding to the end of the array the contents of the collection that implements the interface
        //{
        //    DynamicArray<T> array = new_collection as DynamicArray<T>;
        //    if(array != null)
        //    {
        //        array.AddRange(collection); // доделать
        //    }
        //    else
        //    {
        //        foreach (T item in collection)
        //        {
        //            array.Add(item); //доделать
        //        }
        //    }
        //}
        //private void Add(T Item) { } //доделать метод
        //private void AddRange(IEnumerable<T> collection) { }
        public bool Remove(IEnumerable<T> collection, T item) // 6-method that removes the specified item from the collection
        {
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            if(index >= capacity)
            {
                throw new IndexOutOfRangeException();
            }
            int start = index + 1;
            if (start < capacity)
            {
                Array.Copy(mass, start, mass, index, capacity - start);
            }
            capacity--;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //int capacity = 
            //var mass = new int[] { }; // массив
            DynamicArray<int> dynamicArray = new DynamicArray<int>(); // Создание массива
            


            //int User_count = 16; // Указанная ёмкость массива
            //DynamicArray<int> user_dynamicArray = new DynamicArray<int>(User_count); // Создание массива указанной ёмкости
            //dynamicArray.Add(5);
            Console.WriteLine("Hello World!");
        }
    }
}
