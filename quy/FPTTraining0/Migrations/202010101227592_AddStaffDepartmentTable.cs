namespace FPTTraining0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStaffDepartmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StaffEmail = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Staffs", new[] { "DepartmentId" });
            DropTable("dbo.Staffs");
            DropTable("dbo.Departments");
        }
    }
}
