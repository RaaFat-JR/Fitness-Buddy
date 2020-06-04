namespace FitnessBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newData : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        Full_Name = c.String(nullable: false, maxLength: 255),
                        Birthdate = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        
                    })
                .PrimaryKey(t => t.Id);
            
            
        }
        
        public override void Down()
        {
            
        }
    }
}
