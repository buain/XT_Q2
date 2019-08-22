using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;
using System.IO;

namespace Users.DAL
{
    public class FileStorageUsers : IStorable
    {
        private static List<User> Users { get; set; }
        string file_users = @"C:\Task6\users.txt";
        //public void AddUser(Guid id, string name, DateTime birthday, int age) //Сделать запись в файл с помощью StreamWriter
        //{
            
        //    using (StreamWriter w = new StreamWriter(@"C:\Task6\users.txt", true))
        //    {
        //        w.Write(id);
        //        w.Write(name);
        //        w.Write(birthday);
        //        w.Write(age);
        //    }
        //}
        
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
        //public void DelUser()
        //{

        //}
        //public bool AddUser(User user)
        //{
        //    if (Users.Any(n => n.Id == user.Id))
        //        return false;
        //    Users.Add(user);
        //    return true;
        //}
        //public ICollection<User> GetAllUsers()
        //{
        //    return Users;
        //}
    }
    
}
