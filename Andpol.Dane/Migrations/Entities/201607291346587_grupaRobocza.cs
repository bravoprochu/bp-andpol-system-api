namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grupaRobocza : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KombinacjaRobociznaGrupaRobocza",
                c => new
                    {
                        KombinacjaRobociznaGrupaRoboczaId = c.Int(nullable: false, identity: true),
                        KombinacjaRobociznaRefId = c.Int(nullable: false),
                        RobociznaRefId = c.Int(nullable: false),
                        Wartosc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KombinacjaRobociznaGrupaRoboczaId)
                .ForeignKey("dbo.KombinacjaRobocizna", t => t.KombinacjaRobociznaRefId, cascadeDelete: true)
                .ForeignKey("dbo.Robocizna", t => t.RobociznaRefId)
                .Index(t => t.KombinacjaRobociznaRefId)
                .Index(t => t.RobociznaRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KombinacjaRobociznaGrupaRobocza", "RobociznaRefId", "dbo.Robocizna");
            DropForeignKey("dbo.KombinacjaRobociznaGrupaRobocza", "KombinacjaRobociznaRefId", "dbo.KombinacjaRobocizna");
            DropIndex("dbo.KombinacjaRobociznaGrupaRobocza", new[] { "RobociznaRefId" });
            DropIndex("dbo.KombinacjaRobociznaGrupaRobocza", new[] { "KombinacjaRobociznaRefId" });
            DropTable("dbo.KombinacjaRobociznaGrupaRobocza");
        }
    }
}
