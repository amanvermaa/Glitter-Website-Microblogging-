namespace _3.Glitter_DAL.Migrations
{
    using _3.Glitter_DAL.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_3.Glitter_DAL.GlitterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_3.Glitter_DAL.GlitterDbContext context)
        {
            var users = new List<User>
             {
                 new User { Name = "Aman Verma", Email = "aman@gmail.com", Password = "aman1234!", ContactNo = "8377944034", Country = "India" },
                 new User { Name = "Selmon Khan", Email = "selmon@gmail.com", Password = "selmon1234!", ContactNo = "8377944035", Country = "USA" },
                 new User { Name = "Kashish Soni", Email = "kashish@gmail.com", Password = "kashish1234!", ContactNo = "8377944036", Country = "India"},
                 new User { Name = "Gourav Sharma", Email = "gourav@gmail.com", Password = "gourav1234!", ContactNo = "8377944037", Country = "Maldives"},
                 new User { Name = "Arjun Bhatnagar", Email = "arjun@gmail.com", Password = "arjun1234!", ContactNo = "8377944038", Country = "India"},
                 new User { Name = "Anuj Tyagi", Email = "anuj@gmail.com", Password = "anuj1234!", ContactNo = "8377944039", Country = "India"},
                 new User { Name = "Aman Shakya", Email = "shakya@gmail.com", Password = "shakya1234!", ContactNo = "8377944040", Country = "USA"}};

            foreach (User user in users)
            {
                context.Users.AddOrUpdate(user);
            }


            var tweets = new List<Tweet>
            {
                 new Tweet{ UserID = 1, Message ="Hi My name is Aman Verma #Good",CreatedAt = System.DateTime.Now},
                  new Tweet{ UserID = 2, Message ="Selmon Bhoi Here #Good",CreatedAt = System.DateTime.Now},
                  new Tweet{ UserID = 3, Message ="Kashish would be late to work today! #lazyMorning",CreatedAt = System.DateTime.Now},
                  new Tweet{ UserID = 4, Message ="Gourav is my Name",CreatedAt = System.DateTime.Now},
                  new Tweet{ UserID = 5, Message ="Arjun is my name #Good",CreatedAt = System.DateTime.Now},
                  new Tweet{ UserID = 6, Message ="Selmon Bhoi Here #Good",CreatedAt = System.DateTime.Now},
                  new Tweet{ UserID = 7, Message ="#Good",CreatedAt = System.DateTime.Now},
                  new Tweet{ UserID = 1, Message ="How you doing #Good",CreatedAt = System.DateTime.Now},
                  new Tweet{ UserID = 2, Message ="Going for a shoot #Good",CreatedAt = System.DateTime.Now}
            };
            foreach(Tweet tweet in tweets)
            {
                context.Tweets.AddOrUpdate(tweet);
            }
        }
    }
}
