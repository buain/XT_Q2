using System;

namespace _2._3_user
{
    class User
    {
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string otchestvo;
        public string Otchestvo
        {
            get { return otchestvo; }
            set { otchestvo = value; }
        }
        public DateTime birthday;
        public int age;
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
           
            user.name = "Ivan";
            user.surname = "Petrov";
            user.otchestvo = "Andreevich";
            user.birthday = new DateTime(1994, 05, 24);
            user.age = 25;

            user.Show();

            Console.WriteLine(user.birthday.ToString("d"));
            Console.ReadKey(); //Delay
        }
    }
}
