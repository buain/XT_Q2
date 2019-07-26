using System;
using System.Collections;
using System.Collections.Generic;

namespace _3._3_dynamic_array
{
    public interface IEnumerable
    {
        IEnumerator GetEnumerator();
    }
    public interface IEnumerable<T> : IEnumerable
    {
        new IEnumerator<T> GetEnumerator();
    }
    public class DynamicArray<T> : IEnumerable<int>, IEnumerable
    {
        int[] array = { 1, 8, 9, 5, 7, 6 };

        public IEnumerator GetEnumerator() //10
        {
            foreach (int i in array)
                yield return i;
        }
        IEnumerator<int> IEnumerable<int>.GetEnumerator() //10
        {
            foreach (int j in array)
                yield return j;
        }
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
        public void AddRange(IEnumerable<T> collection, IEnumerable<T> new_collection) // 5-method of adding to the end of the array the contents of the collection that implements the interface
        {
            DynamicArray<T> array = new_collection as DynamicArray<T>;
            if (array != null)
            {
                array.AddRange(collection);
            }
            else
            {
                foreach (T item in collection)
                {
                    array.Add(item);
                }
            }
        }
        private void Add(T Item) { }
        private void AddRange(IEnumerable<T> collection) { }
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
        public void Insert(int index, T item) // 7-method to add an element to an arbitrary array position
        {
            if (index >= capacity)
            {
                throw new IndexOutOfRangeException();
            }

            if (mass.Length == this.capacity)
            {
                this.GrowArray();
            }

            Array.Copy(mass, index, mass, index + 1, capacity - index);

            mass[index] = item;

            capacity++;
        }
        private void GrowArray()
        {
            int newLength = mass.Length == 0 ? (mass.Length * 3) / 2 + 1 : mass.Length << 1;

            T[] newArray = new T[newLength];

            mass.CopyTo(newArray, 0);

            mass = newArray;
        }
        public T this[int index] // 11-indexer that allows you to work with the item with the specified number
        {
            set
            {
                if (index >= capacity)
                {
                    throw new IndexOutOfRangeException();
                }
                mass[index] = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
