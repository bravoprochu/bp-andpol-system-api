namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fakturaSprzedazy_czyAktywna : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinFakturaSprzedazy", "CzyAktywna", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinFakturaSprzedazy", "CzyAktywna");
        }
    }
}
