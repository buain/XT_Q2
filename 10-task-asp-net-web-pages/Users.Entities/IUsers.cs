using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Users.Entities
{
    public interface IUsers
    {
        bool AddUser(User user);
        bool DeleteUser(Guid Id);
        User GetUser(Guid Id);
        IEnumerable<User> GetAllUsers();
        bool GetUserImage(Guid Id);
        bool SetUserImage(Guid Id);
        bool RemoveUserImage(Guid Id);
         
    }
}
