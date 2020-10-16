namespace FPT_Training_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrainerTopicToDb2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrainerTopics", "Topic_Id", "dbo.Topics");
            DropIndex("dbo.TrainerTopics", new[] { "Topic_Id" });
            RenameColumn(table: "dbo.TrainerTopics", name: "Topic_Id", newName: "TopicId");
            AlterColumn("dbo.TrainerTopics", "TopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.TrainerTopics", "TopicId");
            AddForeignKey("dbo.TrainerTopics", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainerTopics", "TopicId", "dbo.Topics");
            DropIndex("dbo.TrainerTopics", new[] { "TopicId" });
            AlterColumn("dbo.TrainerTopics", "TopicId", c => c.Int());
            RenameColumn(table: "dbo.TrainerTopics", name: "TopicId", newName: "Topic_Id");
            CreateIndex("dbo.TrainerTopics", "Topic_Id");
            AddForeignKey("dbo.TrainerTopics", "Topic_Id", "dbo.Topics", "Id");
        }
    }
}
