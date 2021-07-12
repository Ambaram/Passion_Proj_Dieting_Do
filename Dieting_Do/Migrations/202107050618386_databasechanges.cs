namespace Dieting_Do.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasechanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BMIs", "AnimalId", "dbo.Animals");
            DropForeignKey("dbo.Feed_Schedule", "AnimalId", "dbo.Animals");
            DropForeignKey("dbo.Requirements", "AnimalId", "dbo.Animals");
            DropIndex("dbo.BMIs", new[] { "AnimalId" });
            DropIndex("dbo.Feed_Schedule", new[] { "AnimalId" });
            DropIndex("dbo.Requirements", new[] { "AnimalId" });
            AddColumn("dbo.Animals", "animalwithpic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Animals", "picformat", c => c.String());
            AddColumn("dbo.Standard_Data", "SpeciesName", c => c.String());
            AddColumn("dbo.Standard_Data", "St_SpeciesBMI", c => c.Int(nullable: false));
            AddColumn("dbo.Standard_Data", "SpeciesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Standard_Data", "SpeciesId");
            AddForeignKey("dbo.Standard_Data", "SpeciesId", "dbo.Species", "SpeciesId", cascadeDelete: true);
            DropColumn("dbo.Standard_Data", "St_AnimalBMI");
            DropColumn("dbo.Standard_Data", "Species");
            DropColumn("dbo.Standard_Data", "St_No_Of_Meals");
            DropColumn("dbo.Standard_Data", "St_Meal_Time_Diff");
            DropTable("dbo.BMIs");
            DropTable("dbo.Feed_Schedule");
            DropTable("dbo.Requirements");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Requirements",
                c => new
                    {
                        ReqId = c.Int(nullable: false, identity: true),
                        Vitamin = c.Int(nullable: false),
                        Fibre = c.Int(nullable: false),
                        Protein = c.Int(nullable: false),
                        Carbs = c.Int(nullable: false),
                        AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReqId);
            
            CreateTable(
                "dbo.Feed_Schedule",
                c => new
                    {
                        SchedId = c.Int(nullable: false, identity: true),
                        No_Of_Meals = c.Int(nullable: false),
                        Meal_Time_Diff = c.Int(nullable: false),
                        AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SchedId);
            
            CreateTable(
                "dbo.BMIs",
                c => new
                    {
                        BMIId = c.Int(nullable: false, identity: true),
                        AnimalBMI = c.Int(nullable: false),
                        AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BMIId);
            
            AddColumn("dbo.Standard_Data", "St_Meal_Time_Diff", c => c.Int(nullable: false));
            AddColumn("dbo.Standard_Data", "St_No_Of_Meals", c => c.Int(nullable: false));
            AddColumn("dbo.Standard_Data", "Species", c => c.String());
            AddColumn("dbo.Standard_Data", "St_AnimalBMI", c => c.Int(nullable: false));
            DropForeignKey("dbo.Standard_Data", "SpeciesId", "dbo.Species");
            DropIndex("dbo.Standard_Data", new[] { "SpeciesId" });
            DropColumn("dbo.Standard_Data", "SpeciesId");
            DropColumn("dbo.Standard_Data", "St_SpeciesBMI");
            DropColumn("dbo.Standard_Data", "SpeciesName");
            DropColumn("dbo.Animals", "picformat");
            DropColumn("dbo.Animals", "animalwithpic");
            CreateIndex("dbo.Requirements", "AnimalId");
            CreateIndex("dbo.Feed_Schedule", "AnimalId");
            CreateIndex("dbo.BMIs", "AnimalId");
            AddForeignKey("dbo.Requirements", "AnimalId", "dbo.Animals", "AnimalId", cascadeDelete: true);
            AddForeignKey("dbo.Feed_Schedule", "AnimalId", "dbo.Animals", "AnimalId", cascadeDelete: true);
            AddForeignKey("dbo.BMIs", "AnimalId", "dbo.Animals", "AnimalId", cascadeDelete: true);
        }
    }
}
