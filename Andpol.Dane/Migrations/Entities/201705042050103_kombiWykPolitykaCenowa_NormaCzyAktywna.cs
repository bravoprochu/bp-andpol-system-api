namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kombiWykPolitykaCenowa_NormaCzyAktywna : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wykonczenie", "PolitykaCenowaRefId", "dbo.FinPolitykaCenowa");
            DropForeignKey("dbo.FinPolitykaCenowaRegula", "PolitykaCenowa_FinPolitykaCenowaId", "dbo.FinPolitykaCenowa");
            DropIndex("dbo.FinPolitykaCenowaRegula", new[] { "PolitykaCenowa_FinPolitykaCenowaId" });
            DropIndex("dbo.Wykonczenie", new[] { "PolitykaCenowaRefId" });
            DropColumn("dbo.FinPolitykaCenowaRegula", "PolitykaCenowaRefId");
            RenameColumn(table: "dbo.FinPolitykaCenowaRegula", name: "PolitykaCenowa_FinPolitykaCenowaId", newName: "PolitykaCenowaRefId");
            AddColumn("dbo.Norma", "CzyAktywna", c => c.Boolean(nullable: false));
            AddColumn("dbo.KombinacjaWykonczenie", "CzyPolitykaCenowa", c => c.Boolean(nullable: false));
            AddColumn("dbo.KombinacjaWykonczenie", "Ilosc", c => c.Byte(nullable: false));
            AddColumn("dbo.KombinacjaWykonczenie", "PolitykaCenowaRefId", c => c.Int());
            AlterColumn("dbo.FinPolitykaCenowaRegula", "PolitykaCenowaRefId", c => c.Int(nullable: false));
            AlterColumn("dbo.Norma", "Nazwa", c => c.String());
            CreateIndex("dbo.FinPolitykaCenowaRegula", "PolitykaCenowaRefId");
            CreateIndex("dbo.KombinacjaWykonczenie", "PolitykaCenowaRefId");
            AddForeignKey("dbo.KombinacjaWykonczenie", "PolitykaCenowaRefId", "dbo.FinPolitykaCenowa", "FinPolitykaCenowaId");
            AddForeignKey("dbo.FinPolitykaCenowaRegula", "PolitykaCenowaRefId", "dbo.FinPolitykaCenowa", "FinPolitykaCenowaId", cascadeDelete: true);
            DropColumn("dbo.Wykonczenie", "CzyPolitykaCenowa");
            DropColumn("dbo.Wykonczenie", "PolitykaCenowaRefId");
            DropColumn("dbo.Wykonczenie", "PolitykaCenowaAktywnaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wykonczenie", "PolitykaCenowaAktywnaId", c => c.Int());
            AddColumn("dbo.Wykonczenie", "PolitykaCenowaRefId", c => c.Int());
            AddColumn("dbo.Wykonczenie", "CzyPolitykaCenowa", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.FinPolitykaCenowaRegula", "PolitykaCenowaRefId", "dbo.FinPolitykaCenowa");
            DropForeignKey("dbo.KombinacjaWykonczenie", "PolitykaCenowaRefId", "dbo.FinPolitykaCenowa");
            DropIndex("dbo.KombinacjaWykonczenie", new[] { "PolitykaCenowaRefId" });
            DropIndex("dbo.FinPolitykaCenowaRegula", new[] { "PolitykaCenowaRefId" });
            AlterColumn("dbo.Norma", "Nazwa", c => c.String(nullable: false));
            AlterColumn("dbo.FinPolitykaCenowaRegula", "PolitykaCenowaRefId", c => c.Int());
            DropColumn("dbo.KombinacjaWykonczenie", "PolitykaCenowaRefId");
            DropColumn("dbo.KombinacjaWykonczenie", "Ilosc");
            DropColumn("dbo.KombinacjaWykonczenie", "CzyPolitykaCenowa");
            DropColumn("dbo.Norma", "CzyAktywna");
            RenameColumn(table: "dbo.FinPolitykaCenowaRegula", name: "PolitykaCenowaRefId", newName: "PolitykaCenowa_FinPolitykaCenowaId");
            AddColumn("dbo.FinPolitykaCenowaRegula", "PolitykaCenowaRefId", c => c.Int(nullable: false));
            CreateIndex("dbo.Wykonczenie", "PolitykaCenowaRefId");
            CreateIndex("dbo.FinPolitykaCenowaRegula", "PolitykaCenowa_FinPolitykaCenowaId");
            AddForeignKey("dbo.FinPolitykaCenowaRegula", "PolitykaCenowa_FinPolitykaCenowaId", "dbo.FinPolitykaCenowa", "FinPolitykaCenowaId");
            AddForeignKey("dbo.Wykonczenie", "PolitykaCenowaRefId", "dbo.FinPolitykaCenowa", "FinPolitykaCenowaId");
        }
    }
}
