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
        private IStorable storageusers; //=> Dependensies.FileStorage;
        
        public UsersManager()
        {
            this.storageusers = new DAL.FileStorageUsers();
        }
        public bool AddUser(string name, DateTime birthday) // 
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
        
        public User GetUserId(Guid Id)
        {
            return this.storageusers.GetUser(Id);
        }
        public User[] GetAllUsers()
        {
            return this.storageusers.GetAllUsers().ToArray();
        }
        public bool DeleteUser(User user)
        {
            if (this.storageusers.DeleteUser(user.Id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
