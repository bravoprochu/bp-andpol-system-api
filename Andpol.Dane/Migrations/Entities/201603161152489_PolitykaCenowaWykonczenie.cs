namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PolitykaCenowaWykonczenie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wykonczenie", "PolitykaCenowaRefId", c => c.Int());
            AlterColumn("dbo.FinPolitykaCenowa", "Nazwa", c => c.String(nullable: false));
            CreateIndex("dbo.Wykonczenie", "PolitykaCenowaRefId");
            AddForeignKey("dbo.Wykonczenie", "PolitykaCenowaRefId", "dbo.FinPolitykaCenowa", "FinPolitykaCenowaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wykonczenie", "PolitykaCenowaRefId", "dbo.FinPolitykaCenowa");
            DropIndex("dbo.Wykonczenie", new[] { "PolitykaCenowaRefId" });
            AlterColumn("dbo.FinPolitykaCenowa", "Nazwa", c => c.String());
            DropColumn("dbo.Wykonczenie", "PolitykaCenowaRefId");
        }
    }
}
