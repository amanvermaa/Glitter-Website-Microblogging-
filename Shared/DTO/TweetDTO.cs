using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class TweetDTO
    {
        [Key]
        public int TweetID { get; set; }
        public int UserID { get; set; }
        public string Message { get; set; }
        public System.DateTime CreatedAt { get; set; }

    }
}
