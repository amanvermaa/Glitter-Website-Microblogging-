using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _1.Glitter_Presentation.Models
{
    public class UserRegisterModel
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Invalid Password format")]
        public string Password { get; set; }
        [Required]
        [StringLength(12)]
        public string ContactNo { get; set; }
        [Required]
        public string Country { get; set; }
        public string ImagePath { get; set; }
       
    }
}