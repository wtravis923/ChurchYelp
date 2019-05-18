namespace ChurchYelp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leader", "LeaderName", c => c.String(nullable: false));
            DropColumn("dbo.Leader", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leader", "UserID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Leader", "LeaderName", c => c.String());
        }
    }
}
