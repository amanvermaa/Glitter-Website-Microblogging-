using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.Glitter_Presentation.Models
{
    public class CreateTweetModel
    {
        [Key]
        public int TweetID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        [StringLength(240)]
        public string Message { get; set; }




    }
}