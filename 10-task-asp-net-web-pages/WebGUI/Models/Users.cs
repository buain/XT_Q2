using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGUI.Models
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public Users()
        {

        }
    }
}