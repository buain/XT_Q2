using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Entities
{
    public class IRoles
    {
        bool AddAccount(Account account);
        bool AddRoleToAccount(System.Guid AccountID, Guid RoleId);
        Account GetAccount(System.Guid id);
        bool DeleteAccount(Account account);
        IEnumerable<Role> GetAccountRoles(Account account);
        IEnumerable<Role> GetAllRoles();
        IEnumerable<Account> GetAllAccounts();
        Account GetAccount(string username);
        Role GetRole(Guid id);
        bool DeleteRoleFromAccount(Guid AccountID, Guid RoleId);
        IEnumerable<Role> GetNoAccountRoles(Account account);
    }
}
