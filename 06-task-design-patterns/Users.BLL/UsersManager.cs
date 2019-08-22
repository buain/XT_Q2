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
        public IStorable storageusers; //=> Dependensies.FileStorage;

        //public IEnumerable<User> GetAllUsers()
        //{

        //}
        public bool AddUser(string name, DateTime birthday) // метод кладет данные в DAL
        {
            var user = new User(name, birthday);
            if (this.storageusers.AddUser(user))
            {
                return true;
            }
            else
            {
                return false;
            }
            //FileStorageUsers.AddUser(new User(id, name, birthday, age));
        }
        public bool AddUser(User user)
        {
            if (this.storageusers.AddUser(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //public void AddUser(User user)
        //{
        //    FileStorageUsers.AddUser(user);
        //}
        //public static void DelUser(Guid id)
        //{
        //    FileStorageUsers.DelUser(id);
        //}

    }
}
