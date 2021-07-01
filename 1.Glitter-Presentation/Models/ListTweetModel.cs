using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.Glitter_Presentation.Models
{
    public class ListTweetModel
    {
        [Key]
        public int TweetID { get; set; }
        public int UserID { get; set; }
        public string Message { get; set; }
        public System.DateTime CreatedAt { get; set; }

    }
}