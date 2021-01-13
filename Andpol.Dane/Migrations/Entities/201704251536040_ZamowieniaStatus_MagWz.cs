namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZamowieniaStatus_MagWz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MagWzPozycjaZamowienie",
                c => new
                    {
                        MagWzPozycjaZamowienieId = c.Int(nullable: false, identity: true),
                        MagWzRefId = c.Int(nullable: false),
                        ZamowienieRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MagWzPozycjaZamowienieId)
                .ForeignKey("dbo.MagWz", t => t.MagWzRefId, cascadeDelete: true)
                .ForeignKey("dbo.Zamowienie", t => t.ZamowienieRefId, cascadeDelete: true)
                .Index(t => t.MagWzRefId)
                .Index(t => t.ZamowienieRefId);
            
            CreateTable(
                "dbo.MagWz",
                c => new
                    {
                        MagWzId = c.Int(nullable: false, identity: true),
                        BaseMagWzId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CzyKorekta = c.Boolean(nullable: false),
                        CzyZaksiegowana = c.Boolean(nullable: false),
                        DataWystawienia = c.DateTime(nullable: false),
                        KontrahentRefId = c.Int(nullable: false),
                        NumerDokumentu = c.String(),
                        NumerDokumentuZrodlowego = c.String(),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.MagWzId)
                .ForeignKey("dbo.Kontrahent", t => t.KontrahentRefId, cascadeDelete: true)
                .Index(t => t.KontrahentRefId);
            
            CreateTable(
                "dbo.MagWzPozycjaPozMag",
                c => new
                    {
                        MagWzPozycjaPozMagId = c.Int(nullable: false, identity: true),
                        Ilosc = c.Double(nullable: false),
                        MagWzRefId = c.Int(nullable: false),
                        PozycjaMagazynowaRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MagWzPozycjaPozMagId)
                .ForeignKey("dbo.MagWz", t => t.MagWzRefId, cascadeDelete: true)
                .ForeignKey("dbo.MagPozycjaMagazynowa", t => t.PozycjaMagazynowaRefId, cascadeDelete: true)
                .Index(t => t.MagWzRefId)
                .Index(t => t.PozycjaMagazynowaRefId);
            
            AddColumn("dbo.Zamowienie", "ZamowienieStatus", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MagWzPozycjaZamowienie", "ZamowienieRefId", "dbo.Zamowienie");
            DropForeignKey("dbo.MagWzPozycjaZamowienie", "MagWzRefId", "dbo.MagWz");
            DropForeignKey("dbo.MagWzPozycjaPozMag", "PozycjaMagazynowaRefId", "dbo.MagPozycjaMagazynowa");
            DropForeignKey("dbo.MagWzPozycjaPozMag", "MagWzRefId", "dbo.MagWz");
            DropForeignKey("dbo.MagWz", "KontrahentRefId", "dbo.Kontrahent");
            DropIndex("dbo.MagWzPozycjaPozMag", new[] { "PozycjaMagazynowaRefId" });
            DropIndex("dbo.MagWzPozycjaPozMag", new[] { "MagWzRefId" });
            DropIndex("dbo.MagWz", new[] { "KontrahentRefId" });
            DropIndex("dbo.MagWzPozycjaZamowienie", new[] { "ZamowienieRefId" });
            DropIndex("dbo.MagWzPozycjaZamowienie", new[] { "MagWzRefId" });
            DropColumn("dbo.Zamowienie", "ZamowienieStatus");
            DropTable("dbo.MagWzPozycjaPozMag");
            DropTable("dbo.MagWz");
            DropTable("dbo.MagWzPozycjaZamowienie");
        }
    }
}
