using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Entities
{
    public interface IAwards
    {
        bool AddAward(Award award);
        bool AddAwardToUser(Guid user_id, Guid award_id);
        Award GetAward(Guid Id);
    }
}
