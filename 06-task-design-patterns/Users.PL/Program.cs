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
                        //TODO BLL - add user
                        //UserList.AddUser()....

                        Console.WriteLine("Input user name:");
                        var name = Console.ReadLine();
                        Guid Id = default(Guid);
                        Console.WriteLine("Input user BirthDay in format dd.MM.yyyy:");
                        DateTime birthday = DateTime.Parse(Console.ReadLine());
                        int age = DateTime.Today.Year - birthday.Year;
                        UsersManager.AddUser(Id, name, birthday, age);

                        SelectOptionByUser();
                        break;
                    case 2:
                        //TODO BLL - prepear to delete user
                        //TODO DAL - delete user
                        //UserList.DeleteUser()....
                        SelectOptionByUser();
                        break;
                    case 3:
                        //TODO BLL - get all users 
                        //TODO PL - show all users
                        //ShowUsers(UserList.GetAllUsers())
                        SelectOptionByUser();
                        break;
                    case 4:
                        return;
                }
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
