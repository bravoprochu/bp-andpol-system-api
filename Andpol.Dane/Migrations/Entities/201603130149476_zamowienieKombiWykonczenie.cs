namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zamowienieKombiWykonczenie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ZamowienieKombiWykonczenie",
                c => new
                    {
                        ZamowienieKombiWykonczenieId = c.Int(nullable: false, identity: true),
                        KombinacjaWykonczenieRefId = c.Int(nullable: false),
                        ZamowienieKombiRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZamowienieKombiWykonczenieId)
                .ForeignKey("dbo.KombinacjaWykonczenie", t => t.KombinacjaWykonczenieRefId, cascadeDelete: true)
                .ForeignKey("dbo.ZamowienieKombi", t => t.ZamowienieKombiRefId)
                .Index(t => t.KombinacjaWykonczenieRefId)
                .Index(t => t.ZamowienieKombiRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZamowienieKombiWykonczenie", "ZamowienieKombiRefId", "dbo.ZamowienieKombi");
            DropForeignKey("dbo.ZamowienieKombiWykonczenie", "KombinacjaWykonczenieRefId", "dbo.KombinacjaWykonczenie");
            DropIndex("dbo.ZamowienieKombiWykonczenie", new[] { "ZamowienieKombiRefId" });
            DropIndex("dbo.ZamowienieKombiWykonczenie", new[] { "KombinacjaWykonczenieRefId" });
            DropTable("dbo.ZamowienieKombiWykonczenie");
        }
    }
}
