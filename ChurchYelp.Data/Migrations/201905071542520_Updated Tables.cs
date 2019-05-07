namespace ChurchYelp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Church", "ChurchCity", c => c.String(nullable: false));
            AddColumn("dbo.Church", "ChurchState", c => c.String(nullable: false));
            AddColumn("dbo.Church", "CommunityInvolvementRating", c => c.Single(nullable: false));
            AddColumn("dbo.Church", "FriendlyRating", c => c.Single(nullable: false));
            AddColumn("dbo.Church", "FacilityRating", c => c.Single(nullable: false));
            AddColumn("dbo.Church", "MusicRating", c => c.Single(nullable: false));
            AddColumn("dbo.Church", "MessageRating", c => c.Single(nullable: false));
            AddColumn("dbo.Leader", "SpeakingAbilityRating", c => c.Single(nullable: false));
            AddColumn("dbo.Leader", "EngagingRating", c => c.Single(nullable: false));
            AddColumn("dbo.Leader", "AuthenticRating", c => c.Single(nullable: false));
            AddColumn("dbo.Leader", "RapportRating", c => c.Single(nullable: false));
            AlterColumn("dbo.Church", "ChurchName", c => c.String(nullable: false));
            DropColumn("dbo.Church", "UserID");
            DropColumn("dbo.Church", "ChurchLocation");
            DropColumn("dbo.Church", "CommunityInvolvement");
            DropColumn("dbo.Church", "Friendliness");
            DropColumn("dbo.Church", "Facilities");
            DropColumn("dbo.Church", "Music");
            DropColumn("dbo.Church", "Message");
            DropColumn("dbo.Leader", "SpeakingAbility");
            DropColumn("dbo.Leader", "Engaging");
            DropColumn("dbo.Leader", "Authentic");
            DropColumn("dbo.Leader", "Rapport");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leader", "Rapport", c => c.Single(nullable: false));
            AddColumn("dbo.Leader", "Authentic", c => c.Single(nullable: false));
            AddColumn("dbo.Leader", "Engaging", c => c.Single(nullable: false));
            AddColumn("dbo.Leader", "SpeakingAbility", c => c.Single(nullable: false));
            AddColumn("dbo.Church", "Message", c => c.Single(nullable: false));
            AddColumn("dbo.Church", "Music", c => c.Single(nullable: false));
            AddColumn("dbo.Church", "Facilities", c => c.Single(nullable: false));
            AddColumn("dbo.Church", "Friendliness", c => c.Single(nullable: false));
            AddColumn("dbo.Church", "CommunityInvolvement", c => c.Single(nullable: false));
            AddColumn("dbo.Church", "ChurchLocation", c => c.String());
            AddColumn("dbo.Church", "UserID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Church", "ChurchName", c => c.String());
            DropColumn("dbo.Leader", "RapportRating");
            DropColumn("dbo.Leader", "AuthenticRating");
            DropColumn("dbo.Leader", "EngagingRating");
            DropColumn("dbo.Leader", "SpeakingAbilityRating");
            DropColumn("dbo.Church", "MessageRating");
            DropColumn("dbo.Church", "MusicRating");
            DropColumn("dbo.Church", "FacilityRating");
            DropColumn("dbo.Church", "FriendlyRating");
            DropColumn("dbo.Church", "CommunityInvolvementRating");
            DropColumn("dbo.Church", "ChurchState");
            DropColumn("dbo.Church", "ChurchCity");
        }
    }
}
