namespace ChurchYelp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Church",
                c => new
                    {
                        ChurchID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        ChurchName = c.String(),
                        ChurchLocation = c.String(),
                        CommunityInvolvement = c.Single(nullable: false),
                        Friendliness = c.Single(nullable: false),
                        Facilities = c.Single(nullable: false),
                        Music = c.Single(nullable: false),
                        Message = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ChurchID);
            
            CreateTable(
                "dbo.ChurchRating",
                c => new
                    {
                        ChurchID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        ChurchRatingID = c.Int(nullable: false),
                        CommunityInvolvementRating = c.Single(nullable: false),
                        FriendlyRating = c.Single(nullable: false),
                        FacilityRating = c.Single(nullable: false),
                        MusicRating = c.Single(nullable: false),
                        MessageRating = c.Single(nullable: false),
                        Church_ChurchID = c.Int(),
                    })
                .PrimaryKey(t => t.ChurchID)
                .ForeignKey("dbo.Church", t => t.Church_ChurchID)
                .Index(t => t.Church_ChurchID);
            
            CreateTable(
                "dbo.LeaderRating",
                c => new
                    {
                        LeaderID = c.Int(nullable: false, identity: true),
                        LeaderRatingID = c.Int(nullable: false),
                        UserID = c.Guid(nullable: false),
                        SpeakingAbilityRating = c.Single(nullable: false),
                        EngagingRating = c.Single(nullable: false),
                        AuthenticRating = c.Single(nullable: false),
                        RapportRating = c.Single(nullable: false),
                        Leaders_LeaderID = c.Int(),
                    })
                .PrimaryKey(t => t.LeaderID)
                .ForeignKey("dbo.Leader", t => t.Leaders_LeaderID)
                .Index(t => t.Leaders_LeaderID);
            
            CreateTable(
                "dbo.Leader",
                c => new
                    {
                        LeaderID = c.Int(nullable: false, identity: true),
                        LeaderName = c.String(),
                        UserID = c.Guid(nullable: false),
                        SpeakingAbility = c.Single(nullable: false),
                        Engaging = c.Single(nullable: false),
                        Authentic = c.Single(nullable: false),
                        Rapport = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.LeaderID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.LeaderRating", "Leaders_LeaderID", "dbo.Leader");
            DropForeignKey("dbo.ChurchRating", "Church_ChurchID", "dbo.Church");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.LeaderRating", new[] { "Leaders_LeaderID" });
            DropIndex("dbo.ChurchRating", new[] { "Church_ChurchID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Leader");
            DropTable("dbo.LeaderRating");
            DropTable("dbo.ChurchRating");
            DropTable("dbo.Church");
        }
    }
}
