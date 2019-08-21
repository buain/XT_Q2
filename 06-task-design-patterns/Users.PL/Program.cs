using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;
using Users.BLL;

namespace Users.PL
{
    class Program
    {
        public static UsersManager UsersManager { get; } = new UsersManager();
        static void Main(string[] args)
        {
            SelectOptionByUser();
            Console.ReadKey();
        }
        public static void SelectOptionByUser()
        {
            Console.WriteLine("Choose what to do with user's info:");
            Console.WriteLine("1.Create.");
            Console.WriteLine("2.Delete.");
            Console.WriteLine("3.View list of users");
            Console.WriteLine("4.Exit.");

            var input = Console.ReadLine();

            if (uint.TryParse(input, out uint SelectedOption)
                && SelectedOption > 0
                && SelectedOption < 5)
            {
                switch (SelectedOption)
                {
                    case 1:
                        //TODO BLL - prepear to add user
                        //TODO DAL - add user
                        //UserList.AddUser()....

                        Console.WriteLine("Input user name:");
                        var name = Console.ReadLine();
                        Guid Id = default(Guid);
                        Console.WriteLine("Input user BirthDay in format dd.MM.yyyy:");
                        DateTime birthday = DateTime.Parse(Console.ReadLine());
                        int age = DateTime.Today.Year - birthday.Year;
                        //UsersManager manager = new UsersManager();
                        UsersManager.AddUser(Id, name, birthday, age);

                        SelectOptionByUser();
                        break;
                    case 2:
                        //TODO BLL - prepear to delete user
                        //TODO DAL - delete user
                        //UserList.DeleteUser()....
                        Console.WriteLine("Input user name to delete:");
                        var name_delete = Console.ReadLine();
                        Guid del_Id = Guid.Parse(name_delete);
                        //UsersManager.DelUser(del_Id);
                        SelectOptionByUser();
                        break;
                    case 3:
                        //TODO BLL - get all users 
                        //TODO PL - show all users
                        //ShowUsers(UserList.GetAllUsers())
                        IEnumerable<User> users = UsersManager.GetAllUsers();
                        ShowUsers(users);
                        SelectOptionByUser();
                        break;
                    case 4:
                        return;
                }
            }
        }

        private static void ShowUsers(IEnumerable<User> users)
        {
            foreach(var item in users)
            {
                Console.WriteLine($"{item.Id}, {item.Name}, {item.BirthDay}, {item.Age}");
            }
        }

        //internal static void CreateUser()
        //{

        //    Console.WriteLine("Input user name:");
        //    var name = Console.ReadLine();

        //    Console.WriteLine("Input user BirthDay in format dd.MM.yyyy:");
        //    DateTime birthday = DateTime.Parse(Console.ReadLine());
        //    int age = DateTime.Today.Year - birthday.Year;

        //}
    }
}
