namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fakturaSprzedazy_magWzIds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinFakturaSprzedazy", "MagWzIds", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinFakturaSprzedazy", "MagWzIds");
        }
    }
}
