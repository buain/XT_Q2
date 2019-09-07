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
        public static UsersManager usersmanager;
        public static Dictionary<int, Guid> UserIds = new Dictionary<int, Guid>(10);
        public static string UsersString = "{0,-3} {1,-20} {2,-20} {3,-5}";

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
                        GetAllUsers();
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
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("The Name cannot be empty");
            }

            Console.WriteLine("Input user BirthDay in format dd.MM.yyyy:");
            DateTime birthday; // = DateTime.Parse(Console.ReadLine());
            string[] input_date;

            try
            {
                input_date = Console.ReadLine().Split(new[] { '.' }, 3);
                birthday = new DateTime(int.Parse(input_date[2]), int.Parse(input_date[1]), int.Parse(input_date[0]));
            }
            catch
            {
                Console.WriteLine("Wrong input date of birth.");
                return;
            }

            try
            {
                if(usersmanager.AddUser(name, birthday))
                {
                    Console.WriteLine("User created succesfully");
                }
                else
                {
                    Console.WriteLine("User do not created");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("User do not created");
                Console.WriteLine(e);
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
                Console.WriteLine(UsersString, "Id", "Name", "BirthDay", "Age");
                CountUserIds();
                foreach(var items in UserIds)
                {
                    User user = users.Single(n => n.Id == UserIds[items.Key]);
                    Console.WriteLine(
                        UsersString,
                        items.Key.ToString(),
                        user.Name, 
                        user.BirthDay.ToString("dd.MM.yyyy"), 
                        user.Age.ToString());
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
                    Console.WriteLine($"User with Id {input} deleted");
                }
                else
                {
                    Console.WriteLine("Delete unsuccessfully");
                }
            }
            catch
            {
                Console.WriteLine("Wrong Id of user");
                return;
            }
        }
        
    }
}
