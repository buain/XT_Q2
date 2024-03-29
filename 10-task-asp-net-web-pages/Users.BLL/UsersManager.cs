﻿using System;
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
        private IUsers storageusers; //=> Dependensies.FileStorage;
        private IAwards storageawards;
        private IRoles storageroles;

        public UsersManager()
        {
            storageusers = new FileStorageUsers();
            storageawards = new FileStorageAwards();
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
        
        public bool AddAward(string title)
        {
            var award = new Award(title);
            if (storageawards.AddAward(award))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddAward(Award award)
        {
            if (this.storageawards.AddAward(award))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddAwardToUser(Guid userId, Guid awardId)
        {
            if(storageusers.GetUser(userId) == null)
            {
                throw new ArgumentException("No user with such Id");
            }
            if (storageawards.GetAward(awardId) == null)
            {
                throw new ArgumentException("No award with such Id");
            }
            if (storageawards.AddAwardToUser(userId, awardId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Award[] GetAllAwards()
        {
            return storageawards.GetAllAwards().ToArray();
        }

        public Award[] GetUserAwards(User user)
        {
            return storageawards.GetUserAwards(user).ToArray();
        }
        public bool GetUserImage(Guid userId)
        {
            if (storageusers.GetUser(userId) == null)
            {
                throw new ArgumentException("No such user with this Id");
            }
            try
            {
                if (storageusers.GetUserImage(userId))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool SetUserImage(Guid userId)
        {
            if (storageusers.GetUser(userId) == null)
            {
                throw new ArgumentException("No user with such Id");
            }
            if (storageusers.SetUserImage(userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveUserImage(Guid userId)
        {
            if(storageusers.GetUser(userId) == null)
            {
                throw new ArgumentException("No user with such Id");
            }
            if (storageusers.RemoveUserImage(userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GetAwardImage(Guid awardId)
        {
            if(storageawards.GetAward(awardId) == null)
            {
                throw new ArgumentException("No award with this Id");
            }
            if (storageawards.GetAwardImage(awardId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Award GetAwardId(Guid Id)
        {
            return storageawards.GetAward(Id);
        }
        public bool SetAwardImage(Guid awardId)
        {
            if(storageawards.GetAward(awardId) == null)
            {
                throw new ArgumentException("No award with this Id");
            }
            if (storageawards.SetAwardImage(awardId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveAwardImage(Guid awardId)
        {
            if(storageawards.GetAward(awardId) == null)
            {
                throw new ArgumentException("No award with this Id");
            }
            if (storageawards.RemoveAwardImage(awardId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CreateAccount(Account account)
        {
            if (storageroles.AddAccount(account))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddRoleToAccount(Guid AccountId, Guid RoleId)
        {
            if (storageroles.AddRoleToAccount(AccountId, RoleId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Account GetAccount(Guid id)
        {
            return storageroles.GetAccount(id);
        }

        public Account GetAccount(string username)
        {
            return storageroles.GetAccount(username);
        }

        public Role GetRole(Guid id)
        {
            return storageroles.GetRole(id);
        }

        public IEnumerable<Role> GetAccountRoles(Account account)
        {
            return storageroles.GetAccountRoles(account).ToArray();
        }

        public IEnumerable<Role> GetNoAccountRoles(Account account)
        {
            return storageroles.GetNoAccountRoles(account).ToArray();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return storageroles.GetAllRoles().ToArray();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return storageroles.GetAllAccounts().ToArray();
        }

        public bool DeleteRoleFromAccount(Guid AccountID, Guid RoleID)
        {
            return storageroles.DeleteRoleFromAccount(AccountID, RoleID);
        }
    }
}
