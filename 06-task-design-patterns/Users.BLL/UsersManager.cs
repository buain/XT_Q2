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
    public static class UsersManager
    {
        public static IStorable FileStorageUsers => Dependensies.FileStorage;
        
        public static void GetAllUsers()
        {

        }
        public static void AddUser(Guid id, string name, DateTime birthday, int age) // метод кладет данные в базу
        {
            FileStorageUsers.AddUser(new User(id, name, birthday, age));
        }
        public static void AddUser(User user)
        {
            FileStorageUsers.AddUser(user);
        }
    }
}
