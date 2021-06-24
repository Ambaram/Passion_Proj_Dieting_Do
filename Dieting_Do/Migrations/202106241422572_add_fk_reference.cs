namespace Dieting_Do.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_fk_reference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "SpeciesId", c => c.Int(nullable: false));
            AddColumn("dbo.BMIs", "AnimalId", c => c.Int(nullable: false));
            AddColumn("dbo.Feed_Schedule", "AnimalId", c => c.Int(nullable: false));
            AddColumn("dbo.Requirements", "AnimalId", c => c.Int(nullable: false));
            CreateIndex("dbo.Animals", "SpeciesId");
            CreateIndex("dbo.BMIs", "AnimalId");
            CreateIndex("dbo.Feed_Schedule", "AnimalId");
            CreateIndex("dbo.Requirements", "AnimalId");
            AddForeignKey("dbo.Animals", "SpeciesId", "dbo.Species", "SpeciesId", cascadeDelete: true);
            AddForeignKey("dbo.BMIs", "AnimalId", "dbo.Animals", "AnimalId", cascadeDelete: true);
            AddForeignKey("dbo.Feed_Schedule", "AnimalId", "dbo.Animals", "AnimalId", cascadeDelete: true);
            AddForeignKey("dbo.Requirements", "AnimalId", "dbo.Animals", "AnimalId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requirements", "AnimalId", "dbo.Animals");
            DropForeignKey("dbo.Feed_Schedule", "AnimalId", "dbo.Animals");
            DropForeignKey("dbo.BMIs", "AnimalId", "dbo.Animals");
            DropForeignKey("dbo.Animals", "SpeciesId", "dbo.Species");
            DropIndex("dbo.Requirements", new[] { "AnimalId" });
            DropIndex("dbo.Feed_Schedule", new[] { "AnimalId" });
            DropIndex("dbo.BMIs", new[] { "AnimalId" });
            DropIndex("dbo.Animals", new[] { "SpeciesId" });
            DropColumn("dbo.Requirements", "AnimalId");
            DropColumn("dbo.Feed_Schedule", "AnimalId");
            DropColumn("dbo.BMIs", "AnimalId");
            DropColumn("dbo.Animals", "SpeciesId");
        }
    }
}
