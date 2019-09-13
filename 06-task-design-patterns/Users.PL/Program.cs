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
        public static Dictionary<int, Guid> AwardIds = new Dictionary<int, Guid>(10);
        public static string UsersString = "{0,-3} {1,-20} {2,-20} {3,-5}";
        public static string UsersStringShort = "{0,-3} {1,-10}";
        public static string AwardsString = "{0,-3} {1,-20}";

        static Program()
        {
            usersmanager = new UsersManager();
        }
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
            Console.WriteLine("4.Add type of award");
            Console.WriteLine("5.Add award to user");
            Console.WriteLine("6.View types of awards");
            Console.WriteLine("7.View awards of user");
            Console.WriteLine("8.Exit.");

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
                        CreateAward();
                        SelectOptionByUser();
                        break;
                    case 5:
                        AddAwardToUser();
                        SelectOptionByUser();
                        break;
                    case 6:
                        GetAllAwards();
                        SelectOptionByUser();
                        break;
                    case 7:
                        GetUserAwards();
                        SelectOptionByUser();
                        break;
                    case 8:
                        return;
                }
            }
        }

        public static void CountUserIds()
        {
            int i = 1;
            UserIds.Clear();
            List<User> users = usersmanager.GetAllUsers().ToList();
            foreach(var items in users)
            {
                UserIds.Add(i, items.Id);
                i++;
            }
        }

        public static void CountAwardIds()
        {
            int i = 1;
            AwardIds.Clear();
            List<Award> awards = usersmanager.GetAllAwards().ToList();
            foreach (var items in awards)
            {
                AwardIds.Add(i, items.Id);
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
                    Console.WriteLine("User created successfully");
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
        
        internal static void CreateAward()
        {
            Console.WriteLine("Input type of award:");
            var title = Console.ReadLine();

            try
            {
                if (usersmanager.AddAward(title))
                {
                    Console.WriteLine("Award created successfully");
                }
                else
                {
                    Console.WriteLine("Award do not created");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Award do not created");
                Console.WriteLine(e.Message);
            }
        }

        internal static void AddAwardToUser()
        {
            Console.WriteLine("Input user Id:");
            string input_user = Console.ReadLine();

            if (!UserIds.ContainsKey(int.Parse(input_user)))
            {
                Console.WriteLine("Wrong user Id!");
                return;
            }

            Guid userId = UserIds[int.Parse(input_user)];

            Console.WriteLine("Input award Id:");
            string input_award = Console.ReadLine();
            if (!AwardIds.ContainsKey(int.Parse(input_award)))
            {
                Console.WriteLine("Wrong award Id!");
                return;
            }

            Guid awardId = AwardIds[int.Parse(input_award)];

            try
            {
                if(usersmanager.AddAwardToUser(userId, awardId))
                {
                    Console.WriteLine("Award added successfully");
                }
                else
                {
                    Console.WriteLine("Award do not added");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Award do not added");
                Console.WriteLine(e.Message);
                return;
            }
        }

        internal static void GetAllAwards()
        {
            List<Award> awardInfo = usersmanager.GetAllAwards().ToList<Award>();
            if(awardInfo.Count == 0)
            {
                Console.WriteLine("No awards at all");
            }
            else
            {
                CountAwardIds();
                Console.WriteLine(AwardsString, "Id", "Award Type");
                foreach(var item in AwardIds)
                {
                    Award award = awardInfo.Single(n => n.Id == AwardIds[item.Key]);
                    Console.WriteLine(AwardsString, item.Key.ToString(), award.Title.ToString());
                }
            }
        }

        internal static void GetUserAwards()
        {
            Console.WriteLine("Input user Id");
            string input = Console.ReadLine();

            if (!UserIds.ContainsKey(int.Parse(input)))
            {
                Console.WriteLine("Wrong user id");
                return;
            }

            Guid newGuid = UserIds[int.Parse(input)];

            try
            {
                User newUser = usersmanager.GetUserId(newGuid);
                Award[] userAwards = usersmanager.GetUserAwards(newUser);

                if(userAwards.Length == 0)
                {
                    Console.WriteLine("The User do not have any awards");
                }
                else
                {
                    Console.WriteLine(UsersStringShort, "Id", "Name");
                    Console.WriteLine(UsersStringShort, input, newUser.Name.ToString());
                    Console.WriteLine("User's list of awards:");
                    Console.WriteLine(AwardsString, "Id", "Award type");

                    foreach(var award in userAwards)
                    {
                        Console.WriteLine(AwardsString, AwardIds.Single(n => n.Value == award.Id).Key.ToString());
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Wrong user Id");
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
