namespace FitnessBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTrainerID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "TrainerID", "dbo.Trainers");
            DropIndex("dbo.Members", new[] { "TrainerID" });
            RenameColumn(table: "dbo.Members", name: "TrainerID", newName: "Trainer_Id");
            AlterColumn("dbo.Members", "Trainer_Id", c => c.Int());
            CreateIndex("dbo.Members", "Trainer_Id");
            AddForeignKey("dbo.Members", "Trainer_Id", "dbo.Trainers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "Trainer_Id", "dbo.Trainers");
            DropIndex("dbo.Members", new[] { "Trainer_Id" });
            AlterColumn("dbo.Members", "Trainer_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Members", name: "Trainer_Id", newName: "TrainerID");
            CreateIndex("dbo.Members", "TrainerID");
            AddForeignKey("dbo.Members", "TrainerID", "dbo.Trainers", "Id", cascadeDelete: true);
        }
    }
}
