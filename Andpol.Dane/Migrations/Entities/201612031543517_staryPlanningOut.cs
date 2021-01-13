namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staryPlanningOut : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ZamowienieKombiObszycie", "PlanningMaterialBelkaRefId", "dbo.PlanningMaterialBelka");
            DropForeignKey("dbo.PlanningMaterial", "MaterialRefId", "dbo.Material");
            DropForeignKey("dbo.PlanningMaterial", "PlanningRefId", "dbo.Planning");
            DropForeignKey("dbo.PlanningMaterialBelka", "PlanningMaterialRefId", "dbo.PlanningMaterial");
            DropForeignKey("dbo.PlanningPozycjaMagazynowa", "PlanningRefId", "dbo.Planning");
            DropForeignKey("dbo.PlanningPozycjaMagazynowa", "PozycjaMagazynowaRefId", "dbo.MagPozycjaMagazynowa");
            DropForeignKey("dbo.PlanningProdukcjaDzial", "PlanningRefId", "dbo.Planning");
            DropForeignKey("dbo.PlanningProdukcjaDzialRezerwacjaCzasu", "PlanningProdukcjaDzialRefId", "dbo.PlanningProdukcjaDzial");
            DropForeignKey("dbo.PlanningProdukcjaDzial", "ProdukcjaDzialRefId", "dbo.ProdukcjaDzial");
            DropForeignKey("dbo.MaterialBelkaRozchodObszycie", "PlanningRefId", "dbo.Planning");
            DropForeignKey("dbo.PlanningMaterialBelka", "MaterialBelkaRefId", "dbo.MaterialBelka");
            DropIndex("dbo.ZamowienieKombiObszycie", new[] { "PlanningMaterialBelkaRefId" });
            DropIndex("dbo.PlanningMaterialBelka", new[] { "MaterialBelkaRefId" });
            DropIndex("dbo.PlanningMaterialBelka", new[] { "PlanningMaterialRefId" });
            DropIndex("dbo.MaterialBelkaRozchodObszycie", new[] { "PlanningRefId" });
            DropIndex("dbo.PlanningMaterial", new[] { "MaterialRefId" });
            DropIndex("dbo.PlanningMaterial", new[] { "PlanningRefId" });
            DropIndex("dbo.PlanningPozycjaMagazynowa", new[] { "PlanningRefId" });
            DropIndex("dbo.PlanningPozycjaMagazynowa", new[] { "PozycjaMagazynowaRefId" });
            DropIndex("dbo.PlanningProdukcjaDzial", new[] { "PlanningRefId" });
            DropIndex("dbo.PlanningProdukcjaDzial", new[] { "ProdukcjaDzialRefId" });
            DropIndex("dbo.PlanningProdukcjaDzialRezerwacjaCzasu", new[] { "PlanningProdukcjaDzialRefId" });
            DropColumn("dbo.ZamowienieKombiObszycie", "PlanningMaterialBelkaRefId");
            DropColumn("dbo.MaterialBelkaRozchodObszycie", "PlanningRefId");
            DropTable("dbo.PlanningMaterialBelka");
            DropTable("dbo.Planning");
            DropTable("dbo.PlanningMaterial");
            DropTable("dbo.PlanningPozycjaMagazynowa");
            DropTable("dbo.PlanningProdukcjaDzial");
            DropTable("dbo.PlanningProdukcjaDzialRezerwacjaCzasu");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlanningProdukcjaDzialRezerwacjaCzasu",
                c => new
                    {
                        PlanningProdukcjaDzialRezerwacjaCzasuId = c.Int(nullable: false, identity: true),
                        PlanningProdukcjaDzialRefId = c.Int(nullable: false),
                        PlanningEnd = c.DateTime(nullable: false),
                        PlanningStart = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningProdukcjaDzialRezerwacjaCzasuId);
            
            CreateTable(
                "dbo.PlanningProdukcjaDzial",
                c => new
                    {
                        PlanningProdukcjaDzialId = c.Int(nullable: false, identity: true),
                        PlanningRefId = c.Int(nullable: false),
                        ProdukcjaDzialRefId = c.Int(nullable: false),
                        RobociznaRazem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningProdukcjaDzialId);
            
            CreateTable(
                "dbo.PlanningPozycjaMagazynowa",
                c => new
                    {
                        PlanningPozycjaMagazynowaId = c.Int(nullable: false, identity: true),
                        PlanningRefId = c.Int(nullable: false),
                        PozycjaMagazynowaRefId = c.Int(nullable: false),
                        Wartosc = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningPozycjaMagazynowaId);
            
            CreateTable(
                "dbo.PlanningMaterial",
                c => new
                    {
                        PlanningMaterialId = c.Int(nullable: false, identity: true),
                        MaterialRefId = c.Int(nullable: false),
                        PlanningRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningMaterialId);
            
            CreateTable(
                "dbo.Planning",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdukcjaStart = c.DateTime(nullable: false),
                        ProdukcjaEnd = c.DateTime(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlanningMaterialBelka",
                c => new
                    {
                        PlanningMaterialBelkaId = c.Int(nullable: false, identity: true),
                        MaterialBelkaRefId = c.Int(nullable: false),
                        PlanningMaterialRefId = c.Int(nullable: false),
                        ZuzycieWartosc = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningMaterialBelkaId);
            
            AddColumn("dbo.MaterialBelkaRozchodObszycie", "PlanningRefId", c => c.Int(nullable: false));
            AddColumn("dbo.ZamowienieKombiObszycie", "PlanningMaterialBelkaRefId", c => c.Int());
            CreateIndex("dbo.PlanningProdukcjaDzialRezerwacjaCzasu", "PlanningProdukcjaDzialRefId");
            CreateIndex("dbo.PlanningProdukcjaDzial", "ProdukcjaDzialRefId");
            CreateIndex("dbo.PlanningProdukcjaDzial", "PlanningRefId");
            CreateIndex("dbo.PlanningPozycjaMagazynowa", "PozycjaMagazynowaRefId");
            CreateIndex("dbo.PlanningPozycjaMagazynowa", "PlanningRefId");
            CreateIndex("dbo.PlanningMaterial", "PlanningRefId");
            CreateIndex("dbo.PlanningMaterial", "MaterialRefId");
            CreateIndex("dbo.MaterialBelkaRozchodObszycie", "PlanningRefId");
            CreateIndex("dbo.PlanningMaterialBelka", "PlanningMaterialRefId");
            CreateIndex("dbo.PlanningMaterialBelka", "MaterialBelkaRefId");
            CreateIndex("dbo.ZamowienieKombiObszycie", "PlanningMaterialBelkaRefId");
            AddForeignKey("dbo.PlanningMaterialBelka", "MaterialBelkaRefId", "dbo.MaterialBelka", "MaterialBelkaId", cascadeDelete: true);
            AddForeignKey("dbo.MaterialBelkaRozchodObszycie", "PlanningRefId", "dbo.Planning", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlanningProdukcjaDzial", "ProdukcjaDzialRefId", "dbo.ProdukcjaDzial", "ProdukcjaDzialId", cascadeDelete: true);
            AddForeignKey("dbo.PlanningProdukcjaDzialRezerwacjaCzasu", "PlanningProdukcjaDzialRefId", "dbo.PlanningProdukcjaDzial", "PlanningProdukcjaDzialId", cascadeDelete: true);
            AddForeignKey("dbo.PlanningProdukcjaDzial", "PlanningRefId", "dbo.Planning", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlanningPozycjaMagazynowa", "PozycjaMagazynowaRefId", "dbo.MagPozycjaMagazynowa", "MagPozycjaMagazynowaId", cascadeDelete: true);
            AddForeignKey("dbo.PlanningPozycjaMagazynowa", "PlanningRefId", "dbo.Planning", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlanningMaterialBelka", "PlanningMaterialRefId", "dbo.PlanningMaterial", "PlanningMaterialId", cascadeDelete: true);
            AddForeignKey("dbo.PlanningMaterial", "PlanningRefId", "dbo.Planning", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlanningMaterial", "MaterialRefId", "dbo.Material", "MaterialId", cascadeDelete: true);
            AddForeignKey("dbo.ZamowienieKombiObszycie", "PlanningMaterialBelkaRefId", "dbo.PlanningMaterialBelka", "PlanningMaterialBelkaId");
        }
    }
}
