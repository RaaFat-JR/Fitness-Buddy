namespace FitnessBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePhoneIntoString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Trainers", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "PhoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
