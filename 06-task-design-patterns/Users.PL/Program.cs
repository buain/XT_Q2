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
        public static UsersManager usersmanager;// { get; } = new UsersManager();
        public static Dictionary<int, Guid> UserIds = new Dictionary<int, Guid>(10);

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
                        CreateUser();
                        SelectOptionByUser();
                        break;
                    case 2:      
                        DeleteUser();
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

        public static void CountUserIds()
        {
            int i = 1;
            UserIds.Clear();
            List<User> users = usersmanager.GetAllUsers().ToList<User>();
            foreach(var items in users)
            {
                UserIds.Add(i, items.Id);
                i++;
            }
        }

        internal static void CreateUser()
        {
            Console.WriteLine("Input user name:");
            var name = Console.ReadLine();

            Console.WriteLine("Input user BirthDay in format dd.MM.yyyy:");
            DateTime birthday = DateTime.Parse(Console.ReadLine());
            //int age = DateTime.Today.Year - birthday.Year;
            usersmanager.AddUser(name, birthday);
        }

        private static void ShowUsers(IEnumerable<User> users)
        {
            foreach(var item in users)
            {
                Console.WriteLine($"{item.Id}, {item.Name}, {item.BirthDay}, {item.Age}");
            }
        }

        internal static void GetAllUsers()
        {
            List<User> users = usersmanager.GetAllUsers().ToList<User>();
            if(users.Count == 0)
            {
                Console.WriteLine("Users list is empty");
            }
            else
            {
                Console.WriteLine("Data of Users:");//////
                CountUserIds();
                foreach(var items in UserIds)
                {
                    User user = users.Single(n => n.Id == UserIds[items.Key]);
                    Console.WriteLine(
                        items.Key.ToString(),
                        user.Name, 
                        user.BirthDay.ToString("dd.MM.yyyy"), 
                        user.Age.ToString());////
                }
            }
        }

        internal static void DeleteUser()
        {
            Console.WriteLine("Input user Id to delete");
            string input = Console.ReadLine();

            if (!UserIds.ContainsKey(int.Parse(input)))
            {
                Console.WriteLine("Wrong input!");
            }

            Guid deleteGuid = UserIds[int.Parse(input)];
            try
            {
                User deleteUser = usersmanager.GetUserId(deleteGuid);
                if (usersmanager.DeleteUser(deleteUser))
                {

                }
            }
        }
        
    }
}
