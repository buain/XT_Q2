using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;
using System.IO;

namespace Users.DAL
{
    public class FileStorageAwards : IAwards
    {
        private const string FileAwards = @"D:\Task6\awards.txt";
        private const string FileAwardsUsers = @"D:\Task6\awards_users.txt";
        private string file_awards;
        private string file_awards_users;

        public FileStorageAwards()
        {
            this.file_awards = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileAwards);
            this.file_awards_users = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileAwardsUsers);
        }

        public bool AddAward(Award award)
        {
            if(GetAward(award.Id) != null)
            {
                return false;
            }

            try
            {
                File.AppendAllLines(file_awards, new[] { CreateLineFromAward(award) });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Award GetAward(Guid id)
        {
            return GetAllAwards().FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<Award> GetAllAwards()
        {
            string[] lines = File.ReadAllLines(file_awards);
            foreach(string line in lines)
            {
                var award = CreateAwardFromLine(line);
                if(award != null)
                {
                    yield return award;
                }
            }
        }
        private static string CreateLineFromAward(Award award)
        {
            return string.Format($"{award.Id.ToString()}_{award.Title.ToString()}");
        }

        private static Award CreateAwardFromLine(string line)
        {
            var awardField = line.Split('_');
            if(awardField.Length != 2)
            {
                return null;
            }
            return new Award(awardField[1])
            {
                Id = Guid.Parse(awardField[0]),
            };
        }

        public bool AddAwardToUser(Guid userID, Guid awardID)
        {
            Guid newID = Guid.NewGuid();

            try
            {
                if (!File.Exists(this.file_awards_users))
                {
                    return false;
                }

                File.AppendAllLines(this.file_awards_users, new[] { CreateLineForUsersAward(userID, awardID) });
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string CreateLineForUsersAward(Guid userId, Guid awardId)
        {
            return string.Format($"{userId.ToString()}_{awardId.ToString()}");
        }

        public IEnumerable<Award> GetUserAwards(User user)
        {
            if (!File.Exists(file_awards_users))
            {
                throw new FileNotFoundException("File not found");
            }

            string[] lines = File.ReadAllLines(file_awards_users);
            foreach (string line in lines)
            {
                var usersAward = line.Split('_');
                Guid userId = Guid.Parse(usersAward[1]);

                if (userId == user.Id)
                {
                    Guid awardId = Guid.Parse(usersAward[2]);
                    yield return this.GetAward(awardId);
                }
            }
        }
    }
}
