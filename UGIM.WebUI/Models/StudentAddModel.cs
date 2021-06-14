using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UGIM.WebUI.Models
{
    public class StudentAddModel
    {
        public int Id { get; set; }
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
        public int BirthYear { get; set; }
        [Required]
        [StringLength(2)]
        public string Class { get; set; }
        [Required]
        public int UgimYear { get; set; }
        [Required]
        public int GroupNumber { get; set; }
    }
}
