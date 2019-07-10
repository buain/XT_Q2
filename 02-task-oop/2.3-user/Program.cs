using System;

namespace _2._3_user
{
    class User
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        private string otchestvo;
        public string Otchestvo
        {
            get { return otchestvo; }
            set { otchestvo = value; }
        }
        public DateTime Birthday;
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public void Show()
        {
            Console.WriteLine(Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
           
            user.Name = "Ivan";
            user.Surname = "Petrov";
            user.Otchestvo = "Andreevich";
            user.Birthday = new DateTime(1994, 05, 24);
            user.Age = 25;

            user.Show();

            Console.WriteLine(user.Birthday.ToString("d"));
            Console.ReadKey(); //Delay
        }
    }
}
