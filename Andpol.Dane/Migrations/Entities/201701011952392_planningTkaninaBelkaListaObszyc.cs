namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class planningTkaninaBelkaListaObszyc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanningTkaninaBelkaListaObszyc",
                c => new
                    {
                        PlanningTkaninaBelkaListaObszycId = c.Int(nullable: false, identity: true),
                        IsDone = c.Boolean(nullable: false),
                        PlanningTkaninaBelkaRefId = c.Int(nullable: false),
                        ZamowienieKombiObszycieRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningTkaninaBelkaListaObszycId)
                .ForeignKey("dbo.PlanningTkaninaBelka", t => t.PlanningTkaninaBelkaRefId, cascadeDelete: true)
                .ForeignKey("dbo.ZamowienieKombiObszycie", t => t.ZamowienieKombiObszycieRefId, cascadeDelete: true)
                .Index(t => t.PlanningTkaninaBelkaRefId)
                .Index(t => t.ZamowienieKombiObszycieRefId);
            
            AddColumn("dbo.PlanningTkaninaBelka", "Uwagi", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlanningTkaninaBelkaListaObszyc", "ZamowienieKombiObszycieRefId", "dbo.ZamowienieKombiObszycie");
            DropForeignKey("dbo.PlanningTkaninaBelkaListaObszyc", "PlanningTkaninaBelkaRefId", "dbo.PlanningTkaninaBelka");
            DropIndex("dbo.PlanningTkaninaBelkaListaObszyc", new[] { "ZamowienieKombiObszycieRefId" });
            DropIndex("dbo.PlanningTkaninaBelkaListaObszyc", new[] { "PlanningTkaninaBelkaRefId" });
            DropColumn("dbo.PlanningTkaninaBelka", "Uwagi");
            DropTable("dbo.PlanningTkaninaBelkaListaObszyc");
        }
    }
}
