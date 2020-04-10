namespace FitnessBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToTrainers : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Trainers ON");
            Sql("INSERT INTO Trainers (Id, F_Name, L_Name, PhoneNumber, Birthdate, Email) VALUES (1, 'Muhammed', 'RaaFat', 01156889772, 3/12/1997, 'muhammedraafat6@gmail.com')");
        }
        
        public override void Down()
        {
        }
    }
}
