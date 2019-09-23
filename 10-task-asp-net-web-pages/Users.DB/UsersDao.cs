using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;

namespace Users.DB
{
    public class UsersDao : IUsers
    {
        private static string connectionString;

        public UsersDao()
        {
            try
            {
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["UsersAwardsDBConnection"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception("connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[\"UsersAwardsDBConnection\"].ConnectionString;", ex);
            }
        }

        public bool AddUser(User user)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("dbo.AddUser", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                command.Parameters.Add(new SqlParameter("@Id", user.Id));
                command.Parameters.Add(new SqlParameter("@Name", user.Name));
                command.Parameters.Add(new SqlParameter("@BirthDay", user.BirthDay));

                con.Open();
                var reader = command.ExecuteNonQuery();
                return reader > 0 ? true : false;
            }
        }

        public User GetUser(Guid id)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT TOP 1 [Id], [Name], [BirthDay] FROM dbo.[Users] WHERE [Id] = @id", con);
                command.Parameters.Add(new SqlParameter("@id", id));

                con.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User()
                    {
                        Id = (Guid)reader["ID"],
                        Name = (string)reader["Name"],
                        BirthDay = (DateTime)reader["BirthDay"],
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Name], [BirthDay] FROM dbo.[Users]", con);
                con.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User()
                    {
                        Id = (Guid)reader["ID"],
                        Name = (string)reader["Name"],
                        BirthDay = (DateTime)reader["BirthDay"],
                    };
                }
            }
        }

        public IEnumerable<UserImage> GetAllImages()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Image] FROM dbo.[UserImage]", con);
                con.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new UserImage()
                    {
                        UserId = (Guid)reader["Id"],
                        Image = (string)reader["Image"],
                    };
                }
            }
        }

        public bool DeleteUser(Guid id)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("dbo.DeleteUser", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };

                command.Parameters.Add(new SqlParameter("@Id", id));

                con.Open();
                var reader = command.ExecuteNonQuery();

                return reader > 0 ? true : false;
            }
        }

        public bool SetAllUsers(IEnumerable<User> users)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("DELETE FROM dbo.Users", con);
                con.Open();
                var reader = command.ExecuteNonQuery();
            }

            try
            {

                foreach (var user in users)
                {
                    if (!this.AddUser(user))
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

        public bool SetUserImage(Guid id)
        {
            try
            {
                this.RemoveUserImage(id);

                using (var con = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("INSERT INTO dbo.UserImage (Id, Image) VALUES (@Id, @Image)", con);
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

        public bool GetUserImage(Guid id)
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("SELECT TOP 1 [Id], [Image] FROM dbo.UserImage WHERE [Id] = @id", con);
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

        public bool RemoveUserImage(Guid id)
        {
            if (this.GetUser(id) == null)
            {
                return false;
            }

            try
            {
                if (this.GetUserImage(id))
                {
                    using (var con = new SqlConnection(connectionString))
                    {
                        var command = new SqlCommand("DELETE FROM dbo.UserImage WHERE [Id] = @Id", con);
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
