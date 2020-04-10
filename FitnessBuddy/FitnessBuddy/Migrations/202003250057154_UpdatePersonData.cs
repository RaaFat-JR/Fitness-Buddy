namespace FitnessBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePersonData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Members", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Members", "Full_Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Trainers", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Trainers", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Trainers", "Full_Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Trainers", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Members", "F_Name");
            DropColumn("dbo.Members", "L_Name");
            DropColumn("dbo.Trainers", "F_Name");
            DropColumn("dbo.Trainers", "L_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "L_Name", c => c.String());
            AddColumn("dbo.Trainers", "F_Name", c => c.String());
            AddColumn("dbo.Members", "L_Name", c => c.String());
            AddColumn("dbo.Members", "F_Name", c => c.String());
            AlterColumn("dbo.Trainers", "Email", c => c.String());
            AlterColumn("dbo.Members", "Email", c => c.String());
            DropColumn("dbo.Trainers", "Full_Name");
            DropColumn("dbo.Trainers", "ConfirmPassword");
            DropColumn("dbo.Trainers", "Password");
            DropColumn("dbo.Members", "Full_Name");
            DropColumn("dbo.Members", "ConfirmPassword");
            DropColumn("dbo.Members", "Password");
        }
    }
}
