namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fakturaSprzedazy_korekta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinFakturaSprzedazyDodatkoweInfo",
                c => new
                    {
                        FinFakturaSprzedazyId = c.Int(nullable: false),
                        Colli = c.Int(),
                        KontrahentDealerAdresDostawyRefId = c.Int(),
                        WagaBrutto = c.Double(),
                        WagaNetto = c.Double(),
                    })
                .PrimaryKey(t => t.FinFakturaSprzedazyId)
                .ForeignKey("dbo.FinFakturaSprzedazy", t => t.FinFakturaSprzedazyId)
                .ForeignKey("dbo.KontrahentDealer", t => t.KontrahentDealerAdresDostawyRefId)
                .Index(t => t.FinFakturaSprzedazyId)
                .Index(t => t.KontrahentDealerAdresDostawyRefId);
            
            CreateTable(
                "dbo.FinFakturaSprzedazy",
                c => new
                    {
                        FinFakturaSprzedazyId = c.Int(nullable: false, identity: true),
                        BaseFakturaSprzedazyId = c.Int(),
                        CreatedBy = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CzyDodatkoweInfo = c.Boolean(nullable: false),
                        CzyKorekta = c.Boolean(nullable: false),
                        DataWystawienia = c.DateTime(nullable: false),
                        NabywcaRefId = c.Int(nullable: false),
                        NumerDokumentu = c.String(),
                        PlatnoscRefId = c.Int(nullable: false),
                        RazemBrutto = c.Double(nullable: false),
                        RazemNetto = c.Double(nullable: false),
                        RazemPodatek = c.Double(nullable: false),
                        SprzedawcaRefId = c.Int(nullable: false),
                        Uwagi = c.String(),
                        WalutaRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FinFakturaSprzedazyId)
                .ForeignKey("dbo.FinFakturaSprzedazyPlatnosc", t => t.PlatnoscRefId, cascadeDelete: true)
                .ForeignKey("dbo.FinWaluta", t => t.WalutaRefId, cascadeDelete: true)
                .ForeignKey("dbo.Kontrahent", t => t.NabywcaRefId)
                .ForeignKey("dbo.Kontrahent", t => t.SprzedawcaRefId)
                .Index(t => t.NabywcaRefId)
                .Index(t => t.PlatnoscRefId)
                .Index(t => t.SprzedawcaRefId)
                .Index(t => t.WalutaRefId);
            
            CreateTable(
                "dbo.FinFakturaSprzedazyPozycja",
                c => new
                    {
                        FinFakturaSprzedazyPozycjaId = c.Int(nullable: false, identity: true),
                        CzyKorekta = c.Boolean(nullable: false),
                        CzyPozMag = c.Boolean(nullable: false),
                        FakturaSprzedazyPozycjaOrygRef = c.Int(),
                        FakturaSprzedazyRefId = c.Int(),
                        FakturaSprzedazyZmianyRefId = c.Int(),
                        Ilosc = c.Double(nullable: false),
                        PozycjaMagazynowaRefId = c.Int(),
                        Nazwa = c.String(),
                        PodatekStawkaRefId = c.Int(nullable: false),
                        WartoscJedn = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FinFakturaSprzedazyPozycjaId)
                .ForeignKey("dbo.JednPodatekStawka", t => t.PodatekStawkaRefId, cascadeDelete: true)
                .ForeignKey("dbo.MagPozycjaMagazynowa", t => t.PozycjaMagazynowaRefId)
                .ForeignKey("dbo.FinFakturaSprzedazy", t => t.FakturaSprzedazyRefId)
                .ForeignKey("dbo.FinFakturaSprzedazy", t => t.FakturaSprzedazyZmianyRefId)
                .Index(t => t.FakturaSprzedazyRefId)
                .Index(t => t.FakturaSprzedazyZmianyRefId)
                .Index(t => t.PozycjaMagazynowaRefId)
                .Index(t => t.PodatekStawkaRefId);
            
            CreateTable(
                "dbo.FinFakturaSprzedazyPlatnosc",
                c => new
                    {
                        FinFakturaSprzedazyPlatnoscId = c.Int(nullable: false, identity: true),
                        IleDni = c.Int(),
                        Uwagi = c.String(),
                        PlatnoscRodzajRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FinFakturaSprzedazyPlatnoscId)
                .ForeignKey("dbo.JednPlatnoscRodzaj", t => t.PlatnoscRodzajRefId, cascadeDelete: true)
                .Index(t => t.PlatnoscRodzajRefId);
            
            AddColumn("dbo.Kontrahent", "KontoBankoweSwift", c => c.String(maxLength: 11));
            AddColumn("dbo.Kontrahent", "KontoBankowe2Swift", c => c.String(maxLength: 11));
            AddColumn("dbo.MagWz", "FinFakturaSprzedazyRefId", c => c.Int());
            CreateIndex("dbo.MagWz", "FinFakturaSprzedazyRefId");
            AddForeignKey("dbo.MagWz", "FinFakturaSprzedazyRefId", "dbo.FinFakturaSprzedazy", "FinFakturaSprzedazyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinFakturaSprzedazyDodatkoweInfo", "KontrahentDealerAdresDostawyRefId", "dbo.KontrahentDealer");
            DropForeignKey("dbo.FinFakturaSprzedazy", "SprzedawcaRefId", "dbo.Kontrahent");
            DropForeignKey("dbo.FinFakturaSprzedazy", "NabywcaRefId", "dbo.Kontrahent");
            DropForeignKey("dbo.FinFakturaSprzedazy", "WalutaRefId", "dbo.FinWaluta");
            DropForeignKey("dbo.FinFakturaSprzedazyPlatnosc", "PlatnoscRodzajRefId", "dbo.JednPlatnoscRodzaj");
            DropForeignKey("dbo.FinFakturaSprzedazy", "PlatnoscRefId", "dbo.FinFakturaSprzedazyPlatnosc");
            DropForeignKey("dbo.MagWz", "FinFakturaSprzedazyRefId", "dbo.FinFakturaSprzedazy");
            DropForeignKey("dbo.FinFakturaSprzedazyPozycja", "FakturaSprzedazyZmianyRefId", "dbo.FinFakturaSprzedazy");
            DropForeignKey("dbo.FinFakturaSprzedazyPozycja", "FakturaSprzedazyRefId", "dbo.FinFakturaSprzedazy");
            DropForeignKey("dbo.FinFakturaSprzedazyPozycja", "PozycjaMagazynowaRefId", "dbo.MagPozycjaMagazynowa");
            DropForeignKey("dbo.FinFakturaSprzedazyPozycja", "PodatekStawkaRefId", "dbo.JednPodatekStawka");
            DropForeignKey("dbo.FinFakturaSprzedazyDodatkoweInfo", "FinFakturaSprzedazyId", "dbo.FinFakturaSprzedazy");
            DropIndex("dbo.FinFakturaSprzedazyPlatnosc", new[] { "PlatnoscRodzajRefId" });
            DropIndex("dbo.MagWz", new[] { "FinFakturaSprzedazyRefId" });
            DropIndex("dbo.FinFakturaSprzedazyPozycja", new[] { "PodatekStawkaRefId" });
            DropIndex("dbo.FinFakturaSprzedazyPozycja", new[] { "PozycjaMagazynowaRefId" });
            DropIndex("dbo.FinFakturaSprzedazyPozycja", new[] { "FakturaSprzedazyZmianyRefId" });
            DropIndex("dbo.FinFakturaSprzedazyPozycja", new[] { "FakturaSprzedazyRefId" });
            DropIndex("dbo.FinFakturaSprzedazy", new[] { "WalutaRefId" });
            DropIndex("dbo.FinFakturaSprzedazy", new[] { "SprzedawcaRefId" });
            DropIndex("dbo.FinFakturaSprzedazy", new[] { "PlatnoscRefId" });
            DropIndex("dbo.FinFakturaSprzedazy", new[] { "NabywcaRefId" });
            DropIndex("dbo.FinFakturaSprzedazyDodatkoweInfo", new[] { "KontrahentDealerAdresDostawyRefId" });
            DropIndex("dbo.FinFakturaSprzedazyDodatkoweInfo", new[] { "FinFakturaSprzedazyId" });
            DropColumn("dbo.MagWz", "FinFakturaSprzedazyRefId");
            DropColumn("dbo.Kontrahent", "KontoBankowe2Swift");
            DropColumn("dbo.Kontrahent", "KontoBankoweSwift");
            DropTable("dbo.FinFakturaSprzedazyPlatnosc");
            DropTable("dbo.FinFakturaSprzedazyPozycja");
            DropTable("dbo.FinFakturaSprzedazy");
            DropTable("dbo.FinFakturaSprzedazyDodatkoweInfo");
        }
    }
}
