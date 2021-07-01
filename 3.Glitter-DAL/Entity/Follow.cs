using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Glitter_DAL.Entity
{
    public class Follow
    {
        [Key]
        public int FollowID { get; set; }
        [Required]
        public int UserID { get; set; }
        public int FollowingIDs { get; set; }
    }
}
