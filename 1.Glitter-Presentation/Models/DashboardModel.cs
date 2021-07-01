using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1.Glitter_Presentation.Models
{
    public class DashboardModel
    {
        public int TweetID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public System.DateTime CreatedAt { get; set; }

        public int TotalLikes { get; set; }
        public int TotalDislikes { get; set; }

    }
}