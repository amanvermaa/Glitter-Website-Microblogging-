﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.Glitter_Presentation.Models
{
    public class ListUserModel
    {
        [Key]
        public int UserID { get; set; }
        
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}