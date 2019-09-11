using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Entities
{
    class UsersAwards
    {
        public Guid UserId { get; set; }
        public Guid AwardId { get; set; }
        public UsersAwards()
        {

        }
        public UsersAwards(Guid userId, Guid awardId)
        {
            UserId = userId;
            AwardId = awardId;
        }
        public UsersAwards(User user, Award award)
        {
            UserId = user.Id;
            AwardId = award.Id;
        }
    }
}
