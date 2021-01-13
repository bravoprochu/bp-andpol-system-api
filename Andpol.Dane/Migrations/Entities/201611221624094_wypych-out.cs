namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wypychout : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ZamowienieKombi", "WypychRefId", "dbo.Wypych");
            DropIndex("dbo.ZamowienieKombi", new[] { "WypychRefId" });
            DropColumn("dbo.ZamowienieKombi", "WypychRefId");
            DropTable("dbo.Wypych");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Wypych",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ZamowienieKombi", "WypychRefId", c => c.Int());
            CreateIndex("dbo.ZamowienieKombi", "WypychRefId");
            AddForeignKey("dbo.ZamowienieKombi", "WypychRefId", "dbo.Wypych", "Id");
        }
    }
}
