
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Construction_Context

{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public override string UserName { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }

        [Required, StringLength(11)]
        public override string PhoneNumber { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string LastName { get; set; }
        public byte[]? image { get; set; }

    }
}
