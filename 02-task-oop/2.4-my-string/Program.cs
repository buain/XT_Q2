using System;

namespace _2._4_my_string
{
    class MyString
    {
        public string stroka = "";
        public string strokaNew = "";
        public char[] ToArray() //преобразование строки в массив
        {
            return stroka.ToCharArray();
        }
        public void PrintArray(char[] toArray)
        {
            Console.WriteLine("Вывод на экран массива из строки:");
            for (int i = 0; i < toArray.Length; i++)
            {
                Console.WriteLine(toArray[i]);
            }
        }
        public void Conkat() //конкатенация строк
        {
            string conkatResult = stroka + " " + strokaNew;
            Console.WriteLine($"\nРезультат конкатенации строк: {conkatResult}");
        }
        public void ToString(char[] toArray) //преобразование массива в строку
        {
            string toString = String.Concat<char>(toArray);
            Console.WriteLine($"Результат преобразования массива в строку: {toString}");
        }
        public void Search() //поиск символа "i"
        {
            Console.WriteLine(@"Первая позиция символа ""i"" в строке: {0}", stroka.IndexOf('i'));
        }
        public void Compare() //сравнение строк
        {
            int result = String.Compare(stroka, strokaNew);
            if (result < 0)
            {
                Console.WriteLine("Строка stroka перед строкой strokaNew");
            }
            else if (result > 0)
            {
                Console.WriteLine("Строка stroka стоит после строки strokaNew");
            }
            else
            {
                Console.WriteLine("Строки stroka и strokaNew идентичны");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            MyString mystring = new MyString();
            mystring.stroka = "myfavoritenumberis777";
            mystring.strokaNew = "happynew2020year";

            char[] toArray = mystring.ToArray();
            mystring.PrintArray(toArray);

            mystring.Conkat();
            mystring.ToString(toArray);
            mystring.Search();
            mystring.Compare();

            Console.ReadKey(); //Delay
        }
    }
}
