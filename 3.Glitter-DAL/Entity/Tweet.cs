using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Glitter_DAL.Entity
{
    public class Tweet
    {
        [Key]
        public int TweetID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        [StringLength(maximumLength:240)]
        public string Message { get; set; }
        [Required]
        public System.DateTime CreatedAt { get; set; }
       
      

    }
}
