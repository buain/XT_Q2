using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Users.Entities
{
    public interface IStorable
    {
        bool AddUser(User user);
        bool DeleteUser(Guid Id);
        User GetUser(Guid Id);
        IEnumerable<User> GetAllUsers();
         
         
    }
}
