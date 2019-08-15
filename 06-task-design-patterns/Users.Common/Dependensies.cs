using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.DAL;
using Users.Entities;

namespace Users.Common
{
    public static class Dependensies
    {
        public static IStorable FileStorage { get; } = new FileStorageUsers();
    }
}
