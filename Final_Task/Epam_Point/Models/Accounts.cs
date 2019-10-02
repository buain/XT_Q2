using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam_Point.Models
{
    public class Accounts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nik { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}