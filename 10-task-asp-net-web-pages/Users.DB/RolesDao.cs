using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;

namespace Users.DB
{
    class RolesDao : IRoles
    {
        private static string connectionString;

        public RolesDao()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["UsersAwardsDBConnection"].ConnectionString;

        }

        public bool AddAccount(Account account)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("INSERT INTO dbo.AppAccounts (Id, Login, Password) VALUES (@Id, @Login, @Password)", con);
                command.Parameters.Add(new SqlParameter("@Id", account.Id));
                command.Parameters.Add(new SqlParameter("@Login", account.Login));
                command.Parameters.Add(new SqlParameter("@Password", account.Password));

                con.Open();
                var reader = command.ExecuteNonQuery();

                return reader > 0 ? true : false;
            }
        }

        public bool AddRoleToAccount(Guid AccountId, Guid RoleId)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("INSERT INTO dbo.AppUserRoles (UserId, RoleId) VALUES (@UserId, @RoleId)", con);
                command.Parameters.Add(new SqlParameter("@UserId", AccountId));
                command.Parameters.Add(new SqlParameter("@RoleId", RoleId));

                con.Open();
                var reader = command.ExecuteNonQuery();

                return reader > 0 ? true : false;
            }
        }

        public Account GetAccount(Guid id)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT TOP 1 [Id], [Login], [Password] FROM dbo.[AppAccounts] WHERE dbo.[AppAccounts].[Id] = @id", con);
                command.Parameters.Add(new SqlParameter("@id", id));

                con.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Account()
                    {
                        Id = (Guid)reader["ID"],
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public Role GetRole(Guid id)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT TOP 1 [Id], [RoleName] FROM dbo.[AppRoles] WHERE dbo.[AppRoles].[Id] = @id", con);
                command.Parameters.Add(new SqlParameter("@id", id));

                con.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Role()
                    {
                        Id = (Guid)reader["Id"],
                        RoleName = (string)reader["RoleName"],
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public Account GetAccount(string username)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT TOP 1 [Id], [Login], [Password] FROM dbo.[AppAccounts] WHERE dbo.[AppAccounts].[Login] = @username", con);
                command.Parameters.Add(new SqlParameter("@username", username));

                con.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Account()
                    {
                        Id = (Guid)reader["Id"],
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public bool DeleteAccount(Account account)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("DELETE FROM dbo.AppAccounts WHERE Id = @Id", con);
                command.Parameters.Add(new SqlParameter("@Id", account.Id));

                con.Open();
                var reader = command.ExecuteNonQuery();

                return reader > 0 ? true : false;
            }
        }

        public System.Collections.Generic.IEnumerable<Role> GetAccountRoles(Account account)
        {
            using (var con = new SqlConnection(connectionString))
            {
                ///!!!!
                var command = new SqlCommand("SELECT dbo.AppRoles.Id, dbo.AppRoles.RoleName " +
                    "FROM dbo.AppRoles INNER JOIN dbo.AppUserRoles " +
                    "ON dbo.AppRoles.Id = dbo.AppUserRoles.RoleId " +
                    "WHERE dbo.AppUserRoles.UserId = @UserId", con);
                command.Parameters.Add(new SqlParameter("@UserId", account.Id));

                con.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Role()
                    {
                        Id = (Guid)reader["Id"],
                        RoleName = (string)reader["RoleName"],
                    };
                }
            }
        }

        public IEnumerable<Role> GetNoAccountRoles(Account account)
        {
            var allRoles = this.GetAllRoles().ToList();
            var userRoles = this.GetAccountRoles(account).ToList();
            if (userRoles.Count() == 0)
            {
                foreach (var role in allRoles)
                {
                    yield return role;
                }
            }
            else
            {
                foreach (var role in allRoles)
                {
                    bool contains = false;
                    foreach (var other in userRoles)
                    {
                        if (role.Id == other.Id)
                        {
                            contains = true;
                        }
                    }

                    if (!contains)
                    {
                        yield return role;
                    }
                }
            }
        }

        public IEnumerable<Role> GetAllRoles()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT ID, RoleName FROM dbo.AppRoles", con);
                con.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Role()
                    {
                        Id = (Guid)reader["Id"],
                        RoleName = (string)reader["RoleName"],
                    };
                }
            }
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT Id, Login, Password FROM dbo.AppAccounts", con);
                con.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Account()
                    {
                        Id = (Guid)reader["Id"],
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                    };
                }
            }
        }

        public bool DeleteRoleFromAccount(System.Guid AccountId, System.Guid RoleId)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("DELETE FROM dbo.AppUserRoles WHERE UserId=@UserId AND RoleId=@RoleId", con);
                command.Parameters.Add(new SqlParameter("@UserId", AccountId));
                command.Parameters.Add(new SqlParameter("@RoleId", RoleId));

                con.Open();
                var reader = command.ExecuteNonQuery();

                return reader > 0 ? true : false;
            }
        }
    }
}
