using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class FollowDTO
    {
        public int FollowID { get; set; }
        public int UserID { get; set; }
        public int FollowingIDs { get; set; }
    }
}
