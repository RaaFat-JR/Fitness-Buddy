namespace FitnessBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgramTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        WorkOut_Plan = c.String(),
                        Training_Time = c.String(),
                        Supplments = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Programs");
        }
    }
}
