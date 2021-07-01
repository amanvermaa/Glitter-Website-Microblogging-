using _3.Glitter_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Glitter_DAL
{
    class GlitterDbContext : DbContext
    {
        public GlitterDbContext() : base("GlitterDatabase") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Follow> Follows { get; set; }

        public DbSet<LikeDislike> LikeDislikes { get; set; }

        public DbSet<Hashtag> Hashtags { get; set; }


    }
}
