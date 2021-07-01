using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class DashboardDTO
    {
        public string Name { get; set; }
        public string  Message { get; set; }
        public System.DateTime CreatedAt { get; set; }

        public int TotalLikes { get; set; }
        public int TotalDislikes { get; set; }
    }
}
