namespace FPTTraining0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrainerTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "PassEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "PassEmail");
        }
    }
}
