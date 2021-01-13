namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zamowienieplanningRefRemove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Zamowienie", "PlanningRefId", "dbo.Planning");
            DropIndex("dbo.Zamowienie", new[] { "PlanningRefId" });
            DropColumn("dbo.Zamowienie", "PlanningRefId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zamowienie", "PlanningRefId", c => c.Int());
            CreateIndex("dbo.Zamowienie", "PlanningRefId");
            AddForeignKey("dbo.Zamowienie", "PlanningRefId", "dbo.Planning", "Id");
        }
    }
}
