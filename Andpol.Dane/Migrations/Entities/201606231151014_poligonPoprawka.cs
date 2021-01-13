namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poligonPoprawka : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KombinacjaRobocizna", "RobociznaRefId", "dbo.Robocizna");
            DropIndex("dbo.KombinacjaRobocizna", new[] { "RobociznaRefId" });
            CreateTable(
                "dbo.PlanningMaterial",
                c => new
                    {
                        PlanningMaterialId = c.Int(nullable: false, identity: true),
                        MaterialRefId = c.Int(nullable: false),
                        PlanningRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningMaterialId)
                .ForeignKey("dbo.Material", t => t.MaterialRefId, cascadeDelete: true)
                .ForeignKey("dbo.Planning", t => t.PlanningRefId, cascadeDelete: true)
                .Index(t => t.MaterialRefId)
                .Index(t => t.PlanningRefId);
            
            CreateTable(
                "dbo.PlanningMaterialBelka",
                c => new
                    {
                        PlanningMaterialBelkaId = c.Int(nullable: false, identity: true),
                        MaterialBelkaRefId = c.Int(nullable: false),
                        PlanningMaterialRefId = c.Int(nullable: false),
                        ZuzycieWartosc = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningMaterialBelkaId)
                .ForeignKey("dbo.MaterialBelka", t => t.MaterialBelkaRefId, cascadeDelete: true)
                .ForeignKey("dbo.PlanningMaterial", t => t.PlanningMaterialRefId, cascadeDelete: true)
                .Index(t => t.MaterialBelkaRefId)
                .Index(t => t.PlanningMaterialRefId);
            
            CreateTable(
                "dbo.PlanningPozycjaMagazynowa",
                c => new
                    {
                        PlanningPozycjaMagazynowaId = c.Int(nullable: false, identity: true),
                        PlanningRefId = c.Int(nullable: false),
                        PozycjaMagazynowaRefId = c.Int(nullable: false),
                        Wartosc = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningPozycjaMagazynowaId)
                .ForeignKey("dbo.Planning", t => t.PlanningRefId, cascadeDelete: true)
                .ForeignKey("dbo.MagPozycjaMagazynowa", t => t.PozycjaMagazynowaRefId, cascadeDelete: true)
                .Index(t => t.PlanningRefId)
                .Index(t => t.PozycjaMagazynowaRefId);
            
            CreateTable(
                "dbo.PlanningProdukcjaDzial",
                c => new
                    {
                        PlanningProdukcjaDzialId = c.Int(nullable: false, identity: true),
                        PlanningRefId = c.Int(nullable: false),
                        ProdukcjaDzialRefId = c.Int(nullable: false),
                        RobociznaRazem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningProdukcjaDzialId)
                .ForeignKey("dbo.Planning", t => t.PlanningRefId, cascadeDelete: true)
                .ForeignKey("dbo.ProdukcjaDzial", t => t.ProdukcjaDzialRefId, cascadeDelete: true)
                .Index(t => t.PlanningRefId)
                .Index(t => t.ProdukcjaDzialRefId);
            
            CreateTable(
                "dbo.PlanningProdukcjaDzialRezerwacjaCzasu",
                c => new
                    {
                        PlanningProdukcjaDzialRezerwacjaCzasuId = c.Int(nullable: false, identity: true),
                        PlanningProdukcjaDzialRefId = c.Int(nullable: false),
                        PlanningEnd = c.DateTime(nullable: false),
                        PlanningStart = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningProdukcjaDzialRezerwacjaCzasuId)
                .ForeignKey("dbo.PlanningProdukcjaDzial", t => t.PlanningProdukcjaDzialRefId, cascadeDelete: true)
                .Index(t => t.PlanningProdukcjaDzialRefId);
            
            CreateTable(
                "dbo.ProdukcjaDzial",
                c => new
                    {
                        ProdukcjaDzialId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        PoziomProdukcji = c.Int(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.ProdukcjaDzialId);
            
            AddColumn("dbo.Planning", "ProdukcjaStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Planning", "ProdukcjaEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Planning", "Uwagi", c => c.String());
            AddColumn("dbo.MaterialBelka", "StanRzeczywisty", c => c.Double(nullable: false));
            AddColumn("dbo.ZamowienieKombiObszycie", "PlanningMaterialBelkaRefId", c => c.Int());
            AddColumn("dbo.KombinacjaRobocizna", "ProdukcjaDzialRefId", c => c.Int(nullable: false));
            AddColumn("dbo.Robocizna", "ProdukcjaDzialRefId", c => c.Int(nullable: false));
            CreateIndex("dbo.ZamowienieKombiObszycie", "PlanningMaterialBelkaRefId");
            CreateIndex("dbo.Robocizna", "ProdukcjaDzialRefId");
            CreateIndex("dbo.KombinacjaRobocizna", "ProdukcjaDzialRefId");
            AddForeignKey("dbo.ZamowienieKombiObszycie", "PlanningMaterialBelkaRefId", "dbo.PlanningMaterialBelka", "PlanningMaterialBelkaId");
            AddForeignKey("dbo.Robocizna", "ProdukcjaDzialRefId", "dbo.ProdukcjaDzial", "ProdukcjaDzialId", cascadeDelete: true);
            AddForeignKey("dbo.KombinacjaRobocizna", "ProdukcjaDzialRefId", "dbo.ProdukcjaDzial", "ProdukcjaDzialId", cascadeDelete: true);
            DropColumn("dbo.Planning", "DataRealizacji");
            DropColumn("dbo.KombinacjaRobocizna", "RobociznaRefId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KombinacjaRobocizna", "RobociznaRefId", c => c.Int(nullable: false));
            AddColumn("dbo.Planning", "DataRealizacji", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.KombinacjaRobocizna", "ProdukcjaDzialRefId", "dbo.ProdukcjaDzial");
            DropForeignKey("dbo.PlanningProdukcjaDzial", "ProdukcjaDzialRefId", "dbo.ProdukcjaDzial");
            DropForeignKey("dbo.Robocizna", "ProdukcjaDzialRefId", "dbo.ProdukcjaDzial");
            DropForeignKey("dbo.PlanningProdukcjaDzialRezerwacjaCzasu", "PlanningProdukcjaDzialRefId", "dbo.PlanningProdukcjaDzial");
            DropForeignKey("dbo.PlanningProdukcjaDzial", "PlanningRefId", "dbo.Planning");
            DropForeignKey("dbo.PlanningPozycjaMagazynowa", "PozycjaMagazynowaRefId", "dbo.MagPozycjaMagazynowa");
            DropForeignKey("dbo.PlanningPozycjaMagazynowa", "PlanningRefId", "dbo.Planning");
            DropForeignKey("dbo.PlanningMaterial", "PlanningRefId", "dbo.Planning");
            DropForeignKey("dbo.PlanningMaterial", "MaterialRefId", "dbo.Material");
            DropForeignKey("dbo.PlanningMaterialBelka", "PlanningMaterialRefId", "dbo.PlanningMaterial");
            DropForeignKey("dbo.PlanningMaterialBelka", "MaterialBelkaRefId", "dbo.MaterialBelka");
            DropForeignKey("dbo.ZamowienieKombiObszycie", "PlanningMaterialBelkaRefId", "dbo.PlanningMaterialBelka");
            DropIndex("dbo.KombinacjaRobocizna", new[] { "ProdukcjaDzialRefId" });
            DropIndex("dbo.Robocizna", new[] { "ProdukcjaDzialRefId" });
            DropIndex("dbo.PlanningProdukcjaDzialRezerwacjaCzasu", new[] { "PlanningProdukcjaDzialRefId" });
            DropIndex("dbo.PlanningProdukcjaDzial", new[] { "ProdukcjaDzialRefId" });
            DropIndex("dbo.PlanningProdukcjaDzial", new[] { "PlanningRefId" });
            DropIndex("dbo.PlanningPozycjaMagazynowa", new[] { "PozycjaMagazynowaRefId" });
            DropIndex("dbo.PlanningPozycjaMagazynowa", new[] { "PlanningRefId" });
            DropIndex("dbo.PlanningMaterialBelka", new[] { "PlanningMaterialRefId" });
            DropIndex("dbo.PlanningMaterialBelka", new[] { "MaterialBelkaRefId" });
            DropIndex("dbo.ZamowienieKombiObszycie", new[] { "PlanningMaterialBelkaRefId" });
            DropIndex("dbo.PlanningMaterial", new[] { "PlanningRefId" });
            DropIndex("dbo.PlanningMaterial", new[] { "MaterialRefId" });
            DropColumn("dbo.Robocizna", "ProdukcjaDzialRefId");
            DropColumn("dbo.KombinacjaRobocizna", "ProdukcjaDzialRefId");
            DropColumn("dbo.ZamowienieKombiObszycie", "PlanningMaterialBelkaRefId");
            DropColumn("dbo.MaterialBelka", "StanRzeczywisty");
            DropColumn("dbo.Planning", "Uwagi");
            DropColumn("dbo.Planning", "ProdukcjaEnd");
            DropColumn("dbo.Planning", "ProdukcjaStart");
            DropTable("dbo.ProdukcjaDzial");
            DropTable("dbo.PlanningProdukcjaDzialRezerwacjaCzasu");
            DropTable("dbo.PlanningProdukcjaDzial");
            DropTable("dbo.PlanningPozycjaMagazynowa");
            DropTable("dbo.PlanningMaterialBelka");
            DropTable("dbo.PlanningMaterial");
            CreateIndex("dbo.KombinacjaRobocizna", "RobociznaRefId");
            AddForeignKey("dbo.KombinacjaRobocizna", "RobociznaRefId", "dbo.Robocizna", "Id", cascadeDelete: true);
        }
    }
}
