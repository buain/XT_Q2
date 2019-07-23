using System;
using System.Collections;
using System.Collections.Generic;

namespace _3._1_lost
{
    class Program
    {
        static void Display(IEnumerable<int> numbers)
        {
            foreach (var i in numbers)
                Console.Write(i + "  ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
            Display(numbers);
            bool remove = false;
            while(numbers.Count > 1)
            {

                for (int i = 0; i < numbers.Count; i++)
                {
                    
                        if (i % 2 != 0)
                        {
                            if (remove)
                            {

                                numbers.RemoveAt(i);

                            }
                            else
                            {
                                remove = !remove;
                            }
                        }
                        Display(numbers);
                    


                    //if (i % 2 != 0)
                    //{
                    //    if (remove)
                    //    {
                    //        //if (i % 2 != 0)
                    //        //{
                    //        numbers.RemoveAt(i);

                    //    }

                    //    //}
                    //    //else
                    //    //{
                    //    //     remove = !remove;
                    //    //}
                    //}






                    //if (remove)
                    //{
                    //    numbers.RemoveAt(i++);
                    //}
                    //else
                    //{
                    //    remove = !remove;
                    //}
                    //Display(numbers);
                }
                //Display(numbers);
            }

            //foreach(int i in numbers)
            //{
            //    Console.Write(i + "  ");
            //}
            //Console.WriteLine();
            //for (int i = 1; i <= numbers.Count; i++)
            //{
            //    if(i%2 == 0)
            //    {
            //        numbers.RemoveAt(i);
            //    }
            //    Console.Write(i + "  ");
            //    i++;

            //}
            
            Console.ReadKey(); //Delay

            //var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //PrintList(list);
            //bool delete = false;
            //while (list.Count > 1)
            //{
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        if (delete) list.RemoveAt(i--);
            //        delete = !delete;
            //    }
            //    PrintList(list);
            //}
            //Console.Read();
        }
    }
}
