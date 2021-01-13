namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class obszycieDlugoscSzerokosc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KombinacjaObszycie", "Dlugosc", c => c.Double(nullable: false));
            AddColumn("dbo.KombinacjaObszycie", "Szerokosc", c => c.Double(nullable: false));
            DropColumn("dbo.KombinacjaObszycie", "Wartosc");
            DropColumn("dbo.KombinacjaObszycie", "Wartosc2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KombinacjaObszycie", "Wartosc2", c => c.Double(nullable: false));
            AddColumn("dbo.KombinacjaObszycie", "Wartosc", c => c.Double(nullable: false));
            DropColumn("dbo.KombinacjaObszycie", "Szerokosc");
            DropColumn("dbo.KombinacjaObszycie", "Dlugosc");
        }
    }
}
