namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KalendarzDniRoboczych : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KalendarzDniRoboczychDzialProd",
                c => new
                    {
                        KalendarzDniRoboczychDzialProdId = c.Int(nullable: false, identity: true),
                        KalendarzDniRoboczychRefId = c.Int(),
                        ProdukcjaDzialRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KalendarzDniRoboczychDzialProdId)
                .ForeignKey("dbo.KalendarzDniRoboczych", t => t.KalendarzDniRoboczychRefId, cascadeDelete: true)
                .ForeignKey("dbo.ProdukcjaDzial", t => t.ProdukcjaDzialRefId, cascadeDelete: true)
                .Index(t => t.KalendarzDniRoboczychRefId)
                .Index(t => t.ProdukcjaDzialRefId);
            
            CreateTable(
                "dbo.KalendarzDniRoboczych",
                c => new
                    {
                        KalendarzDniRoboczychId = c.Int(nullable: false, identity: true),
                        DzienRoboczy = c.DateTime(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.KalendarzDniRoboczychId);
            
            CreateTable(
                "dbo.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad",
                c => new
                    {
                        KalendarzDniRoboczychDzialProdGrupaRoboczaSkladId = c.Int(nullable: false, identity: true),
                        Ilosc = c.Int(nullable: false),
                        KalendarzDniRoboczychDzialProdRefId = c.Int(nullable: false),
                        RobociznaRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KalendarzDniRoboczychDzialProdGrupaRoboczaSkladId)
                .ForeignKey("dbo.KalendarzDniRoboczychDzialProd", t => t.KalendarzDniRoboczychDzialProdRefId, cascadeDelete: true)
                .ForeignKey("dbo.Robocizna", t => t.RobociznaRefId)
                .Index(t => t.KalendarzDniRoboczychDzialProdRefId)
                .Index(t => t.RobociznaRefId);
            
            CreateTable(
                "dbo.KalendarzDniRoboczychSzablon",
                c => new
                    {
                        KalendarzDniRoboczychDzialProdId = c.Int(nullable: false),
                        Nazwa = c.String(),
                    })
                .PrimaryKey(t => t.KalendarzDniRoboczychDzialProdId)
                .ForeignKey("dbo.KalendarzDniRoboczychDzialProd", t => t.KalendarzDniRoboczychDzialProdId, cascadeDelete: true)
                .Index(t => t.KalendarzDniRoboczychDzialProdId);
            
            CreateTable(
                "dbo.KalendarzDniRoboczychZakres",
                c => new
                    {
                        KalendarzDniRoboczychZakresId = c.Int(nullable: false, identity: true),
                        CzasDuration = c.String(maxLength: 5),
                        CzasEnd = c.DateTime(nullable: false),
                        CzasStart = c.DateTime(nullable: false),
                        KalendarzDniRoboczychDzialProdId = c.Int(nullable: false),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.KalendarzDniRoboczychZakresId)
                .ForeignKey("dbo.KalendarzDniRoboczychDzialProd", t => t.KalendarzDniRoboczychDzialProdId, cascadeDelete: true)
                .Index(t => t.KalendarzDniRoboczychDzialProdId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KalendarzDniRoboczychDzialProd", "ProdukcjaDzialRefId", "dbo.ProdukcjaDzial");
            DropForeignKey("dbo.KalendarzDniRoboczychZakres", "KalendarzDniRoboczychDzialProdId", "dbo.KalendarzDniRoboczychDzialProd");
            DropForeignKey("dbo.KalendarzDniRoboczychSzablon", "KalendarzDniRoboczychDzialProdId", "dbo.KalendarzDniRoboczychDzialProd");
            DropForeignKey("dbo.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad", "RobociznaRefId", "dbo.Robocizna");
            DropForeignKey("dbo.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad", "KalendarzDniRoboczychDzialProdRefId", "dbo.KalendarzDniRoboczychDzialProd");
            DropForeignKey("dbo.KalendarzDniRoboczychDzialProd", "KalendarzDniRoboczychRefId", "dbo.KalendarzDniRoboczych");
            DropIndex("dbo.KalendarzDniRoboczychZakres", new[] { "KalendarzDniRoboczychDzialProdId" });
            DropIndex("dbo.KalendarzDniRoboczychSzablon", new[] { "KalendarzDniRoboczychDzialProdId" });
            DropIndex("dbo.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad", new[] { "RobociznaRefId" });
            DropIndex("dbo.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad", new[] { "KalendarzDniRoboczychDzialProdRefId" });
            DropIndex("dbo.KalendarzDniRoboczychDzialProd", new[] { "ProdukcjaDzialRefId" });
            DropIndex("dbo.KalendarzDniRoboczychDzialProd", new[] { "KalendarzDniRoboczychRefId" });
            DropTable("dbo.KalendarzDniRoboczychZakres");
            DropTable("dbo.KalendarzDniRoboczychSzablon");
            DropTable("dbo.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad");
            DropTable("dbo.KalendarzDniRoboczych");
            DropTable("dbo.KalendarzDniRoboczychDzialProd");
        }
    }
}
