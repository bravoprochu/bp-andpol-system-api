namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaterialSzerokosc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Material", "SzerokoscBelki", c => c.Double(nullable: false));
            AlterColumn("dbo.MaterialBelka", "StanAktualny", c => c.Double(nullable: false));
            AlterColumn("dbo.MaterialBelka", "StanPoczatkowy", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MaterialBelka", "StanPoczatkowy", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MaterialBelka", "StanAktualny", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Material", "SzerokoscBelki");
        }
    }
}
