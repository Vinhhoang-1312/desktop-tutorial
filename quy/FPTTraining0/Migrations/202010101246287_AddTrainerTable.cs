namespace FPTTraining0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrainerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TrainerEmail = c.String(nullable: false),
                    MajorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Majors", t => t.MajorId, cascadeDelete: true)
                .Index(t => t.MajorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "MajorId", "dbo.Majors");
            DropIndex("dbo.Trainers", new[] { "MajorId" });
            DropTable("dbo.Trainers");
            DropTable("dbo.Majors");

        }
    }
}
