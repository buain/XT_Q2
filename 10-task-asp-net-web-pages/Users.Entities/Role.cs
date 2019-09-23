using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Entities
{
    public class Role
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Length line must be from 1 to 255 symbols")]
        public string RoleName { get; set; }
    }
}
