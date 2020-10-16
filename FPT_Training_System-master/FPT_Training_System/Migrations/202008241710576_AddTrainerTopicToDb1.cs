namespace FPT_Training_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrainerTopicToDb1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrainerTopics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainerId = c.String(maxLength: 128),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TrainerId)
                .Index(t => t.TrainerId)
                .Index(t => t.Topic_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainerTopics", "TrainerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrainerTopics", "Topic_Id", "dbo.Topics");
            DropIndex("dbo.TrainerTopics", new[] { "Topic_Id" });
            DropIndex("dbo.TrainerTopics", new[] { "TrainerId" });
            DropTable("dbo.TrainerTopics");
        }
    }
}
