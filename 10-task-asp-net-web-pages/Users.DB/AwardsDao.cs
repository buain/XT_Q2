using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;

namespace Users.DB
{
    class AwardsDao : IAwards
    {
        private static string connectionString;
        public AwardsDao()
        {

        }

        public bool AddAward(Award award)
        {
            
        }

        public bool AddAwardToUser(Guid user_id, Guid award_id)
        {
            
        }

        public IEnumerable<Award> GetAllAwards()
        {
            
        }

        public Award GetAward(Guid Id)
        {
            
        }

        public IEnumerable<Award> GetUserAwards(User user)
        {
            
        }
    }
}
