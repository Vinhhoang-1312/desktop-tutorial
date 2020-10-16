namespace FPT_Training_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uploadDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainees", "Phone", c => c.String());
            DropColumn("dbo.Trainees", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainees", "PhoneNumber", c => c.String());
            DropColumn("dbo.Trainees", "Phone");
        }
    }
}
