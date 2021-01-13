namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmiany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GotowyKupiony",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GotowyKupionyWartosc",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wartosc = c.Int(nullable: false),
                        GotowyKupionyRefId = c.Int(nullable: false),
                        KombinacjaRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GotowyKupiony", t => t.GotowyKupionyRefId, cascadeDelete: true)
                .ForeignKey("dbo.Kombinacja", t => t.KombinacjaRefId, cascadeDelete: true)
                .Index(t => t.GotowyKupionyRefId)
                .Index(t => t.KombinacjaRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GotowyKupionyWartosc", "KombinacjaRefId", "dbo.Kombinacja");
            DropForeignKey("dbo.GotowyKupionyWartosc", "GotowyKupionyRefId", "dbo.GotowyKupiony");
            DropIndex("dbo.GotowyKupionyWartosc", new[] { "KombinacjaRefId" });
            DropIndex("dbo.GotowyKupionyWartosc", new[] { "GotowyKupionyRefId" });
            DropTable("dbo.GotowyKupionyWartosc");
            DropTable("dbo.GotowyKupiony");
        }
    }
}
