using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["UsersAwardsDBConnection"].ConnectionString;
        }

        public bool AddAward(Award award)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("dbo.AddAward", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };

                command.Parameters.Add(new SqlParameter("@Id", award.Id));
                command.Parameters.Add(new SqlParameter("@Title", award.Title));

                con.Open();
                var reader = command.ExecuteNonQuery();

                return reader > 0 ? true : false;
            }
        }

        public bool AddAwardToUser(Guid user_id, Guid award_id)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("INSERT INTO dbo.UserAwards ([UserId], [AwardId]) VALUES (@UserId, @AwardId)", con);
                command.Parameters.Add(new SqlParameter("@UserId", user_id));
                command.Parameters.Add(new SqlParameter("@AwardId", award_id));

                con.Open();
                var reader = command.ExecuteNonQuery();

                return reader > 0 ? true : false;
            }
        }

        public Award GetAward(Guid id)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT TOP 1 [Id], [Title] FROM dbo.[Awards] WHERE Id = @id", con);
                command.Parameters.Add(new SqlParameter("@id", id));

                con.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Award()
                    {
                        Id = (Guid)reader["Id"],
                        Title = (string)reader["Title"],
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public bool DeleteUserAwards(User user)
        {
            return true;
        }

        public IEnumerable<Award> GetUserAwards(User user)
        {
            using (var con = new SqlConnection(connectionString))
            {

                var command = new SqlCommand("dbo.GetUserAwards", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };

                command.Parameters.Add(new SqlParameter("@UserId", user.Id));

                con.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //  dbo.AppRoles.ID, dbo.AppRoles.RoleName
                    yield return new Award()
                    {
                        Id = (Guid)reader["Id"],
                        Title = (string)reader["Title"],
                    };
                }
            }
        }

        public IEnumerable<Award> GetAllAwards()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Title] FROM dbo.[Awards]", con);
                con.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Award()
                    {
                        Id = (Guid)reader["Id"],
                        Title = (string)reader["Title"],
                    };
                }
            }
        }

        public IEnumerable<UsersAward> GetAllUserAwards()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("dbo.GetAllUserAwards", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };

                con.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //  dbo.AppRoles.ID, dbo.AppRoles.RoleName
                    yield return new UsersAward()
                    {
                        UserId = (Guid)reader["UserId"],
                        AwardId = (Guid)reader["AwardId"],
                    };
                }
            }
        }

        public bool SetAllAwards(IEnumerable<Award> awards)
        {
            // 1!!
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("DELETE FROM dbo.Awars", con);
                con.Open();
                var reader = command.ExecuteNonQuery();
            }

            try
            {
                foreach (var award in awards)
                {
                    if (!this.AddAward(award))
                    {
                        return false;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SetAllUserAwards(IEnumerable<UsersAward> _usersAndAwardsList)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("DELETE FROM dbo.UserAwards", con);
                con.Open();
                var reader = command.ExecuteNonQuery();
            }

            try
            {
                foreach (var ua in _usersAndAwardsList)
                {
                    if (!this.AddAwardToUser(ua.UserId, ua.AwardId))
                    {
                        return false;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SetAwardImage(Guid id)
        {
            try
            {
                this.RemoveAwardImage(id);

                using (var con = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("INSERT INTO dbo.AwardImage (Id, Image) VALUES (@Id, @Image)", con);
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.Parameters.Add(new SqlParameter("@Image", id.ToString()));

                    con.Open();
                    var reader = command.ExecuteNonQuery();

                    return reader > 0 ? true : false;

                }
            }
            catch
            {
                return false;
            }
        }


        public bool GetAwardImage(Guid id)
        {
            if (this.GetAward(id) == null)
            {
                return false;
            }

            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("SELECT TOP 1 [Id], [Image] FROM dbo.AwardImage WHERE Id = @id", con);
                    command.Parameters.Add(new SqlParameter("@id", id));

                    con.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveAwardImage(Guid id)
        {
            if (this.GetAward(id) == null)
            {
                return false;
            }

            try
            {
                if (this.GetAwardImage(id))
                {
                    using (var con = new SqlConnection(connectionString))
                    {
                        var command = new SqlCommand("DELETE FROM dbo.[AwardImage] WHERE [Id] = @Id", con);
                        command.Parameters.Add(new SqlParameter("@Id", id));

                        con.Open();
                        var reader = command.ExecuteNonQuery();

                        return reader > 0 ? true : false;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
