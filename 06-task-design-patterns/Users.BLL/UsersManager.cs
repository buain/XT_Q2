using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;
using Users.Common;
using Users.DAL;

namespace Users.BLL
{
    public class UsersManager
    {
        public IStorable FileStorageUsers => Dependensies.FileStorage;
        
        public IEnumerable<User> GetAllUsers()
        {

        }
        public void AddUser(Guid id, string name, DateTime birthday, int age) // метод кладет данные в базу
        {
            FileStorageUsers.AddUser(new User(id, name, birthday, age));
        }
        public void AddUser(User user)
        {
            FileStorageUsers.AddUser(user);
        }
        //public static void DelUser(Guid id)
        //{
        //    FileStorageUsers.DelUser(id);
        //}
    }
}
