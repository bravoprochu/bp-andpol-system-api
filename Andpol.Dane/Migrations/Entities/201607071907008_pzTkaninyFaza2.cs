namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pzTkaninyFaza2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinFakturaPozycjeTkaniny", "MaterialRefId", c => c.Int(nullable: false));
            CreateIndex("dbo.FinFakturaPozycje", "VatZakupuRefId");
            CreateIndex("dbo.FinFakturaZakupu", "WalutaRefId");
            CreateIndex("dbo.FinFakturaPozycjeTkaniny", "MaterialRefId");
            CreateIndex("dbo.FinPlatnoscPrzypomnienie", "WalutaRefId");
            AddForeignKey("dbo.FinFakturaPozycje", "VatZakupuRefId", "dbo.JednPodatekStawka", "JednPodatekStawkaId", cascadeDelete: true);
            AddForeignKey("dbo.FinFakturaPozycjeTkaniny", "MaterialRefId", "dbo.Material", "MaterialId", cascadeDelete: true);
            AddForeignKey("dbo.FinFakturaZakupu", "WalutaRefId", "dbo.FinWaluta", "FinWalutaId", cascadeDelete: true);
            AddForeignKey("dbo.FinPlatnoscPrzypomnienie", "WalutaRefId", "dbo.FinWaluta", "FinWalutaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinPlatnoscPrzypomnienie", "WalutaRefId", "dbo.FinWaluta");
            DropForeignKey("dbo.FinFakturaZakupu", "WalutaRefId", "dbo.FinWaluta");
            DropForeignKey("dbo.FinFakturaPozycjeTkaniny", "MaterialRefId", "dbo.Material");
            DropForeignKey("dbo.FinFakturaPozycje", "VatZakupuRefId", "dbo.JednPodatekStawka");
            DropIndex("dbo.FinPlatnoscPrzypomnienie", new[] { "WalutaRefId" });
            DropIndex("dbo.FinFakturaPozycjeTkaniny", new[] { "MaterialRefId" });
            DropIndex("dbo.FinFakturaZakupu", new[] { "WalutaRefId" });
            DropIndex("dbo.FinFakturaPozycje", new[] { "VatZakupuRefId" });
            DropColumn("dbo.FinFakturaPozycjeTkaniny", "MaterialRefId");
        }
    }
}
