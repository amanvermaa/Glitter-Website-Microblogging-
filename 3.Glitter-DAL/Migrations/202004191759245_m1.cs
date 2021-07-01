namespace _3.Glitter_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        FollowID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        FollowingIDs = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FollowID);
            
            CreateTable(
                "dbo.Hashtags",
                c => new
                    {
                        HashtagID = c.Int(nullable: false, identity: true),
                        HastagText = c.String(),
                        count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HashtagID);
            
            CreateTable(
                "dbo.LikeDislikes",
                c => new
                    {
                        LikeID = c.Int(nullable: false, identity: true),
                        TweetID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LikeID);
            
            CreateTable(
                "dbo.Tweets",
                c => new
                    {
                        TweetID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Message = c.String(nullable: false, maxLength: 240),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TweetID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Tweets");
            DropTable("dbo.LikeDislikes");
            DropTable("dbo.Hashtags");
            DropTable("dbo.Follows");
        }
    }
}
