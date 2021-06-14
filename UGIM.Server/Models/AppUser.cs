using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UGIM.Server.Models
{
    public class AppUser:IdentityUser
    {
        
        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(60)]
        public string LastName { get; set; }
        public string Title { get; set; }

    }
}
