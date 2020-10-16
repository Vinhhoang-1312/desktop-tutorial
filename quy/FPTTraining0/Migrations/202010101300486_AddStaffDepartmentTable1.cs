namespace FPTTraining0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStaffDepartmentTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "PassEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staffs", "PassEmail");
        }
    }
}
