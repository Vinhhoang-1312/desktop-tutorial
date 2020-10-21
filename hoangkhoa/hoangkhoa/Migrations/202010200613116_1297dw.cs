namespace hoangkhoa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1297dw : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TraineeCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TraineeId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TraineeId)
                .Index(t => t.TraineeId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        WorkingPlace = c.String(),
                        Phone = c.String(),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.TrainerTopics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainerId = c.String(maxLength: 128),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TrainerId)
                .Index(t => t.TrainerId)
                .Index(t => t.TopicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainerTopics", "TrainerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrainerTopics", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Trainers", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.TraineeCourses", "TraineeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TraineeCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.TrainerTopics", new[] { "TopicId" });
            DropIndex("dbo.TrainerTopics", new[] { "TrainerId" });
            DropIndex("dbo.Trainers", new[] { "TopicId" });
            DropIndex("dbo.TraineeCourses", new[] { "CourseId" });
            DropIndex("dbo.TraineeCourses", new[] { "TraineeId" });
            DropTable("dbo.TrainerTopics");
            DropTable("dbo.Trainers");
            DropTable("dbo.TraineeCourses");
        }
    }
}
