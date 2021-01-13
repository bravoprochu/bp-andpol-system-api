namespace Andpol.Dane.Migrations.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logsDelete : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogsDelete",
                c => new
                    {
                        LogsDeleteId = c.Int(nullable: false, identity: true),
                        DataUsuniecia = c.DateTime(nullable: false),
                        Tabela = c.String(),
                        UserName = c.String(),
                        Uwagi = c.String(),
                    })
                .PrimaryKey(t => t.LogsDeleteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogsDelete");
        }
    }
}
