namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class planningNowyProdukcjaDzialExtProdukcjaBrygadzista : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanningDzienRoboczyZamowienieKombi",
                c => new
                    {
                        PlanningDzienRoboczyZamowienieKombiId = c.Int(nullable: false, identity: true),
                        IsDone = c.Boolean(nullable: false),
                        BrygadzistaNazwa = c.String(),
                        PlanningDzienRoboczyRefId = c.Int(nullable: false),
                        ZamowienieKombiRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningDzienRoboczyZamowienieKombiId)
                .ForeignKey("dbo.PlanningDzienRoboczy", t => t.PlanningDzienRoboczyRefId, cascadeDelete: true)
                .ForeignKey("dbo.ZamowienieKombi", t => t.ZamowienieKombiRefId, cascadeDelete: true)
                .Index(t => t.PlanningDzienRoboczyRefId)
                .Index(t => t.ZamowienieKombiRefId);
            
            CreateTable(
                "dbo.PlanningDzienRoboczy",
                c => new
                    {
                        PlanningDzienRoboczyId = c.Int(nullable: false, identity: true),
                        PlanningRefId = c.Int(nullable: false),
                        KalendarzDniRoboczychDzialProdRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningDzienRoboczyId)
                .ForeignKey("dbo.KalendarzDniRoboczychDzialProd", t => t.KalendarzDniRoboczychDzialProdRefId, cascadeDelete: true)
                .ForeignKey("dbo.Planning", t => t.PlanningRefId, cascadeDelete: true)
                .Index(t => t.PlanningRefId)
                .Index(t => t.KalendarzDniRoboczychDzialProdRefId);
            
            CreateTable(
                "dbo.ProdukcjaBrygadzista",
                c => new
                    {
                        ProdukcjaBrygadzistaId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        ProdukcjaDzialRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdukcjaBrygadzistaId)
                .ForeignKey("dbo.ProdukcjaDzial", t => t.ProdukcjaDzialRefId, cascadeDelete: true)
                .Index(t => t.ProdukcjaDzialRefId);
            
            CreateTable(
                "dbo.Planning",
                c => new
                    {
                        PlanningId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PlanningId);
            
            CreateTable(
                "dbo.PlanningPozycjaMagazynowa",
                c => new
                    {
                        PlanningPozycjaMagazynowaId = c.Int(nullable: false, identity: true),
                        CzyWydane = c.Boolean(nullable: false),
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
                "dbo.PlanningTkaninaBelka",
                c => new
                    {
                        PlanningTkaninaBelkaId = c.Int(nullable: false, identity: true),
                        CzyWydane = c.Boolean(nullable: false),
                        MaterialBelkaRefId = c.Int(nullable: false),
                        PlanningRefId = c.Int(nullable: false),
                        Wartosc = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PlanningTkaninaBelkaId)
                .ForeignKey("dbo.MaterialBelka", t => t.MaterialBelkaRefId, cascadeDelete: true)
                .ForeignKey("dbo.Planning", t => t.PlanningRefId, cascadeDelete: true)
                .Index(t => t.MaterialBelkaRefId)
                .Index(t => t.PlanningRefId);
            
            AddColumn("dbo.KalendarzDniRoboczychDzialProd", "CzyKalendarzDniRoboczychZakresAktywny", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProdukcjaDzial", "CzyTkaninaBelka", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProdukcjaDzial", "CzyPozycjaMagazynowa", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProdukcjaDzial", "NadrzedneIds", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlanningDzienRoboczyZamowienieKombi", "ZamowienieKombiRefId", "dbo.ZamowienieKombi");
            DropForeignKey("dbo.PlanningDzienRoboczyZamowienieKombi", "PlanningDzienRoboczyRefId", "dbo.PlanningDzienRoboczy");
            DropForeignKey("dbo.PlanningTkaninaBelka", "PlanningRefId", "dbo.Planning");
            DropForeignKey("dbo.PlanningTkaninaBelka", "MaterialBelkaRefId", "dbo.MaterialBelka");
            DropForeignKey("dbo.PlanningPozycjaMagazynowa", "PozycjaMagazynowaRefId", "dbo.MagPozycjaMagazynowa");
            DropForeignKey("dbo.PlanningPozycjaMagazynowa", "PlanningRefId", "dbo.Planning");
            DropForeignKey("dbo.PlanningDzienRoboczy", "PlanningRefId", "dbo.Planning");
            DropForeignKey("dbo.PlanningDzienRoboczy", "KalendarzDniRoboczychDzialProdRefId", "dbo.KalendarzDniRoboczychDzialProd");
            DropForeignKey("dbo.ProdukcjaBrygadzista", "ProdukcjaDzialRefId", "dbo.ProdukcjaDzial");
            DropIndex("dbo.PlanningTkaninaBelka", new[] { "PlanningRefId" });
            DropIndex("dbo.PlanningTkaninaBelka", new[] { "MaterialBelkaRefId" });
            DropIndex("dbo.PlanningPozycjaMagazynowa", new[] { "PozycjaMagazynowaRefId" });
            DropIndex("dbo.PlanningPozycjaMagazynowa", new[] { "PlanningRefId" });
            DropIndex("dbo.ProdukcjaBrygadzista", new[] { "ProdukcjaDzialRefId" });
            DropIndex("dbo.PlanningDzienRoboczy", new[] { "KalendarzDniRoboczychDzialProdRefId" });
            DropIndex("dbo.PlanningDzienRoboczy", new[] { "PlanningRefId" });
            DropIndex("dbo.PlanningDzienRoboczyZamowienieKombi", new[] { "ZamowienieKombiRefId" });
            DropIndex("dbo.PlanningDzienRoboczyZamowienieKombi", new[] { "PlanningDzienRoboczyRefId" });
            DropColumn("dbo.ProdukcjaDzial", "NadrzedneIds");
            DropColumn("dbo.ProdukcjaDzial", "CzyPozycjaMagazynowa");
            DropColumn("dbo.ProdukcjaDzial", "CzyTkaninaBelka");
            DropColumn("dbo.KalendarzDniRoboczychDzialProd", "CzyKalendarzDniRoboczychZakresAktywny");
            DropTable("dbo.PlanningTkaninaBelka");
            DropTable("dbo.PlanningPozycjaMagazynowa");
            DropTable("dbo.Planning");
            DropTable("dbo.ProdukcjaBrygadzista");
            DropTable("dbo.PlanningDzienRoboczy");
            DropTable("dbo.PlanningDzienRoboczyZamowienieKombi");
        }
    }
}
