using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class HashtagDTO
    {
        [Key]
        public int HashtagID { get; set; }
        public string HastagText { get; set; }
        public int count { get; set; }
    }
}
