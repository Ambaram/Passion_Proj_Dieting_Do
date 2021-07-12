namespace Dieting_Do.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class completedbupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vets",
                c => new
                    {
                        VetID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ClinicName = c.String(),
                        Location = c.String(),
                        Phone = c.String(),
                        Standard_Data_SpeciesId = c.Int(),
                        Species_SpeciesId = c.Int(),
                    })
                .PrimaryKey(t => t.VetID)
                .ForeignKey("dbo.Standard_Data", t => t.Standard_Data_SpeciesId)
                .ForeignKey("dbo.Species", t => t.Species_SpeciesId)
                .Index(t => t.Standard_Data_SpeciesId)
                .Index(t => t.Species_SpeciesId);
            
            CreateTable(
                "dbo.AnnualEvents",
                c => new
                    {
                        AnnualEventID = c.Int(nullable: false, identity: true),
                        AnnulaEventName = c.String(),
                        Organizer = c.String(),
                        Category = c.String(),
                        ShelterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnnualEventID)
                .ForeignKey("dbo.Shelters", t => t.ShelterID, cascadeDelete: true)
                .Index(t => t.ShelterID);
            
            CreateTable(
                "dbo.Shelters",
                c => new
                    {
                        ShelterID = c.Int(nullable: false, identity: true),
                        ShelterName = c.String(),
                        Location = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        OwnerName = c.String(),
                    })
                .PrimaryKey(t => t.ShelterID);
            
            CreateTable(
                "dbo.SpeciesShelters",
                c => new
                    {
                        Species_SpeciesId = c.Int(nullable: false),
                        Shelter_ShelterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Species_SpeciesId, t.Shelter_ShelterID })
                .ForeignKey("dbo.Species", t => t.Species_SpeciesId, cascadeDelete: true)
                .ForeignKey("dbo.Shelters", t => t.Shelter_ShelterID, cascadeDelete: true)
                .Index(t => t.Species_SpeciesId)
                .Index(t => t.Shelter_ShelterID);
            
            AddColumn("dbo.Animals", "Vet_VetID", c => c.Int());
            AddColumn("dbo.Animals", "Shelter_ShelterID", c => c.Int());
            CreateIndex("dbo.Animals", "Vet_VetID");
            CreateIndex("dbo.Animals", "Shelter_ShelterID");
            AddForeignKey("dbo.Animals", "Vet_VetID", "dbo.Vets", "VetID");
            AddForeignKey("dbo.Animals", "Shelter_ShelterID", "dbo.Shelters", "ShelterID");
            AddForeignKey("dbo.Animals", "SpeciesId", "dbo.Species", "SpeciesId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnnualEvents", "ShelterID", "dbo.Shelters");
            DropForeignKey("dbo.Vets", "Species_SpeciesId", "dbo.Species");
            DropForeignKey("dbo.SpeciesShelters", "Shelter_ShelterID", "dbo.Shelters");
            DropForeignKey("dbo.SpeciesShelters", "Species_SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Animals", "SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Animals", "Shelter_ShelterID", "dbo.Shelters");
            DropForeignKey("dbo.Vets", "Standard_Data_SpeciesId", "dbo.Standard_Data");
            DropForeignKey("dbo.Animals", "Vet_VetID", "dbo.Vets");
            DropIndex("dbo.SpeciesShelters", new[] { "Shelter_ShelterID" });
            DropIndex("dbo.SpeciesShelters", new[] { "Species_SpeciesId" });
            DropIndex("dbo.AnnualEvents", new[] { "ShelterID" });
            DropIndex("dbo.Vets", new[] { "Species_SpeciesId" });
            DropIndex("dbo.Vets", new[] { "Standard_Data_SpeciesId" });
            DropIndex("dbo.Animals", new[] { "Shelter_ShelterID" });
            DropIndex("dbo.Animals", new[] { "Vet_VetID" });
            DropColumn("dbo.Animals", "Shelter_ShelterID");
            DropColumn("dbo.Animals", "Vet_VetID");
            DropTable("dbo.SpeciesShelters");
            DropTable("dbo.Shelters");
            DropTable("dbo.AnnualEvents");
            DropTable("dbo.Vets");
        }
    }
}
