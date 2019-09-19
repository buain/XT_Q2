using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebGUI.Models
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Userss { get; set; }

    }
}