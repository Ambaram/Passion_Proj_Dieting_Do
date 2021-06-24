namespace Dieting_Do.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class animalandspeciesentities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        AnimalName = c.String(),
                        AnimalWeight = c.Int(nullable: false),
                        AnimalHeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        AnimalSpecies = c.String(),
                    })
                .PrimaryKey(t => t.SpeciesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Species");
            DropTable("dbo.Animals");
        }
    }
}
