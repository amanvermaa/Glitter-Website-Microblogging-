using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class LikeDislikeDTO
    {
        
        public int LikeID { get; set; }
        public int TweetID { get; set; }
        public int UserID { get; set; }

        public int Action { get; set; } = 0;
    }
}
