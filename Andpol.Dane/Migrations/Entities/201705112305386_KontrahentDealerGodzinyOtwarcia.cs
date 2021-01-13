namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KontrahentDealerGodzinyOtwarcia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KontrahentDealer", "GodzinyOtwarcia", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KontrahentDealer", "GodzinyOtwarcia");
        }
    }
}
