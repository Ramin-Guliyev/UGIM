using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UGIM.Server.Models
{
    public class Student
    {
        public int  Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string FatherName { get; set; }
        [Required]
        [StringLength(200)]
        public string School { get; set; }
        [Required]
        public int  BirthYear { get; set; }
        [Required]
        [StringLength(2)]
        public string Class { get; set; }

        public int UgimYear { get; set; }
        public int GroupNumber { get; set; }
        public string AppUserId { get; set; }
    }
}
