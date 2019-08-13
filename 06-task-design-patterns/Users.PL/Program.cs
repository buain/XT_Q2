using System;

namespace Users.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectToDo();
            Console.ReadKey();
        }
        public static void SelectToDo()
        {
            Console.WriteLine("Choose what to do with user's info:");
            Console.WriteLine("1.Create.");
            Console.WriteLine("2.Delete.");
            Console.WriteLine("3.View list of users");
            Console.WriteLine("4.Exit.");

            var input = Console.ReadLine();

            if(uint.TryParse(input, out uint SelectedOption)
                && SelectedOption > 0
                && SelectedOption < 5)
            {
                switch (SelectedOption)
                {
                    case 1:
                        //UserList.AddUser....
                        SelectToDo();
                        break;
                    case 2:
                        //UserList.DeleteUser....
                        SelectToDo();
                        break;
                    case 3:
                        //ShowUsers(UserList.GetAllUsers())
                        SelectToDo();
                        break;
                    case 4:
                        return;
                }
            }
        }

    }
}
