using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Glitter_DAL.Entity
{
    public class LikeDislike
    {
        enum Like_Dislike
        {
            like = -1,
            Dislike = 1
        }
        [Key]
        public int LikeID { get; set; }
        public int TweetID { get;set; }
        [Required]
        public int UserID { get; set; }

        public int Action { get; set; }

    }
}
