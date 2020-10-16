namespace FPTTraining0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTraineeCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TraineeEmail = c.String(nullable: false),
                        PassEmail = c.String(nullable: false),
                        Birth = c.String(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainees", "CourseId", "dbo.Courses");
            DropIndex("dbo.Trainees", new[] { "CourseId" });
            DropTable("dbo.Trainees");
            DropTable("dbo.Courses");
        }
    }
}
