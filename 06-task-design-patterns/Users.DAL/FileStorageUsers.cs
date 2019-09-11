using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;
using System.IO;

namespace Users.DAL
{
    public class FileStorageUsers : IUsers
    {
        //private static List<User> Users { get; set; }
        private const string FileUsers = @"D:\Task6\users.txt";
        private string file_users;
        
        public FileStorageUsers()
        {
            this.file_users = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileUsers);
        }
        public bool AddUser(User user)
        {
            try
            {
                File.AppendAllLines(file_users, new[] { RecordUser(user) });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string RecordUser(User user)
        {
            return string.Format($"{user.Id.ToString()}, {user.Name.ToString()}, {user.BirthDay.ToString()}");
        }
        public bool DeleteUser(Guid Id)
        {
            try
            {
                if (!File.Exists(this.file_users))
                {
                    return false;
                }

                var allusers = this.GetAllUsers()
                    .Where(n => n.Id != Id)
                    .Select(n => RecordUser(n));

                File.WriteAllLines(this.file_users, allusers);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public User GetUser(Guid id)
        {
            return this.GetAllUsers().FirstOrDefault(n => n.Id==id);
        }
        public IEnumerable<User> GetAllUsers()
        {
            if (!File.Exists(this.file_users))
            {
                Console.WriteLine("File not found");
            }

            string[] lines = File.ReadAllLines(this.file_users);

            foreach(string line in lines)
            {
                var user = RecordLine(line);
                if(user != null)
                {
                    yield return user;
                }
            }
        }
        private static User RecordLine(string line)
        {
            var userFields = line.Split('_');
            if(userFields.Length != 3)
            {
                return null;
            }
            return new User(userFields[1], DateTime.Parse(userFields[2]))
            {
                Id = Guid.Parse(userFields[0]),
            };
        }
    }
    
}
