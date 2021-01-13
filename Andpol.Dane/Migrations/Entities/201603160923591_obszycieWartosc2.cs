namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class obszycieWartosc2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KombinacjaObszycie", "Wartosc2", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KombinacjaObszycie", "Wartosc2");
        }
    }
}
