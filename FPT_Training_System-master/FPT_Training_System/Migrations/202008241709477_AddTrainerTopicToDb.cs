namespace FPT_Training_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrainerTopicToDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrainerTopics", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.TrainerTopics", "TrainerId", "dbo.AspNetUsers");
            DropIndex("dbo.TrainerTopics", new[] { "TrainerId" });
            DropIndex("dbo.TrainerTopics", new[] { "Topic_Id" });
            DropTable("dbo.TrainerTopics");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TrainerTopics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainerId = c.String(maxLength: 128),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TrainerTopics", "Topic_Id");
            CreateIndex("dbo.TrainerTopics", "TrainerId");
            AddForeignKey("dbo.TrainerTopics", "TrainerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TrainerTopics", "Topic_Id", "dbo.Topics", "Id");
        }
    }
}
