namespace Dieting_Do.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animals", "SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Standard_Data", "SpeciesId", "dbo.Species");
            DropIndex("dbo.Standard_Data", new[] { "SpeciesId" });
            DropPrimaryKey("dbo.Standard_Data");
            AlterColumn("dbo.Standard_Data", "SpeciesId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Standard_Data", "SpeciesId");
            AddForeignKey("dbo.Animals", "SpeciesId", "dbo.Standard_Data", "SpeciesId", cascadeDelete: true);
            DropColumn("dbo.Standard_Data", "DataId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Standard_Data", "DataId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Animals", "SpeciesId", "dbo.Standard_Data");
            DropPrimaryKey("dbo.Standard_Data");
            AlterColumn("dbo.Standard_Data", "SpeciesId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Standard_Data", "DataId");
            CreateIndex("dbo.Standard_Data", "SpeciesId");
            AddForeignKey("dbo.Standard_Data", "SpeciesId", "dbo.Species", "SpeciesId", cascadeDelete: true);
            AddForeignKey("dbo.Animals", "SpeciesId", "dbo.Species", "SpeciesId", cascadeDelete: true);
        }
    }
}
