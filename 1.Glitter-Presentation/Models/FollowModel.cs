using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.Glitter_Presentation.Models
{
    public class FollowModel
    {
       
        public int UserID { get; set; }
        public int FollowingIDs { get; set; }
    }
}