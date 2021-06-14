using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UGIM.Server.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
    }
}
