namespace Dieting_Do.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_all_the_entities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BMIs",
                c => new
                    {
                        BMIId = c.Int(nullable: false, identity: true),
                        AnimalBMI = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BMIId);
            
            CreateTable(
                "dbo.Feed_Schedule",
                c => new
                    {
                        SchedId = c.Int(nullable: false, identity: true),
                        No_Of_Meals = c.Int(nullable: false),
                        Meal_Time_Diff = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SchedId);
            
            CreateTable(
                "dbo.Requirements",
                c => new
                    {
                        ReqId = c.Int(nullable: false, identity: true),
                        Vitamin = c.Int(nullable: false),
                        Fibre = c.Int(nullable: false),
                        Protein = c.Int(nullable: false),
                        Carbs = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReqId);
            
            CreateTable(
                "dbo.Standard_Data",
                c => new
                    {
                        DataId = c.Int(nullable: false, identity: true),
                        St_AnimalBMI = c.Int(nullable: false),
                        Species = c.String(),
                        St_Protein = c.Int(nullable: false),
                        St_Carbs = c.Int(nullable: false),
                        St_Fibre = c.Int(nullable: false),
                        St_Vitamin = c.Int(nullable: false),
                        St_Fat = c.Int(nullable: false),
                        St_No_Of_Meals = c.Int(nullable: false),
                        St_Meal_Time_Diff = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DataId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Standard_Data");
            DropTable("dbo.Requirements");
            DropTable("dbo.Feed_Schedule");
            DropTable("dbo.BMIs");
        }
    }
}
