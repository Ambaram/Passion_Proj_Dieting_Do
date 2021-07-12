namespace Dieting_Do.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventdto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Shelters", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shelters", "Location", c => c.String());
        }
    }
}
