using System;

namespace _2._5_employee
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
    class Employee : User
    {
        public int experience;
        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        public string position;
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        public void Display()
        {
            Console.WriteLine(Position);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();

            employee.name = "Ivan";
            employee.surname = "Petrov";
            employee.otchestvo = "Andreevich";
            employee.birthday = new DateTime(1994, 05, 24);
            employee.age = 25;
            employee.experience = 5;
            employee.position = "manager";

            employee.Show();
            employee.Display();

            Console.ReadKey(); //Delay
        }
    }
}
