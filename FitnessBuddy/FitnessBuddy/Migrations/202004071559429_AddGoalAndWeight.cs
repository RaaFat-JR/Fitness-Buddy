namespace FitnessBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGoalAndWeight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "CurrentWeight", c => c.Int(nullable: false));
            AddColumn("dbo.Members", "Goal", c => c.String(nullable: false));
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "Goal");
            DropColumn("dbo.Trainers", "CurrentWeight");
            DropColumn("dbo.Members", "Goal");
            DropColumn("dbo.Members", "CurrentWeight");
        }
    }
}
