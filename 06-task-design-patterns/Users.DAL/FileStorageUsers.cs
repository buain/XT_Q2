using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;

namespace Users.DAL
{
    public class FileStorageUsers : IStorable
    {
        private static List<User> Users { get; set; }
        string file_users = @"C:\Task6\users.txt";
        public void AddUser() //Сделать запись в файл с помощью StreamWriter (Task 5)
        {

        }
        public void DeleteUser()
        {

        }
        public bool AddUser(User user)
        {
            if (Users.Any(n => n.Id == user.Id))
                return false;
            Users.Add(user);
            return true;
        }
        public ICollection<User> GetAllUsers()
        {
            return Users;
        }
    }
    
}
