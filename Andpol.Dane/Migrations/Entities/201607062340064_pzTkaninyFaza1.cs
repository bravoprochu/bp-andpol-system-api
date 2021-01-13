namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pzTkaninyFaza1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GotowyKupionyWartosc", "GotowyKupionyRefId", "dbo.GotowyKupiony");
            DropForeignKey("dbo.GotowyKupionyWartosc", "KombinacjaRefId", "dbo.Kombinacja");
            DropIndex("dbo.GotowyKupionyWartosc", new[] { "GotowyKupionyRefId" });
            DropIndex("dbo.GotowyKupionyWartosc", new[] { "KombinacjaRefId" });
            CreateTable(
                "dbo.FinFakturaPozycjeTkaniny",
                c => new
                    {
                        FinFakturaPozycjeTkaninyId = c.Int(nullable: false, identity: true),
                        Cena = c.Double(nullable: false),
                        FakturaZakupuRefId = c.Int(nullable: false),
                        Ilosc = c.Double(nullable: false),
                        VatZakupuRefId = c.Int(nullable: false),
                        Wartosc = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FinFakturaPozycjeTkaninyId)
                .ForeignKey("dbo.FinFakturaZakupu", t => t.FakturaZakupuRefId, cascadeDelete: true)
                .ForeignKey("dbo.JednPodatekStawka", t => t.VatZakupuRefId, cascadeDelete: true)
                .Index(t => t.FakturaZakupuRefId)
                .Index(t => t.VatZakupuRefId);
            
            CreateTable(
                "dbo.MaterialBelkaPzTkaniny",
                c => new
                    {
                        MaterialBelkaPzTkaninyId = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CzyZaksiegowana = c.Boolean(nullable: false),
                        CzyPowierzona = c.Boolean(nullable: false),
                        DataWystawienia = c.DateTime(nullable: false),
                        DokumentZrodlowyNr = c.String(),
                        FakturaZakupuRefId = c.Int(),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.MaterialBelkaPzTkaninyId)
                .ForeignKey("dbo.FinFakturaZakupu", t => t.FakturaZakupuRefId)
                .Index(t => t.FakturaZakupuRefId);
            
            CreateTable(
                "dbo.FinWaluta",
                c => new
                    {
                        FinWalutaId = c.Int(nullable: false, identity: true),
                        Skrot = c.String(maxLength: 3),
                        Nazwa = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.FinWalutaId);
            
            AddColumn("dbo.ChangeLog", "Wersja", c => c.String());
            AddColumn("dbo.FinFakturaPozycje", "VatZakupuRefId", c => c.Int(nullable: false));
            AddColumn("dbo.FinFakturaZakupu", "WalutaRefId", c => c.Int(nullable: false));
            AddColumn("dbo.MaterialBelka", "CzyAktywna", c => c.Boolean(nullable: false));
            AddColumn("dbo.MaterialBelka", "CzyPotwierdzona", c => c.Boolean(nullable: false));
            AddColumn("dbo.MaterialBelka", "CzyPowierzona", c => c.Boolean(nullable: false));
            AddColumn("dbo.MaterialBelka", "DokumentZrodlowyNr", c => c.String());
            AddColumn("dbo.MaterialBelka", "MaterialBelkaPzTkaninyRefId", c => c.Int());
            AddColumn("dbo.FinPlatnoscPrzypomnienie", "WalutaRefId", c => c.Int(nullable: false));
            CreateIndex("dbo.MaterialBelka", "MaterialBelkaPzTkaninyRefId");
            AddForeignKey("dbo.MaterialBelka", "MaterialBelkaPzTkaninyRefId", "dbo.MaterialBelkaPzTkaniny", "MaterialBelkaPzTkaninyId");
            DropColumn("dbo.MaterialBelka", "Dostepny");
            DropTable("dbo.GotowyKupiony");
            DropTable("dbo.GotowyKupionyWartosc");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GotowyKupionyWartosc",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wartosc = c.Int(nullable: false),
                        GotowyKupionyRefId = c.Int(nullable: false),
                        KombinacjaRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GotowyKupiony",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MaterialBelka", "Dostepny", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.MaterialBelka", "MaterialBelkaPzTkaninyRefId", "dbo.MaterialBelkaPzTkaniny");
            DropForeignKey("dbo.MaterialBelkaPzTkaniny", "FakturaZakupuRefId", "dbo.FinFakturaZakupu");
            DropForeignKey("dbo.FinFakturaPozycjeTkaniny", "VatZakupuRefId", "dbo.JednPodatekStawka");
            DropForeignKey("dbo.FinFakturaPozycjeTkaniny", "FakturaZakupuRefId", "dbo.FinFakturaZakupu");
            DropIndex("dbo.MaterialBelkaPzTkaniny", new[] { "FakturaZakupuRefId" });
            DropIndex("dbo.MaterialBelka", new[] { "MaterialBelkaPzTkaninyRefId" });
            DropIndex("dbo.FinFakturaPozycjeTkaniny", new[] { "VatZakupuRefId" });
            DropIndex("dbo.FinFakturaPozycjeTkaniny", new[] { "FakturaZakupuRefId" });
            DropColumn("dbo.FinPlatnoscPrzypomnienie", "WalutaRefId");
            DropColumn("dbo.MaterialBelka", "MaterialBelkaPzTkaninyRefId");
            DropColumn("dbo.MaterialBelka", "DokumentZrodlowyNr");
            DropColumn("dbo.MaterialBelka", "CzyPowierzona");
            DropColumn("dbo.MaterialBelka", "CzyPotwierdzona");
            DropColumn("dbo.MaterialBelka", "CzyAktywna");
            DropColumn("dbo.FinFakturaZakupu", "WalutaRefId");
            DropColumn("dbo.FinFakturaPozycje", "VatZakupuRefId");
            DropColumn("dbo.ChangeLog", "Wersja");
            DropTable("dbo.FinWaluta");
            DropTable("dbo.MaterialBelkaPzTkaniny");
            DropTable("dbo.FinFakturaPozycjeTkaniny");
            CreateIndex("dbo.GotowyKupionyWartosc", "KombinacjaRefId");
            CreateIndex("dbo.GotowyKupionyWartosc", "GotowyKupionyRefId");
            AddForeignKey("dbo.GotowyKupionyWartosc", "KombinacjaRefId", "dbo.Kombinacja", "KombinacjaId", cascadeDelete: true);
            AddForeignKey("dbo.GotowyKupionyWartosc", "GotowyKupionyRefId", "dbo.GotowyKupiony", "Id", cascadeDelete: true);
        }
    }
}
